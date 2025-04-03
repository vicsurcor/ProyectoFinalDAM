using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models.User
{
    public class UserRole
    {
        [Required]
        public required string Name { get; set; }

        public static IEnumerable<UserRole> GetUserRoles()
        {
            yield return new UserRole { Name = "Admin" };
            yield return new UserRole { Name = "Client" };
        }

        public static UserRole GetUserRole(string name)
        {
            
            return (name != null) ? GetUserRoles().FirstOrDefault(ur => ur.Name == name): throw new ArgumentException("User role is invalid or null");
            
        }
    }
}
