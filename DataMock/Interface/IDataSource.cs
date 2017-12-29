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
        /// <returns>List of agence</returns>
        List<EAgence> GetListOfAgences();

        /// <summary>
        /// Get all agence
        /// </summary>
        /// <param name="pFileName">File name</param>
        /// <returns>List of agence</returns>
        List<EAgence> GetListOfAgences(string pFileName);

        /// <summary>
        /// Get all Employee
        /// </summary>
        /// <returns>List of Employee</returns>
        List<EEmployee> GetListOfEmployees();

        /// <summary>
        /// Get all Employee
        /// </summary>
        /// <param name="pFileName">File name</param>
        /// <returns>List of Employee</returns>
        List<EEmployee> GetListOfEmployees(string pFileName);
    }
}
