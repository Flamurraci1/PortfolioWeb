using Microsoft.EntityFrameworkCore;

namespace PortfolioWeb.Models
{

    [Keyless]
    public class Contact
    {
        public string Address { get; set; }
        public string Twitter { get; set; }
        public string Email { get; set; }

    }
}
