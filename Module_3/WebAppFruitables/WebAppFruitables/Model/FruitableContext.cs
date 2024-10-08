﻿using Microsoft.EntityFrameworkCore;
using WebAppFruitables.Model;

namespace WebAppAuthentication.Model;

public class FruitableContext : DbContext
{
    public FruitableContext(DbContextOptions options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Slide> Slide { get; set; }
    public DbSet<Testimonial> Testimonial { get; set; }
    public DbSet<Product> Product { get; set; }

}