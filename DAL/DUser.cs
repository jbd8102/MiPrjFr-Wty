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
    /// User DAL
    /// </summary>
    public class DUser : IDUser
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
        /// Get list of user
        /// </summary>
        /// <returns>List of user</returns>
        public List<EUser> GetListOfUsers()
        {
            List<EUser> vListUsers = null;
            string vKey = "GetListOfUsers";

            try
            {
                // Get list from cache
                vListUsers = MemoryCache.Default[vKey] as List<EUser>;

                // Get list from data source
                if (vListUsers == null)
                {
                    vListUsers = DataSource.GetListOfUsers();
                }
            }
            catch (Exception vException)
            {
                throw vException;
            }

            return vListUsers;
        }

        /// <summary>
        /// Get list of user
        /// </summary>
        /// <param name="pFileName">File name</param>
        /// <returns>List of user</returns>
        public List<EUser> GetListOfUsers(string pFileName)
        {
            List<EUser> vListUsers = null;
            string vKey = $"GetListOfUsers_{ pFileName }";

            try
            {
                // Get list from cache
                vListUsers = MemoryCache.Default[vKey] as List<EUser>;

                // Get list from data source
                if (vListUsers == null)
                {
                    vListUsers = DataSource.GetListOfUsers(pFileName);
                }
            }
            catch (Exception vException)
            {
                throw vException;
            }

            return vListUsers;
        }
    }
}
