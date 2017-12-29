using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.WhoIs.CDL;

namespace Demo.WhoIs.DAL
{
    /// <summary>
    /// Interface Employee DAL
    /// </summary>
    public interface IDEmployee
    {
        /// <summary>
        /// Get all Employee
        /// </summary>
        /// <returns>List of Employee</returns>
        List<EEmployee> GetListOfEmployees();
        
        /// <summary>
        /// Get all Employee from specific file data
        /// </summary>
        /// <param name="pFileName"></param>
        /// <returns></returns>
        List<EEmployee> GetListOfEmployees(string pFileName);
    }
}
