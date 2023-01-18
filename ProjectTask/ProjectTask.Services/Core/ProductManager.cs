using Microsoft.EntityFrameworkCore;
using ProjectTask.Core.Models;
using ProjectTask.Data.Data;
using ProjectTask.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTask.Services.Core
{
    public class ProductManager : IProductManager
    {
        private readonly DataContext _context;

        public ProductManager(
            DataContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> CreateProductAsync(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return await _context.Product.ToListAsync();
        }

        public async Task<List<Product>> DeleteProductAsync(int productId)
        {
            var dbProduct = await _context.Product.FindAsync(productId);

            _context.Product.Remove(dbProduct);
            await _context.SaveChangesAsync();

            return await _context.Product.ToListAsync();
        }

        public Task<List<Product>> GetProductsAsync(int categoryId)
        {
            return _context.Product.Where(x => x.CategoryId == categoryId).ToListAsync();
        }

        public async Task<List<Product>> UpdateProductAsync(Product product)
        {
            var dbProduct = await _context.Product.FindAsync(product.Id);

            dbProduct.Name = product.Name;

            await _context.SaveChangesAsync();

            return await _context.Product.ToListAsync();
        }
    }
}
