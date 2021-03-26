using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        [HttpGet]
        public IActionResult RsvpForm() => View();

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse) {
            if(ModelState.IsValid)
            {
                Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }
            return View();
        }

        public ViewResult ListResponses() {
            return View(Repository.Responses.Where(r => r.WillAttend == true));
        }
    }
}
