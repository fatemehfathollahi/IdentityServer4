﻿

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Models
{ 
    public class PlusClientScope
    {
        public int Id { get; set; }
        public string Scope { get; set; }

        public int ClientId { get; set; }
        public PlusClient Client { get; set; }
    }
}