using System.ComponentModel;

namespace WebAppChat.Model;

public class Login
{
    [DisplayName("Email")] public string Eml { get; set; }
    [DisplayName("Password")] public string Pwd { get; set; }
    [DisplayName("Rem")] public bool Remember { get; set; }
}