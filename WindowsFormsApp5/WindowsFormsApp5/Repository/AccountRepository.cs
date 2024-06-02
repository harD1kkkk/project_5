﻿using ConsoleApp1.Enity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsFormsApp5.Entity;

namespace ConsoleApp1.Repository
{
    public class AccountRepository
    {

        public List<Account> GetAllAccounts(SqlConnection connection)
        {
            List<Account> accounts = new List<Account>();

            string query = @"
        SELECT Accounts.*, Roles.role_name
        FROM Accounts
        JOIN Roles ON Accounts.role_id = Roles.role_id
            ";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        string name = Convert.ToString(reader["name"]);
                        string email = Convert.ToString(reader["email"]);
                        string password = Convert.ToString(reader["password"]);
                        string roleName = Convert.ToString(reader["role_name"]);
                        int role_id = Convert.ToInt32(reader["role_id"]);
                        Account account = new Account(id, name, email, password, roleName, role_id);
                        accounts.Add(account);
                    }
                }
            }
            return accounts;
        }


        public int CreateNewAccount(SqlConnection connection, string name, string email, string password, int role_id)
        {
            int id = 0;
            string query = $"insert into Accounts(name,email,password,role_id) output INSERTED.ID " + $" Values  (@name, @email, @password,@role_id)";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = name;
                cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = email;
                cmd.Parameters.Add("@password", System.Data.SqlDbType.NVarChar).Value = password;
                cmd.Parameters.Add("@role_id", System.Data.SqlDbType.NVarChar).Value = role_id;
                id = (int)cmd.ExecuteScalar();
                MessageBox.Show("Inserted row with id: " + id);
            }
            return id;
        }


        public Account GetId(SqlConnection connection, int id)
        {
            string query = @"
        SELECT Accounts.*, Roles.role_name 
        FROM Accounts 
        JOIN Roles ON Accounts.role_id = Roles.role_id
        WHERE id=@id";
            int id2 = 0;
            Account account = null;
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.Add("@id", System.Data.SqlDbType.NVarChar).Value = id;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id2 = Convert.ToInt32(reader["id"]);
                        string name = Convert.ToString(reader["name"]);
                        string email = Convert.ToString(reader["email"]);
                        string password = Convert.ToString(reader["password"]);
                        string roleName = Convert.ToString(reader["role_name"]);
                        int role_id = Convert.ToInt32(reader["role_id"]);

                        Console.WriteLine("id: " + id);
                        Console.WriteLine("name: " + name);
                        Console.WriteLine("email: " + email);
                        Console.WriteLine("password: " + password);
                        Console.WriteLine("role id: " + role_id);
                        account = new Account(id, name, email, password, roleName, role_id);
                    }
                }
            }
            if (id2 == 0)
            {
                MessageBox.Show("Error: id not exist");
                return null;
            }
            return account;
        }

        public Account GetName(SqlConnection connection, string name)
        {
            string query = @"
        SELECT Accounts.*, Roles.role_name 
        FROM Accounts 
        JOIN Roles ON Accounts.role_id = Roles.role_id
        WHERE name=@name";
            string name2 = "";
            Account account = null;
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = name;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        name2 = Convert.ToString(reader["name"]);
                        string email = Convert.ToString(reader["email"]);
                        string password = Convert.ToString(reader["password"]);
                        int role_id = Convert.ToInt32(reader["role_id"]);
                        string roleName = Convert.ToString(reader["role_name"]);
                        account = new Account(id, name, email, password, roleName, role_id);
                    }
                }
            }
            if (name2 == "")
            {
                MessageBox.Show("Error: Name not exist");
                return null;
            }
            return account;
        }

        public Account GetEmail(SqlConnection connection, string email)
        {
            string query = @"
        SELECT Accounts.*, Roles.role_name 
        FROM Accounts 
        JOIN Roles ON Accounts.role_id = Roles.role_id 
        WHERE email=@email";
            string email2 = "";
            Account account = null;
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = email;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        string name = Convert.ToString(reader["name"]);
                        email2 = Convert.ToString(reader["email"]);
                        string password = Convert.ToString(reader["password"]);
                        int role_id = Convert.ToInt32(reader["role_id"]);
                        string roleName = Convert.ToString(reader["role_name"]);
                        account = new Account(id, name, email, password, roleName, role_id);
                    }
                }
            }
            if (email2 == "")
            {
                MessageBox.Show("Error: Email not exist");
                return null;
            }
            return account;
        }

        public Account GetPassword(SqlConnection connection, string password)
        {
            string query = @"
        SELECT Accounts.*, Roles.role_name 
        FROM Accounts 
        JOIN Roles ON Accounts.role_id = Roles.role_id
        WHERE password=@password";
            string password2 = "";
            Account account = null;
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.Add("@password", System.Data.SqlDbType.NVarChar).Value = password;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        string name = Convert.ToString(reader["name"]);
                        string email = Convert.ToString(reader["email"]);
                        password2 = Convert.ToString(reader["password"]);
                        int role_id = Convert.ToInt32(reader["role_id"]);
                        string roleName = Convert.ToString(reader["role_name"]);
                        account = new Account(id, name, email, password, roleName, role_id);
                    }
                }
            }
            if (password2 == "")
            {
                MessageBox.Show("Error: Password not exist");
                return null;
            }
            return account;
        }

        public Account GetRole_Id(SqlConnection connection, string name, string email, string password)
        {
            string query = @"
        SELECT Accounts.*, Roles.role_name 
        FROM Accounts 
        JOIN Roles ON Accounts.role_id = Roles.role_id
        WHERE Accounts.name = @name AND Accounts.email = @email AND password = @password
    ";
            string name2 = "";
            string email2 = "";
            string password2 = "";
            Account account = null;
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = name;
                cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = email;
                cmd.Parameters.Add("@password", System.Data.SqlDbType.NVarChar).Value = password;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        name2 = Convert.ToString(reader["name"]);
                        email2 = Convert.ToString(reader["email"]);
                        password2 = Convert.ToString(reader["password"]);
                        int role_id = Convert.ToInt32(reader["role_id"]);
                        string roleName = Convert.ToString(reader["role_name"]);
                        account = new Account(id, name2, email2, password2, roleName, role_id);
                    }
                }
            }
            if (name2 == "" || email2 == " " || password2 == "")
            {
                MessageBox.Show("Error: Name or Email or Password are incorrect");
                return null;
            }
            return account;
        }




        public void DeleteAccount(SqlConnection connection, int id)
        {
            string query = $"DELETE FROM Accounts WHERE  id = @id";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Account was deleted with id: " + id);
            }
        }


        public void UpdateAccount(SqlConnection connection, int id, string name, string email, string password, int role_id)
        {
            string query = "UPDATE Accounts SET name = @name, email = @email, password = @password, role_id = @role_id WHERE id = @id";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@role_id", role_id);

                cmd.ExecuteNonQuery();
                MessageBox.Show($"Account updated with id: {id}");
            }

        }


        public Account GetAccountByNameEmailPassword(SqlConnection connection, string name, string email, string password)
        {
            string query = @"
        SELECT Accounts.*, Roles.role_name 
        FROM Accounts 
        JOIN Roles ON Accounts.role_id = Roles.role_id
        WHERE Accounts.name = @name AND Accounts.email = @email AND password = @password
    ";

            string name2 = "";
            string email2 = "";
            string password2 = "";
            Account account = null;
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = name;
                cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = email;
                cmd.Parameters.Add("@password", System.Data.SqlDbType.NVarChar).Value = password;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        name2 = Convert.ToString(reader["name"]);
                        email2 = Convert.ToString(reader["email"]);
                        password2 = Convert.ToString(reader["password"]);
                        int role_id = Convert.ToInt32(reader["role_id"]);
                        string roleName = Convert.ToString(reader["role_name"]);
                        account = new Account(id, name, email, password, roleName, role_id);
                    }
                }
            }
            if (name2 == "" || email2 == " " || password2 == "")
            {
                MessageBox.Show("Error: Name or Email or Password are incorrect");
                return null;
            }
            return account;
        }


        public List<Student> GetAllStudents(SqlConnection connection)
        {
            List<Student> students = new List<Student>();
            string query = @"
SELECT 
    Students.student_id, 
    Students.first_name, 
    Students.last_name, 
    Students.email, 
    Students.password, 
    Students.IsHomeworkDone, 
    Teachers.teacher_name, 
    Classes.class_name, 
    Classes.class_id 
FROM 
    Students 
JOIN 
    Classes ON Students.class_id = Classes.class_id
JOIN 
    Teachers ON Classes.teacher_id = Teachers.teacher_id";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["student_id"]);
                        string first_name = Convert.ToString(reader["first_name"]);
                        string last_name = Convert.ToString(reader["last_name"]);
                        string email = Convert.ToString(reader["email"]);
                        string password = Convert.ToString(reader["password"]);
                        bool isHomeworkDone = Convert.ToBoolean(reader["IsHomeworkDone"]);
                        string teacher_name = Convert.ToString(reader["teacher_name"]);
                        string class_name = Convert.ToString(reader["class_name"]);
                        Student student = new Student(id, first_name, last_name, email, password, isHomeworkDone, teacher_name, class_name);
                        students.Add(student);
                    }
                }
            }
            return students;
        }

    }
}
