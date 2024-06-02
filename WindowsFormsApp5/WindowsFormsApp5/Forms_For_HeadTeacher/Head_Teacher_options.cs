using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp5.Forms_For_Teacher;

namespace WindowsFormsApp5.Forms_For_HeadTeacher
{
    public partial class Head_Teacher_options : Form
    {
        public Head_Teacher_options()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form create_Account = new Create_Account
            {
                StartPosition = FormStartPosition.Manual,
                Height = this.Height,
                Width = this.Width,
                Location = this.Location
            };
            create_Account.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form show_All_Accounts = new Show_All_Accounts
            {
                StartPosition = FormStartPosition.Manual,
                Height = this.Height,
                Width = this.Width,
                Location = this.Location
            };
            show_All_Accounts.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form delete_Account = new Delete_Account
            {
                StartPosition = FormStartPosition.Manual,
                Height = this.Height,
                Width = this.Width,
                Location = this.Location
            };
            delete_Account.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form update_Account = new Update_Account
            {
                StartPosition = FormStartPosition.Manual,
                Height = this.Height,
                Width = this.Width,
                Location = this.Location
            };
            update_Account.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form get_Account_By_ID = new Get_Account_By_ID
            {
                StartPosition = FormStartPosition.Manual,
                Height = this.Height,
                Width = this.Width,
                Location = this.Location
            };
            get_Account_By_ID.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form show_All_Students = new Show_All_Students();
            show_All_Students.StartPosition = FormStartPosition.Manual;
            show_All_Students.Height = this.Height;
            show_All_Students.Width = this.Width;
            show_All_Students.Location = this.Location;
            show_All_Students.Show();
        }
    }
}
