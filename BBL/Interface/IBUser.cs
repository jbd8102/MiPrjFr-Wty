using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.WhoIs.CDL;

namespace Demo.WhoIs.BLL
{
    /// <summary>
    /// Interface user business
    /// </summary>
    public interface IBUser
    {
        /// <summary>
        /// Get all user
        /// </summary>
        /// <returns>List of user</returns>
        List<EUser> GetListOfUsers();

        List<EUser> GetListOfUsers(string pFileName);

        /// <summary>
        /// Get user by matricule
        /// </summary>
        /// <param name="pMatricule">Matricule of user</param>
        /// <param name="pFileName">file name of data</param>
        /// <returns>EUser</returns>
        EUser GetUserByMatricule(string pMatricule, string pFileName);

        /// <summary>
        /// Search users by criteria
        /// </summary>
        /// <param name="pCodeAgence">Code of agence</param>
        /// <param name="pName">User first name</param>
        /// <param name="pFileName">File name of data</param>
        /// <returns>List of user</returns>
        List<EUser> SearchUsersByCriteria(string pCodeAgence, string pName, string pFileName);
    }
}
