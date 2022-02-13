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

        private void Button_Directory_Save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.InputDirectory = Textbox_Input_Directory.Text;
            Properties.Settings.Default.OutputDirectory = Textbox_Output_Directory.Text;
            Properties.Settings.Default.Save();

            this.Visible = false;
        }

        private void Button_Directory_Cancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
