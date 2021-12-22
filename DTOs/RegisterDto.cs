using System.ComponentModel.DataAnnotations;

namespace ASP.NETCoreWebApplication.DTOs
{
    public class RegisterDto
    {
        [Required] public string UserName { get; set; }

        [Required] public string Password { get; set; }
    }
}