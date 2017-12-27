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
    /// Agence DAL
    /// </summary>
    public class BAgence : IBAgence
    {
        private IDAgence _dac;

        /// <summary>
        /// Instance of DataSource
        /// </summary>
        public IDAgence Dac
        {
            get
            {
                if (_dac == null)
                {
                    _dac = new DAgence();
                }

                return _dac;
            }
        }        

        /// <summary>
        /// Get list of agence
        /// </summary>
        /// <returns>List of agence</returns>
        public List<EAgence> GetListOfAgences()
        {
            List<EAgence> vListAgences = null;

            try
            {
                vListAgences = Dac.GetListOfAgences();
            }
            catch (Exception vException)
            {
                throw vException;
            }

            return vListAgences;            
        }

        /// <summary>
        /// Get agence by code
        /// </summary>
        /// <returns>Agence entity</returns>
        public EAgence GetAgenceByCode(string pCode)
        {
            EAgence vEAgence = null;

            try
            {
                vEAgence = Dac.GetAgenceByCode(pCode);
            }
            catch (Exception vException)
            {
                throw vException;
            }

            return vEAgence;
        }
    }
}
