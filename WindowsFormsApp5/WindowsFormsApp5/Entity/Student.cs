namespace WindowsFormsApp5.Entity
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsHomeworkDone { get; set; } = false;
        public string NameTeacher { get; set; }
        public string Class_name { get; set; }

        public Student(int id, string firstName, string lastName, string email, string password, bool isHomeworkDone, string nameTeacher, string class_name)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            IsHomeworkDone = isHomeworkDone;
            NameTeacher = nameTeacher;
            Class_name = class_name;
        }
    }
}
