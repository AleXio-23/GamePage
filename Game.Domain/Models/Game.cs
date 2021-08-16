using Game.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Domain.Models
{
    public partial class Game: BaseEntity<int>
    {
        public Game()
        {
            GameCategories = new HashSet<GameCategory>();
        }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string GameUrl { get; set; }

        public virtual ICollection<GameCategory> GameCategories { get; set; }
    }
}
