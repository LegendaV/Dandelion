namespace DandelionAPI
{
    public class Game
    {
        private static int globalId = 0;

        public readonly int Id;
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
