using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VWStockApp.Models;
using VWStockApp.Services;

namespace VWStockApp.Pages.StockRepo
{
    public class IndexModel : PageModel
    {
        private readonly IStockRepository stockRepository;

        public IEnumerable<StockItem> StockItems { get; set; }

        [BindProperty(SupportsGet = true)]
        public string q { get; set; }

        public IndexModel(IStockRepository stockRepository)
        {
            this.stockRepository = stockRepository;
        }

        public void OnGet()
        {
            if (string.IsNullOrEmpty(q))
			{
                StockItems = stockRepository.GetAllStock();
            }
			else
			{
                StockItems = stockRepository.Search(q);
            }
        }

        /*public JsonResult OnGet()
		{
            StockItems = stockRepository.GetAllStock();
            return new JsonResult(StockItems);
		}*/
    }
}
