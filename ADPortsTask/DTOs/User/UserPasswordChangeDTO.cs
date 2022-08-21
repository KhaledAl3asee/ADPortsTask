using System.ComponentModel.DataAnnotations;

namespace ADPortsTask.DTOs
{
    public class UserPasswordChangeDTO : UserNewPasswordDto
    {
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
    }
}
