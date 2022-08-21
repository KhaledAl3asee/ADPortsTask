using System.ComponentModel.DataAnnotations;

namespace ADPortsTask.DTOs
{
    public class UserNewPasswordDto 
    {
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Compare("NewPassword", ErrorMessage = "Passwords don't match")]
        public string ConfirmNewPassword { get; set; }
    }
}
