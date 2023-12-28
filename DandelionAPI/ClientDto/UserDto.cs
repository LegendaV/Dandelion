namespace DandelionAPI
{
    public class UserDto
    {
        public int Id { get; set; }
        public string AccessToken { get; set; }
        public string Name { get; set; }

        public UserDto(int id, string name, string accessToken)
        {
            Id = id;
            Name = name;
            AccessToken = accessToken;
        }
    }
}
