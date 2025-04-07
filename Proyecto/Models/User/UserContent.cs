

using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Proyecto.Models.User
{
    public class UserContent
    {
        public int Id { get; set; } = 1;
        public User User { get; set; } = new User();
        //[Newtonsoft.Json.JsonIgnore]
        public Dictionary<int, SaveFile> Saves { get; set; } = new Dictionary<int, SaveFile>
        {
            {1, new SaveFile() }
        };
        public double TimePlayed { get; set; } = 10.50;
        public int EnemiesDefeated { get; set; } = 0;
        public int LevelsCleared { get; set; } = 0;
        public int CharacterLevel { get; set; } = 0;
        public int Deaths { get; set; } = 0;
        public DateTime FirstPlayed { get; set; } = DateTime.Now;
        public DateTime LastPlayed { get; set; } = DateTime.Now.AddHours(2);

        public UserContent() { }
        public UserContent(User user)
        {
            this.User = user;
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
