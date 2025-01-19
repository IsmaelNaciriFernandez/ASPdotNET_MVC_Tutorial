using Microsoft.AspNetCore.Mvc;
using ASPdotNET_MVC_Tutorial.Models;

namespace ASPdotNET_MVC_Tutorial.Controllers
{
    public class ItemsController : Controller
    {
        public IActionResult Overview()
        {
            var item = new Item() { Name = "Razer Keyboard" };
            return View(item);
        }

        public IActionResult Edit(int id)
        {
            return Content($"Id: {id}");
        }

    }
}
