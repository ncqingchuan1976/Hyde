using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Routing;
using System.Net.Http;
using System.Web.Http;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Hyde.Api.Constraint
{
    public class OptionalRegExConstraint : IHttpRouteConstraint
    {
        private readonly string _regEx;
        public OptionalRegExConstraint(string expression)
        {
            if (string.IsNullOrEmpty(expression))
            {
                throw new ArgumentNullException("expression");
            }
            _regEx = expression;
        }
        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values, HttpRouteDirection routeDirection)
        {

            if (values[parameterName] != RouteParameter.Optional)
            {
                object value;
                values.TryGetValue(parameterName, out value);
                string pattern = "^(" + _regEx + ")$";
                string input = Convert.ToString(value, CultureInfo.InvariantCulture);
                return Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
            }
            return true;
        }
    }
}