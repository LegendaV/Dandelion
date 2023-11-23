namespace DandelionAPI
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public UserDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
