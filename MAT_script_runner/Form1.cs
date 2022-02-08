using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAT_script_runner
{
    public partial class MAT_Script_Runner : Form
    {
        public MAT_Script_Runner()
        {
            InitializeComponent();
        }

        private void TCPIP_Connection_Button_Click(object sender, EventArgs e)
        {
            label1.Text = "Button pressed: TCPIP Connection";
        }

        private void Bluetooth_Connection_Button_Click(object sender, EventArgs e)
        {
            label1.Text = "Button pressed: Bluetooth Connection";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
