namespace Proyecto.Models.User
{
    // Modelo que engloba un Usuario Completo (Credenciales de registro y Contenido).
    public class UserViewModel
    {
        // Usuario para el registro.
        public User User { get; set; } = new User();
        // Contenido poseido por el Usuario.
        public UserContent UserContent { get; set; } = new UserContent();

        public UserViewModel() { }

        public UserViewModel(User user, UserContent userContent)
        {
            User = user;
            UserContent = userContent;
        }
    }

    

}
