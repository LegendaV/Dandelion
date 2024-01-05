using DandelionAPI.ClientDto;
using DandelionAPI.Interface;

namespace DandelionAPI
{
    public class Game : IGame
    {
        private static int globalId = 0;

        public int Id { get; private set; }
        public int OwnerId { get; private set; }
        public List<User> Users { get; set; } = new();

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Url { get; private set; }
        public string CommitSha { get; private set; }
        public string ExeFileName { get; set; }

        public Game(int ownerId, string name, string description, string url, string commitSha, string exeFileName = null)
        {
            Id = globalId++;
            OwnerId = ownerId;
            Name = name;
            Description = description;
            Url = url;
            CommitSha = commitSha;
            ExeFileName = exeFileName;
        }

        public static implicit operator Game(GameDto dto)
        {
            return new Game(dto.OwnerId, dto.Name, dto.Description, dto.Url, dto.CommitSha, dto.ExeFileName);
        }
    }
}