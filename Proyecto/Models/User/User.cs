namespace Proyecto.Models.User
{
    public class User
    {
        public int Id { get; set; } = 1;
        public string UserName { get; set; } = "TestUser";
        public string UserEmail { get; set; } = "TestUserEmail@test.com";
        public string Password { get; set; } = "TestPassword";
        public UserRole UserRole { get; set; } = UserRole.GetUserRole("Client");
    }
}
