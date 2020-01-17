using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class ImageProcessor
    {
        public static async Task<ImageModel> LoadImage(int comicNumber = 0)
        {
            ImageModel DownloadedImage = new ImageModel();
            //url for the connection for the connection to the website api
            string url = "";
            if (comicNumber > 0)
            {
                url = $"https://xkcd.com/{comicNumber}/info.0.json";
            }
            else 
            {
                url = "https://xkcd.com/info.0.json";
            }
            using (HttpResponseMessage response = await APIHelper.APIClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    DownloadedImage = await response.Content.ReadAsAsync<ImageModel>();
                    return DownloadedImage;
                }
                else 
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
