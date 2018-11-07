using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace CIRelay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        // GET: AzurePipeline
        [HttpPost]
        public void Post([FromBody] string value)
        {
            Console.WriteLine(value);
            //return new string[] { "value1", "value2" };
            //  curl -X POST -H "Content-Type: application/json" -d '{"value1":"test","value2":"test","value3":"test"}'"
            //  https://maker.ifttt.com/trigger/CI_Build_result/with/key/den2SL6fXRgg4MJUsAj27w

            RestClient client = new RestClient("https://maker.ifttt.com/trigger/CI_Build_result/with/key/den2SL6fXRgg4MJUsAj27w");
            RestRequest request = new RestRequest(Method.POST);
            //request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Content-Type", "application/json");

            ITFFFModel model = new ITFFFModel();
            model.value1 = "VS";
            model.value2 = "Ean";
            model.value3 = value;

            var json = JsonConvert.SerializeObject(model);
            request.AddParameter("Image", json, ParameterType.RequestBody);

            var response = client.Execute(request);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}