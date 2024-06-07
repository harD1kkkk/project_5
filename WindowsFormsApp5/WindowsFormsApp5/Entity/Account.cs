namespace ConsoleApp1.Enity
{
    public class Account
    {
        public Account(int id, string name, string email, string password)//,string role_name, int role_id
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            //Role_Name = role_name;
            //Role_Id = role_id;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public string Role_Name {  get; set; }
        //public int Role_Id { get; set; }
    }
}
