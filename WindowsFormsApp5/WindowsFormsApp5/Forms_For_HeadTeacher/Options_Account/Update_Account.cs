using ConsoleApp1.Controller;
using ConsoleApp1.Enity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp5.Forms_For_HeadTeacher
{
    public partial class Update_Account : Form
    {
        private readonly AccountController accountController = new AccountController();
        public Update_Account()
        {
            InitializeComponent();
            ShowAllAccounts();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowAllAccounts();
            string str = textBox5.Text;
            int id = Convert.ToInt32(str);
            Account account = accountController.GetId(id);

            if (account != null)
            {
                string name = textBox1.Text;
                string email = textBox2.Text;
                string password = textBox3.Text;
                int role_id = int.Parse(textBox4.Text);

                accountController.UpdateAccount(id, name, email, password, role_id);
                account = accountController.GetId(id);

                ListViewItem item = new ListViewItem(account.Id.ToString());
                item.SubItems.Add(account.Name);
                item.SubItems.Add(account.Email);
                item.SubItems.Add(account.Password);
                item.SubItems.Add(account.Role_Id.ToString());
                listView1.Items.Add(item);

                listView1.Items.Clear();
                ShowAllAccounts();
            }
            else
            {
                MessageBox.Show("Account not exist.");
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
                item.SubItems.Add(account.Role_Id.ToString());
                listView1.Items.Add(item);
            });
        }
    }
}
