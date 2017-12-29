using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.WhoIs.DataMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.WhoIs.CDL;

namespace Demo.WhoIs.DataMock.Tests
{
    [TestClass()]
    public class DataSourceTests
    {
        [TestMethod()]
        public void GetListOfAgencesTest()
        {
            IDataSource vDataSource = new DataSource();
            List<EAgence> vList = null;

            vList = vDataSource.GetListOfAgences();
            Assert.IsTrue(vList != null && vList.Count > 0);
        }

        [TestMethod()]
        public void GetListOfEmployeesTest()
        {
            IDataSource vDataSource = new DataSource();
            List<EEmployee> vList = null;

            vList = vDataSource.GetListOfEmployees();
            Assert.IsTrue(vList != null && vList.Count > 0);
        }
    }
}