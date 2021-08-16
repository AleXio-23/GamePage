using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Application.Games.Models
{
    public class VwGameCategoriesDTO
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int GameId { get; set; }

        public string GameName { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
        public string GameUrl { get; set; }
    }
}
