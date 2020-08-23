﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testappdotnet.Models;

namespace testappdotnet.Dtos
{
    public class UserForDetailesDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string knownAs { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string City { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<PhotosForDetailsDto> Photos { get; set; }
    }
}
