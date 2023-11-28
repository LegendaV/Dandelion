using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DandelionAPI.Controllers
{
    [ApiController]
    public class GameControllerr : ControllerBase
    {
        [HttpPost("{id}/game")]
        [Authorize]
        public async Task<ActionResult<Game[]>> GetUserGame(int id)
        {
            var user = Repo.GetAllUsers().Where(u => u.Id == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Пользователь не найден");
            }
            var games = Repo.GetAllGames().Where(g => user.Games.Contains(g.Id));
            return games.ToArray();
        }

        [HttpPost("{userId}/getGame/{gameID}")]
        [Authorize]
        public async Task<ActionResult> AddGameOnUserProfile(int userId, int gameID)
        {
            var user = Repo.GetAllUsers().Where(u => u.Id == userId).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Пользователь не найден");
            }
            var game = Repo.GetAllGames().Where(g => g.Id == gameID).FirstOrDefault();
            if (game == null)
            {
                return BadRequest("Игра не найдена");
            }

            user.AddGameOnProfile(game);
            return Ok();
        }
    }
}
