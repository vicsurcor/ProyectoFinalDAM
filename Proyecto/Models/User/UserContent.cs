

using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Proyecto.Extra;

namespace Proyecto.Models.User
{
    // Modelo que engloba el contenido del Usuario.
    public class UserContent
    {
        // Ultima id disponible.
        [Newtonsoft.Json.JsonIgnore]
        public static int _LastId = 1;
        // Id del Contenido.
        public int Id { get; set; }
        // Usuario al que pertenece el Contenido.
        public User User { get; set; } = new User();
        //[Newtonsoft.Json.JsonIgnore]
        // Archivos de guardado que posee el Usuario.
        public Dictionary<int, SaveFile> Saves { get; set; } = new Dictionary<int, SaveFile>
        {
            {1, new SaveFile() }
        };
        // Tiempo jugado del Usuario.
        public double TimePlayed { get; set; } = 10.50;
        // Enemigos derrotados por el Usuario.
        public int EnemiesDefeated { get; set; } = 0;
        // Niveles superados por el Usuario.
        public int LevelsCleared { get; set; } = 0;
        // Nivel actual del Usuario.
        public int CharacterLevel { get; set; } = 0;
        // Muertes totales del Usuario.
        public int Deaths { get; set; } = 0;
        // Momento en el que el Usuario jugo al juego por primera vez.
        public DateTime FirstPlayed { get; set; } = DateTime.Now;
        // Ultimo momento de juego del Usuario.
        public DateTime LastPlayed { get; set; } = DateTime.Now.AddHours(2);

        // Recuento de los Ids al crear un nuevo ContenidoUsuario.
        static UserContent() 
        {
            _LastId = InitializeId.InitializeUserContentIds();
        }
        public UserContent() 
        {
            Id = _LastId;
        }
        public UserContent(User user)
        {
            this.User = user;
            Id = _LastId;
        }

        // Metodos Json por si son necesarios.
        #region Json
        public UserContent DeserializeUserContent(string json)
        {
            if (json != null)
            {
                var obj = JsonConvert.DeserializeObject<UserContent>(json);
                Id = obj.Id;
                TimePlayed = obj.TimePlayed;
                EnemiesDefeated = obj.EnemiesDefeated;
                LevelsCleared = obj.LevelsCleared;
                CharacterLevel = obj.CharacterLevel;
                Deaths = obj.Deaths;
                FirstPlayed = obj.FirstPlayed;
                LastPlayed = obj.LastPlayed;
                return obj;
            }
            else
            {
                throw new NullReferenceException();
            }
        }
        public string SerializeUserContent(UserContent user)
        {
            if (user != null)
            {
                return JsonConvert.SerializeObject(user);
            }
            else
            {
                throw new NullReferenceException();
            }
        }
        #endregion

        // Metodos auxiliares.
        #region Aux
        public static string DeconstructTime(double timeInHours)
        {
            int hours = (int)timeInHours;
            double fractionalHours = timeInHours - hours;
            int minutes = (int)(fractionalHours * 60);
            double fractionalMinutes = (fractionalHours * 60) - minutes;
            int seconds = (int)(fractionalMinutes * 60);

            return $"{hours} Hours, {minutes} minutes, {seconds} seconds";
        }

        public bool AddSave(SaveFile save)
        {
            if (save != null)
            {
                if (Saves.TryGetValue(save.Id, out SaveFile _save) && save.SaveTime > _save.SaveTime)
                {
                    Saves[save.Id] = save;
                    return true;
                }
                else if (!Saves.ContainsKey(save.Id))
                {
                    Saves.Add(save.Id, save);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new NullReferenceException();
            }

        }
        #endregion
    }
}
