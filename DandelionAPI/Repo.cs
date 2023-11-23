namespace DandelionAPI
{
    public static class Repo
    {
        private static readonly List<User> users = new List<User>{ new User("Slava", "SlavaSlava".GetHashCode(), "Slava@mail.ru") };

        public static IEnumerable<User> GetAllUsers()
        {
            return users;
        }

        public static void AddUser(User user)
        {
            users.Add(user);
        }
    }
}
