using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace eBookManager
{
    public partial class AddClassification : Form
    {
        public KeyValuePair<string, string> pair;

        public AddClassification()
        {
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            pair =  new KeyValuePair<string, string>(txtClassification.Text, txtNumber.Text);

            Application.OpenForms["AddClassification"].Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.OpenForms["AddClassification"].Close();
        }

  
    }
}
