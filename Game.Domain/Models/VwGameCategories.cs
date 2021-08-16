using Game.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Domain.Models
{
    public class VwGameCategories: BaseEntity<int>
    {
        public int CategoryId { get; set; }
        public int GameId { get; set; }

        public string GameName { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
        public string GameUrl { get; set; }
    }
}
