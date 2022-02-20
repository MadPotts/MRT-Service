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

namespace WeatherData {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1 {
        public root getWeatherData(string lat, string lon) {

            //168 hours is 7 days
            string url = "https://api.solcast.com.au/world_radiation/forecasts?latitude=";
            url += lat + "&longitude=" + lon +
                "&hours=168&format=json&api_key=PDtmqjjkMCbnGHP_8619MMSeMNA70Tgt";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();

            Rootobject obj = JsonConvert.DeserializeObject<Rootobject>(responsereader);

            //create objects and initialize
            root r = new root();
            dataForecasts[] forecast = new dataForecasts[7];
            for(int i = 0; i < 7; i++) {
                forecast[i] = new dataForecasts();
            }

            string time = DateTime.Now.ToString("hh");
            int num = Int32.Parse(time);

            //the offset is so that I grab the forecasted data at the same time of every day.
            //The 48 is because the api gives you data every half hour
            int offset = 0;
            for (int i = 0; i < 7; i++) {
                forecast[i].airTemp = obj.forecasts[num + offset].air_temp;
                forecast[i].directNormalIrradiance = obj.forecasts[num + offset].dni;
                forecast[i].diffuseIrradiance = obj.forecasts[num + offset].dhi;
                offset = offset + 48;
            }

            r.forecast = forecast;

            return r;

        }

    }
}
