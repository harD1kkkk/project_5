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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp5.Forms_For_HeadTeacher
{
    public partial class Delete_Account : Form
    {
        private readonly AccountController accountController = new AccountController();
        public Delete_Account()
        {
            InitializeComponent();
            ShowAllAccounts();
        }


        private void Delete_Account_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowAllAccounts();
            string str = textBox1.Text;
            int id = Convert.ToInt32(str);
            Account account = accountController.GetId(id);

            if (account != null)
            {
                accountController.DeleteAccount(id);
                List<Account> accounts = accountController.GetAllAccounts();
                accounts.ForEach(account1 =>
                {
                    ListViewItem item = new ListViewItem(account1.Id.ToString());
                    item.SubItems.Add(account1.Name);
                    item.SubItems.Add(account1.Email);
                    item.SubItems.Add(account1.Password);
                    item.SubItems.Add(account1.Role_Id.ToString());
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
        private void ShowAllAccounts()
        {
            listView1.Items.Clear();
            List<Account> accounts = accountController.GetAllAccounts();
            accounts.ForEach(account =>
            {
                ListViewItem item = new ListViewItem(account.Id.ToString());
                item.SubItems.Add(account.Name);
                item.SubItems.Add(account.Email);
                item.SubItems.Add(account.Password);
                item.SubItems.Add(account.Role_Name);
                item.SubItems.Add(account.Role_Id.ToString());
                listView1.Items.Add(item);
            });
        }
    }
}
