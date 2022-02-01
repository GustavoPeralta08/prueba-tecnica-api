using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wheelzy.Data.Repository.Interfaces
{
    public interface IUnitWork : IDisposable
    {
        IProductRepository ProductRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
        Task SaveChangesAsync();
    }
}
