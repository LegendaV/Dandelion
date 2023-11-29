namespace DandelionAPI
{
    public static class Repo
    {
        private static readonly List<User> users = new List<User>{ new User("Slava", "SlavaSlava".GetHashCode(), "Slava@mail.ru") };
        private static readonly List<Game> games = new List<Game> { new Game(0, "LightAndDrkness", "", ""), new Game(0, "BattleCity", "", "") };

        public static IEnumerable<User> GetAllUsers()
        {
            return users;
        }

        public static void AddUser(User user)
        {
            users.Add(user);
        }

        public static IEnumerable<Game> GetAllGames()
        {
            return games;
        }
    }
}
