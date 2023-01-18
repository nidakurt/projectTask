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
    public class CategoryManager : ICategoryManager
    {
        private readonly DataContext _context;

        public CategoryManager(
            DataContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> CreateCategoryAsync(Category category)
        {
            _context.Category.Add(category);
            await _context.SaveChangesAsync();

            return await _context.Category.ToListAsync();
        }

        public async Task<List<Category>> DeleteCategoryAsync(int categoryId)
        {
            var dbCategory = await _context.Category.FindAsync(categoryId);

            _context.Category.Remove(dbCategory);
            await _context.SaveChangesAsync();

            return await _context.Category.ToListAsync();
        }

        public Task<List<Category>> GetCategoryAsync()
        {
            return _context.Category.ToListAsync();
        }

        public async Task<List<Category>> UpdateCategoryAsync(Category category)
        {
            var dbCategory = await _context.Category.FindAsync(category.Id);

            dbCategory.Name = category.Name;

            await _context.SaveChangesAsync();

            return await _context.Category.ToListAsync();

        }
    }
}
