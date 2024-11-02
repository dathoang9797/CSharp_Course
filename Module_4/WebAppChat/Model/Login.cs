using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAppChat.Model;

public class Login
{
    [Required(ErrorMessage = "Required")]
    [DisplayName("Email")]
    public string Eml { get; set; }

    [Required(ErrorMessage = "Required")]
    [DisplayName("Password")]
    public string Pwd { get; set; }

    [DisplayName("Rem")] public bool Remember { get; set; }
}