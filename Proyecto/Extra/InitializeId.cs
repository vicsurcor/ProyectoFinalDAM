using Proyecto.Models.User;

namespace Proyecto.Extra
{
    public static class InitializeId
    {
        
        public static int InitializeIds()
        {
            
            List<UserContent> users = JsonMethods.GetJsonUserContents();
            Console.WriteLine(users.Count);
            return users.Count + 1;
        }

    }
        
}
