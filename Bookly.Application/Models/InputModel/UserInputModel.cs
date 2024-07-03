namespace Bookly.Application.Model.InputModels
{
    public class UserInputModel 
    {
        public UserInputModel(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
    }
}