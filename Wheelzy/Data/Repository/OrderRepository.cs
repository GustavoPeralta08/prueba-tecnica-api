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
    public class OrderRepository : IOrderRepository
    {
        private readonly WheelzyDbContext _context;
        protected readonly DbSet<Order> _entities;
        public OrderRepository(WheelzyDbContext context)
        {
            _context = context;
            _entities = context.Set<Order>();
        }

        public async Task Add(Order entity)
        {
            await _entities.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            Order entity = await GetById(id);
            _entities.Remove(entity);
        }

        public IEnumerable<Order> GetAll()
        {
            return _entities.ToList();
        }

        public async Task<Order> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public void Update(Order entity)
        {
            _entities.Update(entity);
        }
    }
}
