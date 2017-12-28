using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.WhoIs.CDL;

namespace Demo.WhoIs.DAL
{
    /// <summary>
    /// Interface agence DAL
    /// </summary>
    public interface IDAgence
    {
        /// <summary>
        /// Get all agence
        /// </summary>
        /// <returns>List of agence</returns>
        List<EAgence> GetListOfAgences();

        /// <summary>
        /// Get all agence
        /// </summary>
        /// <param name="pFileName">File name</param>
        /// <returns>List of agence</returns>
        List<EAgence> GetListOfAgences(string pFileName);
    }
}
