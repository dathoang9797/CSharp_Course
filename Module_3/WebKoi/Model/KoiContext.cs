﻿using Microsoft.EntityFrameworkCore;
using WebKoi.Models;

namespace WebKoi.Model;

public class KoiContext : DbContext
{
    public KoiContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Customer> Customer { get; set; }
    public DbSet<Business> Business { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<NumberOfOrder> NumberOfOrders { get; set; }
    public DbSet<Article> Article { get; set; }
    public DbSet<Member> Member { get; set; }
    public DbSet<Invoice> Invoice { get; set; }
    public DbSet<Status> Status { get; set; }
    public DbSet<Recommend> Recommend { get; set; }

    public DbSet<InvoiceDetail> InvoiceDetail { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<InvoiceDetail>(p => p.HasKey(q => new { q.InvoiceId, q.ProductId }));
    }
}