using System.ComponentModel.DataAnnotations;

namespace CalamariBlog.Models.ServiceModels
{
    public class SendContactEmailRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public string MobileNumber { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
