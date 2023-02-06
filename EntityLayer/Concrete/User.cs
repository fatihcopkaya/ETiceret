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
        public string PhoneNumber { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Role { get; set; } = "User";
        public bool IsActived { get; set; }
        [NotMapped]
        public string Password { get; set; }
        [NotMapped]
        public string PasswordAgain { get; set; }
        [NotMapped]
        public string FullName { get { return this.FirstName + " " + this.LastName; } private set { } }
        [NotMapped]
        public bool IsRegister { get; set; }
    }
}