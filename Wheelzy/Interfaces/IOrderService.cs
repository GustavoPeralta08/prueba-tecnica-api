using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wheelzy.Model.DTO;
using Wheelzy.Model.Entites;

namespace Wheelzy.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders();

        Task<Order> GetOrder(int id);

        Task InsertOrder(Order product);

        Task<bool> UpdateOrder(Order post);

        Task<bool> DeleteOrder(int id);

        Task InsertOrderDetail(int orderId, List<OrderDetail> orderDetails);
        IEnumerable<OrderWithDetail> GetOrdersWithDetail();
    }
}
