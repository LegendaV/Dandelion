namespace DandelionAPI
{
    public class UserAuthenticationDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class UserRegisterDto
    {
        public string UserName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
