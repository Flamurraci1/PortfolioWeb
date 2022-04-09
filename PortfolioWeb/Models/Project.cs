using Microsoft.EntityFrameworkCore;

namespace PortfolioWeb.Models
{
    [Keyless]
    public class Project
    {
        
        public string Name { get; set; }
        public string ImgName { get; set; }

        public string Description { get; set; }
    }
}
