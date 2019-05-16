using Agiblock.Base;
using Agiblock.Models;
using Agiblock.Repository.Interface;
using Agiblock.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agiblock.Services
{
    public class RealBookService : BaseService<Book>, IRealBookService
    {
        private readonly IRepository _repository;

        public RealBookService(IRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}