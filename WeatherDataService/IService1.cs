using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WeatherData {
    [ServiceContract]
    public interface IService1 {

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/getWeatherData/{lat}/{lon}")]
        root getWeatherData(string lat, string lon);
    }

    //my objects
    [DataContract]
    public class root {
        [DataMember]
        public dataForecasts[] forecast { get; set; }
    }

    [DataContract]
    public class dataForecasts {
        [DataMember]
        public int airTemp { get; set; }
        [DataMember]
        public int directNormalIrradiance { get; set; }
        [DataMember]
        public int diffuseIrradiance { get; set; }
    }

    //other api's objects
    [DataContract]
    public class Rootobject {
        [DataMember]
        public Forecast[] forecasts { get; set; }
    }

    [DataContract]
    public class Forecast {
        [DataMember]
        public int ghi { get; set; }
        [DataMember]
        public int ghi90 { get; set; }
        [DataMember]
        public int ghi10 { get; set; }
        [DataMember]
        public int ebh { get; set; }
        [DataMember]
        public int dni { get; set; }
        [DataMember]
        public int dni10 { get; set; }
        [DataMember]
        public int dni90 { get; set; }
        [DataMember]
        public int dhi { get; set; }
        [DataMember]
        public int air_temp { get; set; }
        [DataMember]
         public int zenith { get; set; }
        [DataMember]
        public int azimuth { get; set; }
        [DataMember]
        public int cloud_opacity { get; set; }
        [DataMember]
        public DateTime period_end { get; set; }
        [DataMember]
        public string period { get; set; }
    }

}
