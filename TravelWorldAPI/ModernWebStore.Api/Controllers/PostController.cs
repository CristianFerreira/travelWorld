using ModernWebStore.Domain.Entities;
using ModernWebStore.Domain.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ModernWebStore.Api.Controllers
{
    public class PostController : BaseController
    {

        private readonly IPostApplicationService _service;

        public PostController(IPostApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        //[Authorize]
        [Route("api/post/listAll")]
        public Task<HttpResponseMessage> Get()
        {
            var post = _service.Get();
            return CreateResponse(HttpStatusCode.Created, post);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/post/{skip}/{take}")]
        public Task<HttpResponseMessage> Get(int skip, int take)
        {
            var post = _service.Get(skip, take);
            return CreateResponse(HttpStatusCode.Created, post);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/post/{id}")]
        public Task<HttpResponseMessage> Get(int id)
        {
            var post = _service.Get(id);
            return CreateResponse(HttpStatusCode.Created, post);
        }

        [HttpPost]
        //[Authorize]
        [Route("api/post/create")]
        public Task<HttpResponseMessage> Post(Post post)
        {
            var postRegister = _service.Create(post);
            return CreateResponse(HttpStatusCode.Created, postRegister);
        }

        [HttpPut]
        //[Authorize]
        [Route("api/post/update")]
        public Task<HttpResponseMessage> Put(Post post)
        {
            var postUpdate = _service.Update(post);
            return CreateResponse(HttpStatusCode.OK, postUpdate);
        }

        [HttpDelete]
        //[Authorize]
        [Route("api/post/delete/{id}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            var postDelete = _service.Delete(id);
            return CreateResponse(HttpStatusCode.OK, postDelete);
        }

        [HttpPost]
        //[Authorize]
        [Route("api/post/deleteAlot")]
        public Task<HttpResponseMessage> DeleteAlot(List<Post> post)
        {
            var postDelete = _service.DeleteAlot(post);
            return CreateResponse(HttpStatusCode.OK, postDelete);
        }



    }
}