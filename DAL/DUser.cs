using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            try
            {
                vListUsers = DataSource.GetListOfUsers();
            }
            catch (Exception vException)
            {
                throw vException;
            }

            return vListUsers;
        }

        /// <summary>
        /// Get user by matricule
        /// </summary>
        /// <param name="pMatricule"></param>
        /// <returns>User entity</returns>
        public EUser GetUserByMatricule(string pMatricule)
        {
            EUser vEUser = null;
            List<EUser> vListUsers = null;

            try
            {
                vListUsers = this.GetListOfUsers();
                vEUser = vListUsers.Single(s => s.Matricule == pMatricule);
            }
            catch (Exception vException)
            {
                throw vException;
            }

            return vEUser;
        }
    }
}
