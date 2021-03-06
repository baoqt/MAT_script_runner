using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MAT_script_runner
{
    public partial class Filename_Formatting : Form
    {
        public Filename_Formatting()
        {
            InitializeComponent();

            Textbox_Gesture.Text = Properties.Settings.Default.GestureName;
            Numeric_Participant.Value = Properties.Settings.Default.ParticipantNumber;
            Numeric_Trial.Maximum = Decimal.MaxValue;
            Numeric_Trial.Value = Properties.Settings.Default.TrialNumber;
        }

        private MAT_Script_Runner mainForm;

        public Filename_Formatting(Form callingForm)
        {
            mainForm = callingForm as MAT_Script_Runner;

            InitializeComponent();

            Textbox_Gesture.Text = Properties.Settings.Default.GestureName;
            Numeric_Participant.Value = Properties.Settings.Default.ParticipantNumber;
            Numeric_Trial.Maximum = Decimal.MaxValue;
            Numeric_Trial.Value = Properties.Settings.Default.TrialNumber;
        }

        private void Button_Filename_Save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.GestureName = Textbox_Gesture.Text;
            Properties.Settings.Default.ParticipantNumber = (int) Numeric_Participant.Value;
            Properties.Settings.Default.TrialNumber = (int) Numeric_Trial.Value;
            Properties.Settings.Default.Save();

            mainForm.Numeric_Quick_Trial.Value = Properties.Settings.Default.TrialNumber;
            mainForm.Numeric_Quick_Participant.Value = Properties.Settings.Default.ParticipantNumber;

            this.Dispose();
            this.Close();
        }

        private void Button_Filename_Cancel_Click(object sender, EventArgs e)
        {           
            this.Dispose();
            this.Close();
        }
    }
}
