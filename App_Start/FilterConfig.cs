using System.Web;
using System.Web.Mvc;

namespace kirillov_chat_api_api_api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
