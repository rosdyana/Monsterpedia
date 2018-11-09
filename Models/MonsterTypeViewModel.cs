using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Monsterpedia.Models
{
    public class MonsterTypeViewModel
    {
        public List<Monster> Monsters;
        public SelectList Types;
        public string MonsterType { get; set; }
        public string SearchString { get; set; }
    }
}