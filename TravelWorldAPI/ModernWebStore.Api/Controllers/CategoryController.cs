
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
    public class CategoryController : BaseController
    {
        private readonly ICategoryApplicationService _service;

        public CategoryController(ICategoryApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        //[Authorize]
        [Route("api/categories")]
        public Task<HttpResponseMessage> Get()
        {
            var categories = _service.Get();
            return CreateResponse(HttpStatusCode.Created, categories);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/categories/{skip}/{take}")]
        public Task<HttpResponseMessage> Get(int skip, int take)
        {
            var categories = _service.Get(skip, take);
            return CreateResponse(HttpStatusCode.Created, categories);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/categories/{id}")]
        public Task<HttpResponseMessage> Get(int id)
        {
            var category = _service.Get(id);
            return CreateResponse(HttpStatusCode.Created, category);
        }

        [HttpPost]
        //[Authorize]
        [Route("api/categories/create")]
        public Task<HttpResponseMessage> Post(Category category)
        {

            var categoryRegister =_service.Create(category);
            return CreateResponse(HttpStatusCode.Created, categoryRegister);
        }

        [HttpPut]
        //[Authorize]
        [Route("api/categories/update")]
        public Task<HttpResponseMessage> Put(Category category) 
        {
            var categoryUpdate = _service.Update(category);
            return CreateResponse(HttpStatusCode.OK, categoryUpdate);
        }

        [HttpDelete]
        //[Authorize]
        [Route("api/categories/{id}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            var categoryDelete =_service.Delete(id);
            return CreateResponse(HttpStatusCode.OK, categoryDelete);
        }

        [HttpPost]
        //[Authorize]
        [Route("api/categories/deleteAlot")]
        public Task<HttpResponseMessage> DeleteAlot(List<Category> categories)
        {
            var categoryDelete = _service.DeleteAlot(categories);
            return CreateResponse(HttpStatusCode.OK, categoryDelete);
        }

    }
}