using Proyecto.Models.User;

namespace Proyecto.Extra
{
    // Clase para la Inicializacion de los Id de la api.
    public static class InitializeId
    {
        // Id Contenido de Usuario.
        public static int InitializeUserContentIds()
        {
            
            List<UserContent> users = JsonMethods.GetJsonUserContents();
            Console.WriteLine(users.Count);
            return users.Count + 1;
        }
        // Id Archivos de guardado.
        public static int InitializeSaveFileIds()
        {
            List<UserContent> users = JsonMethods.GetJsonUserContents();
            int maxId = 0;
            foreach (var user in users)
            {
                if (user.Saves.Count > maxId)
                {
                    maxId = user.Saves.Count;
                }
            }
            return maxId + 1;
        }
        // Id Usuario
        public static int InitializeUserIds()
        {
            List<UserContent> users = JsonMethods.GetJsonUserContents();
            int maxId = 0;
            foreach (var user in users)
            {
                if (user.User.Id > maxId)
                {
                    maxId = user.User.Id;
                }
            }
            return maxId + 1;
        }
    }
        
}
