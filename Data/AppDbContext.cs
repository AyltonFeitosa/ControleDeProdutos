using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControleDeProdutos.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ControleDeProdutos.Models.ProductModel> ProductModel { get; set; } = default!;

public DbSet<ControleDeProdutos.Models.UserModel> UserModel { get; set; } = default!;

public DbSet<ControleDeProdutos.Models.LoginModel> LoginModel { get; set; } = default!;
    }
