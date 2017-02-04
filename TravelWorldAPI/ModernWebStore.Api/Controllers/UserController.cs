
using ModernWebStore.Domain.Commands.UserCommands;
using ModernWebStore.Domain.Entities;
using ModernWebStore.Domain.Services;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ModernWebStore.Api.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserApplicationService _service;

        public UserController(IUserApplicationService service)
        {
            this._service = service;
        }

        //[HttpGet]
        //[Route("api/users")]
        //[Authorize(Roles = "admin")]
        //public Task<HttpResponseMessage> Get()
        //{
        //    var users = _service.List();
        //    return CreateResponse(HttpStatusCode.OK, users);
        //}

        [HttpPost]
        [Route("api/users")]
        public Task<HttpResponseMessage> Post(User user)
        {
          
            var userRegister = _service.Register(user);

            return CreateResponse(HttpStatusCode.OK, userRegister);
        }
    }
}