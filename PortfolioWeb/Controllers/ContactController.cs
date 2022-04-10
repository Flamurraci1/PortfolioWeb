using Microsoft.AspNetCore.Mvc;
using PortfolioWeb.Data;
using PortfolioWeb.Models;
using System.Linq;

namespace PortfolioWeb.Controllers
{
    public class ContactController : Controller
    {
        private readonly ProjectDbContext _ProjectDbcontext;

        public ContactController(ProjectDbContext projectdbcontext)
        {
            _ProjectDbcontext = projectdbcontext;

        }
        public IActionResult GetMyData()
        {
            IEnumerable<Contact> contactList = _ProjectDbcontext.Contacts.ToList();
            return Json(contactList);
           
        }
        
    }
}
