using ConsoleApp1.Controller;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsApp5.Entity;

namespace WindowsFormsApp5.Forms_For_Administrator.Options_Students
{
    public partial class Administrator_Create_Student : Form
    {
        private readonly AccountController accountController = new AccountController();
        public Administrator_Create_Student()
        {
            InitializeComponent();
            ShowAllStudents();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowAllStudents();
            string first_name = textBox1.Text;
            string last_name = textBox2.Text;
            string email = textBox3.Text;
            string password = textBox4.Text;
            bool isHomeworkSet = false;
            if (comboBox1.SelectedIndex == 0)
            {
                isHomeworkSet = true;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                isHomeworkSet = false;
            }
            bool isHomeworkDone = false;
            int class_id = Convert.ToInt32(textBox5.Text);

            //int role_id = 1;

            accountController.CreateNewStudent(first_name, last_name, email, password, isHomeworkSet, isHomeworkDone, class_id); //, role_id
            ShowAllStudents();
            MessageBox.Show("Created Student successfully");

        }
        private void ShowAllStudents()
        {
            Response<List<Student>> response = accountController.GetAllStudents();
            listView1.Items.Clear();
            if (response.errorMessage != null)
            {
                MessageBox.Show(response.errorMessage);
                return;
            }
            List<Student> students = response.Obj;
            students.ForEach(student =>
            {
                ListViewItem item = new ListViewItem(student.Id.ToString());
                item.SubItems.Add(student.FirstName);
                item.SubItems.Add(student.LastName);
                item.SubItems.Add(student.Email);
                item.SubItems.Add(student.Password);
                item.SubItems.Add(student.IsHomeworkSet ? "SET" : "NOT SET");
                item.SubItems.Add(student.IsHomeworkDone ? "COMPLETED" : "NOT COMPLETED");
                item.SubItems.Add(student.Teacher_First_Name);
                item.SubItems.Add(student.Teacher_Last_Name);
                item.SubItems.Add(student.Class_name);
                item.SubItems.Add(student.Class_id.ToString());
                listView1.Items.Add(item);
            });
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Administrator_Create_Student_Load(object sender, EventArgs e)
        {

        }
    }
}
