using Microsoft.AspNetCore.Mvc;
using PortfolioWeb.Models;
using System.Linq;

namespace PortfolioWeb.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactDbContext _contactdbcontext;

        public ContactController(ContactDbContext contactdbcontext)
        {
            contactdbcontext = _contactdbcontext;

        }
        public IActionResult GetData()
        {
            IEnumerable<Contact> contactList = _contactdbcontext.Contacts;
            return Json(contactList);
           
        }
        
    }
}
