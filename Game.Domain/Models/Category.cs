using Game.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Domain.Models
{
    public partial class Category: BaseEntity<int>
    {
        public Category()
        {
            GameCategories = new HashSet<GameCategory>();
        }
        public string Name { get; set; }
        public virtual ICollection<GameCategory> GameCategories { get; set; }
    }
}
