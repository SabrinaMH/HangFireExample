using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Hangfire;
using Newtonsoft.Json;

namespace Scheduling.Controllers
{
    [RoutePrefix("schedule")]
    public class ScheduleController : ApiController
    {
        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "You got me");
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post()
        {
            var client = new BackgroundJobClient();
            var test = "test param";
            client.Enqueue(() => CallApi(test));
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        public void CallApi(string param)
        {
            var client = new HttpClient();
            var httpResponse = client.GetAsync("http://localhost:65273/schedule").Result;
            var result = httpResponse.Content.ReadAsStringAsync().Result;
            Console.WriteLine("From within CallApi. Param {0}. Result {1}", param, result);
        }
    }
}
