using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationForm.Data.Entities
{
    [Table("Sector")]
    public class Sector
    {
        [Key]
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public int Value { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Sector> Children { get; set; }

        public virtual ICollection<UserSector> UserSectors { get; set; }

        [ForeignKey("ParentId")]
        public virtual Sector Parent { get; set; }
    }
}
