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

namespace WindowsFormsApp5.Forms_For_Administrator.Options_Teacher
{
    public partial class HeadTeacher_Show_All_Teachers : Form
    {
        private readonly AccountController accountController = new AccountController();
        public HeadTeacher_Show_All_Teachers()
        {
            InitializeComponent();
        }
        private void ShowAllTeachers()
        {
            listView1.Items.Clear();
            List<Account> teachers = accountController.GetAllAccounts();
            teachers.ForEach(teacher =>
            {
                ListViewItem item = new ListViewItem(teacher.Id.ToString());
                item.SubItems.Add(teacher.Name);
                item.SubItems.Add(teacher.Email);
                item.SubItems.Add(teacher.Password);
                //item.SubItems.Add(teacher.Role_Name);
                //item.SubItems.Add(teacher.Role_Id.ToString());
                listView1.Items.Add(item);
            });
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
