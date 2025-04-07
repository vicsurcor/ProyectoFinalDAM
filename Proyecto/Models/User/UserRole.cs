using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models.User
{
    public class UserRole
    {
        [Required]
        public string Name { get; set; }

        public UserRole (string name) { Name = name; }

        public static IEnumerable<UserRole> GetUserRoles()
        {
            yield return new UserRole("Admin");
            yield return new UserRole("Client");
        }

        public static UserRole GetUserRole(string name)
        {
            
            return (name != null) ? GetUserRoles().FirstOrDefault(ur => ur.Name == name): throw new ArgumentException("User role is invalid or null");
            
        }
    }
}
