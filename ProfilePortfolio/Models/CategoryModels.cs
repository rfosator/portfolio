using System.ComponentModel.DataAnnotations;

namespace ProfilePortfolio.Models
{
    public class CreateCategoryModel
    {
        [Required]
        public string Name { get; set; }
        public bool Enabled { get; set; }
    }
}
