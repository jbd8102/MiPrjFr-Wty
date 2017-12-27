using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.WhoIs.CDL
{
    /// <summary>
    /// Entity User
    /// </summary>
    public class EUser
    {
        /// <summary>
        /// Numero matricule
        /// </summary>
        public string Matricule { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string Prenom { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Code agence of attachment
        /// </summary>
        public string AgenceCode { get; set; }

        /// <summary>
        /// Flag is actif
        /// </summary>
        public bool IsActif { get; set; }
    }
}
