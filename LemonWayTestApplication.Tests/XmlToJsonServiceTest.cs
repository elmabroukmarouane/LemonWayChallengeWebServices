using System;
using LemonWayTestApplication.Services.XmlToJson;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LemonWayTestApplication.Tests
{
    [TestClass]
    public class XmlToJsonServiceTest
    {
        [TestMethod]
        public void XmlToJson_Xml_Output_IsEqual()
        {
            var xmlToJsonService = new XmlToJsonService();
            var xml = "<TRANS><HPAY><ID>103</ID><STATUS>3</STATUS><EXTRA><IS3DS>0</IS3DS><AUTH>031183</AUTH></EXTRA><INT_MSG/><MLABEL>501767XXXXXX6700</MLABEL><MTOKEN>project01</MTOKEN></HPAY></TRANS>";
            var json = "{\"TRANS\":{\"HPAY\":{\"ID\":\"103\",\"STATUS\":\"3\",\"EXTRA\":{\"IS3DS\":\"0\",\"AUTH\":\"031183\"},\"INT_MSG\":null,\"MLABEL\":\"501767XXXXXX6700\",\"MTOKEN\":\"project01\"}}}";
            Assert.IsTrue(xmlToJsonService.XmlToJson(xml).Equals(json));
        }
    }
}
