using System.ComponentModel.DataAnnotations;

namespace ADPortsTask.DTOs
{
    public class AuthMinimalDto
    {
        [EmailAddress]
        public virtual string Email { get; set; }
    }
}
