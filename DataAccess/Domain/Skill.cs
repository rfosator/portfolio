using Data.Domain;
using System.ComponentModel.DataAnnotations;

namespace Profile.Data.Domain
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int LevelId { get; set; }
        [Required]
        public bool Enabled { get; set; }
                
        public Category Category { get; set; }
    }
}
