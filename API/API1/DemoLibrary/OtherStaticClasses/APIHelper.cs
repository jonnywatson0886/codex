using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public static class APIHelper
    {
        //made static to be once per appliaction can also be checked for null
        public static HttpClient APIClient { get; set; }
        /// <summary>
        /// setup for the API client
        /// </summary>
        public static void NewAPIClient()
        {
             //intislise client 
            APIClient = new HttpClient();
            //would usually add in for single address
            //APIClient.BaseAddress = new Uri("http://webaddress");
            //end of usual
            APIClient.DefaultRequestHeaders.Accept.Clear();
            APIClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        /// <summary>
        /// function to check live internet connection
        /// </summary>
        /// <returns></returns>
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
