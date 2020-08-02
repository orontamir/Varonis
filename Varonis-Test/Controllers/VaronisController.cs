using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Varonic.DataBase;
using Varonic.IO;

namespace Varonis_Test.Controllers
{
    public class VaronisController : ApiController
    {

      
        // GET: api/Varonis/5
        [Route("api/Varonis/{id}")]
        public string Get(string id)
        {
            string path;
            if ( string.IsNullOrEmpty(id))
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NoContent)
                {
                    Content = new StringContent("Name value or id  is null"),
                    ReasonPhrase = "Name value or id is null"
                });
            }
            var jsonDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\..\\Data\\Varonis.json";
            jsonDir = jsonDir.Replace("file:\\","");
            using (var r = new StreamReader(jsonDir))
            {
                string json = r.ReadToEnd();
                var data = (JObject)JsonConvert.DeserializeObject(json);
                path = data[id].Value<string>();
            }
            var score = Read.Instance.ReadJsonFromPath(path);   
            return score.ToString();
        }

     
    }
}
