using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ADPortsTask.DTOs
{
    public class AuthLoginDto : AuthMinimalDto
    {
        [DataType(DataType.Password)]
        public virtual string Password { get; set; }
    }
}
