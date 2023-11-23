namespace DandelionAPI
{
    public class UserAuthenticationDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class UserRegisterDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
