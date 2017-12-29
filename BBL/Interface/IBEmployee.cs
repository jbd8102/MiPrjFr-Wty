using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.WhoIs.CDL;

namespace Demo.WhoIs.BLL
{
    /// <summary>
    /// Interface Employee business
    /// </summary>
    public interface IBEmployee
    {
        /// <summary>
        /// Get all Employee
        /// </summary>
        /// <returns>List of Employee</returns>
        List<EEmployee> GetListOfEmployees();

        List<EEmployee> GetListOfEmployees(string pFileName);

        /// <summary>
        /// Get Employee by matricule
        /// </summary>
        /// <param name="pMatricule">Matricule of Employee</param>
        /// <param name="pFileName">file name of data</param>
        /// <returns>EEmployee</returns>
        EEmployee GetEmployeeByMatricule(string pMatricule, string pFileName);

        /// <summary>
        /// Search Employees by criteria
        /// </summary>
        /// <param name="pCodeAgence">Code of agence</param>
        /// <param name="pName">Employee first name</param>
        /// <param name="pFileName">File name of data</param>
        /// <returns>List of Employee</returns>
        List<EEmployee> SearchEmployeesByCriteria(string pCodeAgence, string pName, string pFileName);
    }
}
