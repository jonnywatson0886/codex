﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class ImageProcessor
    {
        public async Task LoadImage(int comicNumber = 0)
        {
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
            
            }
        }
    }
}
