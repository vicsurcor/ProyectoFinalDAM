namespace Proyecto.Models.User
{
    public class UserContent
    {
        public int Id { get; set; }
        public string SaveName { get; set; }
        public DateTime TimePlayed { get; set; }
        public int EnemiesDefeated { get; set; }
        public int LevelsCleared { get; set; }
        public int CharacterLevel { get; set; }
        public int Deaths {  get; set; }
    }
}
