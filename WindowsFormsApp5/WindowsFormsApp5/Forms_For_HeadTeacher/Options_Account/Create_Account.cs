﻿using ConsoleApp1.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace WindowsFormsApp5.Forms_For_Teacher
{
    public partial class Create_Account : Form
    {
        private readonly AccountController accountController = new AccountController();
        public Create_Account()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Create_Account_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string email = textBox2.Text;
            string password = textBox3.Text;
            int role_id = int.Parse(textBox4.Text);

            accountController.CreateNewAccount(name, email, password, role_id);
            MessageBox.Show("Created Account successfully");
        }
    }
}
