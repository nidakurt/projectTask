using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTask.Core.Models;
using ProjectTask.Data.Data;
using ProjectTask.Services.Core;

namespace ProjectTask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ProductManager _productManager;

        public ProductController(DataContext context)
        {
            _context = context;
            _productManager = new ProductManager(context);
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts(int categoryId)
        {
            if(categoryId == 0)
            {
                return BadRequest("Kategori Bulunamadı!");
            }
            return Ok(await _productManager.GetProductsAsync(categoryId));
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> CreateProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest("Ürün Bulunamadı!");
            }
            return Ok(await _productManager.CreateProductAsync(product));
        }

        [HttpPut]
        public async Task<ActionResult<List<Product>>> UpdateProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest("Ürün Bulunamadı!");
            }
            return Ok(await _productManager.UpdateProductAsync(product));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Product>>> DeleteProducto(int id)
        {
            if (id == 0)
            {
                return BadRequest("Ürün Bulunamadı!");
            }
            return Ok(await _productManager.DeleteProductAsync(id));
        }
    }
}
