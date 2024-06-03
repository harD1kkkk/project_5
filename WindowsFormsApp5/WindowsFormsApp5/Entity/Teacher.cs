using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5.Entity
{
    public class Teacher
    {
        public Teacher(int id, string firstName, string lastName, string email, string password, string class_Name, int class_Id)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Class_Name = class_Name;
            Class_Id = class_Id;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Class_Name { get; set; }
        public int Class_Id { get; set; }
    }
}
