using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FASHOP.DAL.Models;
namespace FASHOP.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Models.Category> Categories { get; set; }
        public DbSet<Models.CategoryTranslation> CategoryTranslations { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
