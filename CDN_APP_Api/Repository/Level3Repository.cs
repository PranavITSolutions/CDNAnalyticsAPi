using CDN_APP_Api.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CDN_APP_Api.Repository
{
    public class Level3Repository
    {

        public static List<Coordinates> GetCoordinatesList()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    const string query = "usp_GetCoordinates";
                    return db.Query<Coordinates>(query, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.GetBaseException());
                return null;
            }
        }

        public static List<Clusters> GetClusterDetails()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    const string query = "usp_GetClusterDetails";
                    return db.Query<Clusters>(query, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.GetBaseException());
                return null;
            }
        }

        public static List<Clusters> GetServerDetailsByCluster(string cluster)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    const string query = "usp_GetServerDetailsByCluster";
                    var param = new DynamicParameters();
                    param.Add("@cluster", cluster);
                    var gwinfo = db.Query<Clusters>(query, param, commandType: CommandType.StoredProcedure);
                    return gwinfo.ToList();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.GetBaseException());
                return null;
            }
        }

        ///-------------------------------drill downs-------------------------------
        //clulster drill down

        public static List<Clusters> GetClustersInDrillDown()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    const string query = "usp_GetDrilldownClusterDetails";
                    return db.Query<Clusters>(query, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.GetBaseException());
                return null;
            }
        }

        public static List<Clusters> GetServersInDrillDown()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    const string query = "usp_getDrilldownServerList";
                    return db.Query<Clusters>(query, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.GetBaseException());
                return null;
            }
        }

        public static List<Clusters> GetServersActiveInDrillDown()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    const string query = "usp_getDrilldownServerListOnline";
                    return db.Query<Clusters>(query, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.GetBaseException());
                return null;
            }
        }

        public static List<Clusters> GetServersInactiveInDrillDown()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    const string query = "usp_getDrilldownServerListDraining";
                    return db.Query<Clusters>(query, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.GetBaseException());
                return null;
            }
        }

        ///---------------------------------------Widget Counts-------------------------------------///        
        ///
        public static List<Widgets> GetAllWidgetsCount()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    const string query = "usp_GetAllWidgetCounts";
                    return db.Query<Widgets>(query, commandType: CommandType.StoredProcedure).AsList();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.GetBaseException());
                return null;
            }
        }

        public static int GetClustersInWidgetCount()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    const string query = "select count(distinct cluster_name) from bds_new";
                    return db.ExecuteScalar<int>(query);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.GetBaseException());
                return 0;
            }
        }

        public static int GetServersInWidgetCount()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    const string query = "select count(distinct servers_id) from server_infos";
                    return db.ExecuteScalar<int>(query);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.GetBaseException());
                return 0;
            }
        }

        public static int GetServersActiveInWidgetCount()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    const string query = "select count(distinct sc.servers_id) from bds_new b   inner join server_clusters sc on  sc.cluster_name = b.cluster_name"
                    + " inner join server_infos si on sc.servers_id = si.servers_id  inner join RA_CM_Data_Dump rcd on rcd.cluster = b.cluster_name where b.serving_state = 'online' ";
                    return db.ExecuteScalar<int>(query);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.GetBaseException());
                return 0;
            }
        }

        public static int GetServersInactiveInWidgetCount()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    const string query = "select count(distinct sc.servers_id) from bds_new b  inner join server_clusters sc on  sc.cluster_name = b.cluster_name"
                    + " inner join server_infos si on sc.servers_id = si.servers_id  inner join RA_CM_Data_Dump rcd on rcd.cluster = b.cluster_name where b.serving_state = 'Draining' ";
                    return db.ExecuteScalar<int>(query);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.GetBaseException());
                return 0;
            }
        }

        ///-------------------------------Server Counts By Region, State-------------------
        //-------------------------------Starts Here---------------------------------------//    

        //public static List<Servers> GetServerCountDetailsByRegion()
        //{
        //    try
        //    {
        //        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
        //        {
        //            const string query = "usp_GetServersClustersDetails";
        //            return db.Query<Servers>(query, commandType:CommandType.StoredProcedure).ToList();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e.Message);
        //        Debug.WriteLine(e.GetBaseException());
        //        return null;
        //    }
        //}
        public static List<Servers> GetServerCountDetailsByRegion()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    //const string query = "select *, servers_id as server_count, cluster_name as cluster_count from Map_CountryLevelData";
                    const string query = "select * from mapcountryleveldata";
                    return db.Query<Servers>(query).ToList();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.GetBaseException());
                return null;
            }
        }

        public static List<Clusters> GetCountryLevelDetailsByRegion(string area)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    const string query = "usp_GetServersClustersDetails";
                    var param = new DynamicParameters();
                    param.Add("@area", area);
                    return db.Query<Clusters>(query, param, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.GetBaseException());
                return null;
            }
        }

        public static List<State> GetServerCountDetailsByState()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    //const string query = "usp_GetStateDetails";
                    const string query = "select * from  Map_StateLevelData";
                    return db.Query<State>(query).ToList();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.GetBaseException());
                return null;
            }
        }

        public static List<Clusters> GetStateLevelDetailsByArea(string state)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@state", state);
                    const string query = "usp_GetClusterDetailsByState";
                    return db.Query<Clusters>(query, param, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.GetBaseException());
                return null;
            }
        }

        public static List<City> GetServerCountDetailsByCity()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    //const string query = "usp_GetStateDetails";
                    const string query = "select * from Map_CityLevelData";
                    return db.Query<City>(query).ToList();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.GetBaseException());
                return null;
            }
        }


        public static List<Clusters> GetCityLevelDetailsInList(string city)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@city", city);
                    const string query = "usp_GetMapDrillDownByCity";
                    return db.Query<Clusters>(query, param, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.GetBaseException());
                return null;
            }
        }

        public static List<Chart> GetChartCountPercentages()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    const string query = "usp_GetCountsOfDraining";
                    return db.Query<Chart>(query, commandType: CommandType.StoredProcedure).AsList();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.GetBaseException());
                return null;
            }
        }


        public static List<Chart> GetHealthPercentages()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    const string query = "usp_getHealthPercentages";
                    var obj = db.Query<Chart>(query, commandType: CommandType.StoredProcedure).AsList();
                    return obj;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.GetBaseException());
                return null;
            }
        }

        //---------------------------------------drill down for city , state and city
        public static List<Clusters> GetMapDrillDownByCountry(string code)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    const string query = "usp_GetMapDrillDownByCountry";
                    var param = new DynamicParameters();
                    //param.Add("@code", "'%" + code + "%'");
                    param.Add("@code", code);
                    return db.Query<Clusters>(query, param, commandType: CommandType.StoredProcedure).AsList();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.GetBaseException());
                return null;
            }
        }

        public static List<Clusters> GetMapDrillDownByCity(string city)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    const string query = "usp_GetMapDrillDownByCity";
                    var param = new DynamicParameters();
                    param.Add("@city", city);
                    return db.Query<Clusters>(query, param, commandType: CommandType.StoredProcedure).AsList();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.GetBaseException());
                return null;
            }
        }

        public static List<HealthMetrics> GetHealthMetricsByGateway()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    const string query = "usp_GetHealthMetricsByGateway";
                    return db.Query<HealthMetrics>(query, commandType: CommandType.StoredProcedure).AsList();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.GetBaseException());
                return null;
            }
        }


        public static List<HealthMetrics> GetHealthMetricsByCluster()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    const string query = "usp_GetHealthMetricsByCluster";
                    return db.Query<HealthMetrics>(query, commandType: CommandType.StoredProcedure).AsList();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.GetBaseException());
                return null;
            }
        }

        public static List<Alerts> GetAlertsStatus()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    const string query = "usp_GetCDNAnalyticsAlertsDetails";
                    return db.Query<Alerts>(query, commandType: CommandType.StoredProcedure).AsList();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.GetBaseException());
                return null;
            }
        }

        public static List<Clusters> GetAlertsDetailsByContainer(string container)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    const string query = "usp_GetAlertsDetailsByContainer";
                    var param = new DynamicParameters();
                    param.Add("@container", container);
                    return db.Query<Clusters>(query, param, commandType: CommandType.StoredProcedure).ToList();

                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.GetBaseException());
                return null;
            }
        }

        public static List<Chart> GetGatewayChart()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    const string query = "usp_GetGatewayChart";

                    return db.Query<Chart>(query, commandType: CommandType.StoredProcedure).ToList();

                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.GetBaseException());
                return null;
            }
        }

        public static List<Clusters> GetGatewayChartByList(int item)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    const string query = "usp_GetGatewayChartByList";
                    var param = new DynamicParameters();
                    param.Add("@item", item);
                    return db.Query<Clusters>(query, param, commandType: CommandType.StoredProcedure).ToList();

                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.GetBaseException());
                return null;
            }
        }

        public static List<HealthMetrics> GetHealthMetricsGatewayDetails(string gateway)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    const string query = "usp_GetHealthMetricsGatewayDetails";
                    var param = new DynamicParameters();
                    param.Add("@gateway", gateway);
                    return db.Query<HealthMetrics>(query, param, commandType: CommandType.StoredProcedure).AsList();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.GetBaseException());
                return null;
            }
        }
        public static List<Alerts> GetAlertsDetails(int severity)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    const string query = "select top (1500) case when severity=0 then 'Urgent' when severity=1 then 'Critical' when severity=2 then 'Major' when severity=3 then 'Minor' when severity=4 then 'Info'  end as severity, alert_Type,created, Container,Object,Message from alerts where severity=@severity  order by created desc";
                    var param = new DynamicParameters();
                    param.Add("@severity", severity);
                    return db.Query<Alerts>(query, param).ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.GetBaseException());
                return null;
            }
        }

        public static List<Clusters> GetServerUpgradationList(string region, int count, string cluster, string fp_version)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_DummyServerUpdateProc", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@region", region);
                    cmd.Parameters.AddWithValue("@days", count);
                    cmd.Parameters.AddWithValue("@cluster_name", cluster);
                    cmd.Parameters.AddWithValue("@fp_version", fp_version);
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds);
                    DataTable dt = new DataTable();
                    for (int i = 0; i < ds.Tables.Count; i++)
                        dt.Merge(ds.Tables[i]);
                    List<Clusters> li = new List<Clusters>();
                    Clusters obj_Clusters;
                    foreach (DataRow dr in dt.Rows)
                    {
                        obj_Clusters = new Clusters(); 
                        obj_Clusters.Cluster_Name = dr["cluster_name"].ToString();
                        obj_Clusters.Aname = dr["aname"].ToString();
                        obj_Clusters.Servers_ID = dr["servers_id"].ToString();
                        obj_Clusters.fp_version = dr["fp_version"].ToString();
                        obj_Clusters.Genesis = dr["Genesis"].ToString();
                        obj_Clusters.gateway = dr["gateway"].ToString();
                        obj_Clusters.Location = dr["Location"].ToString();
                        obj_Clusters.HostName = dr["hostname"].ToString();
                        obj_Clusters.serving_state = dr["serving_state"].ToString();
                        obj_Clusters.Layer = dr["layer"].ToString();
                        obj_Clusters.OS = dr["os"].ToString();
                        obj_Clusters.day_count = dr["Day_count"].ToString(); 
                        li.Add(obj_Clusters);
                    }
                    return li;
                }                
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.GetBaseException());
                return null;
            }
        }
        public static List<string> ExtractDecimalFromString(string str)
        {
            List<string> st = new List<string>();
            int i = 0;
            var sb = new StringBuilder();
            foreach (var c in str.Where(c => c == '.' || Char.IsDigit(c)))
            {

                sb.Append(c);
                if (i != 0)
                {
                    string v = sb.ToString();
                    st.Add(v);
                    i = 0;
                    sb = new StringBuilder();
                }
                if (c == '.')
                {
                    i++;
                }
            }
            return st;
        }        
        public static List<Clusters> GetServerUpgradationListADO(string region, int count, string cluster, string fp_version)
        {
            //Console.WriteLine(s);
            try
            {
                List<Clusters> list = new List<Clusters>();
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    string str = fp_version;
                    const string query = "HariSStoredProc";
                    //const string query = "usp_dummyValuesforClusters";
                    var param = new DynamicParameters();
                    param.Add("@region", region);
                    param.Add("@days", count);
                    param.Add("@cluster_name", cluster);
                    param.Add("@fp_version", fp_version);
                    List<string> li = ExtractDecimalFromString(fp_version);                    
                    string firstWord = fp_version.Split(' ').First();                    
                    string str1 = "";
                    int c = li.Count;
                    if (firstWord != "Not")
                    {
                        foreach (string st in li)
                        {
                            if (li[c - 1] == st)
                                str1 += "'" + st + "%'";
                            else
                                str1 += "'" + st + "%' or b.fp_version like ";
                        }
                    }
                    else
                    {
                        foreach (string st in li)
                        {
                            if (li[c - 1] == st)
                                str1 += "'" + st + "%'";
                            else
                                str1 += "'" + st + "%' or b.fp_version not like ";
                        }
                    }
                
                    param.Add("@fp1", str1);
                    list.AddRange(db.Query<Clusters>(query, param, commandType: CommandType.StoredProcedure).AsList());
                }
                //const string query = "HariSStoredProc";
                //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString);
                //SqlCommand cmd = new SqlCommand(query, conn);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@region", region);
                //cmd.Parameters.AddWithValue("@days", count);
                //cmd.Parameters.AddWithValue("@cluster_name", cluster);
                //cmd.Parameters.AddWithValue("@fp_version", fp_version);
                //List<string> li = ExtractDecimalFromString(fp_version);
                //string str1 = "";
                //int c = li.Count;
                //foreach (string st in li)
                //{
                //    if (li[c - 1] == st)
                //        str1 += "'" + st + "%'";
                //    else
                //        str1 += "'" + st + "%' or b.fp_version like ";
                //}
                //conn.Open();
                //cmd.Parameters.AddWithValue("@fp1", str1);
                //DataTable dt = new DataTable();
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //da.Fill(dt);
                //List<DataRow> list1 = dt.AsEnumerable().ToList();                
                return list;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.GetBaseException());
                return null;
            }
        }

        public static List<Clusters> GetServerUpgradationDetails()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    const string query = "usp_ServerUpgradation";                    
                    return db.Query<Clusters>(query, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.GetBaseException());
                return null;
            }
        }
    }
}