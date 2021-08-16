using Game.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Domain.Models
{
    public partial class GameCategory : BaseEntity<int>
    {
        public int CategoryId { get; set; }
        public int GameId { get; set; }

        public virtual Category Category {get ; set;}
        public virtual Game Game {get ; set;}
    }
}
