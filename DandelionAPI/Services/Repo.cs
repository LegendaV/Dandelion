using Microsoft.EntityFrameworkCore;

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
            return appDbContext.Games;
        }

        public void AddGame(Game game)
        {
            appDbContext.Games.AddRange(game);
            appDbContext.SaveChanges();
        }

        public void GetGameOnProfille(User user, Game game)
        {
            user.Games.Add(game);
            appDbContext.SaveChanges();
        }

        public List<User> GetUsersWithGame()
        {
            return appDbContext.Users.Include(g => g.Games).ToList();
        }
    }
}
