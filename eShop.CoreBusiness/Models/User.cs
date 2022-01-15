using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;

namespace eShop.CoreBusiness.Models
{
    public class User : IdentityUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public User(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public User() : base() { }

        public void GetUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public List<Order> Orders { get; set; } 
    }
}
