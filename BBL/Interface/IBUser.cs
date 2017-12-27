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

        /// <summary>
        /// Get user by matricule
        /// </summary>
        /// <returns>EUser</returns>
        EUser GetUserByMatricule(string pMatricule);

        /// <summary>
        /// Search users by criteria
        /// </summary>
        /// <param name="pCodeAgence">Code of agence</param>
        /// <param name="pFirstName">User first name</param>
        /// <returns></returns>
        List<EUser> SearchUsersByCriteria(string pCodeAgence, string pFirstName);
    }
}
