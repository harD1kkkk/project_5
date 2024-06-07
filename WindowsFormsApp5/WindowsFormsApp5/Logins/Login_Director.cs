using ConsoleApp1.Controller;
using ConsoleApp1.Enity;
using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp5.Forms_For_HeadTeacher;
using WindowsFormsApp5.Forms_For_Teacher;
using WindowsFormsApp5.Forms_For_Administrator;

namespace WindowsFormsApp5
{
    public partial class Login_Director : Form
    {
        private readonly AccountController accountController = new AccountController();
        public Login_Director()
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
            //string name = textBox1.Text;
            //string email = textBox3.Text;
            //string password = textBox2.Text;

            string name = "Tomas";
            string email = "tomas.gerada@gmail.com";
            string password = "5dasdsaASd";
            Response<Account> response = accountController.SignIn(name, email, password);

            if (response.errorMessage != null)
            {
                MessageBox.Show(response.errorMessage);
                return;
            }

            Form headTeacher_options = new HeadTeacher_options
            {
                StartPosition = FormStartPosition.Manual,
                Height = this.Height,
                Width = this.Width,
                Location = this.Location
            };
            headTeacher_options.Show();


            //int role_id = accountController.GetRole_Id(name, email, password);

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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
