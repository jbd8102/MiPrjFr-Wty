using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.WhoIs.CDL;
using Demo.WhoIs.DAL;

namespace Demo.WhoIs.BLL
{
    /// <summary>
    /// User BLL
    /// </summary>
    public class BUser : IBUser
    {
        private IDUser _dac;

        /// <summary>
        /// Instance of DataSource
        /// </summary>
        public IDUser Dac
        {
            get
            {
                if (_dac == null)
                {
                    _dac = new DUser();
                }

                return _dac;
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
                vListUsers = Dac.GetListOfUsers();
            }
            catch (Exception vException)
            {
                throw vException;
            }

            return vListUsers;
        }

        /// <summary>
        /// Search users by criteria
        /// </summary>
        /// <param name="pCodeAgence">Code of agence</param>
        /// <param name="pName">User first name</param>
        /// <returns></returns>
        public List<EUser> SearchUsersByCriteria(string pCodeAgence, string pName)
        {
            EUser vEUser = null;
            List<EUser> vListUsers = null;

            try
            {
                // Get all user
                vListUsers = Dac.GetListOfUsers();

                // Filter by criteria
                var vResultat = from user in vListUsers
                                where ((!"0".Equals(pCodeAgence) && user.AgenceCode == pCodeAgence) || "0".Equals(pCodeAgence)) &&
                                      ((!string.IsNullOrEmpty(pName) && user.Nom.ToLower().Contains(pName.ToLower())) ||
                                        (!string.IsNullOrEmpty(pName) && user.Prenom.ToLower().Contains(pName.ToLower())) ||
                                        string.IsNullOrEmpty(pName))
                                select new
                                {
                                    Matricule = user.Matricule,
                                    Nom = user.Nom,
                                    Prenom = user.Prenom,
                                    Telephone = user.Telephone,
                                    Email = user.Email,
                                    AgenceCode = user.AgenceCode,
                                    IsActif = user.IsActif
                                };

                // Cast
                vListUsers = new List<EUser>();
                foreach (var user in vResultat)
                {
                    vEUser = new EUser();

                    vEUser.Matricule = user.Matricule;
                    vEUser.Nom = user.Nom;
                    vEUser.Prenom = user.Prenom;
                    vEUser.Telephone = user.Telephone;
                    vEUser.Email = user.Email;
                    vEUser.AgenceCode = user.AgenceCode;
                    vEUser.IsActif = user.IsActif;

                    vListUsers.Add(vEUser);
                }
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

            try
            {
                vEUser = Dac.GetUserByMatricule(pMatricule);
            }
            catch (Exception vException)
            {
                throw vException;
            }

            return vEUser;
        }
    }
}
