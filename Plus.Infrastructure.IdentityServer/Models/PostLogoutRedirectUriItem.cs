using System.ComponentModel.DataAnnotations;

namespace Plus.Infrastructure.IdentityServer.Models
{
    public class PostLogoutRedirectUriItem
    {
        public int Id { get; set; }
        [Required]
        public string PostLogoutRedirectUri { get; set; }
    }
}
