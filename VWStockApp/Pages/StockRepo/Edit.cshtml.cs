using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using VWStockApp.Models;
using VWStockApp.Services;

namespace VWStockApp.Pages.StockRepo
{
    public class EditModel : StockEditPageModel
    {
        private readonly IStockRepository stockRepository;

        public EditModel(IStockRepository stockRepository)
		{
            this.stockRepository = stockRepository;
		}

        [BindProperty]
        public StockItem StockItem { get; set; }
        [BindProperty(SupportsGet = true)]
        public int MakeID { get; set; }
        [BindProperty(SupportsGet = true)]
        public int ModelID { get; set; }
        [BindProperty(SupportsGet = true)]
        public int TrimID { get; set; }

        public IActionResult OnGet(int id)
        {
            StockItem = stockRepository.GetStock(id);

            if (StockItem == null)
			{
                return RedirectToPage("/NotFound");
			}

            //Prepopulate SelectLists for selected stock item
            PopulateCarMakeSL(stockRepository, StockItem.MakeID);
            PopulateCarModelSL(stockRepository, StockItem.CarModelID);
            PopulateTrimLevelSL(stockRepository, StockItem.TrimLevelID);
            PopulateColourSL(stockRepository, StockItem.ColourID);
            PopulatePrice(stockRepository, StockItem.TrimLevelID);
            return Page();
        }

        public JsonResult OnGetModels()
        {
            return new JsonResult(stockRepository.GetCarModelsByMake(MakeID));
        }

        public JsonResult OnGetTrims()
        {
            return new JsonResult(stockRepository.GetTrimsByModel(ModelID));
        }

        public JsonResult OnGetPrice()
        {
            return new JsonResult(stockRepository.GetPrice(TrimID));
        }

        public IActionResult OnPost()
		{
            stockRepository.Update(StockItem);
            return RedirectToPage("Index");
		}
    }
}
