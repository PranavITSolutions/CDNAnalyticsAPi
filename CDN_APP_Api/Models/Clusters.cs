using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDN_APP_Api.Models
{
    public class Clusters
    {
        public string Cluster_Name { get; set; }
        public string Servers_ID { get; set; }
        public int Server_Count { get; set; }
        public string Active { get; set; }
        public string Genesis { get; set; }
        public string Location { get; set; }
        public string HostName { get; set; }
        public string serving_state { get; set; }
        public string Layer { get; set; }
        public string Aname { get; set; }
        public string OS { get; set; }
        public string Object { get; set; }
        public string gateway { get; set; }
        public DateTime Cleared  { get; set; }
        public string day_count { get; set; }
        public string Severity { get; set; }
        public string fp_version { get; set; }
        public string Raw_Bindings { get; set; }
    }

    public class Servers
    {   
        public string country_code { get; set; }
        public int cluster_count { get; set; }
        public int server_count { get; set; }
        public int online_values { get; set; }
        public int draining_values { get; set; }
        public decimal country_latitude { get; set; }
        public decimal country_longitude { get; set; }
        public string cluster_name { get; set; }
        public int servers_id { get; set; }
        public string serving_state { get; set; }

    }


    public class State
    {//country_code, state, Latitude, longitude, cluster_count,server_count
        public string country_code { get; set; }//
        public string State_code { get; set; }//
        public int cluster_count { get; set; }//
        public int server_count { get; set; }//
        public decimal latitude { get; set; }//
        public decimal longitude { get; set; }//
        public string cluster_name { get; set; }
        public int servers_id { get; set; }
        public string serving_state { get; set; }

    }

    //City, Country_code, Cluster_count, Server_count, Latitude, Longitude
    public class City
    {
        public string City_name { get; set; }
        public string Country_code { get; set; }
        public int Cluster_count { get; set; }
        public int draining_values { get; set; }
        public int online_values { get; set; }
        public int Server_count { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string cluster_name { get; set; }
        public string serving_state { get; set; }
        public int servers_id { get; set; }
    }

    public class Chart
    {
        //gateway,draining_values,online_values,total_servers, Percentage
        public string Gateway { get; set; }
        public int Total_Servers { get; set; }
        public int Total_gateways { get; set; }
        public int Draining_Values { get; set; }
        public int Online_Values { get; set; }
        public decimal Percentage { get; set; }
    }

    public class Widgets
    {
        public int Total_Clusters{ get; set; }
        public int Total_Servers { get; set; }
        public int Draining_Values { get; set; }
        public int Online_Values { get; set; }
    }


    public class HealthMetrics
    {
        
        public decimal Avg_Mbps { get; set; }
        public decimal Avg_Hps { get; set; }
        public decimal Sum_Mbps { get; set; }
        public decimal Sum_Hps { get; set; }
        public decimal Sum_sfb_percent { get; set; }
        public decimal Avg_sfb_percent { get; set; }
        public decimal Sum_sf_percent { get; set; }
        public decimal Avg_sf_percent { get; set; }
        public string Cluster_Name { get; set; }        
        public string Gateway { get; set; }
    }


    public class Alerts
    {//container	gateway	si_server_name	active	serving_state	alert_server_name	cleared
        //severity	alert_Type	created	Container	Object	Message
        public string Container { get; set; }
        public string Alert_type { get; set; }         
        public string Severity { get; set; }
        public string Object { get; set; }
        public DateTime created { get; set; }
        public string Message { get; set; }

        public int total_alerts { get; set; }
        public int urgent_alerts { get; set; }
        public int critical_alerts { get; set; }
        public int Major_alerts { get; set; }        
        public int Minor_alerts { get; set; }
        public int Info_alerts { get; set; }
        

        //urgent_values critical_values Major_values Minor_values    Info_values
    }
}