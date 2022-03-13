namespace BikramApi.Modeels
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string LeaveType { get; set; }
    }
    public class TakeLeave
    {
        public string Name { get; set; }
        public string LeaveType { get;set; }
    }
    public class Login
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
   
}
