using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using RestSharp;
using RestSharp.Authenticators;


namespace MOT_Web_App.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        // GET api/values
        [Route("api/getRegistration")]
        [HttpGet]
        public IEnumerable<string> Get(string registrationNumber)
        {
            var client = new RestClient("https://beta.check-mot.service.gov.uk/trade/vehicles/mot-tests?registration=" + registrationNumber);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-api-key", "fZi8YcjrZN1cGkQeZP7Uaa4rTxua8HovaswPuIno");
            IRestResponse response = client.Execute(request);
            yield return response.Content;
        }
    }
}
