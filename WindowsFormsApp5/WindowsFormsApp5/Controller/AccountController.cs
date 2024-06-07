using ConsoleApp1.Enity;
using ConsoleApp1.Service;
using System;
using System.Collections.Generic;
using WindowsFormsApp5;
using WindowsFormsApp5.Entity;

namespace ConsoleApp1.Controller
{
    public class AccountController
    {
        private readonly AccountService accountService = new AccountService();
        public List<Account> GetAllAccounts()
        {
            return accountService.GetAllAccounts();
        }
        public List<Teacher> GetAllTeachers()
        {
            return accountService.GetAllTeachers();
        }

        public int CreateNewAccount(string name, string email, string password) //, int role_id
        {
            return accountService.CreateNewAccount(name, email, password); //, role_id
        }

        public int CreateNewTeacher(string first_name, string last_name, string email, string password, int class_id)
        {
            return accountService.CreateNewTeacher(first_name, last_name, email, password, class_id);
        }


        public Account GetName(string name)
        {
            return accountService.GetName(name);
        }

        public Account GetEmail(string email)
        {
            return accountService.GetEmail(email);
        }

        public Account GetPassword(string password)
        {
            return accountService.GetPassword(password);
        }

        public Account GetId(int id)
        {
            return accountService.GetId(id);
        }

        public Teacher Get_Teacher_Id(int id)
        {
            return accountService.Get_Teacher_Id(id);
        }

        //public int GetRole_Id(string name, string email, string password)
        //{
        //    return accountService.GetRole_id(name, email, password);
        //}


        public void DeleteAccount(int id)
        {
            accountService.DeleteAccount(id);
        }

        public void DeleteTeacher(int id)
        {
            accountService.DeleteTeacher(id);
        }


        public void UpdateAccount(int id, string name, string email, string password) //, int role_id
        {
            accountService.UpdateAccount(id, name, email, password); //, role_id
        }

        public void UpdateTeacher(int id,string first_name, string last_name, string email, string password, int class_id)
        {
            accountService.UpdateTeacher(id,first_name, last_name, email, password, class_id);
        }


        public List<Student> GetAllStudents()
        {
            return accountService.GetAllStudents();
        }





        public Response<Account> SignIn(string name, string email, string password)
        {
            Response<Account> response = new Response<Account>();
            try
            {
                response.Obj = accountService.SignIn(name, email, password);
            }
            catch (Exception ex)
            {
                response.errorMessage = ex.Message;
            }
            return response;
        }
    }
}
