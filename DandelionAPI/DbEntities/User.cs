using DandelionAPI.Interface;

namespace DandelionAPI
{
    public class User
    {
        private static int id_counter = 0;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public int PasswordHash { get; set; }

        public readonly HashSet<int> Games = new HashSet<int>();

        public User(string name, int passwordHash, string login)
        {
            Id = id_counter++;
            Name = name;
            PasswordHash = passwordHash;
            Login = login;
        }

        public void AddGameOnProfile(IGame game)
        {
            Games.Add(game.Id);
        }
    }
}
