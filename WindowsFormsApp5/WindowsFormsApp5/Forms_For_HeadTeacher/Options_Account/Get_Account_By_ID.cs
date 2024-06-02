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

namespace WindowsFormsApp5.Forms_For_HeadTeacher
{
    public partial class Get_Account_By_ID : Form
    {
        private readonly AccountController accountController = new AccountController();
        public Get_Account_By_ID()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string str = textBox1.Text;
            int id = Convert.ToInt32(str);
            Account account = accountController.GetId(id);

            if (account != null)
            {
                ListViewItem item = new ListViewItem(account.Id.ToString());
                item.SubItems.Add(account.Name);
                item.SubItems.Add(account.Email);
                item.SubItems.Add(account.Password);
                item.SubItems.Add(account.Role_Name);
                item.SubItems.Add(account.Role_Id.ToString());
                listView1.Items.Add(item);
            }
            else
            {
                MessageBox.Show("Account not exist.");
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
