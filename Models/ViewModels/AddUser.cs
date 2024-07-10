namespace LinBeach.Models.ViewModels
{
    public class AddUser
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool AdminRole { get; set; }
    }
}
