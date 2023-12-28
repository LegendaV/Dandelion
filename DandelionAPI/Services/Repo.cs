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
