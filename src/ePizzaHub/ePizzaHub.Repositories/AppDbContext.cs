﻿using System;
using ePizzaHub.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ePizzaHub.Repositories
{
	public class AppDbContext : IdentityDbContext<User, Role, int>
	{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

		public DbSet<Category> Categories { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<ItemType> ItemTypes { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<PaymentDetails> PaymentDetails { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder
            //        .UseSqlServer(@"data source=localhost; initial catalog=ePizzaHub;
            //            user id=sa; password=Test@1@2;");
            //}

            base.OnConfiguring(optionsBuilder);
        }
    }
}

