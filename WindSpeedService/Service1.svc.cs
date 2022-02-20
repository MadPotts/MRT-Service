using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace WindService {
    public class Service1 : IService1 {

        //this method gets the data from the troposphere api with the given latitude
        //and longitude, and returns the array of wind speeds in that area for the next week
        public root getWindSpeed(string lat, string lon) {
            string url = "https://api.troposphere.io/forecast/";
            url += lat;
            url += ",";
            url += lon;
            url += "?token=e93836f68aba12f0c61dbd3e068f0493f775cf5fdecf0c4db8";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();

            Rootobject obj = JsonConvert.DeserializeObject<Rootobject>(responsereader);

            //create objects and initialize
            root r = new root();
            windSpeedForecast[] forecast = new windSpeedForecast[7];
            for (int i = 0; i < 7; i++) {
                forecast[i] = new windSpeedForecast();
            }

            for (int i = 0; i < 7; i++) {
                forecast[i].windSpeed = obj.data.daily[i].windSpeed;

                DateTime date = obj.data.daily[i].time.Date;
                string dateStr = date.ToString("MM-dd-yyyy");
                forecast[i].windSpeedDate = dateStr;
            }
            r.forecast = forecast;

            return r;
        }
    }
}
