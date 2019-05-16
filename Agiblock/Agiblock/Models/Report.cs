using Agiblock.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agiblock.Models
{
    public class Report : IBaseEntity
    {
        public int Id { get; set; }
        public String description { get; set; }

        public virtual User userTarget { get; set; }

        public virtual Book bookTarget { get; set; }

        public virtual User author { get; set; }

        public void CreateReportByBookId()
        {

        }
    }
}