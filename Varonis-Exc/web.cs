using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varonic.Utilities;

namespace Varonis_Exc
{
    public class web: IAction
    {
        public string Action(string id)
        {
            var username = ConfigurationManager.AppSettings["Username"];
            var password = ConfigurationManager.AppSettings["Password"];
            string url = string.Format(ConfigurationManager.AppSettings["Url"], id);
            var content = HttpWebRequestHandler.Instance.GetReleases(url, username, password);
            return content;
        }
    }
}
