using System.Web;
using System.Web.Mvc;

namespace EXA_M03_JULIO_CAYAX
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
