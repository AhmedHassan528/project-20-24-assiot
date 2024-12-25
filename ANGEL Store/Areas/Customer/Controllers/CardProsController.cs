using ANGEL.Models;
using ANGEL_Store.Data;
using ANGEL_Store.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace ANGEL_Store.Controllers
{
    
    [Area("Customer")]
    public class CardProsController : Controller
    {
        

        private readonly ApplicationDbContext _context;
        public CardProsController(ApplicationDbContext context)
        {
            _context = context;

        }

        private List<CardPro> GetCards()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var card = (from CardPro in _context.CardPros
                        where CardPro.UserId == userId
                        select new CardPro
                        {

                            CardId = CardPro.CardId,
                            UserId = CardPro.UserId,
                            ItemName = CardPro.ItemName,
                            ItemPrice = (CardPro.ItemPrice * CardPro.QTY),
                            SelectedColor = CardPro.SelectedColor,
                            SelectedSize = CardPro.SelectedSize,
                            QTY = CardPro.QTY,
                            ItemImage = CardPro.ItemImage
                        }).ToList();

            return card;
        }

        public async Task<IActionResult> Index()
        {

            var card = GetCards();
            ViewBag.totalPrice = card.Sum(c => c.ItemPrice);
            return View(card);

        }
        public async Task<IActionResult> AddToCart(Item item)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (item == null || item.ItemStatus == false || userId == null)
            {
                return NotFound();
            }
            var cardPro = new CardPro
            {
                UserId = userId,
                ItemName = item.ItemName,
                ItemPrice = item.ItemPrice,
                SelectedColor = item.SelectedColor,
                SelectedSize = item.SelectedSize,
                ItemImage = item.ItemImage,
                QTY = item.ItemQuantity
            };
            ModelState.Remove("ImageFile");
            if (ModelState.IsValid)
            {
                _context.CardPros.Add(cardPro);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "CardPros");
            }
            else
            {
                return NotFound();
            }
        }



        public async Task<IActionResult> OrderSummary()
        {
            var card = GetCards();
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ViewBag.totalPrice = card.Sum(c => c.ItemPrice);
            var Locations = await _context.Locations.Where(i => i.UserId == userId).ToListAsync();
            ViewBag.Locations = Locations;
            return View(card);
        }

        // POST: Items/Create


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OrderSummary(CardPro card)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var Locations = await _context.Locations.Where(i => i.AddressId == card.SelectedLocationId).Where(i => i.UserId == userId).ToListAsync();

            if (Locations.Count == 0 || card.SelectedPaymentMethod == null)
            {
                return NotFound();
            }
            if(card.SelectedPaymentMethod == "cash on delivery")
            {
                return RedirectToAction("Create", "Order", card);
            }
            else if(card.SelectedPaymentMethod == "credit card")
            {
                return RedirectToAction("FirstStep", "Paymob");
            }

            return RedirectToAction("Index", "Order");

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Card = await _context.CardPros
                .Include(i => i.item)
                .FirstOrDefaultAsync(m => m.CardId == id);
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == Card.UserId)
            {
                _context.CardPros.Remove(Card);
                await _context.SaveChangesAsync();

            }
            return RedirectToAction(nameof(Index));
        }



    }
}
