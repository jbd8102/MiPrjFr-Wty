using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Demo.WhoIs.BLL;
using Demo.WhoIs.CDL;

namespace Demo.WhoIs.WebUI.Controls
{
    public partial class ucEmployeeDetails : System.Web.UI.UserControl
    {
        #region Property

        private IBAgence _agenceService;
        /// <summary>
        /// Agence business
        /// </summary>
        public IBAgence AgenceService
        {
            get
            {
                if (_agenceService == null)
                {
                    _agenceService = new BAgence();
                }

                return _agenceService;
            }
        }

        private IBUser _userService;
        /// <summary>
        /// User business
        /// </summary>
        public IBUser UserService
        {
            get
            {
                if (_userService == null)
                {
                    _userService = new BUser();
                }

                return _userService;
            }
        }

        /// <summary>
        /// Matricule employee
        /// </summary>
        public string MatriculeEmployee { get; set; }

        #endregion

        #region Methods

        public void UpdateEmployeeInformation()
        {
            EUser vEUser = null;
            EAgence vEAgence = null;

            if (!string.IsNullOrEmpty(this.MatriculeEmployee))
            {
                vEUser = UserService.GetUserByMatricule(this.MatriculeEmployee);

                if(vEUser != null)
                {
                    // Get agence
                    vEAgence = AgenceService.GetAgenceByCode(vEUser.AgenceCode);
                    if (vEAgence != null)
                    {
                        lblAgenceValue.Text = vEAgence.Libelle;
                    }
                    
                    lblMatriculeValue.Text = vEUser.Matricule;
                    lblFirstNameValue.Text = vEUser.Nom;
                    lblLastNameValue.Text = vEUser.Prenom;
                    lblPhoneValue.Text = vEUser.Telephone;
                    lblEmailValue.Text = vEUser.Email;
                    lblIsActifValue.Text = vEUser.IsActif ? "OUI" : "NON";
                }
            }
        }

        /// <summary>
        /// Clear employee data
        /// </summary>
        private void ClearEmployeeInformation()
        {
            lblAgenceValue.Text = "";
            lblMatriculeValue.Text = "";
            lblFirstNameValue.Text = "";
            lblLastNameValue.Text = "";
            lblPhoneValue.Text = "";
            lblEmailValue.Text = "";
            lblIsActifValue.Text = "";
        }

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateEmployeeInformation();
        }
        
        #endregion
    }
}