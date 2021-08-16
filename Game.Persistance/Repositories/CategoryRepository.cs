using Game.Application.Interfaces.Persistance.Processing;
using Game.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Persistance.Repositories
{
    class CategoryRepository<T, I> : Repository<T, I>, ICategoryRepository<T, I> where T : BaseEntity<I>
    {

        public CategoryRepository(GameDbContext context) : base(context)
        {

        }
    }
}
