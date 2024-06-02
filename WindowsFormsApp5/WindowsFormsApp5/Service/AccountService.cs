using ConsoleApp1.Enity;
using ConsoleApp1.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsFormsApp5.Entity;

namespace ConsoleApp1.Service
{
    public class AccountService
    {
        //readonly string connectionString = "Server=tcp:newtestdb2.database.windows.net,1433;" +
        //    "Initial Catalog=Test;Persist Security Info=False;User ID=CloudSA142084fb;" +
        //    "Password=1qaz!QAZ;MultipleActiveResultSets=False;" +
        //    "Encrypt=True;TrustServerCertificate=False;Connection Timeout=30; Pooling=true; Max Pool Size=10; Min Pool Size=2;";
        readonly string connectionString = System.Configuration.ConfigurationManager
            .ConnectionStrings["db1_connectionString"].ConnectionString;
        private readonly AccountRepository accountRepository = new AccountRepository();
        public List<Account> GetAllAccounts()
        {
            List<Account> accounts = null;
            using (SqlConnection conection = new SqlConnection(connectionString))
            {
                try
                {
                    conection.Open();
                    accounts = accountRepository.GetAllAccounts(conection);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return accounts;
        }


        public int CreateNewAccount(string name, string email, string password, int role_id)
        {
            using (SqlConnection conection = new SqlConnection(connectionString))
            {

                try
                {
                    conection.Open();
                    accountRepository.CreateNewAccount(conection, name, email, password, role_id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            return 0;
        }


        public Account GetId(int id)
        {
            Account account = null;
            using (SqlConnection conection = new SqlConnection(connectionString))
            {
                try
                {
                    conection.Open();
                    account = accountRepository.GetId(conection, id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (account == null)
                {
                    MessageBox.Show("Account with id: " + id + " not exist");
                }
            }
            return account;

        }

        public Account GetName(string name)
        {
            Account account = null;
            using (SqlConnection conection = new SqlConnection(connectionString))
            {
                try
                {
                    conection.Open();
                    account = accountRepository.GetName(conection, name);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (account == null)
                {
                    MessageBox.Show("Account with name: " + name + " not exist");
                }
            }
            return account;
        }

        public Account GetEmail(string email)
        {
            Account account = null;
            using (SqlConnection conection = new SqlConnection(connectionString))
            {
                try
                {
                    conection.Open();
                    account = accountRepository.GetEmail(conection, email);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (account == null)
                {
                    MessageBox.Show("Account with email: " + email + " not exist");
                }
            }
            return account;
        }

        public Account GetPassword(string password)
        {
            Account account = null;
            using (SqlConnection conection = new SqlConnection(connectionString))
            {
                try
                {
                    conection.Open();
                    account = accountRepository.GetPassword(conection, password);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (account == null)
                {
                    MessageBox.Show("Account with password: " + password + " not exist");
                }
            }
            return account;
        }

        public int GetRole_id(string name, string email, string password)
        {
            int role_id = 0;
            Account account = null;
            using (SqlConnection conection = new SqlConnection(connectionString))
            {
                try
                {
                    conection.Open();
                    account = accountRepository.GetRole_Id(conection, name, email, password);
                    role_id = account.Role_Id;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (account == null)
                {
                    MessageBox.Show("Account not exist");
                }
            }
            return role_id;
        }

        public void DeleteAccount(int id)
        {
            if (GetId(id) == null)
            {
                MessageBox.Show("Error: Account with id: " + id + "not exist");
            }
            else
            {
                using (SqlConnection conection = new SqlConnection(connectionString))
                {
                    try
                    {
                        conection.Open();
                        accountRepository.DeleteAccount(conection, id);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }


        public void UpdateAccount(int id, string name, string email, string password, int role_id)
        {
            if (GetId(id) == null)
            {
                MessageBox.Show("Error: Account with id: " + id + "not exist");
            }
            else
            {
                using (SqlConnection conection = new SqlConnection(connectionString))
                {
                    try
                    {
                        conection.Open();
                        accountRepository.UpdateAccount(conection, id, name, email, password, role_id);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }


        public Account SignIn(string name, string email, string password)
        {
            using (SqlConnection conection = new SqlConnection(connectionString))
            {
                Account account = null;

                try
                {
                    conection.Open();
                    account = accountRepository.GetAccountByNameEmailPassword(conection, name, email, password);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (account == null || account.Name != name || account.Email != email || account.Password != password)
                {
                    throw new Exception("Error: Name or Email or Password are incorrect");
                }

                return account;
            }
        }



        public List<Student> GetAllStudents()
        {
            List<Student> Students = null;
            using (SqlConnection conection = new SqlConnection(connectionString))
            {
                try
                {
                    conection.Open();
                    Students = accountRepository.GetAllStudents(conection);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return Students;
        }

    }

}
