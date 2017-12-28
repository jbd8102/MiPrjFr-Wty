using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.WhoIs.CDL;

namespace Demo.WhoIs.DAL
{
    /// <summary>
    /// Interface user DAL
    /// </summary>
    public interface IDUser
    {
        /// <summary>
        /// Get all user
        /// </summary>
        /// <returns>List of user</returns>
        List<EUser> GetListOfUsers();
        
        /// <summary>
        /// Get all user from specific file data
        /// </summary>
        /// <param name="pFileName"></param>
        /// <returns></returns>
        List<EUser> GetListOfUsers(string pFileName);
    }
}
