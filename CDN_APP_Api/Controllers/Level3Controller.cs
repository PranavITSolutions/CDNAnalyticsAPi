using CDN_APP_Api.Repository;
using CDN_APP_Api.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CDN_APP_Api.Controllers
{
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class Level3Controller : ApiController
    {
        
        [Route("api/get/coordinates/list")]//w
        public HttpResponseMessage GetCoordinates()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_001", "Success", Level3Repository.GetCoordinatesList()));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_101", "Application Error", exception.Message));
            }
            return response;
        }
        
        [Route("api/get/clusters/list")]//w
        public HttpResponseMessage GetCoordinatesByServerID()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_001", "Success", Level3Repository.GetClusterDetails()));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_101", "Application Error", exception.Message));
            }
            return response;
        }
        
        [Route("api/get/servers/cluster/{cluster?}")]
        public HttpResponseMessage GetServerDetailsByCluster(string cluster)
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_001", "Success", Level3Repository.GetServerDetailsByCluster(cluster)));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_101", "Application Error", exception.Message));
            }
            return response;
        }
        
        //-------------------------------------------Drilldown lists----------------------------------
        [Route("api/get/drilldown/clusters/list")]
        public HttpResponseMessage GetClustersInDrillDown()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_001", "Success", Level3Repository.GetClustersInDrillDown()));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_101", "Application Error", exception.Message));
            }
            return response;
        }
        
        [Route("api/get/drilldown/servers/list")]
        public HttpResponseMessage GetServersInDrillDown()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_001", "Success", Level3Repository.GetServersInDrillDown()));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_101", "Application Error", exception.Message));
            }
            return response;
        }

        [Route("api/get/drilldown/servers/active")]
        public HttpResponseMessage GetServersActiveInDrillDown()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_001", "Success", Level3Repository.GetServersActiveInDrillDown()));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_101", "Application Error", exception.Message));
            }
            return response;
        }
        
        [Route("api/get/drilldown/servers/inactive")]
        public HttpResponseMessage GetServersInctiveInDrillDown()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_001", "Success", Level3Repository.GetServersInactiveInDrillDown()));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_101", "Application Error", exception.Message));
            }
            return response;
        }

        ///---------------------------------------Widget Counts---------------------------------///

        [Route("api/get/all/widgets/count")]
        public HttpResponseMessage GetAllWidgetsCount()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_001", "Success", Level3Repository.GetAllWidgetsCount()));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_101", "Application Error", exception.Message));
            }
            return response;
        }


        [Route("api/get/count/clusters/list")]
        public HttpResponseMessage GetClustersInWidgetCount()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_001", "Success", Level3Repository.GetClustersInWidgetCount()));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_101", "Application Error", exception.Message));
            }
            return response;
        }

        [Route("api/get/count/servers/list")]
        public HttpResponseMessage GetServersInWidgetCount()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_001", "Success", Level3Repository.GetServersInWidgetCount()));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_101", "Application Error", exception.Message));
            }
            return response;
        }
        
        [Route("api/get/count/servers/active")]
        public HttpResponseMessage GetServersActiveInWidgetCount()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_001", "Success", Level3Repository.GetServersActiveInWidgetCount()));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_101", "Application Error", exception.Message));
            }
            return response;
        }
        
        [Route("api/get/count/servers/inactive")]
        public HttpResponseMessage GetServersInctiveInWidgetCount()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_001", "Success", Level3Repository.GetServersInactiveInWidgetCount()));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_101", "Application Error", exception.Message));
            }
            return response;
        }
        ///-------------------------------Server Counts By Region, State-------------------
        //-------------------------------Starts Here---------------------------------------//        

        [Route("api/get/countryleveldata")]
        public HttpResponseMessage GetServerCountDetailsByRegion()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_001", "Success", Level3Repository.GetServerCountDetailsByRegion()));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_101", "Application Error", exception.Message));
            }
            return response;
        }

        [Route("api/get/countryleveldata/{area?}")]
        public HttpResponseMessage GetCountryLevelDetailsByRegion(string area)
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_001", "Success", Level3Repository.GetCountryLevelDetailsByRegion(area)));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_101", "Application Error", exception.Message));
            }
            return response;
        }

        [Route("api/get/stateleveldata")]
        public HttpResponseMessage GetServerCountDetailsByState()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_001", "Success", Level3Repository.GetServerCountDetailsByState()));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_101", "Application Error", exception.Message));
            }
            return response;
        }

        [Route("api/get/stateleveldata/{state?}")]
        public HttpResponseMessage GetStateLevelDetailsByArea(string state)
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_001", "Success", Level3Repository.GetStateLevelDetailsByArea(state)));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_101", "Application Error", exception.Message));
            }
            return response;
        }

        [Route("api/get/cityleveldata")]
        public HttpResponseMessage GetServerCountDetailsByCity()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_001", "Success", Level3Repository.GetServerCountDetailsByCity()));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_101", "Application Error", exception.Message));
            }
            return response;
        }//

        [Route("api/get/cityleveldata/{city?}")]
        public HttpResponseMessage GetCityLevelDetailsInList(string city)
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_001", "Success", Level3Repository.GetCityLevelDetailsInList(city)));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_101", "Application Error", exception.Message));
            }
            return response;
        }

        //[Route("api/get/chart/counts")]
        [Route("api/get/chart/percentage")]
        public HttpResponseMessage GetChartCountPercentages()
        {
            HttpResponseMessage response = null;
            try//exception handling
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_001", "success", Level3Repository.GetChartCountPercentages()));
            }
            catch(Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_101", "Application Error", exception.Message));
            }
            return response;
        }

        [Route("api/get/chart/counts")]
        public HttpResponseMessage GetHealthPercentages()
        {
            HttpResponseMessage response = null;
            try//exception handling
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_001", "success", Level3Repository.GetHealthPercentages()));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_101", "Application Error", exception.Message));
            }
            return response;
        }
        //--------------------------------------------Drill down for map by city, state and country
        [Route("api/get/map/drilldown/country/{code?}")]
        public HttpResponseMessage GetMapDrillDownByCountry(string code)
        {
            HttpResponseMessage response = null;
            try//exception handling
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_001", "success", Level3Repository.GetMapDrillDownByCountry(code)));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_101", "Application Error", exception.Message));
            }
            return response;
        }

        [Route("api/get/healthmetrics/gateway")]
        public HttpResponseMessage GetHealthMetricsByGateway()
        {
            HttpResponseMessage response = null;
            try//exception handling
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_001", "success", Level3Repository.GetHealthMetricsByGateway()));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_101", "Application Error", exception.Message));
            }
            return response;
        }
        [Route("api/get/healthmetrics/cluster")]
        public HttpResponseMessage GetHealthMetricsByCluster()
        {
            HttpResponseMessage response = null;
            try//exception handling
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_001", "success", Level3Repository.GetHealthMetricsByCluster()));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_101", "Application Error", exception.Message));
            }
            return response;
        }

        [Route("api/get/alerts")]
        public HttpResponseMessage GetAlertsStatus()
        {
            HttpResponseMessage response = null;
            try//exception handling
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_001", "success", Level3Repository.GetAlertsStatus()));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_101", "Application Error", exception.Message));
            }
            return response;
        }
        [Route("api/get/alerts/{container?}")]
        public HttpResponseMessage GetAlertsDetailsByContainer(string container)
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_001", "Success", Level3Repository.GetAlertsDetailsByContainer(container)));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_101", "Application Error", exception.Message));
            }
            return response;
        }

        [Route("api/get/gateway")]
        public HttpResponseMessage GetGatewayChart()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_001", "Success", Level3Repository.GetGatewayChart()));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_101", "Application Error", exception.Message));
            }
            return response;
        }

        [Route("api/get/gateway/chart/details/{item?}")]
        public HttpResponseMessage GetGatewayChartByList(int item)
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_001", "Success", Level3Repository.GetGatewayChartByList(item)));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_101", "Application Error", exception.Message));
            }
            return response;
        }


        [Route("api/get/healthmetrics/gateway/{gateway?}")]
        public HttpResponseMessage GetHealthMetricsGatewayDetails(string gateway)
        {
            HttpResponseMessage response = null;
            try//exception handling
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_001", "success", Level3Repository.GetHealthMetricsGatewayDetails(gateway)));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_101", "Application Error", exception.Message));
            }
            return response;
        }
        [Route("api/get/alerts/details/{severity?}")]
        public HttpResponseMessage GetAlertsDetails(int severity)
        {
            HttpResponseMessage response = null;
            try//exception handling
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_001", "success", Level3Repository.GetAlertsDetails(severity)));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_101", "Application Error", exception.Message));
            }
            return response;
        }

        [Route("api/get/server/upgradation/{region?}/{count?}/{cluster?}/{fp_version?}")]
        [AllowAnonymous]
        public HttpResponseMessage GetServerUpgradationList(string region, int count, string cluster, string fp_version)
        {
            HttpResponseMessage response = null;
            try//exception handling
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_001", "success", Level3Repository.GetServerUpgradationList(region, count, cluster, fp_version)));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_101", "Application Error", exception.Message));
            }
            return response;
        }

        [Route("api/get/server/upgradation/details")]
        public HttpResponseMessage GetServerUpgradationDetails()
        {
            HttpResponseMessage response = null;
            try//exception handling
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_001", "success", Level3Repository.GetServerUpgradationDetails()));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.GetBaseException());
                response = Request.CreateResponse(HttpStatusCode.OK, new CLResponseMessage("CCA_101", "Application Error", exception.Message));
            }
            return response;
        }
    }
}