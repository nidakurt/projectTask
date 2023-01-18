using Microsoft.EntityFrameworkCore;
using ProjectTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTask.Data.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Category> Category => Set<Category>();
        public DbSet<Product> Product => Set<Product>();
    }
}
