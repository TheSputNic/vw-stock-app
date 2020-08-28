using System;
using System.Collections.Generic;
using VWStockApp.Models;

namespace VWStockApp.Services
{
	public interface IStockRepository
	{
		IEnumerable<StockItem> Search(string q);
		IEnumerable<StockItem> GetAllStock();
		StockItem GetStock(int id);
		StockItem Update(StockItem updatedStock);
		StockItem Add(StockItem newStock);
		StockItem Delete(int id);

		IEnumerable<Make> GetMakes();
		IEnumerable<CarModel> GetCarModels();
		IEnumerable<CarModel> GetCarModelsByMake(int MakeID);
		IEnumerable<TrimLevel> GetTrims();
		IEnumerable<TrimLevel> GetTrimsByModel(int ModelID);
		IEnumerable<Colour> GetColours();
		decimal GetPrice(int TrimID);
	}
}
