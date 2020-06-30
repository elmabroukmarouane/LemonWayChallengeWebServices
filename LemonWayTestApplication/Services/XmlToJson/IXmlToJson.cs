using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;

namespace LemonWayTestApplication.Services.XmlToJson
{
    interface IXmlToJson
    {
        [WebMethod]
        string XmlToJson(string xml);
    }
}
