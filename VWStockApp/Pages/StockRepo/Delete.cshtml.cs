using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VWStockApp.Data;
using VWStockApp.Models;
using VWStockApp.Services;

namespace VWStockApp.Pages.StockRepo
{
    public class DeleteModel : PageModel
    {
        private readonly IStockRepository stockRepository;

        public DeleteModel(IStockRepository stockRepository)
        {
            this.stockRepository = stockRepository;
        }

        [BindProperty]
        public StockItem StockItem { get; set; }

        public IActionResult OnGet(int id)
        {
            StockItem = stockRepository.GetStock(id);

            if (StockItem == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            StockItem = stockRepository.Delete(id);
            return RedirectToPage("./Index");
        }
    }
}
