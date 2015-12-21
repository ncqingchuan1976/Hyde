using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Routing;
using System.Web.Http.Dispatcher;
using System.Net.Http;
using System.Net;
using System.Threading;
using System.Threading.Tasks;


namespace Hyde.Api.Dispatcher
{
    public class SupplyDispatcher : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if(request.Method.Method=="Post")
            {
                request.CreateResponse(HttpStatusCode.OK);
            }

            
            //IHttpRouteData routeData = request.GetRouteData();

            //var Controller = routeData.Values.SingleOrDefault(t => t.Key.CompareTo("controller") == 0).Value;

            //if (Controller != null)
            //{
            //    switch (Controller.ToString())
            //    {
            //        case "Supply":

            //            break;
            //        default:
            //            break;
            //    }
            //}


            return base.SendAsync(request, cancellationToken);
        }
        //private bool Exists(int ID)
        //{
        //    using (var DAL = Factory.GetProvider<ISupplyDAL>())
        //    {
        //        return DAL.Exist(ID);
        //    }
        //}

        //private Task<HttpResponseMessage> CheckSupplyCode(HttpRequestMessage request, int ID)
        //{

            
        //    if (Exists(ID))
        //        return Task.FromResult(request.CreateResponse(HttpStatusCode.NotFound, new OperateResult<int>(OPERATE_STATE.NOT_IN_RANGE, OPERATE_STATE.NOT_IN_RANGE.ToString(), ID)));
        //    return null;

        //}
    }
}