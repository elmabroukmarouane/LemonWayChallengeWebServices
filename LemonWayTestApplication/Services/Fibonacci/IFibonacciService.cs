using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;

namespace LemonWayTestApplication.Services.Fibonacci
{
    interface IFibonacciService
    {
        [WebMethod]
        int Fibonacci(int n);
    }
}
