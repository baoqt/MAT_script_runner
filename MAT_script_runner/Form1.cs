using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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

        public MAT_Script_Runner()
        {
            InitializeComponent();
        }

        private void Button_Open_Folders_Click(object sender, EventArgs e)
        {
            System.IO.Directory.CreateDirectory(Properties.Settings.Default.InputDirectory + '\\' + Properties.Settings.Default.GestureName);
            System.IO.Directory.CreateDirectory(Properties.Settings.Default.OutputDirectory + '\\' + Properties.Settings.Default.GestureName);

            if (InputDirectory != "")
            {
                Process.Start("explorer.exe", Properties.Settings.Default.InputDirectory + '\\' + Properties.Settings.Default.GestureName);
            }

            if (OutputDirectory != "")
            {
                Process.Start("explorer.exe", Properties.Settings.Default.OutputDirectory + '\\' + Properties.Settings.Default.GestureName);
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
                Button_Start_Bluetooth_Connection.Text = "Stop Bluetooth Connection";
            }
            else
            {
                Button_Start_Bluetooth_Connection.Text = "Start Bluetooth Connection";
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
    }
}
