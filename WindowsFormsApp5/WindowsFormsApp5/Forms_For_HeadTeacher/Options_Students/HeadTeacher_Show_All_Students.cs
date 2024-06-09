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

namespace WindowsFormsApp5.Forms_For_HeadTeacher
{
    public partial class Administrator_Show_All_Students : Form
    {
        private readonly AccountController accountController = new AccountController();
        public Administrator_Show_All_Students()
        {
            InitializeComponent();
            ShowAllStudents();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                item.SubItems.Add(student.IsHomeworkDone ? "COMPLETED" : "NOT COMPLETED");
                item.SubItems.Add(student.Teacher_First_Name);
                item.SubItems.Add(student.Teacher_Last_Name);
                item.SubItems.Add(student.Class_name);
                item.SubItems.Add(student.Class_id.ToString());
                listView1.Items.Add(item);
            });
        }


        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
