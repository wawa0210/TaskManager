using System;
using System.Threading.Tasks;
using CommonLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DoGetTest()
        {
            var resuestUrl = "https://api.blockcomet.com/v0/news?pageSize=16&versionId=V24NV0&currentPage=2";
            var result =  resuestUrl.DoGetAsync(null).GetAwaiter().GetResult();
            var count = 0;

        }
    }
}
