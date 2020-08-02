using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Varonic.IO
{
     public class Read
    {
        public int ReadJsonFromPath(string path)
        {
            var allPath = path + "\\" + "source.json";
            using (var r = new StreamReader(allPath))
            {
                var json = r.ReadToEnd();
                var arr = JObject.Parse(json)["score"].Select(x => (int)x).ToArray();
                return arr.Sum();
            }
        }

        /// <summary>
        /// Singleton
        /// </summary>
        private static Read _instance = null;

        public static Read Instance => _instance ?? (_instance = new Read());
    }
}
