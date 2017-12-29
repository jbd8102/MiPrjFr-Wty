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

        private IBEmployee _EmployeeService;
        /// <summary>
        /// Employee business
        /// </summary>
        public IBEmployee EmployeeService
        {
            get
            {
                if (_EmployeeService == null)
                {
                    _EmployeeService = new BEmployee();
                }

                return _EmployeeService;
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
            EEmployee vEEmployee = null;
            EAgence vEAgence = null;

            if (!string.IsNullOrEmpty(this.MatriculeEmployee))
            {
                vEEmployee = EmployeeService.GetEmployeeByMatricule(this.MatriculeEmployee, _Default.GetEmployeeXmlPath());

                if(vEEmployee != null)
                {
                    // Get agence
                    vEAgence = AgenceService.GetAgenceByCode(vEEmployee.AgenceCode, _Default.GetAgenceXmlPath());
                    if (vEAgence != null)
                    {
                        lblAgenceValue.Text = vEAgence.Libelle;
                    }
                    
                    lblMatriculeValue.Text = vEEmployee.Matricule;
                    lblFirstNameValue.Text = vEEmployee.Nom;
                    lblLastNameValue.Text = vEEmployee.Prenom;
                    lblPhoneValue.Text = vEEmployee.Telephone;
                    lblEmailValue.Text = vEEmployee.Email;
                    lblIsActifValue.Text = vEEmployee.IsActif ? "OUI" : "NON";
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