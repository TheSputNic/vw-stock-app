using System;
using System.Collections.Generic;
using System.Text;
using VWStockApp.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace VWStockApp.Services
{
	public class SQLStockRepository : IStockRepository
	{
		private readonly AppDbContext context;
		public SQLStockRepository(AppDbContext _context)
		{
			context = _context;
		}

		public StockItem Add(StockItem newStock)
		{
			context.Add(newStock);
			context.SaveChanges();
			return newStock;
		}

		public StockItem Delete(int id)
		{
			StockItem stockItem = context.StockItem.Find(id);
			if (stockItem != null)
			{
				context.Remove(stockItem);
				context.SaveChanges();
			}
			return stockItem;
		}

		public  IEnumerable<StockItem> GetAllStock()
		{
			return context.StockItem
				.Include(s => s.Make)
				.Include(s => s.CarModel)
					.ThenInclude(m => m.Body)
				.Include(s => s.Colour)
				.Include(s => s.TrimLevel)
					.ThenInclude(t => t.Features)
				.AsNoTracking();
		}

		public StockItem GetStock(int id)
		{
			return context.StockItem
				.Include(s => s.Make)
				.Include(s => s.CarModel)
				.Include(s => s.Colour)
				.Include(s => s.TrimLevel)
					.ThenInclude(s => s.Features)
				.AsNoTracking()
				.ToList()
				.FirstOrDefault();

			//Using Stored Procedures to get the same return as LINQ
			/*var stockItem = context.StockItem.FromSqlRaw<StockItem>("spGetStockById", id).ToList().First();
			var make = context.Makes.FromSqlRaw<Make>("spGetMakeById", stockItem.MakeID).First();
			var carModel = context.CarModels.FromSqlRaw<CarModel>("spGetModelById", stockItem.CarModelID).First() ;
			var trimLevel = context.TrimLevels.FromSqlRaw<TrimLevel>("spGetTrimById", stockItem.TrimLevelID).First();
			var colour = context.Colours.FromSqlRaw<Colour>("spGetColourById", stockItem.ColourID).First();

			return new StockItem
			{
				ID = stockItem.ID,
				MakeID = stockItem.MakeID,
				CarModelID = stockItem.CarModelID,
				TrimLevelID = stockItem.TrimLevelID,
				ColourID = stockItem.ColourID,
				Make = make,
				CarModel = carModel,
				TrimLevel = trimLevel,
				Colour = colour,
				PriceModifier = stockItem.PriceModifier
			};*/
		}

	public IEnumerable<StockItem> Search(string q)
		{
			return context.StockItem.Where(s => s.Make.Name.Contains(q) ||
												s.CarModel.Name.Contains(q) ||
												s.TrimLevel.Name.Contains(q))
				.Include(s => s.Make)
				.Include(s => s.CarModel)
				.Include(s => s.Colour)
				.Include(s => s.TrimLevel)
					.ThenInclude(s => s.Features)
				.AsNoTracking();
		}

		public StockItem Update(StockItem updatedStock)
		{
			var item = context.StockItem.Attach(updatedStock);
			item.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			context.SaveChanges();
			return updatedStock;
		}

		public IEnumerable<Make> GetMakes()
		{
			var modelsQuery = from m in context.Makes
							  orderby m.Name // Sort by Name
							  select m;
			return modelsQuery.AsNoTracking();
		}

		public IEnumerable<CarModel> GetCarModels()
		{
			var modelsQuery = from m in context.CarModels
							  orderby m.Name // Sort by Name
							  select m;
			return modelsQuery.AsNoTracking();
		}

		public IEnumerable<TrimLevel> GetTrims()
		{
			var trimsQuery = from t in context.TrimLevels
							 orderby t.Name // Sort by Name
							 select t;
			return trimsQuery.AsNoTracking();
		}

		public IEnumerable<CarModel> GetCarModelsByMake(int MakeID)
		{
			var modelsQuery = from m in context.CarModels
							  where (m.MakeID == MakeID)
							  orderby m.Name // Sort by Name
							  select m;
			return modelsQuery.AsNoTracking();
		}

		public IEnumerable<TrimLevel> GetTrimsByModel(int ModelID)
		{
			var trimsQuery = from t in context.TrimLevels
							 where (t.CarModelID == ModelID)
							 orderby t.Name // Sort by Name
							 select t;
			return trimsQuery.AsNoTracking();
		}

		public IEnumerable<Colour> GetColours()
		{
			var coloursQuery = from c in context.Colours
							  orderby c.Name // Sort by Name
							  select c;
			return coloursQuery.AsNoTracking();
		}

		public decimal GetPrice(int TrimID)
		{
			var priceQuery = from t in context.TrimLevels
							 where t.ID == TrimID
							 select t.Price;
			return priceQuery.First();
		}
	}
}
