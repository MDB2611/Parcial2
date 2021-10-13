using Lucky_DannyMarceloDávilaBarrancos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lucky_DannyMarceloDávilaBarrancos.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Lucky> Lucky { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
