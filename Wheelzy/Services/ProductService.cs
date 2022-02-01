using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wheelzy.Interfaces;
using Wheelzy.Model.Entites;
using Wheelzy.Data.Repository.Interfaces;

namespace Wheelzy.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitWork _unitWork;

        public ProductService(IUnitWork unitWork)
        {
            _unitWork = unitWork;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            await _unitWork.ProductRepository.Delete(id);
            await _unitWork.SaveChangesAsync();
            return true;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _unitWork.ProductRepository.GetAll();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _unitWork.ProductRepository.GetById(id);
        }

        public async Task InsertProduct(Product product)
        {
            await _unitWork.ProductRepository.Add(product);
            await _unitWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            _unitWork.ProductRepository.Update(product);
            await _unitWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateStatus(int id, bool status)
        {
            var product = await _unitWork.ProductRepository.GetById(id);
            product.Status = status;
            _unitWork.ProductRepository.Update(product);
            await _unitWork.SaveChangesAsync();
            return true;
        }
    }
}
