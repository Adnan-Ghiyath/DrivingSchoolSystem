using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Buisness;

namespace DVLD.API_S
{
    public partial class Send_Emil_Form : Form
    {
        API _Send = new API(new Email_API());
        public Send_Emil_Form()
        {
            InitializeComponent();
     
        }

        private void Send_Emil_Form_Load(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
           if(MessageBox.Show("You will Send an Email to this clent ", "are you Sure?", MessageBoxButtons.YesNo)==DialogResult.Yes)
            _Send.Send(txtSubject.Text, txtBody.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
