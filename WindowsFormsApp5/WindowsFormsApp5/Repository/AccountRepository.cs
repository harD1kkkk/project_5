using ConsoleApp1.Enity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;
using WindowsFormsApp5.Entity;

namespace ConsoleApp1.Repository
{
    public class AccountRepository
    {

        public List<Account> GetAllAccounts(SqlConnection connection)
        {
            List<Account> accounts = new List<Account>();
            /*JOIN Roles ON Accounts.role_id = Roles.role_id
             * , Roles.role_name* */
            string query = @"
        SELECT Accounts.* 
        FROM Accounts
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
                        //string roleName = Convert.ToString(reader["role_name"]);
                        //int role_id = Convert.ToInt32(reader["role_id"]);
                        Account account = new Account(id, name, email, password); //, roleName, role_id
                        accounts.Add(account);
                    }
                }
            }
            return accounts;
        }

        public List<Teacher> GetAllTeachers(SqlConnection connection)
        {
            List<Teacher> teachers = new List<Teacher>();

            string query = @"
        SELECT Teachers.*, Classes.class_name
        FROM Teachers
        JOIN Classes ON Teachers.class_id = Classes.class_id
            ";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        string first_name = Convert.ToString(reader["first_name"]);
                        string last_name = Convert.ToString(reader["last_name"]);
                        string email = Convert.ToString(reader["email"]);
                        string password = Convert.ToString(reader["password"]);
                        string class_name = Convert.ToString(reader["class_name"]);
                        int class_id = Convert.ToInt32(reader["class_id"]);
                        Teacher teacher= new Teacher(id, first_name, last_name, email, password, class_name, class_id);
                        teachers.Add(teacher);
                    }
                }
            }
            return teachers;
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
    Teachers.first_name, 
    Teachers.last_name, 
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

        public int CreateNewAccount(SqlConnection connection, string name, string email, string password) //, int role_id
        {
            int id = 0;
            //                                                      ,role_id                                                      ,@role_id
            string query = $"insert into Accounts(name,email,password) output INSERTED.ID " + $" Values  (@name, @email, @password)";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = name;
                cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = email;
                cmd.Parameters.Add("@password", System.Data.SqlDbType.NVarChar).Value = password;
                //cmd.Parameters.Add("@role_id", System.Data.SqlDbType.NVarChar).Value = role_id;
                id = (int)cmd.ExecuteScalar();
                MessageBox.Show("Inserted row with id: " + id);
            }
            return id;
        }

        public int CreateNewTeacher(SqlConnection connection, string first_name, string last_name, string email, string password, int class_id)
        {
            int id = 0;
            string query = $"insert into Teachers(first_name,last_name,email,password,class_id) output INSERTED.ID " + $" Values  (@first_name,@last_name, @email, @password,@class_id)";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.Add("@first_name", System.Data.SqlDbType.NVarChar).Value = first_name;
                cmd.Parameters.Add("@last_name", System.Data.SqlDbType.NVarChar).Value = last_name;
                cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = email;
                cmd.Parameters.Add("@password", System.Data.SqlDbType.NVarChar).Value = password;
                cmd.Parameters.Add("@class_id", System.Data.SqlDbType.NVarChar).Value = class_id;
                id = (int)cmd.ExecuteScalar();
                MessageBox.Show("Inserted row with id: " + id);
            }
            return id;
        }


        public Account GetId(SqlConnection connection, int id)
        {
            //, Roles.role_name
            //JOIN Roles ON Accounts.role_id = Roles.role_id

            string query = @"
        SELECT Accounts.*
        FROM Accounts 
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
                        //string roleName = Convert.ToString(reader["role_name"]);
                        //int role_id = Convert.ToInt32(reader["role_id"]);

                        Console.WriteLine("id: " + id);
                        Console.WriteLine("name: " + name);
                        Console.WriteLine("email: " + email);
                        Console.WriteLine("password: " + password);
                        //Console.WriteLine("role id: " + role_id);
                        account = new Account(id, name, email, password); //, roleName, role_id
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

        public Teacher Get_Teacher_Id(SqlConnection connection, int id)
        {
            string query = @"
        SELECT Teachers.*, Classes.class_name 
        FROM Teachers 
        JOIN Classes ON Teachers.class_id = Classes.class_id
        WHERE id=@id";
            int id2 = 0;
            Teacher teacher = null;
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.Add("@id", System.Data.SqlDbType.NVarChar).Value = id;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id2 = Convert.ToInt32(reader["id"]);
                        string first_name = Convert.ToString(reader["first_name"]);
                        string last_name = Convert.ToString(reader["last_name"]);
                        string email = Convert.ToString(reader["email"]);
                        string password = Convert.ToString(reader["password"]);
                        string class_name = Convert.ToString(reader["class_name"]);
                        int class_id = Convert.ToInt32(reader["class_id"]);

                        Console.WriteLine("id: " + id);
                        Console.WriteLine("first_name: " + first_name);
                        Console.WriteLine("last_name: " + last_name);
                        Console.WriteLine("email: " + email);
                        Console.WriteLine("password: " + password);
                        Console.WriteLine("class id: " + class_id);
                        teacher = new Teacher(id, first_name, last_name, email, password, class_name, class_id);
                    }
                }
            }
            if (id2 == 0)
            {
                MessageBox.Show("Error: id not exist");
                return null;
            }
            return teacher;
        }



        public Account GetName(SqlConnection connection, string name)
        {
            //Roles.role_name
            //     JOIN Roles ON Accounts.role_id = Roles.role_id
            string query = @"
        SELECT Accounts.*
        FROM Accounts 
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
                        //int role_id = Convert.ToInt32(reader["role_id"]);
                        //string roleName = Convert.ToString(reader["role_name"]);
                        account = new Account(id, name, email, password); //, roleName, role_id
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
            //, Roles.role_name
            //     JOIN Roles ON Accounts.role_id = Roles.role_id
            string query = @"
        SELECT Accounts.*
        FROM Accounts 
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
                        //int role_id = Convert.ToInt32(reader["role_id"]);
                        //string roleName = Convert.ToString(reader["role_name"]);
                        account = new Account(id, name, email, password); //, roleName, role_id
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
            //, Roles.role_name
            //     JOIN Roles ON Accounts.role_id = Roles.role_id
            string query = @"
        SELECT Accounts.*
        FROM Accounts 
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
                        account = new Account(id, name, email, password); //, roleName, role_id
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

    //    public Account GetRole_Id(SqlConnection connection, string name, string email, string password)
    //    {
    //        //, Roles.role_name
    //        //JOIN Roles ON Accounts.role_id = Roles.role_id
    //        string query = @"
    //    SELECT Accounts.*
    //    FROM Accounts 
    //    WHERE Accounts.name = @name AND Accounts.email = @email AND password = @password
    //";
    //        string name2 = "";
    //        string email2 = "";
    //        string password2 = "";
    //        Account account = null;
    //        using (SqlCommand cmd = new SqlCommand(query, connection))
    //        {
    //            cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = name;
    //            cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = email;
    //            cmd.Parameters.Add("@password", System.Data.SqlDbType.NVarChar).Value = password;
    //            using (SqlDataReader reader = cmd.ExecuteReader())
    //            {
    //                if (reader.Read())
    //                {
    //                    int id = Convert.ToInt32(reader["id"]);
    //                    name2 = Convert.ToString(reader["name"]);
    //                    email2 = Convert.ToString(reader["email"]);
    //                    password2 = Convert.ToString(reader["password"]);
    //                    //int role_id = Convert.ToInt32(reader["role_id"]);
    //                    //string roleName = Convert.ToString(reader["role_name"]);
    //                    account = new Account(id, name2, email2, password2); //, roleName, role_id
    //                }
    //            }
    //        }
    //        if (name2 == "" || email2 == " " || password2 == "")
    //        {
    //            MessageBox.Show("Error: Name or Email or Password are incorrect");
    //            return null;
    //        }
    //        return account;
    //    }




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

        public void DeleteTeacher(SqlConnection connection, int id)
        {
            string query = $"DELETE FROM Teachers WHERE  id = @id";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Teacher was deleted with id: " + id);
            }
        }

        public void UpdateAccount(SqlConnection connection, int id, string name, string email, string password) //,int role_id 
        {
            //                                                                                    , role_id = @role_id    
            string query = "UPDATE Accounts SET name = @name, email = @email, password = @password WHERE id = @id";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                //cmd.Parameters.AddWithValue("@role_id", role_id);

                cmd.ExecuteNonQuery();
                MessageBox.Show($"Account updated with id: {id}");
            }

        }

        public void UpdateTeacher(SqlConnection connection, int id, string first_name, string last_name, string email, string password, int class_id)
        {
            string query = "UPDATE Teachers SET first_name = @first_name,last_name=@last_name, email = @email, password = @password, class_id = @class_id WHERE id = @id";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@first_name", first_name);
                cmd.Parameters.AddWithValue("@last_name", last_name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@class_id", class_id);

                cmd.ExecuteNonQuery();
                MessageBox.Show($"Teacher updated with id: {id}");
            }

        }


        public Account GetAccountByNameEmailPassword(SqlConnection connection, string name, string email, string password)
        {
            string query = @"
        SELECT Accounts.*
        FROM Accounts 
        WHERE Accounts.name = @name AND Accounts.email = @email AND Accounts.password = @password
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
                        //int role_id = Convert.ToInt32(reader["role_id"]);
                        //string roleName = Convert.ToString(reader["role_name"]);
                        account = new Account(id, name, email, password);//, roleName, role_id
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


        public Teacher GetTeacherByFirst_NameLast_NameEmailPassword(SqlConnection connection, string first_name,string last_name, string email, string password)
        {
            string query = @"
        SELECT Teachers.*
        FROM Teachers 
        WHERE Teachers.first_name = @first_name AND Teachers.last_name = @last_name AND Teachers.email = @email AND Teachers.password = @password
    ";

            string first_name2 = "";
            string last_name2 = "";
            string email2 = "";
            string password2 = "";
            Teacher teacher = null;
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.Add("@first_name", System.Data.SqlDbType.NVarChar).Value = first_name;
                cmd.Parameters.Add("@last_name", System.Data.SqlDbType.NVarChar).Value = last_name;
                cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = email;
                cmd.Parameters.Add("@password", System.Data.SqlDbType.NVarChar).Value = password;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        first_name2 = Convert.ToString(reader["first_name"]);
                        last_name2 = Convert.ToString(reader["last_name"]);
                        email2 = Convert.ToString(reader["email"]);
                        password2 = Convert.ToString(reader["password"]);
                        string class_name = Convert.ToString(reader["class_name"]);
                        int class_id = Convert.ToInt32(reader["class_id"]);
                        teacher = new Teacher(id, first_name, last_name, email, password, class_name, class_id);
                    }
                }
            }
            if (first_name2 == "" || last_name2=="" || email2 == " " || password2 == "")
            {
                MessageBox.Show("Error: First Name or Last Name or Email or Password are incorrect");
                return null;
            }
            return teacher;
        }


       

    }
}
