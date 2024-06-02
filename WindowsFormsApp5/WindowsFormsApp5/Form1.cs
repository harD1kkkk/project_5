using ConsoleApp1.Controller;
using ConsoleApp1.Enity;
using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp5.Forms_For_HeadTeacher;
using WindowsFormsApp5.Forms_For_Teacher;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        private readonly AccountController accountController = new AccountController();
        public Form1()
        {
            InitializeComponent();
            button1.BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;
            button1.FlatAppearance.BorderSize = 1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string email = textBox3.Text;
            string password = textBox2.Text;

            Response<Account> response = accountController.SignIn(name, email, password);

            if (response.errorMessage != null)
            {
                MessageBox.Show(response.errorMessage);
                return;
            }


            int role_id = accountController.GetRole_Id(name, email, password);
            if (role_id == 1)
            {
                Form head_teacher_options = new Head_Teacher_options
                {
                    StartPosition = FormStartPosition.Manual,
                    Height = this.Height,
                    Width = this.Width,
                    Location = this.Location
                };
                head_teacher_options.Show();
            }
            else if (role_id == 2)
            {
                Form teacher_options = new Teacher_options
                {
                    StartPosition = FormStartPosition.Manual,
                    Height = this.Height,
                    Width = this.Width,
                    Location = this.Location
                };
                teacher_options.Show();
            }
            else
            {
                MessageBox.Show("unknown error");
                return;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
