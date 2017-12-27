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
            Assert.IsTrue(vList.Count > 0);
        }

        [TestMethod()]
        public void GetListOfUsersTest()
        {
            IDataSource vDataSource = new DataSource();
            List<EUser> vList = null;

            vList = vDataSource.GetListOfUsers();
            Assert.IsTrue(vList.Count > 0);
        }
    }
}