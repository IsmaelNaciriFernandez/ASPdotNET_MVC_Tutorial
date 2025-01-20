using Microsoft.AspNetCore.Mvc;
using ASPdotNET_MVC_Tutorial.Models;
using ASPdotNET_MVC_Tutorial.Data;
using Microsoft.EntityFrameworkCore;

namespace ASPdotNET_MVC_Tutorial.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ASPdotNET_MVC_Tutorial_Context _context;

        public ItemsController(ASPdotNET_MVC_Tutorial_Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _context.Item.ToListAsync();
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id, Name, Price")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Item.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(item);
        }

        
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _context.Item.FirstOrDefaultAsync(i => i.Id == id);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Price")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Item.Update(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Item.FirstOrDefaultAsync(i => i.Id == id);
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _context.Item.FirstOrDefaultAsync(i => i.Id == id);
            
            if (item is not null)
            {
                _context.Item.Remove(item);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }


    }
}
