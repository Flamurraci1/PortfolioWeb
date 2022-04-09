using Microsoft.AspNetCore.Mvc;
using PortfolioWeb.Data;
using PortfolioWeb.Models;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace PortfolioWeb.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration Configuration;
        private readonly ILogger<HomeController> _logger;
        private readonly ProjectDbContext _projectDbContext;
        public HomeController(ILogger<HomeController> logger, ProjectDbContext projectDbContext, IConfiguration _configuration)
        {
            Configuration = _configuration;
            _logger = logger;
           _projectDbContext = projectDbContext;
        }
       [HttpGet]
        public IActionResult Index()
        {
            IEnumerable <Project> objProjectList = _projectDbContext.Projects.ToList();
            return View(objProjectList);
        }

        [HttpPost]
        public IActionResult Index(ContactForm model2)
        {
            //Read SMTP settings from AppSettings.json.
            string host = this.Configuration.GetValue<string>("Smtp:Server");
            int port = this.Configuration.GetValue<int>("Smtp:Port");
            string fromAddress = this.Configuration.GetValue<string>("Smtp:FromAddress");
            string userName = this.Configuration.GetValue<string>("Smtp:UserName");
            string password = this.Configuration.GetValue<string>("Smtp:Password");

            using (MailMessage mm = new MailMessage(fromAddress, "fr58693@ubt-uni.net"))
            {

                mm.Body = "Name: " + model2.PersonName + "<br /><br />Email: " + model2.Email + "<br />" +" Message: "+ model2.Message;
                mm.IsBodyHtml = true;


                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = host;
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential(userName, password);
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = port;
                    smtp.Send(mm);
                    ViewBag.Message="Email has been sent";
                }
            }

            return View();
        }



            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
         public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}