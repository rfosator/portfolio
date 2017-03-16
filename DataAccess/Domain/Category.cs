using System.ComponentModel.DataAnnotations;

namespace Data.Domain
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
    }
}
