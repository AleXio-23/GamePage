using Game.Domain.Shared;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Game.Application.Interfaces.Persistance
{
    public interface IRepository<T, I>: IDisposable where T: BaseEntity<I>
    {

        bool Changed();
        int Save();
        Task<int> SaveAsync();


        // ყველა ობიექტის წამოღება
        IQueryable<T> All();

        // ახალი ობიექტის შექმნა
        T Add(T createObject);

        // წაშლა პირობის გათვალისწინებით
        void Delete(T deleteObject);


        // ობიექტის წაშლა
        void Delete(I id);


        T GetById(I id);

        void Update(T updateObject);






    }
}
