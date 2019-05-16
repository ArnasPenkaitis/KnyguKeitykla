using Agiblock.Base;
using Agiblock.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agiblock.Models
{
    public class Filter : IBaseEntity
    {
        public int Id { get; set; }
        public String language { get; set; }

        public String genre { get; set; }

        public OrderByTypes orderType { get; set; }

        public virtual User user { get; set; }
    }
}