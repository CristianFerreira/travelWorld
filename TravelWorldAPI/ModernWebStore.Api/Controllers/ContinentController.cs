using ModernWebStore.Domain.Entities;
using ModernWebStore.Domain.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ModernWebStore.Api.Controllers
{
    public class ContinentController : BaseController
    {

        private readonly IContinentApplicationService _service;

        public ContinentController(IContinentApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        //[Authorize]
        [Route("api/continent/listAll")]
        public Task<HttpResponseMessage> Get()
        {
            var continents = _service.Get();
            return CreateResponse(HttpStatusCode.Created, continents);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/continent/{skip}/{take}")]
        public Task<HttpResponseMessage> Get(int skip, int take)
        {
            var continents = _service.Get(skip, take);
            return CreateResponse(HttpStatusCode.Created, continents);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/continent/{id}")]
        public Task<HttpResponseMessage> Get(int id)
        {
            var continents = _service.Get(id);
            return CreateResponse(HttpStatusCode.Created, continents);
        }

        [HttpPost]
        //[Authorize]
        [Route("api/continent/create")]
        public Task<HttpResponseMessage> Post(Continent continent)
        {
            var continentRegister = _service.Create(continent);
            return CreateResponse(HttpStatusCode.Created, continentRegister);
        }

        [HttpPut]
        //[Authorize]
        [Route("api/continent/update")]
        public Task<HttpResponseMessage> Put(Continent continent)
        {
            var continentUpdate = _service.Update(continent);
            return CreateResponse(HttpStatusCode.OK, continentUpdate);
        }

        [HttpDelete]
        //[Authorize]
        [Route("api/continent/delete/{id}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            var continentDelete = _service.Delete(id);
            return CreateResponse(HttpStatusCode.OK, continentDelete);
        }

        [HttpPost]
        //[Authorize]
        [Route("api/continent/deleteAlot")]
        public Task<HttpResponseMessage> DeleteAlot(List<Continent> continent)
        {
            var continentDelete = _service.DeleteAlot(continent);
            return CreateResponse(HttpStatusCode.OK, continentDelete);
        }



    }
}