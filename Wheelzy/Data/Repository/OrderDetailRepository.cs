using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wheelzy.Context;
using Wheelzy.Data.Repository.Interfaces;
using Wheelzy.Model.Entites;

namespace Wheelzy.Data.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly WheelzyDbContext _context;
        protected readonly DbSet<OrderDetail> _entities;
        public OrderDetailRepository(WheelzyDbContext context)
        {
            _context = context;
            _entities = context.Set<OrderDetail>();
        }

        public async Task Add(OrderDetail entity)
        {
            await _entities.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            OrderDetail entity = await GetById(id);
            _entities.Remove(entity);
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            return _entities.ToList();
        }

        public async Task<OrderDetail> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public List<OrderDetail> GetByOrder(int orderId)
        {
            return _entities.Where(x => x.OrderId == orderId).ToList();
        }

        public void Update(OrderDetail entity)
        {
            _entities.Update(entity);
        }

    }
}
