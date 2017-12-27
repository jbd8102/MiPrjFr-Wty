﻿using System;
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
        /// Get user by matricule
        /// </summary>
        /// <returns>EUser</returns>
        EUser GetUserByMatricule(string pMatricule);
    }
}
