using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorProject.Shared;

    public class BlazorProjectAPIDbContext : DbContext
    {
        public BlazorProjectAPIDbContext (DbContextOptions<BlazorProjectAPIDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
    }
