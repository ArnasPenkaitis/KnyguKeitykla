using Agiblock.Base;
using Agiblock.Models;
using Agiblock.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Agiblock.Controllers
{
    [Route("api/realbook")]
    public class RealBookController:BaseController<Book>
    {
        private readonly IRealBookService _bookService;

        public RealBookController(IRealBookService service) : base(service)
        {
            _bookService = service;
        }

    }
}