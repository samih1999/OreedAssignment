using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalSami.Models
{
    public class RegisterViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string CurrentJob { get; set; }
        public string CurrentJobDesc { get; set; }
        public string Speialization { get; set; }
        public DateTime DOB { get; set; }
        
    }
}
