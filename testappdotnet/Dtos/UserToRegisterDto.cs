using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace testappdotnet.Dtos
{
    public class UserToRegisterDto 
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
