using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAT_script_runner
{
    public partial class MAT_Script_Runner : Form
    {
        public static string InputDirectory = Properties.Settings.Default.InputDirectory;
        public static string OutputDirectory = Properties.Settings.Default.OutputDirectory;
        StreamWriter stream;

        MLApp.MLApp matlab = new MLApp.MLApp();
        static SerialPort comPort = new SerialPort();

        public MAT_Script_Runner()
        {
            InitializeComponent();
            Numeric_COM_Port.Value = Properties.Settings.Default.COMPort;
        }

        private void Button_Open_Folders_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(Properties.Settings.Default.InputDirectory + @"\" + Properties.Settings.Default.GestureName);
            Directory.CreateDirectory(Properties.Settings.Default.OutputDirectory + @"\" + Properties.Settings.Default.GestureName);

            if (InputDirectory != "")
            {
                Process.Start("explorer.exe", Properties.Settings.Default.InputDirectory + @"\" + Properties.Settings.Default.GestureName);
            }

            if (OutputDirectory != "")
            {
                Process.Start("explorer.exe", Properties.Settings.Default.OutputDirectory + @"\" + Properties.Settings.Default.GestureName);
            }
        }

        private void Button_Filename_Formatting_Click(object sender, EventArgs e)
        {
            Filename_Formatting filename_formatting = new Filename_Formatting();
            filename_formatting.Visible = true;
        }

        private void Button_Directory_Settings_Click(object sender, EventArgs e)
        {
            Directory_Settings directory_settings = new Directory_Settings();
            directory_settings.Visible = true;
        }

        private void Button_TCPIP_Connection_Click(object sender, EventArgs e)
        {
        }

        private void Button_Bluetooth_Connection_Click(object sender, EventArgs e)
        {
            Panel_Home.Visible = false;
            Panel_Bluetooth_Connection.Visible = true;
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
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\nCannot open COM port, check your COM port number.");
                }

                

                if (comPort.IsOpen)
                {
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\nError closing COM port.");
                }

                if (!comPort.IsOpen)
                {
                    Timer_Receive_Samples.Enabled = false;

                    matlab.Execute("cd '" + Path.GetDirectoryName(Properties.Settings.Default.ScriptDirectory) + "'");
                    object result = null;
                    matlab.Feval(Path.GetFileNameWithoutExtension(Properties.Settings.Default.ScriptDirectory), 1, out result,
                        Properties.Settings.Default.InputDirectory, Properties.Settings.Default.OutputDirectory, Properties.Settings.Default.GestureName, 
                        Properties.Settings.Default.ParticipantNumber, Properties.Settings.Default.TrialNumber, 0, 0, 0, 0, 0, 0);

                    Properties.Settings.Default.TrialNumber++;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void Button_Bluetooth_Back_Click(object sender, EventArgs e)
        {
            Panel_Home.Visible = true;
            Panel_Bluetooth_Connection.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Numeric_COM_Port_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.COMPort = (int) Numeric_COM_Port.Value;
            Properties.Settings.Default.Save();
        }

        private void Timer_Receive_Samples_Tick(object sender, EventArgs e)
        {
            try
            {
                    //char[] buffer = new char[3000];
                    //comPort.Read(buffer, 0, 3000);
                    //stream.Write(buffer);
                    stream.Write(comPort.ReadExisting());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
