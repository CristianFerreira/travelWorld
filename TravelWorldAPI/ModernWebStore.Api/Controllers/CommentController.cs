using ModernWebStore.Domain.Entities;
using ModernWebStore.Domain.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ModernWebStore.Api.Controllers
{
    public class CommentController : BaseController
    {
        private readonly ICommentApplicationService _service;

        public CommentController(ICommentApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        //[Authorize]
        [Route("api/comment/listAll")]
        public Task<HttpResponseMessage> Get()
        {
            var comments = _service.Get();
            return CreateResponse(HttpStatusCode.Created, comments);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/comment/{skip}/{take}")]
        public Task<HttpResponseMessage> Get(int skip, int take)
        {
            var comments = _service.Get(skip, take);
            return CreateResponse(HttpStatusCode.Created, comments);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/comment/{id}")]
        public Task<HttpResponseMessage> Get(int id)
        {
            var comment = _service.Get(id);
            return CreateResponse(HttpStatusCode.Created, comment);
        }

        [Route("api/comment/PostId/{id}")]
        public Task<HttpResponseMessage> GetByPostId(int id)
        {
            var comments = _service.GetByPostId(id);
            return CreateResponse(HttpStatusCode.Created, comments);
        }


        [HttpPost]
        //[Authorize]
        [Route("api/comment/create")]
        public Task<HttpResponseMessage> Post(Comment comment)
        {

            var commentRegister = _service.Create(comment);
            return CreateResponse(HttpStatusCode.Created, commentRegister);
        }

        [HttpPut]
        //[Authorize]
        [Route("api/comment/update")]
        public Task<HttpResponseMessage> Put(Comment comment)
        {
            var commentUpdate = _service.Update(comment);
            return CreateResponse(HttpStatusCode.OK, commentUpdate);
        }

        [HttpDelete]
        //[Authorize]
        [Route("api/comment/{id}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            var commentDelete = _service.Delete(id);
            return CreateResponse(HttpStatusCode.OK, commentDelete);
        }

        [HttpPost]
        //[Authorize]
        [Route("api/comment/deleteAlot")]
        public Task<HttpResponseMessage> DeleteAlot(List<Comment> comments)
        {
            var commentDelete = _service.DeleteAlot(comments);
            return CreateResponse(HttpStatusCode.OK, commentDelete);
        }
    }
}

