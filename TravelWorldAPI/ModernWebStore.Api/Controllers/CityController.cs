using ModernWebStore.Domain.Entities;
using ModernWebStore.Domain.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ModernWebStore.Api.Controllers
{
    public class CityController : BaseController
    {
       
        private readonly ICityApplicationService _service;

        public CityController(ICityApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        //[Authorize]
        [Route("api/cities")]
        public Task<HttpResponseMessage> Get()
        {
            var cities = _service.Get();
            return CreateResponse(HttpStatusCode.Created, cities);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/cities/{skip}/{take}")]
        public Task<HttpResponseMessage> Get(int skip, int take)
        {
            var cities = _service.Get(skip, take);
            return CreateResponse(HttpStatusCode.Created, cities);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/cities/{id}")]
        public Task<HttpResponseMessage> Get(int id)
        {
            var city = _service.Get(id);
            return CreateResponse(HttpStatusCode.Created, city);
        }

        [HttpPost]
        //[Authorize]
        [Route("api/cities/create")]
        public Task<HttpResponseMessage> Post(City city)
        {
            city.idCountry = city.Country.Id;
            var cityRegister = _service.Create(city);
            return CreateResponse(HttpStatusCode.Created, cityRegister);
        }

        [HttpPut]
        //[Authorize]
        [Route("api/cities/update")]
        public Task<HttpResponseMessage> Put(City city)
        {
            var cityUpdate = _service.Update(city);
            return CreateResponse(HttpStatusCode.OK, cityUpdate);
        }

        [HttpDelete]
        //[Authorize]
        [Route("api/cities/{id}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            var cityDelete = _service.Delete(id);
            return CreateResponse(HttpStatusCode.OK, cityDelete);
        }

        [HttpDelete]
        //[Authorize]
        [Route("api/cities/deleteAlot")]
        public Task<HttpResponseMessage> DeleteAlot(List<City> cities)
        {
            var cityDelete = _service.DeleteAlot(cities);
            return CreateResponse(HttpStatusCode.OK, cityDelete);
        }



    }
}