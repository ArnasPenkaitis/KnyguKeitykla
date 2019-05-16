using Agiblock.Base;
using Agiblock.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agiblock.Models
{
    public class User : IBaseEntity
    {
        public int Id { get; set; }
        public String username { get; set; }

        public String password { get; set; }

        public String name { get; set; }

        public String lastname { get; set; }

        public bool isAdmin { get; set; }

        public bool isBlocked { get; set; }

        public DateTime lastActivity { get; set; }

        public DateTime creationDate { get; set; }

        public String email { get; set; }

        public Sex gender { get; set; }

        public virtual ICollection<Book> books { get; set; }

        public virtual ICollection<Reservation> reservationsAsOwner { get; set; }

        public virtual ICollection<Reservation> reservationsAsLoaner { get; set; }

        public virtual ICollection<Review> reviews { get; set; }

        public virtual ICollection<Report> reports { get; set; }

        public virtual ICollection<Filter> filters { get; set; }
    }
}