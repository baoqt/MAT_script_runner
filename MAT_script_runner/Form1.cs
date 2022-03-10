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
<<<<<<< HEAD
<<<<<<< HEAD
            Numeric_Quick_Trial.Value = Properties.Settings.Default.TrialNumber;
            Numeric_Quick_Participant.Maximum = Decimal.MaxValue;
            Numeric_Quick_Participant.Value = Properties.Settings.Default.ParticipantNumber;

            Textbox_IP.Text = Properties.Settings.Default.IP;
            Numeric_Port.Value = Properties.Settings.Default.Port;
            Numeric_Port.Maximum = Decimal.MaxValue;
<<<<<<< HEAD
            Numeric_Port.Value = Properties.Settings.Default.Port;            
=======
>>>>>>> parent of 5e0bdaf (Adjusted form layout)
=======
            
>>>>>>> parent of 782ef7c (Adjusted TCP functionality)
=======
>>>>>>> parent of 5e0bdaf (Adjusted form layout)
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
            Panel_Controls.Enabled = !Panel_Controls.Enabled;
        }

        private void Button_Bluetooth_Connection_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
<<<<<<< HEAD
            Panel_Home.Enabled = false;
            Panel_Connection.Visible = true;
            Panel_Bluetooth.Visible = true;
            Panel_TCP.Visible = false;
<<<<<<< HEAD
            Checkbox_Voice.Visible = true;
=======
            Numeric_Quick_Trial.Value = Properties.Settings.Default.TrialNumber;
>>>>>>> parent of 5e0bdaf (Adjusted form layout)
=======
>>>>>>> parent of 782ef7c (Adjusted TCP functionality)
=======
            Numeric_Quick_Trial.Value = Properties.Settings.Default.TrialNumber;
>>>>>>> parent of 5e0bdaf (Adjusted form layout)

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
                    Panel_Controls.Enabled = false;

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
                Panel_Controls.Enabled = true;

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
<<<<<<< HEAD
<<<<<<< HEAD
                }
            }
            else if (Button_Start_Connection.Text == "Start TCPIP Connection")
            {
                try
                {
                    server = new TcpListener(IPAddress.Parse(Textbox_IP.Text), (int)Numeric_Port.Value);
                    server.Start();
                    client = server.AcceptTcpClient();

                    Label_Status.Text = "Recording";
                    Label_Status.ForeColor = Color.LimeGreen;

                    netStream = client.GetStream();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n Error socket exception.");
                }

                if (client != null)
                {
                    if (Checkbox_Voice.Checked == true)
                    {
                        countdown.Play();
                    }

                    Button_Start_Connection.Text = "Stop TCPIP Connection";
                    Button_Connection_Back.Enabled = false;
                    Panel_Controls.Enabled = false;
                    Panel_TCP.Enabled = false;

                    Directory.CreateDirectory(Properties.Settings.Default.InputDirectory + @"\" + Properties.Settings.Default.GestureName);
                    Directory.CreateDirectory(Properties.Settings.Default.OutputDirectory + @"\" + Properties.Settings.Default.GestureName);
                    stream = new StreamWriter(Properties.Settings.Default.InputDirectory + @"\" + Properties.Settings.Default.GestureName + @"\" +
                        Properties.Settings.Default.ParticipantNumber + "_" + Properties.Settings.Default.TrialNumber + ".csv");

                    Timer_Receive_Samples.Enabled = true;
                }

                if (Checkbox_Auto_Increment.Checked)
                {
                    Properties.Settings.Default.TrialNumber++;
=======
                    
>>>>>>> parent of 5e0bdaf (Adjusted form layout)
                    Numeric_Quick_Trial.Value = Properties.Settings.Default.TrialNumber;
                    Properties.Settings.Default.Save();
                }
            }
<<<<<<< HEAD
            else if (Button_Start_Connection.Text == "Stop TCPIP Connection")
            {
                client.Close();
                server.Stop();

                Button_Start_Connection.Text = "Start TCPIP Connection";
                Button_Connection_Back.Enabled = true;
                Panel_TCP.Enabled = true;
                client = null;
            }
=======
                    
                    Numeric_Quick_Trial.Value = Properties.Settings.Default.TrialNumber;
                    Properties.Settings.Default.Save();
                }
            }
>>>>>>> parent of 5e0bdaf (Adjusted form layout)
=======
>>>>>>> parent of 5e0bdaf (Adjusted form layout)
        }

        private void Button_Bluetooth_Back_Click(object sender, EventArgs e)
        {
            Panel_Home.Visible = true;
            Panel_Connection.Visible = false;
<<<<<<< HEAD
<<<<<<< HEAD
            Panel_Bluetooth.Visible = false;
            Panel_TCP.Visible = false;
<<<<<<< HEAD
            Checkbox_Voice.Visible = false;
=======
>>>>>>> parent of 5e0bdaf (Adjusted form layout)
=======
>>>>>>> parent of 782ef7c (Adjusted TCP functionality)
=======
>>>>>>> parent of 5e0bdaf (Adjusted form layout)
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Numeric_COM_Port_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.COMPort = (int) Numeric_COM_Port.Value;
            Properties.Settings.Default.Save();
        }
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> parent of 782ef7c (Adjusted TCP functionality)
        private void Textbox_IP_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.IP = Textbox_IP.Text;
            Properties.Settings.Default.Save();
        }

        private void Numeric_Port_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Port = (int)Numeric_Port.Value;
            Properties.Settings.Default.Save();
        }
=======
>>>>>>> parent of 5e0bdaf (Adjusted form layout)
=======
>>>>>>> parent of 5e0bdaf (Adjusted form layout)

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
<<<<<<< HEAD
<<<<<<< HEAD
                try
                {
                    int i = netStream.Read(buffer, 0, buffer.Length);
                    stream.Write(System.Text.Encoding.ASCII.GetString(buffer, 0, i));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
=======
                MessageBox.Show(ex.Message);
>>>>>>> parent of 5e0bdaf (Adjusted form layout)
=======
                MessageBox.Show(ex.Message);
>>>>>>> parent of 5e0bdaf (Adjusted form layout)
            }
        }

        private void Numeric_Quick_Trial_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.TrialNumber = (int) Numeric_Quick_Trial.Value;
            Properties.Settings.Default.Save();
        }
<<<<<<< HEAD
<<<<<<< HEAD

        private void Numeric_Quick_Participant_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ParticipantNumber = (int)Numeric_Quick_Participant.Value;
            Properties.Settings.Default.Save();
        }
<<<<<<< HEAD

        private void Background_TCP_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }
=======
>>>>>>> parent of 5e0bdaf (Adjusted form layout)
=======
>>>>>>> parent of 782ef7c (Adjusted TCP functionality)
=======
>>>>>>> parent of 5e0bdaf (Adjusted form layout)
    }
}
