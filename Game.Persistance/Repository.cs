using Game.Application.Interfaces.Persistance;
using Game.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Game.Persistance
{
    public class Repository<T, I> : IRepository<T, I> where T : BaseEntity<I>
    {
        protected GameDbContext context { get; set; }
        protected DbSet<T> DbSet { get; set; }
        protected IQueryable<T> QueryAble { get; set; }

        public Repository(GameDbContext dbContext)
        {
            context = dbContext;
            DbSet = dbContext.Set<T>();
            QueryAble = DbSet;

        }


        public T Add(T createObject)
        {
            return DbSet.Add(createObject).Entity;
        }

        public IQueryable<T> All()
        {
            return QueryAble;
        }

        public bool Changed()
        {
            return false; // test
        }

        public void Delete(T deleteObject)
        {
            DbSet.Remove(deleteObject);
        }

        public void Delete(I id)
        {
            var ent = DbSet.Find(id);
            if(id == null)
            {
                throw new ArgumentNullException();
            }
            if(ent == null)
            {
                throw new Exception($"Object with id: {id} Not Found!");
            }
            DbSet.Remove(ent);
        }

        public T GetById(I id)
        {
            return DbSet.Find(id);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Update(T updateObject)
        {
            DbSet.Attach(updateObject);
        }

        public void Dispose()
        {
            //test
        }
    }
}
