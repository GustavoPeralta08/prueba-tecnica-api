using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wheelzy.Model.Entites;

namespace Wheelzy.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();

        Task<Product> GetProduct(int id);

        Task InsertProduct(Product product);

        Task<bool> UpdateProduct(Product post);

        Task<bool> UpdateStatus(int id, bool status);

        Task<bool> DeleteProduct(int id);
    }
}
