using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using Demo.WhoIs.CDL;
using Demo.WhoIs.DataMock;

namespace Demo.WhoIs.DAL
{
    /// <summary>
    /// Employee DAL
    /// </summary>
    public class DEmployee : IDEmployee
    {
        private IDataSource _dataSource;

        /// <summary>
        /// Instance of DataSource
        /// </summary>
        public IDataSource DataSource
        {
            get
            {
                if (_dataSource == null)
                {
                    _dataSource = new DataSource();
                }

                return _dataSource;
            }
        }

        /// <summary>
        /// Get list of Employee
        /// </summary>
        /// <returns>List of Employee</returns>
        public List<EEmployee> GetListOfEmployees()
        {
            List<EEmployee> vListEmployees = null;
            string vKey = "GetListOfEmployees";

            try
            {
                // Get list from cache
                vListEmployees = MemoryCache.Default[vKey] as List<EEmployee>;

                // Get list from data source
                if (vListEmployees == null)
                {
                    vListEmployees = DataSource.GetListOfEmployees();
                }
            }
            catch (Exception vException)
            {
                throw vException;
            }

            return vListEmployees;
        }

        /// <summary>
        /// Get list of Employee
        /// </summary>
        /// <param name="pFileName">File name</param>
        /// <returns>List of Employee</returns>
        public List<EEmployee> GetListOfEmployees(string pFileName)
        {
            List<EEmployee> vListEmployees = null;
            string vKey = $"GetListOfEmployees_{ pFileName }";

            try
            {
                // Get list from cache
                vListEmployees = MemoryCache.Default[vKey] as List<EEmployee>;

                // Get list from data source
                if (vListEmployees == null)
                {
                    vListEmployees = DataSource.GetListOfEmployees(pFileName);
                }
            }
            catch (Exception vException)
            {
                throw vException;
            }

            return vListEmployees;
        }
    }
}
