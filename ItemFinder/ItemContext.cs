using System;
using ItemFinder.Models;
using Microsoft.EntityFrameworkCore;

namespace ItemFinder
{
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> options) : base(options)
        {
            Console.WriteLine("Context created");
        }

        public DbSet<ItemEntity> ItemEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Console.WriteLine("OnModelCreating");
        }
    }
}