using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weatherApp
{
    public class HttpHelper
    {
        public static async Task<string> getJson(string url)
        {
            using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
            {
                return await client.GetStringAsync(url);
            }
        }
    }
}
