using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wheelzy.Context;
using Wheelzy.Data.Repository.Interfaces;

namespace Wheelzy.Data.Repository
{
    public class UnitWork : IUnitWork
    {
        private readonly WheelzyDbContext _context;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public UnitWork(WheelzyDbContext context)
        {
            _context = context;
        }
        public IProductRepository ProductRepository => _productRepository ?? new ProductRepository(_context);
        public IOrderRepository OrderRepository => _orderRepository ?? new OrderRepository(_context);
        public IOrderDetailRepository OrderDetailRepository => _orderDetailRepository ?? new OrderDetailRepository(_context);
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
