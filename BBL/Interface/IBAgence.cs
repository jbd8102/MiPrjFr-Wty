using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.WhoIs.CDL;

namespace Demo.WhoIs.BLL
{
    /// <summary>
    /// Interface agence business
    /// </summary>
    public interface IBAgence
    {
        /// <summary>
        /// Get all agence
        /// </summary>
        /// <returns>List of agence</returns>
        List<EAgence> GetListOfAgences();

        /// <summary>
        /// Get agence by code
        /// </summary>
        /// <returns>Agence</returns>
        EAgence GetAgenceByCode(string pCode);
    }
}
