using DandelionAPI.Interface;

namespace DandelionAPI
{
    public class User
    {
        private static int id_counter = 0;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }

        public List<Game> Games { get; set; } = new();

        public User(string name, string passwordHash, string login)
        {
            Id = id_counter++;
            Name = name;
            PasswordHash = passwordHash;
            Login = login;
        }
    }
}
