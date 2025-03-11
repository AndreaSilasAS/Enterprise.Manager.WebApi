using System.ComponentModel.DataAnnotations;

namespace Enterprise.Manager.Library.Entities
{
    public class CompanyEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Exchange { get; set; } = string.Empty;
        [Required]
        public string Ticker { get; set; } = string.Empty;
        [Required]
        public string Isin { get; set; } = string.Empty;    
        public string? Website { get; set; }
    }
}
