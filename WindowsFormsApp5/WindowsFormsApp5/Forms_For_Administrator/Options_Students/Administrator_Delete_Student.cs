using ConsoleApp1.Controller;
using ConsoleApp1.Enity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp5.Entity;

namespace WindowsFormsApp5.Forms_For_Administrator.Options_Students
{
    public partial class Administrator_Delete_Student : Form
    {
        private readonly AccountController accountController = new AccountController();
        public Administrator_Delete_Student()
        {
            InitializeComponent();
            ShowAllStudents();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowAllStudents();
            string str = textBox1.Text;
            int id = Convert.ToInt32(str);
            Student student = accountController.Get_Student_Id(id);

            if (student != null)
            {
                accountController.DeleteStudent(id);
                List<Student> students = accountController.GetAllStudents();
                students.ForEach(student1 =>
                {
                    ListViewItem item = new ListViewItem(student1.Id.ToString());
                    item.SubItems.Add(student1.Name);
                    item.SubItems.Add(student1.Email);
                    item.SubItems.Add(student1.Password);
                    //item.SubItems.Add(account1.Role_Id.ToString());
                    listView1.Items.Add(item);
                });

                listView1.Items.Clear();
                ShowAllAccounts();
            }
            else
            {
                MessageBox.Show("Id not exist.");
            }
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
    }
}
