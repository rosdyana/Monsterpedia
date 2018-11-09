using System.ComponentModel.DataAnnotations;

namespace Monsterpedia.Models
{
    public class Skill
    {
        public byte Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}