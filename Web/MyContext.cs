﻿using Microsoft.EntityFrameworkCore;
using Web.Models;

public class MyContext:DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<TotalProduct> Variants { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        optionsBuilder.UseMySQL("server=mysqlstudenti.litv.sssvt.cz;database=4c2_grisadaniel_db1;user=grisadaniel;password=123456;SslMode=none");
    }
}