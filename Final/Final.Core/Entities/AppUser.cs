using Microsoft.AspNetCore.Identity;
namespace Final.Core.Entities
{
    public class AppUser :IdentityUser
    {
        public string Name {  get; set; }
        public string? Surname { get; set; }
        public ICollection<Product>? Products { get; set; } 
    }
}
