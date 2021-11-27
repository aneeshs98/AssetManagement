using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class TblUserRegistration
    {
        public int UId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int? PhoneNumber { get; set; }
        public int? LId { get; set; }

        public virtual TblLogin L { get; set; }
    }
}
