using ProjectTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTask.Services.Abstract
{
    public interface IProductManager
    {
        Task<List<Product>> GetProductsAsync(int categoryId);
        Task<List<Product>> CreateProductAsync(Product product);
        Task<List<Product>> UpdateProductAsync(Product product);
        Task<List<Product>> DeleteProductAsync(int productId);
    }
}
