using System.Web;
using System.Web.Mvc;

namespace GetAspWebApi_Sql_data
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
