using DandelionAPI.ClientDto;
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
        public async Task<ActionResult<List<GameDto>>> GetUserGame(int id)
        {
            var user = repo.GetUsersWithGame().Where(u => u.Id == id).FirstOrDefault();
            if (user == null || this.User.Identity.Name != user.Login)
            {
                return BadRequest("Пользователь не найден");
            }
            return user.Games.Select(g => (GameDto)g).ToList();
        }

        [HttpPost("{userId}/getGame/{gameID}")]
        [Authorize]
        public async Task<ActionResult> AddGameOnUserProfile(int userId, int gameID)
        {
            var user = repo.GetAllUsers().Where(u => u.Id == userId).FirstOrDefault();
            if (user == null || this.User.Identity.Name != user.Login)
            {
                return BadRequest("Пользователь не найден");
            }
            var game = repo.GetAllGames().Where(g => g.Id == gameID).FirstOrDefault();
            if (game == null)
            {
                return BadRequest("Игра не найдена");
            }
            if (user.Games.Contains(game))
            {
                return Ok();
            }

            repo.GetGameOnProfille(user, game);
            return Ok();
        }

        [HttpPost("newGame")]
        [Authorize]
        public async Task<ActionResult> AddNewGame([FromBody] GameDto gameDto)
        {
            repo.AddGame(gameDto);
            return Ok();
        }
    }
}
