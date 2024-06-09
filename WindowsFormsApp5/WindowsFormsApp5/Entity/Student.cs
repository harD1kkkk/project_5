namespace WindowsFormsApp5.Entity
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsHomeworkSet { get; set; } = false;
        public bool IsHomeworkDone { get; set; } = false;
        public string Teacher_First_Name { get; set; }
        public string Teacher_Last_Name { get; set; }
        public string Class_name { get; set; }
        public int Class_id { get; set; }

        public Student(int id, string firstName, string lastName, string email, string password, bool isHomeworkSet, bool isHomeworkDone, string teacher_First_Name, string teacher_Last_Name, string class_name, int class_id)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            IsHomeworkSet = isHomeworkSet;
            IsHomeworkDone = isHomeworkDone;
            Teacher_First_Name = teacher_First_Name;
            Teacher_Last_Name = teacher_Last_Name;
            Class_name = class_name;
            Class_id = class_id;
        }
    }
}
