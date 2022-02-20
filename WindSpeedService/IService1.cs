using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WindService {
    [ServiceContract]
    public interface IService1 {

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/getWindSpeed/{lat}/{lon}")]
        root getWindSpeed(string lat, string lon);
    }

    //my objects
    [DataContract]
    public class root {
        [DataMember]
        public windSpeedForecast[] forecast { get; set; }
    }

    [DataContract]
    public class windSpeedForecast {
        [DataMember]
        public float windSpeed { get; set; }
        [DataMember]
        public string windSpeedDate { get; set; }
    }

    //other api's objects
    [DataContract]
    public class Rootobject {
        [DataMember]
        public object error { get; set; }
        [DataMember]
        public Data data { get; set; }
    }

    [DataContract]
    public class Data {
        [DataMember]
        public string timezone { get; set; }
        [DataMember]
        public Current current { get; set; }
        [DataMember]
        public Hourly[] hourly { get; set; }
        [DataMember]
        public Daily[] daily { get; set; }
    }

    [DataContract]
    public class Current {
        [DataMember]
        public DateTime time { get; set; }
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public float temperature { get; set; }
        [DataMember]
        public float temperatureMin { get; set; }
        [DataMember]
        public float temperatureMax { get; set; }
        [DataMember]
        public float windSpeed { get; set; }
        [DataMember]
        public float windGustsSpeed { get; set; }
        [DataMember]
        public float windBearing { get; set; }
        [DataMember]
        public float relHumidity { get; set; }
        [DataMember]
        public int cloudCover { get; set; }
        [DataMember]
        public float preasure { get; set; }
        [DataMember]
        public int totalPrecipitation { get; set; }
        [DataMember]
        public int rain { get; set; }
        [DataMember]
        public int snow { get; set; }
        [DataMember]
        public float uvIndex { get; set; }
        [DataMember]
        public float airQualityIndex { get; set; }
    }

    [DataContract]
    public class Hourly {
        [DataMember]
        public DateTime time { get; set; }
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public float temperature { get; set; }
        [DataMember]
        public float temperatureMin { get; set; }
        [DataMember]
        public float temperatureMax { get; set; }
        [DataMember]
        public float windSpeed { get; set; }
        [DataMember]
        public float windGustsSpeed { get; set; }
        [DataMember]
        public float windBearing { get; set; }
        [DataMember]
        public float relHumidity { get; set; }
        [DataMember]
        public float cloudCover { get; set; }
        [DataMember]
        public float preasure { get; set; }
        [DataMember]
        public float totalPrecipitation { get; set; }
        [DataMember]
        public float rain { get; set; }
        [DataMember]
        public int snow { get; set; }
        [DataMember]
        public float? uvIndex { get; set; }
        [DataMember]
        public float? airQualityIndex { get; set; }
    }

    [DataContract]
    public class Daily {
        [DataMember]
        public DateTime time { get; set; }
        [DataMember]
        public Sun sun { get; set; }
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public float temperature { get; set; }
        [DataMember]
        public float temperatureMin { get; set; }
        [DataMember]
        public float temperatureMax { get; set; }
        [DataMember]
        public float windSpeed { get; set; }
        [DataMember]
        public float windSpeedMax { get; set; }
        [DataMember]
        public float windBearing { get; set; }
        [DataMember]
        public float relHumidity { get; set; }
        [DataMember]
        public float cloudCover { get; set; }
        [DataMember]
        public float preasure { get; set; }
        [DataMember]
        public float totalPrecipitation { get; set; }
        [DataMember]
        public float rain { get; set; }
        [DataMember]
        public int snow { get; set; }
        [DataMember]
        public float? uvIndexMax { get; set; }
    }

    [DataContract]
    public class Sun {
        [DataMember]
        public DateTime sunrise { get; set; }
        [DataMember]
        public DateTime sunset { get; set; }
    }
}
