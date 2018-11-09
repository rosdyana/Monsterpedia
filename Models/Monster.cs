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
        public string Description { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Monster Type")]
        public string Type { get; set; }

        [Display(Name = "Date Added")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateAdded { get; set; }

    }
}