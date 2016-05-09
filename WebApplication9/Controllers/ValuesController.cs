using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication9.Models;
using WebApplication9.Services;

namespace WebApplication9.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IValuesService _valuesService;
        private readonly ILogger _logger;

        public ValuesController(IValuesService valuesService, ILogger logger)
        {
            _valuesService = valuesService;
            _logger = logger;
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            _logger.Write("Get all values was called", LogLevel.INFO);
            return _valuesService.GetValues().Select(x => x.Value);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return _valuesService.Get(id).Value;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            _valuesService.Add(new Item() { Value = value });
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            _valuesService.Delete(id);
        }
    }
}
