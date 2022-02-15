using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MAT_script_runner
{
    public partial class Directory_Settings : Form
    {
        public Directory_Settings()
        {
            InitializeComponent();

            Textbox_Input_Directory.Text = Properties.Settings.Default.InputDirectory;
            Textbox_Output_Directory.Text = Properties.Settings.Default.OutputDirectory;
            Textbox_Script_Directory.Text = Properties.Settings.Default.ScriptDirectory;
        }

        private void Button_Browse_Input_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog newFolderDialog = new FolderBrowserDialog();
            DialogResult result = newFolderDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Textbox_Input_Directory.Text = newFolderDialog.SelectedPath;
            }    
        }

        private void Button_Output_Browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog newFolderDialog = new FolderBrowserDialog();
            DialogResult result = newFolderDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Textbox_Output_Directory.Text = newFolderDialog.SelectedPath;
            }
        }
        private void Button_Script_Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog newFileDialog = new OpenFileDialog();
            DialogResult result = newFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Textbox_Script_Directory.Text = newFileDialog.FileName;
            }
        }

        private void Button_Directory_Save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.InputDirectory = Textbox_Input_Directory.Text;
            Properties.Settings.Default.OutputDirectory = Textbox_Output_Directory.Text;
            Properties.Settings.Default.ScriptDirectory = Textbox_Script_Directory.Text;
            Properties.Settings.Default.Save();

            this.Dispose();
            this.Close();
        }

        private void Button_Directory_Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
