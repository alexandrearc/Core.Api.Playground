using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Core.Api.Playground.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BeachesController : ControllerBase
    {
        /// <summary>
        /// We want to test that the incoming request can bind with request class
        /// Just for fun we will return the object in XML
        /// </summary>
        /// <param name="request"></param>
        /// <returns>XML Beaches</returns>
        [HttpPost]
        public IActionResult Post([FromBody] BeachRequest request)
        {
            //We want to test that the incoming request can bind with request class
            //Just for fun we will return the object in XML

            //XML needs a root object
            var root = new JObject();
            root.Add("Beach", request.Beach);
            var xmlBeaches = JsonConvert.DeserializeXmlNode(root.ToString());

            return Ok(xmlBeaches);
        }


        public class BeachRequest
        {
            public JToken Beach { get; set; }
        }
    }
}
