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
    public partial class Show_All_Students : Form
    {
        private readonly AccountController accountController = new AccountController();
        public Show_All_Students()
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
            List<Student> Students = accountController.GetAllStudents();
            Students.ForEach(Student =>
            {
                ListViewItem item = new ListViewItem(Student.Id.ToString());
                item.SubItems.Add(Student.FirstName);
                item.SubItems.Add(Student.LastName);
                item.SubItems.Add(Student.Email);
                item.SubItems.Add(Student.Password);
                item.SubItems.Add(Student.Class_id.ToString());
                listView1.Items.Add(item);
            });
        }
    }
}
