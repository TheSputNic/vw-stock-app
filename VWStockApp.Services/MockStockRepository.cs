using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VWStockApp.Models;

namespace VWStockApp.Services
{
	public class MockStockRepository //: IStockRepository
	{
		private List<StockItem> _stockList;

		public MockStockRepository()
		{
			_stockList = new List<StockItem>()
			{
				new StockItem()
				{
					MakeID = 1,
					CarModelID = 1,
					TrimLevelID = 1,
					ColourID =1
				},
				new StockItem()
				{
					MakeID = 1,
					CarModelID = 1,
					TrimLevelID = 2,
					ColourID =2
				},
				new StockItem()
				{
					MakeID = 1,
					CarModelID = 1,
					TrimLevelID = 2,
					ColourID =3
				},
				new StockItem()
				{
					MakeID = 1,
					CarModelID = 1,
					TrimLevelID = 2,
					ColourID =4
				}
			};
		}

		public StockItem Add(StockItem newStock)
		{
			throw new NotImplementedException();
		}

		public StockItem Delete(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<StockItem> GetAllStock()
		{
			return _stockList;
		}

		public StockItem GetStock(int id)
		{
			return _stockList.FirstOrDefault(s => s.ID == id);
		}

		public StockItem Update(StockItem updatedStock)
		{
			StockItem stockItem = _stockList.FirstOrDefault(s => s.ID == updatedStock.ID);
			if (stockItem != null)
			{
				stockItem.MakeID = updatedStock.MakeID;
				stockItem.CarModelID = updatedStock.CarModelID;
				stockItem.ColourID = updatedStock.ColourID;
				stockItem.TrimLevelID = updatedStock.TrimLevelID;
				stockItem.PriceModifier = updatedStock.PriceModifier;
			}
			return stockItem;
		}
	}
}
