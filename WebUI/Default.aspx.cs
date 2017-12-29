using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Demo.WhoIs.BLL;
using Demo.WhoIs.CDL;

namespace Demo.WhoIs.WebUI
{
    public partial class _Default : Page
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

        #endregion

        #region Methods

        /// <summary>
        /// Bind list of agence
        /// </summary>
        private void BindListAgences()
        {
            List<EAgence> vListAgences = null;
            string vFileName = string.Empty;

            try
            {
                vFileName = _Default.GetAgenceXmlPath();
                vListAgences = AgenceService.GetListOfAgences(vFileName);

                // TODO : test to delete
                //vListAgences = AgenceService.GetListOfAgences();

                ddlAgence.DataSource = vListAgences;
                ddlAgence.DataValueField = "Code";
                ddlAgence.DataTextField = "Libelle";
                ddlAgence.DataBind();
            }
            catch (Exception vException)
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                        "alert('" + vException.Message.Replace("'", @"\'").Replace("`", @"\'").Replace("’", @"\'") + "');", true);
            }
        }

        /// <summary>
        /// Get list of Employee to display
        /// </summary>
        private void BindListEmployees()
        {
            List<EEmployee> vListEmployees = null;
            string vFileName = string.Empty;

            try
            {
                vFileName = _Default.GetEmployeeXmlPath();
                vListEmployees = EmployeeService.GetListOfEmployees(vFileName);

                // TODO : test to delete
                //vListEmployees = EmployeeService.GetListOfEmployees();

                rpEmployees.DataSource = vListEmployees;
                rpEmployees.DataBind();
            }
            catch (Exception vException)
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                        "alert('" + vException.Message.Replace("'", @"\'").Replace("`", @"\'").Replace("’", @"\'") + "');", true);
            }
        }

        /// <summary>
        /// Search Employee by criteria
        /// </summary>
        private void SearchEmployee()
        {
            List<EEmployee> vListEmployees = null;
            string vFileName = string.Empty;

            try
            {
                vFileName = _Default.GetEmployeeXmlPath();
                vListEmployees = EmployeeService.SearchEmployeesByCriteria(ddlAgence.SelectedValue, txtName.Text, vFileName);

                rpEmployees.DataSource = vListEmployees;
                rpEmployees.DataBind();
            }
            catch (Exception vException)
            {
                throw vException;
            }
        }

        /// <summary>
        /// Get path of data source
        /// </summary>
        /// <returns>Path</returns>
        private static string GetXmlPath()
        {
            return HttpContext.Current.Server.MapPath(System.Web.HttpRuntime.AppDomainAppVirtualPath + TConstants.SXmlPath);
        }

        /// <summary>
        /// Get file name of Employee data
        /// </summary>
        /// <returns>Filename</returns>
        public static string GetEmployeeXmlPath()
        {
            return string.Format("{0}\\ListEmployees.xml", _Default.GetXmlPath());
        }

        /// <summary>
        /// Get file name of agence data
        /// </summary>
        /// <returns>Filename</returns>
        public static string GetAgenceXmlPath()
        {
            return string.Format("{0}\\ListAgences.xml", _Default.GetXmlPath());
        }

        #endregion

        #region Events

        /// <summary>
        /// Event load page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack == false)
            {
                BindListAgences();
                BindListEmployees();
            }
        }

        /// <summary>
        /// Display Employee information
        /// </summary>
        /// <param name="sender">Button object</param>
        /// <param name="e">Event</param>
        protected void imgInformation_Click(object sender, ImageClickEventArgs e)
        {
            string vMatricule = string.Empty;
            string vFunctionJS = string.Empty;

            try
            {
                vFunctionJS = "javascript:OpenJQueryModalDialog('pnlEmployeeDetails', 'Informations du collaborateur');";
                vMatricule = (sender as ImageButton).Attributes["name"];
                this.ucEmployeeDetails.MatriculeEmployee = vMatricule;
                this.ucEmployeeDetails.UpdateEmployeeInformation();
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "SCRIPT_imgInformation_Click", vFunctionJS, true);
            }
            catch (Exception vException)
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                        "alert('" + vException.Message.Replace("'", @"\'").Replace("`", @"\'").Replace("’", @"\'") + "');", true);
            }
        }

        /// <summary>
        /// Employee search
        /// </summary>
        /// <param name="sender">Button object</param>
        /// <param name="e">Event</param>
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                SearchEmployee();
            }
            catch (Exception vException)
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                        "alert('" + vException.Message.Replace("'", @"\'").Replace("`", @"\'").Replace("’", @"\'") + "');", true);
            }
        }

        /// <summary>
        /// Data bound for repeater
        /// </summary>
        /// <param name="sender">Repeater object</param>
        /// <param name="e">Event</param>
        protected void rpEmployees_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            EEmployee vEEmployee = null;

            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    vEEmployee = (EEmployee)e.Item.DataItem;

                    (e.Item.FindControl("lblMatricule") as Label).Text = vEEmployee.Matricule;
                    (e.Item.FindControl("lblNomPrenom") as Label).Text = $"{vEEmployee.Prenom} {vEEmployee.Nom}";
                    (e.Item.FindControl("imgInformation") as ImageButton).Attributes.Add("name", vEEmployee.Matricule);
                    (e.Item.FindControl("lblIsActif") as Label).Text = vEEmployee.IsActif ? "OUI" : "NON";

                }
            }
            catch(Exception vException)
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                        "alert('" + vException.Message.Replace("'", @"\'").Replace("`", @"\'").Replace("’", @"\'") + "');", true);
            }
        }

        #endregion
    }
}