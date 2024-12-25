using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ANGEL.Models;
using ANGEL_Store.Data;
using ANGEL_Store.Models;
using System.Security.Claims;
//using ANGEL_Store.Data.Migrations;

namespace ANGEL_Store.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ItemsController : Controller
    {
        
        private readonly ApplicationDbContext _context;

        public ItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

       

        public async Task<IActionResult> Index()
        {

            var applicationDbContext = await _context.Items.Include(i => i.category).Where(i => i.ItemStatus == true).Where(m=>m.NumOfProducts > 0).ToListAsync();
            return View(applicationDbContext);
        }
        [HttpGet]

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }
            var clients = await _context.Items
                .FirstOrDefaultAsync(m => m.ItemId == id);

            if (clients == null || clients.ItemStatus == false)
            {
                return NotFound();
            }
            if(clients.NumOfProducts <= 10)
            {
                ViewBag.NumOfProducts = "Only " + clients.NumOfProducts + " left in stock";
            }

            return View(clients);
        }
        [HttpPost]
        public async Task<IActionResult> Details(int id, Item item)

        {
            var items = await _context.Items.FindAsync(id);


            if (item.ItemStatus != false)
            {
                return NotFound();
            }

            items.SelectedColor = item.SelectedColor;
            items.SelectedSize = item.SelectedSize;
            items.ItemQuantity = item.ItemQuantity;

            if (items.ItemQuantity > items.NumOfProducts) 
            {
                
                ViewBag.INstockError = "sorry, but the number of pieces required is greater than what is available";
                return View(items);
            }

            if(items.ItemQuantity <= 0)
            {
                
                ViewBag.Message = "Please enter positive Number in Item Quantity";
                return View(items);
            }


            if (id != item.ItemId)
            {
                return NotFound();
            }
            else
            {
                return RedirectToAction("AddToCart", "CardPros", items);
            }
        }

    }
}
