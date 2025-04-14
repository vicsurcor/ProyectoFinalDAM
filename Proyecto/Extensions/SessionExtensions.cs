using Newtonsoft.Json;

namespace Proyecto.Extensions
{
    // Clase de Extension para autorizacion.
    public static class SessionExtensions
    {
        // Guarda el Usuario en la sesion mientras este este loggeado.
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        // Accede al Usuario guardado en la sesion.
        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
