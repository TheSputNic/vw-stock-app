using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using VWStockApp.Models;

namespace VWStockApp.Services
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
		{
		}

			public DbSet<Make> Makes { get; set; }
			public DbSet<CarModel> CarModels { get; set; }
			public DbSet<Body> Bodies { get; set; }
			public DbSet<Colour> Colours { get; set; }
			public DbSet<TrimLevel> TrimLevels { get; set; }
			public DbSet<Feature> Features { get; set; }
			public DbSet<StockItem> StockItem { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Make>().ToTable("Makes");
			modelBuilder.Entity<CarModel>().ToTable("CarModels");
			modelBuilder.Entity<Body>().ToTable("Bodies");
			modelBuilder.Entity<Colour>().ToTable("Colours");
			modelBuilder.Entity<TrimLevel>().ToTable("TrimLevels");
			modelBuilder.Entity<Feature>().ToTable("Features");
		}
	}
}
