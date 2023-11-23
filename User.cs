namespace DandelionAPI
{
    public class User
    {
        private static int id_counter = 0;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PasswordHash { get; set; }

        public User(string name, int passwordHash, string email)
        {
            Id = id_counter++;
            Name = name;
            PasswordHash = passwordHash;
            Email = email;
        }

        public static implicit operator UserDto(User user)
        {
            return new UserDto(user.Id, user.Name);
        }
    }
}
