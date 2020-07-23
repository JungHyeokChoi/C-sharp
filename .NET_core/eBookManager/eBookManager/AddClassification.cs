using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
        
        //Add Classification
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Regex stringPattern = new Regex(@"[a-zA-Z]");
            Regex numberPattern = new Regex(@"[0-9]");

           
            if (String.IsNullOrWhiteSpace(txtClassification.Text) || String.IsNullOrWhiteSpace(txtNumber.Text))
            {
                MessageBox.Show("Cannot add spaces or null value.", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!stringPattern.IsMatch(txtClassification.Text) || !numberPattern.IsMatch(txtNumber.Text))
            {
                MessageBox.Show("Input english on Classification, Number on number", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                pair = new KeyValuePair<string, string>(txtClassification.Text, txtNumber.Text);

                Application.OpenForms["AddClassification"].Close();
            }
        }

        //Close Form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.OpenForms["AddClassification"].Close();
        }
    }
}
