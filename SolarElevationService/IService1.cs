using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Homework3Part3 {
    [ServiceContract]
    public interface IService1 {

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/getSolarElevation/{lat}/{lon}")]
        root getSolarElevation(string lat, string lon);
    }

    [DataContract]
    public class root {
        [DataMember]
        public solarElevationForecast[] forecast { get; set; }
    }

    [DataContract]
    public class solarElevationForecast {
        [DataMember]
        public float solarElevation { get; set; }
        [DataMember]
        public string date { get; set; }
    }

    [DataContract]
    public class Rootobject {
        [DataMember]
        public Location location { get; set; }
        [DataMember]
        public string date { get; set; }
        [DataMember]
        public string current_time { get; set; }
        [DataMember]
        public string sunrise { get; set; }
        [DataMember]
        public string sunset { get; set; }
        [DataMember]
        public string sun_status { get; set; }
        [DataMember]
        public string solar_noon { get; set; }
        [DataMember]
        public string day_length { get; set; }
        [DataMember]
        public float sun_altitude { get; set; }
        [DataMember]
        public float sun_distance { get; set; }
        [DataMember]
        public float sun_azimuth { get; set; }
        [DataMember]
        public string moonrise { get; set; }
        [DataMember]
        public string moonset { get; set; }
        [DataMember]
        public string moon_status { get; set; }
        [DataMember]
        public float moon_altitude { get; set; }
        [DataMember]
        public float moon_distance { get; set; }
        [DataMember]
        public float moon_azimuth { get; set; }
        [DataMember]
        public float moon_parallactic_angle { get; set; }
    }

    [DataContract]
    public class Location {
        [DataMember]
        public float latitude { get; set; }
        [DataMember]
        public float longitude { get; set; }
    }
}