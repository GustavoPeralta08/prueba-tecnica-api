using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wheelzy.Model.Entites;

namespace Wheelzy.Data.Repository.Interfaces
{
    public interface IOrderDetailRepository : IRepositoryBase<OrderDetail>
    {
        List<OrderDetail> GetByOrder(int orderId);
    }
}
