using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CoreLayer.Entity;

namespace EntityLayer.Concrete
{
    public class User : Entity
    {
       
        public string FirstName { get; set; }       
        public string LastName { get; set; }
        public string Email { get; set; }        
        public string PasswordHash { get; set; }
        public string SecretKey { get; set; } = Guid.NewGuid().ToString().Replace("-", "") + DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "");
        public string Role { get; set; } = "User";
        public DateTime TokenExpiryDate { get; set; }
        public string? Token { get; set; }
        public bool IsActived { get; set; }
        [NotMapped]
        public string Password { get; set; } 
        [NotMapped]
        public string PasswordAgain { get; set; } 
        [NotMapped]
        public string FullName{get{return this.FirstName+" "+this.LastName;} private set{}}
        [NotMapped]
        public bool IsRegister { get; set; }
        public virtual List<Cart> Cart { get; set; }
        public virtual List<Offer> Offers { get; set; }
    }
}