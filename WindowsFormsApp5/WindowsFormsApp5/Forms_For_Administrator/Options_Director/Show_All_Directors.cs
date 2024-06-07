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

namespace WindowsFormsApp5.Forms_For_Administrator
{
    public partial class Show_All_Directors : Form
    {
        private readonly AccountController accountController = new AccountController();
        public Show_All_Directors()
        {
            InitializeComponent();
            ShowAllAccounts();
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
                //item.SubItems.Add(account.Role_Name);
                //item.SubItems.Add(account.Role_Id.ToString());
                listView1.Items.Add(item);
            });
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
