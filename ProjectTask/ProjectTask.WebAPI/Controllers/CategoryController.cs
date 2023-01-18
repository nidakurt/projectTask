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
    public class CategoryController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly CategoryManager _categoryManager;


        public CategoryController(DataContext context)
        {
            _context = context;
            _categoryManager = new CategoryManager(context);

        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            return Ok(await _categoryManager.GetCategoryAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Category>>> CreateCategory(Category category)
        {
            if (category == null)
            {
                return BadRequest("Kategori Bulunamadı!");
            }

            return Ok(await _categoryManager.CreateCategoryAsync(category));
        }

        [HttpPut]
        public async Task<ActionResult<List<Category>>> UpdateCategory(Category category)
        {
            if (category == null)
            {
                return BadRequest("Kategori Bulunamadı!");
            }
            return Ok(await _categoryManager.UpdateCategoryAsync(category));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Category>>> DeleteCategoryo(int id)
        {
            if (id == 0)
            {
                return BadRequest("Kategori Bulunamadı!");
            }
            return Ok(await _categoryManager.DeleteCategoryAsync(id));
        }
    }
}
