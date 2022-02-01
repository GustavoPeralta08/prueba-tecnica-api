using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wheelzy.Data.Repository.Interfaces
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        void Update(T entity);
        Task Delete(int id);
    }
}
