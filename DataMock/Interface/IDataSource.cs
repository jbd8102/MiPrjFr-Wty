using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.WhoIs.CDL;

namespace Demo.WhoIs.DataMock
{
    /// <summary>
    /// Interface of data source
    /// </summary>
    public interface IDataSource
    {
        /// <summary>
        /// Get all agence
        /// </summary>
        /// <returns></returns>
        List<EAgence> GetListOfAgences();

        /// <summary>
        /// Get all user
        /// </summary>
        /// <returns></returns>
        List<EUser> GetListOfUsers();
    }
}
