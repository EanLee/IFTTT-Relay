using Microsoft.AspNetCore.Mvc;
using System;
using Newtonsoft.Json;
using RestSharp;

namespace CIRelay.Controllers
{
    [Route("api/[controller]")]
    public class AzurePipelineController : Controller
    {
        [Produces("application/json")]
        [HttpPost]
        public void Post([FromBody] string value)
        {
            RestClient client = new RestClient("https://maker.ifttt.com/trigger/CI_Build_result/with/key/den2SL6fXRgg4MJUsAj27w");
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");

            ITFFFModel model = new ITFFFModel {value1 = "VS", value2 = "Ean", value3 = value};
            var json = JsonConvert.SerializeObject(model);
            request.AddParameter("Image", json, ParameterType.RequestBody);

            var response = client.Execute(request);
        }

    }
}