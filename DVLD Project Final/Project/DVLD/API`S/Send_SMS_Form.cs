using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.API_S
{
    public partial class Send_SMS_Form : Form
    {
        API _Send = new API(new SMS_API());

        public Send_SMS_Form()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You will Send an Email to this clent ", "are you Sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                _Send.Send(txtSubject.Text, txtBody.Text);
        }
    }
}
