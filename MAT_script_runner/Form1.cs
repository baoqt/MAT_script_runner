using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
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
        NetworkStream netStream;
        TcpClient client = null;
        Task<TcpClient> asyncStatus = null;

        static SerialPort comPort = new SerialPort();
        TcpListener server = null;
        Byte[] buffer = new Byte[3000];
        bool IPFileOpenStatus = false;
        SoundPlayer countdown = new SoundPlayer(@"countdown.wav");

        public MAT_Script_Runner()
        {
            InitializeComponent();

            Numeric_COM_Port.Value = Properties.Settings.Default.COMPort;
            Numeric_Quick_Trial.Maximum = Decimal.MaxValue;
            Numeric_Quick_Trial.Value = Properties.Settings.Default.TrialNumber;
            Numeric_Quick_Participant.Maximum = Decimal.MaxValue;
            Numeric_Quick_Participant.Value = Properties.Settings.Default.ParticipantNumber;

            Textbox_IP.Text = Properties.Settings.Default.IP;
            Numeric_Port.Maximum = Decimal.MaxValue;
            Numeric_Port.Value = Properties.Settings.Default.Port;            
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
            Panel_Home.Enabled = false;
            Panel_Connection.Visible = true;
            Panel_TCP.Visible = true;
            Panel_Bluetooth.Visible = false;
            

            Button_Start_Connection.Text = "Start TCPIP Connection";
        }

        private void Button_Bluetooth_Connection_Click(object sender, EventArgs e)
        {
            Panel_Home.Enabled = false;
            Panel_Connection.Visible = true;
            Panel_Bluetooth.Visible = true;
            Panel_TCP.Visible = false;
            Checkbox_Voice.Visible = true;

            Button_Start_Connection.Text = "Start Bluetooth Connection";
        }

        private void Button_Start_Connection_Click(object sender, EventArgs e)
        {
            if (Button_Start_Connection.Text == "Start Bluetooth Connection")
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

                    Button_Start_Connection.Text = "Stop Bluetooth Connection";
                    Button_Connection_Back.Enabled = false;
                    Panel_Controls.Enabled = false;
                    Panel_Bluetooth.Enabled = false;

                    Directory.CreateDirectory(Properties.Settings.Default.InputDirectory + @"\" + Properties.Settings.Default.GestureName);
                    Directory.CreateDirectory(Properties.Settings.Default.OutputDirectory + @"\" + Properties.Settings.Default.GestureName);
                    stream = new StreamWriter(Properties.Settings.Default.InputDirectory + @"\" + Properties.Settings.Default.GestureName + @"\" +
                        Properties.Settings.Default.ParticipantNumber + "_" + Properties.Settings.Default.TrialNumber + ".csv");

                    Timer_Receive_Samples.Enabled = true;
                }
            }
            else if (Button_Start_Connection.Text == "Stop Bluetooth Connection")
            {
                Button_Start_Connection.Text = "Start Bluetooth Connection";
                Button_Connection_Back.Enabled = true;
                Panel_Controls.Enabled = true;
                Panel_Bluetooth.Enabled = true;

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
                            Properties.Settings.Default.InputDirectory + "\\" + Properties.Settings.Default.GestureName, Properties.Settings.Default.OutputDirectory + 
                            "\\" + Properties.Settings.Default.GestureName, Properties.Settings.Default.GestureName, Properties.Settings.Default.ParticipantNumber, 
                            Properties.Settings.Default.TrialNumber, Checkbox_Plot_Mode.Checked ? 1 : 0, 1, 0, 0, 0, 0, 0);
                    }

                    if (Checkbox_Auto_Increment.Checked)
                    {
                        Properties.Settings.Default.TrialNumber++;
                        Numeric_Quick_Trial.Value = Properties.Settings.Default.TrialNumber;
                        Properties.Settings.Default.Save();
                    }
                }
            }
            else if (Button_Start_Connection.Text == "Start TCPIP Connection")
            {
                try
                {
                    server = new TcpListener(IPAddress.Parse(Textbox_IP.Text), (int)Numeric_Port.Value);
                    server.Start();

                    Label_Status.Text = "Waiting";
                    Label_Status.ForeColor = Color.YellowGreen;

                    Button_Start_Connection.Text = "Stop TCPIP Connection";
                    Button_Connection_Back.Enabled = false;
                    Panel_Controls.Enabled = false;
                    Panel_TCP.Enabled = false;
                    Background_TCP.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n Error socket exception.");
                }
            }
            else if (Button_Start_Connection.Text == "Stop TCPIP Connection")
            {
                Button_Start_Connection.Text = "Start TCPIP Connection";
                Button_Connection_Back.Enabled = true;
                Panel_Controls.Enabled = true;
                Panel_TCP.Enabled = true;

                try
                {
                    Background_TCP.CancelAsync();

                    if (client != null)
                    {
                        client.Close();                     
                        
                        client = null;
                    }

                    if (server != null)
                    {
                        server.Stop();
                        server = null;
                    }
                    
                    Label_Status.Text = "Standby";
                    Label_Status.ForeColor = Color.Gray;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                Timer_Receive_Samples.Enabled = false;

                if (Checkbox_Auto_Increment.Checked)
                {
                    Properties.Settings.Default.TrialNumber++;
                    Numeric_Quick_Trial.Value = Properties.Settings.Default.TrialNumber;
                    Properties.Settings.Default.Save();
                }   
            }
        }

        private void Button_Connection_Back_Click(object sender, EventArgs e)
        {
            Panel_Home.Enabled = true;
            Panel_Connection.Visible = false;
            Panel_Bluetooth.Visible = false;
            Panel_TCP.Visible = false;
            Checkbox_Voice.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Location = Properties.Settings.Default.Location;
        }

        private void MAT_Script_Runner_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Location = Location;
            Properties.Settings.Default.Save();
        }

        private void Numeric_COM_Port_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.COMPort = (int) Numeric_COM_Port.Value;
            Properties.Settings.Default.Save();
        }

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
            if (Panel_Bluetooth.Visible)
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
            else if (Panel_TCP.Visible)
            {
                try
                {
                    int bytesRead = 0; 
                    string bufferString = new string("") ;
                    byte[] ack = new byte[] { (byte)'G', (byte)'o', (byte)'t', (byte)'c', (byte)'h', (byte)'a', (byte)'!' };

                    if (netStream.DataAvailable)
                    {
                        bytesRead = netStream.Read(buffer, 0, buffer.Length);
                        bufferString = System.Text.Encoding.ASCII.GetString(buffer, 0, bytesRead);
                        netStream.Write(ack, 0, 7);
                    }

                    Label_Status.Text = bytesRead.ToString();

                    if (bytesRead > 0)
                    {
                        int bytesWritten = 0;

                        while (bytesWritten < bytesRead)
                        {
                            int startIndex = bufferString[bytesWritten..^0].IndexOf("Start");
                            int stopIndex = bufferString[bytesWritten..^0].IndexOf("Stop");

                            if (stopIndex < startIndex)
                            {
                                stopIndex = bufferString[startIndex..^0].IndexOf("Stop");
                            }

                            if (IPFileOpenStatus)       // Still writing data from current trial, file already open
                            {
                                if (startIndex > 0)     // Start token found
                                {
                                    // Finish writing remaining file at beginning of buffer
                                    stream.Write(bufferString[0..Math.Max(startIndex - 5, 0)]);
                                    bytesWritten += Math.Max(startIndex - 5, 0);

                                    stream.Close();

                                    Properties.Settings.Default.TrialNumber++;
                                    Numeric_Quick_Trial.Value = Properties.Settings.Default.TrialNumber;
                                    Properties.Settings.Default.Save();

                                    stream = new StreamWriter(Properties.Settings.Default.InputDirectory + @"\" + Properties.Settings.Default.GestureName + @"\" +
                                        Properties.Settings.Default.ParticipantNumber + "_" + Properties.Settings.Default.TrialNumber + ".csv");
                                }

                                // Write next chunk
                                stream.Write(bufferString[(startIndex > -1 ? startIndex + 6 : 0)..(stopIndex > -1 ? stopIndex : ^0)]);
                                bytesWritten += (stopIndex > -1 ? stopIndex : bytesRead) - (startIndex > -1 ? startIndex : 0);

                                if (stopIndex > -1)      // Stop token found
                                {
                                    // Close file and prep trial number for next
                                    stream.Close();

                                    Properties.Settings.Default.TrialNumber++;
                                    Numeric_Quick_Trial.Value = Properties.Settings.Default.TrialNumber;
                                    Properties.Settings.Default.Save();
                                }
                            }
                            else                        // Not writing any data, no file open
                            {
                                if (startIndex > -1)    // Start token found
                                {
                                    stream = new StreamWriter(Properties.Settings.Default.InputDirectory + @"\" + Properties.Settings.Default.GestureName + @"\" +
                                        Properties.Settings.Default.ParticipantNumber + "_" + Properties.Settings.Default.TrialNumber + ".csv");

                                    // Write chunk
                                    stream.Write(bufferString[(startIndex + 6)..(stopIndex > -1 ? stopIndex : ^0)]);
                                    bytesWritten += (stopIndex > -1 ? stopIndex : bytesRead) - (startIndex);

                                    if (stopIndex > -1) // Stop token found
                                    {
                                        stream.Close();

                                        Properties.Settings.Default.TrialNumber++;
                                        Numeric_Quick_Trial.Value = Properties.Settings.Default.TrialNumber;
                                        Properties.Settings.Default.Save();
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Numeric_Quick_Trial_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.TrialNumber = (int) Numeric_Quick_Trial.Value;
            Properties.Settings.Default.Save();
        }

        private void Numeric_Quick_Participant_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ParticipantNumber = (int)Numeric_Quick_Participant.Value;
            Properties.Settings.Default.Save();
        }

        private void Background_TCP_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            asyncStatus = server.AcceptTcpClientAsync();

            while (!asyncStatus.IsCompleted)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
            }
                worker.ReportProgress(100);
        }

        private void Background_TCP_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("Canceled.");
            }
            else
            {
                Label_Status.Text = "Recording";
                Label_Status.ForeColor = Color.LimeGreen;

                client = asyncStatus.Result;
                netStream = client.GetStream();

                Directory.CreateDirectory(Properties.Settings.Default.InputDirectory + @"\" + Properties.Settings.Default.GestureName);
                Directory.CreateDirectory(Properties.Settings.Default.OutputDirectory + @"\" + Properties.Settings.Default.GestureName);
                

                Timer_Receive_Samples.Enabled = true;
            }
        }
    }
}
