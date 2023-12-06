using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DandelionAPI.Controllers
{
    [ApiController]
    public class GameController : ControllerBase
    {
        private Repo repo;
        public GameController(Repo repo)
        {
            this.repo = repo;
        }

        [HttpPost("{id}/game")]
        [Authorize]
        public async Task<ActionResult<Game[]>> GetUserGame(int id)
        {
            var user = repo.GetAllUsers().Where(u => u.Id == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Пользователь не найден");
            }
            var games = repo.GetAllGames().Where(g => user.Games.Contains(g.Id));
            return games.ToArray();
        }

        [HttpPost("{userId}/getGame/{gameID}")]
        [Authorize]
        public async Task<ActionResult> AddGameOnUserProfile(int userId, int gameID)
        {
            var user = repo.GetAllUsers().Where(u => u.Id == userId).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Пользователь не найден");
            }
            var game = repo.GetAllGames().Where(g => g.Id == gameID).FirstOrDefault();
            if (game == null)
            {
                return BadRequest("Игра не найдена");
            }

            user.AddGameOnProfile(game);
            return Ok();
        }
    }
}
