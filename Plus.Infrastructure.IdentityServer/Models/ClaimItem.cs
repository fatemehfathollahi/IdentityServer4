﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Models
{
    public class ClaimItem
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
