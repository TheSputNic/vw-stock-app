using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VWStockApp.Data;
using VWStockApp.Models;
using VWStockApp.Services;

namespace VWStockApp.Pages.StockRepo
{
	public class StockEditPageModel : PageModel
	{
		public SelectList CarMakeSL { get; set; }

		public void PopulateCarMakeSL(IStockRepository stockRepository,
			object selectedMake = null)
		{
			var makesQuery = stockRepository.GetMakes();

			CarMakeSL = new SelectList(makesQuery,
					"MakeID", "Name", selectedMake);
		}

		public SelectList CarModelSL { get; set; }

		public void PopulateCarModelSL(IStockRepository stockRepository,
			object selectedModel = null)
		{
			var modelsQuery = stockRepository.GetCarModels();

			CarModelSL = new SelectList(modelsQuery,
					"ID", "Name", selectedModel);
		}

		public SelectList TrimLevelSL { get; set; }

		public void PopulateTrimLevelSL(IStockRepository stockRepository,
			object selectedTrim = null)
		{
			var trimsQuery = stockRepository.GetTrims();

			TrimLevelSL = new SelectList(trimsQuery,
					"ID", "Name", selectedTrim);
		}
		
		public int Price { get; set; }

		public void PopulatePrice(IStockRepository stockRepository, int? TrimID)
		{
			if (TrimID != null)
			{
				Price = (int)stockRepository.GetPrice((int)TrimID);
			}
		}

		public SelectList ColourSL { get; set; }

		public void PopulateColourSL(IStockRepository stockRepository,
			object selectedColour = null)
		{
			var coloursQuery = stockRepository.GetColours();

			ColourSL = new SelectList(coloursQuery,
					"ID", "Name", selectedColour);
		}
	}
}
