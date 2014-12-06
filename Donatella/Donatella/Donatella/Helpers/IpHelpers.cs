using System.Web;

namespace Donatella.Helpers
{
    public class IpHelpers
    {
        public static string GetIp(HttpRequestBase request)
        {
            if (!string.IsNullOrEmpty(request.UserHostAddress))
                return request.UserHostAddress;

            var ip = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ip))
            {
                var ipRange = ip.Split(',');
                var le = ipRange.Length - 1;
                ip = ipRange[le];
            }
            else
            {
                ip = request.ServerVariables["REMOTE_ADDR"];
            }

            return ip;
        }
    }
}