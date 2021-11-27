using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class TblLogin
    {
        public TblLogin()
        {
            TblUserRegistration = new HashSet<TblUserRegistration>();
        }

        public int LId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }

        public virtual ICollection<TblUserRegistration> TblUserRegistration { get; set; }
    }
}
