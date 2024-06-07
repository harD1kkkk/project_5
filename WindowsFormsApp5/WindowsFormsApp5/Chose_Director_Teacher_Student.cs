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
using WindowsFormsApp5.Forms_For_HeadTeacher;

namespace WindowsFormsApp5
{
    public partial class Chose_Director_Teacher_Student : Form
    {
        public Chose_Director_Teacher_Student()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form login_Director = new Login_Director
            {
                StartPosition = FormStartPosition.Manual,
                Height = this.Height,
                Width = this.Width,
                Location = this.Location
            };
            login_Director.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form login_Administrator = new Login_Administrator
            {
                StartPosition = FormStartPosition.Manual,
                Height = this.Height,
                Width = this.Width,
                Location = this.Location
            };
            login_Administrator.Show();
        }
    }
}
