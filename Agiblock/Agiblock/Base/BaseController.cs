using Agiblock.Base.Interface;
using System.Threading.Tasks;
using System.Web.Http;

namespace Agiblock.Base
{
    public class BaseController<T> : ApiController where T : class
    {
        protected readonly IBaseService<T> _service;

        public BaseController(IBaseService<T> service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual async Task<IHttpActionResult> GetEntities()
        {
            var items = await _service.GetEntities();
            return Ok(items);
        }

        [HttpGet]
        public virtual async Task<IHttpActionResult> GetEntityById([FromUri] int id)
        {
            var item = await _service.GetEntityById(id);
            return Ok(item);
        }

        [HttpPost]
        public virtual async Task<IHttpActionResult> CreateEntity([FromBody]T data)
        {
            await _service.CreateEntity(data);
            return Ok();
        }
    }
}