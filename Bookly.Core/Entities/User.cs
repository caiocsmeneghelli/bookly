namespace Bookly.Core.Entities
{
    public class User
    {
        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
    }
}