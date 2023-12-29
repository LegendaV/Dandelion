namespace DandelionAPI.ClientDto
{
    public class GameDto
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string CommitSha { get; set; }

        public static implicit operator GameDto(Game game)
        {
            return new GameDto { Id = game.Id,
                OwnerId = game.OwnerId,
                Name = game.Name,
                Description = game.Description,
                Url = game.Url,
                CommitSha = game.CommitSha };
        }
    }
}
