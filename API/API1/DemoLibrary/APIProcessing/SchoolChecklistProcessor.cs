using DemoLibrary.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.APIProcessing
{
    public static class SchoolChecklistProcessor
    {
        /// <summary>
        /// connects to an API and gathers the raw data into a data model
        /// </summary>
        /// <returns></returns>
        public async static Task<List<CheckListDataModel>> GetCheckListDataAysnc() 
        {
            //for the address
            string Uri = "https://jsonplaceholder.typicode.com/todos";

            //attempt connection using default header
            using (HttpResponseMessage response = await APIHelper.APIClient.GetAsync(Uri))
            {
                //check to see if we got a sucessful reponse
                if (response.IsSuccessStatusCode)
                {
                    var dataList = await response.Content.ReadAsAsync<List<CheckListDataModel>>();
                    return dataList;
                }
                else 
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }
    }
}
