namespace DandelionAPI
{
    public class Repo
    {
        private AppDbContext appDbContext;

        public Repo(AppDbContext dbContext)
        {
            appDbContext = dbContext;
        }

        public IEnumerable<User> GetAllUsers()
        {
            foreach (var item in appDbContext.Users)
            {
                Console.WriteLine($"{item.Name}, {item.Id}, {item.PasswordHash}");
            };
            return appDbContext.Users;
        }

        public void AddUser(User user)
        {
            appDbContext.Users.AddRange(user);
            appDbContext.SaveChanges();
        }

        public IEnumerable<Game> GetAllGames()
        {
            yield return new Game(1, "", "", "");
        }
    }
}
