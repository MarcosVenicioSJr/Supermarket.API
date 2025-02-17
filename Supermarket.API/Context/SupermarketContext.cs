﻿using Microsoft.EntityFrameworkCore;
using Supermarket.API.Entities;

namespace Supermarket.API.Context
{
    public class SupermarketContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public SupermarketContext(DbContextOptions<SupermarketContext> options) : base(options)
        {
        }
    }
}
