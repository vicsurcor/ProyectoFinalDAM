namespace Proyecto.Models.User
{
    public class SaveFile
    {
        public int Id { get; set; } = 1;
        public string Name { get; set; } = "TestSave.Json";
        public string Content { get; set; } = "";
        public DateTime SaveTime { get; set; } = DateTime.Now;

    }
}
