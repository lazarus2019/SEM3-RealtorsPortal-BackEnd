using System.ComponentModel.DataAnnotations;

namespace NETAPI_SEM3.ViewModel
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string ClientURI { get; set; } = "https://www.facebook.com/";
    }
}
