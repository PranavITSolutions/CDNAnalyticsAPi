using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDN_APP_Api.Models
{
    public class Coordinates
    {
        //public string Cluster_name{ get; set; }
        //public string Latitude { get; set; }
        //public string Longitude { get; set; }
        ////public char Lat_dir { get; set; }
        ////public char Long_dir { get; set; }
        //public string Genesis { get; set; }
        public int Servers_Count { get; set; }
        //public string Serving_state { get; set; }
        
        public string Genesis { get; set; }
        public string Location { get; set; }
        public string Cluster_name { get; set; }
        public string Serving_state { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

    }
}