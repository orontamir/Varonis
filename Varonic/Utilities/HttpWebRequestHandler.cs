using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Varonic.Utilities
{
    public class HttpWebRequestHandler
    {
        public string Username;

        public string Password;

        private HttpWebRequestHandler()
        {
          
        }
        public string GetReleases(string url, string username, string password)
        {
            string content = null;
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Credentials = new NetworkCredential(username, password);
                request.Method = "GET";
                

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        if (stream == null) return null;
                        using (var sr = new StreamReader(stream))
                        {
                            content = sr.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception when connect to web service, error message: {e.Message}");
                
            }
           

            return content;
        }

        /// <summary>
        /// Singleton
        /// </summary>
        private static HttpWebRequestHandler _instance = null;

        public static HttpWebRequestHandler Instance => _instance ?? (_instance = new HttpWebRequestHandler());
    }
}
