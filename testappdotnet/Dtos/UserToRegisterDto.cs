using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace testappdotnet.Dtos
{
    public class UserToRegisterDto 
    {
        [Required]
        public string UserName { get; set; }
        
        [Required]
        [StringLength(12,MinimumLength = 8, ErrorMessage ="must provide between 8 and 12 characters")]
        public string Password { get; set; }
    }
}
