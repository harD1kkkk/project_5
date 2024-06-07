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

namespace WindowsFormsApp5.Forms_For_Administrator
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
            listView1.Items.Clear();
            List<Student> students = accountController.GetAllStudents();
            students.ForEach(student =>
            {
                ListViewItem item = new ListViewItem(student.Id.ToString());
                item.SubItems.Add(student.FirstName);
                item.SubItems.Add(student.LastName);
                item.SubItems.Add(student.Email);
                item.SubItems.Add(student.Password);
                item.SubItems.Add(student.IsHomeworkDone ? "COMPLETED" : "NOT COMPLETED");
                item.SubItems.Add(student.NameTeacher);
                item.SubItems.Add(student.Class_name);
                item.SubItems.Add(student);
                listView1.Items.Add(item);
            });
        }

    }
}
