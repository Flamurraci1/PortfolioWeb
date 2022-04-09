using System.ComponentModel.DataAnnotations;

namespace PortfolioWeb.Models
{
    public class ContactForm
    {
        [Required]
        public string PersonName { get; set; }
       [Required]
       [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Message { get; set; }


    }
}
