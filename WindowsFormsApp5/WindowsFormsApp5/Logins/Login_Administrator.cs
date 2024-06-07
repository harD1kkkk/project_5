using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp5.Forms_For_Administrator;

namespace WindowsFormsApp5
{
    public partial class Login_Administrator : Form
    {
        public Login_Administrator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string email = textBox3.Text;
            string password = textBox2.Text;

            if (name == "Administrator" && email == "administrator.admin@gmail.com" && password == "admin") {
                Form administrator_options = new Administrator_options
                {
                    StartPosition = FormStartPosition.Manual,
                    Height = this.Height,
                    Width = this.Width,
                    Location = this.Location
                };
                administrator_options.Show();
            }
            else
            {
                MessageBox.Show("Error: Incorrect Name or Email or Password ");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
