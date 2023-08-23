using Microsoft.AspNetCore.Http;

namespace SpeakHub.Service.Common.Helpers
{
    public class HttpContextHelper
    {
        public static IHttpContextAccessor? Accessor { get; set; }

        public static HttpResponse? Response => Accessor?.HttpContext?.Response;

        public static IHeaderDictionary? ResponseHeaders => Response!.Headers;

        public static HttpContext? HttpContext => Accessor?.HttpContext;

        public static int UserId => GetUserId();

        public static string UserRole => HttpContext?.User.FindFirst("http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value!;
        private static int GetUserId()
        {
            int id;
            bool canParse = int.TryParse(HttpContext?.User?.Claims.FirstOrDefault(p => p.Type == "Id")?.Value, out id);
            return canParse ? id : 0;
        }
    }
}
