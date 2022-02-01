using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wheelzy.Data.Repository.Interfaces;
using Wheelzy.Interfaces;
using Wheelzy.Model.DTO;
using Wheelzy.Model.Entites;

namespace Wheelzy.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitWork _unitWork;

        public OrderService(IUnitWork unitWork)
        {
            _unitWork = unitWork;
        }

        public async Task<bool> DeleteOrder(int id)
        {
            await _unitWork.OrderRepository.Delete(id);
            await _unitWork.SaveChangesAsync();
            return true;
        }

        public async Task<Order> GetOrder(int id)
        {
            return await _unitWork.OrderRepository.GetById(id);
        }

        public IEnumerable<Order> GetOrders()
        {
            return _unitWork.OrderRepository.GetAll();
        }

        public IEnumerable<OrderWithDetail> GetOrdersWithDetail()
        {
            List<OrderWithDetail> orderWithDetails = new List<OrderWithDetail>();

            var orders = _unitWork.OrderRepository.GetAll();
            foreach (var item in orders)
            {
                OrderWithDetail newOrderWithDetail = new OrderWithDetail();
                newOrderWithDetail.OrderId = item.OrderId;
                newOrderWithDetail.DateOrder = item.DateOrder;
                newOrderWithDetail.CantProduct = item.CantProduct;
                newOrderWithDetail.TotalAmount = item.TotalAmount;

                var details = _unitWork.OrderDetailRepository.GetByOrder(item.OrderId);
                newOrderWithDetail.OrderDetail = details;

                orderWithDetails.Add(newOrderWithDetail);

            }

            return orderWithDetails;
        }

        public async Task InsertOrder(Order order)
        {
            await _unitWork.OrderRepository.Add(order);
            await _unitWork.SaveChangesAsync();
        }

        public async Task InsertOrderDetail(int orderId, List<OrderDetail> orderDetails)
        {
            foreach(OrderDetail item in orderDetails)
            {
                item.OrderId = orderId;
                await _unitWork.OrderDetailRepository.Add(item);
                await _unitWork.SaveChangesAsync();
            }
            
            
        }

        public async Task<bool> UpdateOrder(Order order)
        {
            _unitWork.OrderRepository.Update(order);
            await _unitWork.SaveChangesAsync();
            return true;
        }
    }
}
