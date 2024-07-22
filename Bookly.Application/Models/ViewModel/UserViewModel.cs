using Bookly.Core.Entities;

namespace Bookly.Application.Model.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(User user)
        {
            IdUser = user.Id;
            Name = user.Name;
            Email = user.Email;
        }

        public int IdUser { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
    }
}