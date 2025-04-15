

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
        public double TimePlayed { get; set; } = 0;
        // Enemigos derrotados por el Usuario.
        public int EnemiesDefeated { get; set; } = 0;
        // Niveles superados por el Usuario.
        public int LevelsCleared { get; set; } = 0;
        // Nivel actual del Usuario.
        public int CharacterLevel { get; set; } = 0;
        // Muertes totales del Usuario.
        public int Deaths { get; set; } = 0;
        // Momento en el que el Usuario jugo al juego por primera vez.
        public DateTime FirstPlayed { get; set; } = DateTime.MinValue;
        // Ultimo momento de juego del Usuario.
        public DateTime LastPlayed { get; set; } = DateTime.MinValue.AddHours(2);

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

        public UserContent(double timePlayed, int enemiesDefeated, int levelsCleared, int characterLevel, int deaths, DateTime firstPlayed, DateTime lastPlayed)
        {
            TimePlayed = timePlayed;
            EnemiesDefeated = enemiesDefeated;
            LevelsCleared = levelsCleared;
            CharacterLevel = characterLevel;
            Deaths = deaths;
            FirstPlayed = firstPlayed;
            LastPlayed = lastPlayed;
        }

        //private struct SaveContent
        //{
        //    // Tiempo jugado del Usuario.
        //    public double TimePlayed;
        //    // Enemigos derrotados por el Usuario.
        //    public int EnemiesDefeated;
        //    // Niveles superados por el Usuario.
        //    public int LevelsCleared;
        //    // Nivel actual del Usuario.
        //    public int CharacterLevel;
        //    // Muertes totales del Usuario.
        //    public int Deaths;
        //    // Momento en el que el Usuario jugo al juego por primera vez.
        //    public DateTime FirstPlayed;
        //    // Ultimo momento de juego del Usuario.
        //    public DateTime LastPlayed;
        //}


        // Metodos Json por si son necesarios.

        public static UserContent UpdateContent(UserContent user)
        {
            List<UserContent> users = JsonMethods.GetJsonUserContents();
            List<SaveFile> saves = users[users.IndexOf(user) + 1].Saves.Values.ToList();
            List<UserContent> newData = new List<UserContent>();
            foreach (var _save in saves)
            {
                newData.Add(user.DeserializeUserContent(_save.GetContent()));
            }
            return CallAddSaveValues(newData);
        }

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
                if (Saves.Count < 3) 
                {
                    foreach (var _save in Saves)
                    {
                        if (_save.Value.Id == save.Id && save.SaveTime > _save.Value.SaveTime)
                        {
                            Saves[_save.Key] = save;
                            return true;
                        }
                    }
                    if (!Saves.ContainsKey(save.Id))
                    {
                        Saves.TryAdd(save.Id, save);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (Saves.Count == 3)
                {
                    SaveFile oldestSave = null;
                    int oldestKey = 0;
                    foreach (var _save in Saves)
                    {
                        if (oldestSave == null || _save.Value.SaveTime < oldestSave.SaveTime)
                        {
                            oldestSave = _save.Value;
                            oldestKey = _save.Key;
                        }
                    }
                    if (oldestKey != 0)
                    {
                        Saves[oldestKey] = save;
                        return true;
                    }
                }
                return false;
                
            }
            else
            {
                throw new NullReferenceException();
            }

        }

        public static UserContent CallAddSaveValues(List<UserContent> users)
        {
            UserContent param1 = users.Count > 0 ? users[0] : new UserContent();
            UserContent param2 = users.Count > 1 ? users[1] : new UserContent();
            UserContent param3 = users.Count > 2 ? users[2] : new UserContent();

            return AddSaveValues(param1, param2, param3);
        }
        public static UserContent AddSaveValues(UserContent content1, UserContent content2, UserContent content3)
        {
            double timePlayed = 0;
            int enemiesDefeated = 0;
            int levelsCleared = 0;
            int characterLevel = 0;
            int deaths = 0;
            DateTime lastPlayed = DateTime.Now;
            List<UserContent> list = [content1,content2,content3];
            foreach (var _user in list)
            {
                timePlayed += _user.TimePlayed;
                enemiesDefeated += _user.EnemiesDefeated;
                levelsCleared += _user.LevelsCleared;
                deaths += _user.Deaths;
                if (characterLevel < _user.CharacterLevel) 
                {
                    characterLevel = _user.CharacterLevel;
                }
                if (lastPlayed < _user.LastPlayed) 
                {
                    lastPlayed = _user.LastPlayed;
                }

            }
            return new UserContent (timePlayed, enemiesDefeated, levelsCleared, characterLevel, deaths, DateTime.MinValue, lastPlayed);
            
            

        }
        #endregion
    }
}
