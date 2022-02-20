using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAT_script_runner
{
    public partial class MAT_Script_Runner : Form
    {
        MLApp.MLApp matlab;
        bool matInitialized = false;
        StreamWriter stream;

        static SerialPort comPort = new SerialPort();
        SoundPlayer countdown = new SoundPlayer(@"countdown.wav");

        public MAT_Script_Runner()
        {
            InitializeComponent();

            Numeric_COM_Port.Value = Properties.Settings.Default.COMPort;
            Numeric_Quick_Trial.Maximum = Decimal.MaxValue;
        }

        private void Button_Open_Folders_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(Properties.Settings.Default.InputDirectory + @"\" + Properties.Settings.Default.GestureName);
            Directory.CreateDirectory(Properties.Settings.Default.OutputDirectory + @"\" + Properties.Settings.Default.GestureName);

            Process.Start("explorer.exe", Properties.Settings.Default.InputDirectory + @"\" + Properties.Settings.Default.GestureName);
            Process.Start("explorer.exe", Properties.Settings.Default.OutputDirectory + @"\" + Properties.Settings.Default.GestureName);
        }

        private void Button_Filename_Formatting_Click(object sender, EventArgs e)
        {
            Filename_Formatting filename_formatting = new Filename_Formatting(this);
            filename_formatting.ShowDialog();
        }

        private void Button_Directory_Settings_Click(object sender, EventArgs e)
        {
            Directory_Settings directory_settings = new Directory_Settings();
            directory_settings.ShowDialog();
        }

        private void Button_TCPIP_Connection_Click(object sender, EventArgs e)
        {
        }

        private void Button_Bluetooth_Connection_Click(object sender, EventArgs e)
        {
            Numeric_Quick_Trial.Value = Properties.Settings.Default.TrialNumber;

            Panel_Home.Visible = false;
            Panel_Connection.Visible = true;
        }

        private void Button_Start_Bluetooth_Connection_Click(object sender, EventArgs e)
        {
            if (Button_Start_Bluetooth_Connection.Text == "Start Bluetooth Connection")
            {
                comPort.PortName = "COM" + Numeric_COM_Port.Value.ToString();
                comPort.BaudRate = 115200;
                comPort.Parity = Parity.None;
                comPort.DataBits = 8;
                comPort.StopBits = StopBits.One;

                try
                {
                    if (!comPort.IsOpen)
                    {
                        comPort.Open();

                        Label_Status.Text = "Recording";
                        Label_Status.ForeColor = Color.LimeGreen;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\nCannot open COM port, check your COM port number.");
                }

                if (comPort.IsOpen)
                {
                    if (Checkbox_Voice.Checked == true)
                    {
                        countdown.Play();
                    }

                    Button_Start_Bluetooth_Connection.Text = "Stop Bluetooth Connection";

                    Directory.CreateDirectory(Properties.Settings.Default.InputDirectory + @"\" + Properties.Settings.Default.GestureName);
                    Directory.CreateDirectory(Properties.Settings.Default.OutputDirectory + @"\" + Properties.Settings.Default.GestureName);
                    stream = new StreamWriter(Properties.Settings.Default.InputDirectory + @"\" + Properties.Settings.Default.GestureName + @"\" +
                        Properties.Settings.Default.ParticipantNumber + "_" + Properties.Settings.Default.TrialNumber + ".csv");

                    Timer_Receive_Samples.Enabled = true;
                }
            }
            else
            {
                Button_Start_Bluetooth_Connection.Text = "Start Bluetooth Connection";

                try
                {
                    comPort.Close();
                    stream.Close();

                    Label_Status.Text = "Standby";
                    Label_Status.ForeColor = Color.Gray;
            }
                catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nError closing COM port.");
            }

                if (!comPort.IsOpen)
                {
                    Timer_Receive_Samples.Enabled = false;

                    if (Checkbox_Auto_Execute.Checked)
                    {
                            matlab.Execute("cd '" + Path.GetDirectoryName(Properties.Settings.Default.ScriptDirectory) + "'");
                            object result = null;
                            matlab.Feval(Path.GetFileNameWithoutExtension(Properties.Settings.Default.ScriptDirectory), 1, out result,
                                Properties.Settings.Default.InputDirectory, Properties.Settings.Default.OutputDirectory, Properties.Settings.Default.GestureName,
                                Properties.Settings.Default.ParticipantNumber, Properties.Settings.Default.TrialNumber, 0, 0, Checkbox_Plot_Mode.Checked ? 1 : 0, 0, 0, 0);
                    }

                    if (Checkbox_Auto_Increment.Checked)
                    {
                        Properties.Settings.Default.TrialNumber++;
                    }
                    
                    Numeric_Quick_Trial.Value = Properties.Settings.Default.TrialNumber;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void Button_Bluetooth_Back_Click(object sender, EventArgs e)
        {
            Panel_Home.Visible = true;
            Panel_Connection.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Numeric_COM_Port_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.COMPort = (int) Numeric_COM_Port.Value;
            Properties.Settings.Default.Save();
        }

        private void Checkbox_Auto_Execute_CheckedChanged(object sender, EventArgs e)
        {
            if (!matInitialized)
            {
                try
                {
                    matInitialized = true;
                    matlab = new MLApp.MLApp();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\nError Opening MATLAB Command Window.");
                }
                
            }
        }

        private void Timer_Receive_Samples_Tick(object sender, EventArgs e)
        {
            try
            {
                stream.Write(comPort.ReadExisting());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Numeric_Quick_Trial_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.TrialNumber = (int) Numeric_Quick_Trial.Value;
            Properties.Settings.Default.Save();
        }
    }
}
