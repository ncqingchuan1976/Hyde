using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;
namespace Hyde.Api.Filters
{
    /// <summary>
    /// 筛选器，判断模型是否通过验证规则
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class InvalidModelStateFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                var result = actionContext.ModelState.Values.SelectMany(t => t.Errors, (p, t) => t.ErrorMessage);
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, result);
            }

        }
    }
}