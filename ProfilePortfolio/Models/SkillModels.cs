namespace ProfilePortfolio.Models
{
    public class CreateUpdateSkillModel
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int LevelId { get; set; }
        public bool Enabled { get; set; }
    }
}
