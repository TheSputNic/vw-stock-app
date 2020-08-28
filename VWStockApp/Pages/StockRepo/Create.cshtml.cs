using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VWStockApp.Data;
using VWStockApp.Models;
using VWStockApp.Services;

namespace VWStockApp.Pages.StockRepo
{
    public class CreateModel : StockEditPageModel
    {
        private readonly IStockRepository stockRepository;
        public CreateModel(IStockRepository stockRepository)
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

        public IActionResult OnGet()
        {
            PopulateCarMakeSL(stockRepository);
            PopulateColourSL(stockRepository);
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
            stockRepository.Add(StockItem);
            return RedirectToPage("./Index");
        }
    }
}
