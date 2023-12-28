namespace DandelionAPI.ClientDto
{
    public class GameDto
    {
        private static int globalId = 0;

        public int Id { get; }
        public readonly List<int> OwnersId;

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string URL { get; private set; }

    }
}
