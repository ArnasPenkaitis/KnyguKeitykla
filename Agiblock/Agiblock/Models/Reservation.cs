using Agiblock.Base;
using Agiblock.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agiblock.Models
{
    public class Reservation : IBaseEntity
    {
        public int Id { get; set; }
        public String omnivaLocation { get; set; }

        public DateTime sentDate { get; set; }

        public String comment { get; set; }

        public virtual User owner { get; set; }

        public virtual User loaner { get; set; }

        public virtual Book book { get; set; }

        public ReservationTypes reservationType { get; set; }

        public void GetParticularReservation()
        {

        }

        public void UpdateReservation()
        {

        }
    }
}