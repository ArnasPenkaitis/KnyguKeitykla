using Agiblock.Base;
using Agiblock.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agiblock.Models
{
    public class Book: IBaseEntity
    {
        public int Id { get; set; }
        public String title { get; set; }
        public String description { get; set; }
        public bool isAvailable { get; set; }
        public byte? image { get; set; }
        public byte? pdf { get; set; }
        public virtual User owner { get; set; }
        public BookTypes bookType { get; set; }
        public virtual ICollection<Reservation> reservations { get; set; }
        public virtual ICollection<Review> reviews { get; set; }
        public virtual ICollection<Report> reports { get; set; }

        public void GetAllSameBooks()
        {

        }

        public void ReserveBook()
        {

        }
    }
}