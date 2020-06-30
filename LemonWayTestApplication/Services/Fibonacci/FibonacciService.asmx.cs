using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace LemonWayTestApplication.Services.Fibonacci
{
    /// <summary>
    /// Description résumée de FibonacciService
    /// </summary>
    [WebService(Namespace = "http://lemonway.com/webservices")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class FibonacciService : WebService, IFibonacciService
    {
        [WebMethod]
        public int Fibonacci(int n)
        {
            if (n == 1) return 1;
            if (n > 100 || n <= 0) return -1;
            var b = 0;
            var c = 1;
            for (var i = 2; i <= n; i++)
            {
                var a = b + c;
                b = c;
                c = a;
            };
            return c;
        }
    }
}
