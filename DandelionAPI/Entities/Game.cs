using DandelionAPI.Interface;

namespace DandelionAPI
{
    public class Game : IGame
    {
        private static int globalId = 0;

        public int Id { get; }
        public readonly int OwnerID;

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string URL { get; private set; }

        public Game(int ownerId, string name, string description, string url)
        {
            Id = globalId++;
            Name = name;
            Description = description;
            URL = url;
        }
    }
}