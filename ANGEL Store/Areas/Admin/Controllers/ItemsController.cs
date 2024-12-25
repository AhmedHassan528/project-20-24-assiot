using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ANGEL.Models;
using ANGEL_Store.Data;
using NuGet.Packaging.Signing;
using Microsoft.AspNetCore.Authorization;

namespace ANGEL_Store.Areas.Admin.Controllers
{
    [Authorize("AdminRole")]
    [Area("Admin")]
    public class ItemsController : Controller
    {
        // split string to list
        public List<string> wordLists(string ColorSlit)
        {
            string[] ColorArray = ColorSlit.Split(' ');
            List<string> wordList = new List<string>(ColorArray);
            return wordList;
        }

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment hosting;

        public ItemsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            hosting = webHostEnvironment;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Items.Include(i => i.category);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> userView()
        {
            var applicationDbContext = _context.Items.Include(i => i.category);
            return View(await applicationDbContext.ToListAsync());
        }


        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.category)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Items/Create
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Item item)
        {
            // convert string of color to list
            item.Colorlist = wordLists(item.Color);

            // convert string of size to list
            item.Sizelist = wordLists(item.Size);

            // convert string of tag to list
            item.Taglist = wordLists(item.ItemTag);

            // convert string of information to list
            item.Informationlist = wordLists(item.ItemInformation);

            ModelState.Remove("CategoryName");
            ModelState.Remove("ItemImage");
            ModelState.Remove("SelectedColor");
            ModelState.Remove("SelectedSize");


            if (ModelState.IsValid)
            {
                if (item.ImageFile != null)
                {
                    string ImageFolder = Path.Combine(hosting.WebRootPath, "itemImages");
                    string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(item.ImageFile.FileName);
                    string imagePath = Path.Combine(ImageFolder, fileName);
                    item.ImageFile.CopyTo(new FileStream(imagePath, FileMode.Create));
                    item.ItemImage = fileName;

                }

                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", item.CategoryID);
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", item.CategoryID);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Item item)
        {
            // convert string of color to list
            item.Colorlist = wordLists(item.Color);

            // convert string of size to list
            item.Sizelist = wordLists(item.Size);

            // convert string of tag to list
            item.Taglist = wordLists(item.ItemTag);

            // convert string of information to list
            item.Informationlist = wordLists(item.ItemInformation);

            ModelState.Remove("CategoryName");
            ModelState.Remove("ItemImage");
            ModelState.Remove("SelectedColor");
            ModelState.Remove("SelectedSize");

            if (id != item.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (item.ImageFile != null)
                {
                    string ImageFolder = Path.Combine(hosting.WebRootPath, "itemImages");
                    string imagePath = Path.Combine(ImageFolder, item.ImageFile.FileName);
                    item.ImageFile.CopyTo(new FileStream(imagePath, FileMode.Create));
                    item.ItemImage = item.ImageFile.FileName;
                }
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.ItemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", item.CategoryID);
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.category)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.ItemId == id);
        }
    }
}
