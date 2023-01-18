using ProjectTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTask.Services.Abstract
{
    public interface ICategoryManager
    {
        Task<List<Category>> GetCategoryAsync();
        Task<List<Category>> CreateCategoryAsync(Category category);
        Task<List<Category>> UpdateCategoryAsync(Category category);
        Task<List<Category>> DeleteCategoryAsync(int categoryId);

    }
}
