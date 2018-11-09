using System;
using System.ComponentModel.DataAnnotations;

namespace Monsterpedia.Models
{
    public class Monster
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public Skill Skill { get; set; }

        public DateTime DateAdded { get; set; }

        [Range(1, 5)]
        public byte NumberInStock { get; set; }

    }
}