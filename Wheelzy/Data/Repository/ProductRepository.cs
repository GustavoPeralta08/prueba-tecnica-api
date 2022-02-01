using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wheelzy.Context;
using Wheelzy.Model.Entites;
using Wheelzy.Data.Repository.Interfaces;

namespace Wheelzy.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly WheelzyDbContext _context;
        protected readonly DbSet<Product> _entities;
        public ProductRepository(WheelzyDbContext context){
            _context = context;
            _entities = context.Set<Product>();
        }

        public async Task Add(Product entity)
        {
            await _entities.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            Product entity = await GetById(id);
            _entities.Remove(entity);
        }

        public IEnumerable<Product> GetAll()
        {
            return _entities.ToList();
        }

        public async Task<Product> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public  void Update(Product entity)
        {
            _entities.Update(entity);
        }
    }
}
