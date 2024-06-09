using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp5.Forms_For_Administrator.Options_Students;
using WindowsFormsApp5.Forms_For_Teacher;

namespace WindowsFormsApp5.Forms_For_Administrator
{
    public partial class Administrator_options : Form
    {
        public Administrator_options()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form create_Director = new Create_Director
            {
                StartPosition = FormStartPosition.Manual,
                Height = this.Height,
                Width = this.Width,
                Location = this.Location
            };
            create_Director.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form show_All_Director = new Show_All_Directors
            {
                StartPosition = FormStartPosition.Manual,
                Height = this.Height,
                Width = this.Width,
                Location = this.Location
            };
            show_All_Director.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form delete_Director = new Delete_Director
            {
                StartPosition = FormStartPosition.Manual,
                Height = this.Height,
                Width = this.Width,
                Location = this.Location
            };
            delete_Director.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form update_Director = new Update_Director
            {
                StartPosition = FormStartPosition.Manual,
                Height = this.Height,
                Width = this.Width,
                Location = this.Location
            };
            update_Director.Show();
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
            Form show_All_Students = new Administrator_Show_All_Students
            {
                StartPosition = FormStartPosition.Manual,
                Height = this.Height,
                Width = this.Width,
                Location = this.Location
            };
            show_All_Students.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form administrator_Create_Student = new Administrator_Create_Student();
            administrator_Create_Student.StartPosition = FormStartPosition.Manual;
            administrator_Create_Student.Height = this.Height;
            administrator_Create_Student.Width = this.Width;
            administrator_Create_Student.Location = this.Location;
            administrator_Create_Student.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
    }
}
