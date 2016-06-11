using System.Web;
using System.Web.Mvc;

namespace LABMVC07_EvaluacionParametros
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
