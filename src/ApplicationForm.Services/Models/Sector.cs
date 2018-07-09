namespace ApplicationForm.Services.Models
{
    /// <summary>
    /// Represents a Sector.
    /// </summary>
    public class Sector
    {
        public Sector(int id)
        {
            Id = id;
        }

        public int Id { get; }

        public int Value { get; set; }

        public string Title { get; set; }

        public int Level { get; set; }
    }
}
