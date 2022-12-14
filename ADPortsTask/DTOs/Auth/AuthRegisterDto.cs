using System.ComponentModel.DataAnnotations;

namespace ADPortsTask.DTOs
{
    public class AuthRegisterDto : AuthLoginDto
    {
        public virtual string UserName { get; set; }
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public virtual string ConfirmPassword { get; set; }
    }
}
