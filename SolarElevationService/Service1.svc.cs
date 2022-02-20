using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace Homework3Part3 {
    public class Service1 : IService1 {
        //this service gets the solar elevation at a given location at the current time
        //for the next 7 days
        public root getSolarElevation(string lat, string lon) {
            //get current date
            string date = DateTime.UtcNow.ToString("yyyy-MM-dd");

            string url = "https://api.ipgeolocation.io/astronomy?apiKey=483864a7776f42dd8452acd892468047&lat=";

            url += lat + "&long=" + lon + "&date=";

            //create forecast object and initialize
            solarElevationForecast[] forecast = new solarElevationForecast[7];
            for (int i = 0; i < 7; i++) {
                forecast[i] = new solarElevationForecast();
            }
            root r = new root();

            for (int i = 0; i < 7; i++) {
                url += date;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                response.Close();

                Rootobject obj = JsonConvert.DeserializeObject<Rootobject>(responsereader);

                forecast[i].solarElevation = obj.sun_altitude;
                forecast[i].date = date;

                //keep requesting info for subsequent days
                date = DateTime.UtcNow.AddDays(i + 1).ToString("yyyy-MM-dd");
            }

            r.forecast = forecast;

            return r;
        }
    }
}
