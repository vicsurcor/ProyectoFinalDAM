namespace Proyecto.Models.User
{
    public class UserViewModel
    {
        public User User { get; set; } = new User();

        public UserContent UserContent { get; set; } = new UserContent();

        public UserViewModel() { }

        public UserViewModel(User user, UserContent userContent)
        {
            User = user;
            UserContent = userContent;
        }
    }

    

}
