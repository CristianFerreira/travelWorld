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
    public class CountryController : BaseController
    {
        private readonly ICountryApplicationService _service;

        public CountryController(ICountryApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        //[Authorize]
        [Route("api/countries/listAll")]
        public Task<HttpResponseMessage> Get()
        {
            var countries = _service.Get();
            return CreateResponse(HttpStatusCode.Created, countries);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/countries/{skip}/{take}")]
        public Task<HttpResponseMessage> Get(int skip, int take)
        {
            var countries = _service.Get(skip, take);
            return CreateResponse(HttpStatusCode.Created, countries);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/countries/{id}")]
        public Task<HttpResponseMessage> Get(int id)
        {
            var country = _service.Get(id);
            return CreateResponse(HttpStatusCode.Created, country);
        }

        [HttpPost]
        //[Authorize]
        [Route("api/countries/create")]
        public Task<HttpResponseMessage> Post(Country country)
        {
            country.idContinent = country.continent.Id;
            var countryRegister = _service.Create(country);
            return CreateResponse(HttpStatusCode.Created, countryRegister);
        }

        [HttpPost]
        //[Authorize]
        [Route("api/countries/update")]
        public Task<HttpResponseMessage> Update(Country country)
        {
            country.idContinent = country.continent.Id;
            var countryUpdate = _service.Update(country);
            return CreateResponse(HttpStatusCode.OK, countryUpdate);
        }

        [HttpDelete]
        //[Authorize]
        [Route("api/countries/{id}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            var countryDelete = _service.Delete(id);
            return CreateResponse(HttpStatusCode.OK, countryDelete);
        }

        [HttpPost]
        //[Authorize]
        [Route("api/countries/deleteAlot")]
        public Task<HttpResponseMessage> DeleteAlot(List<Country> countries)
        {
            var countryDelete = _service.DeleteAlot(countries);
            return CreateResponse(HttpStatusCode.OK, countryDelete);
        }

    }
}
