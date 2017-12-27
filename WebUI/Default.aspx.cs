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

        #endregion

        #region Methods

        /// <summary>
        /// Bind list of agence
        /// </summary>
        private void BindListAgences()
        {
            List<EAgence> vListAgences = null;

            try
            {
                vListAgences = AgenceService.GetListOfAgences();

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
        /// Get list of user to display
        /// </summary>
        private void BindListUsers()
        {
            List<EUser> vListUsers = null;

            try
            {
                vListUsers = UserService.GetListOfUsers();

                rpUsers.DataSource = vListUsers;
                rpUsers.DataBind();
            }
            catch (Exception vException)
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                        "alert('" + vException.Message.Replace("'", @"\'").Replace("`", @"\'").Replace("’", @"\'") + "');", true);
            }
        }

        /// <summary>
        /// Search user by criteria
        /// </summary>
        private void SearchUser()
        {
            List<EUser> vListUsers = null;

            try
            {
                vListUsers = UserService.SearchUsersByCriteria(ddlAgence.SelectedValue, txtName.Text);

                rpUsers.DataSource = vListUsers;
                rpUsers.DataBind();
            }
            catch (Exception vException)
            {
                throw vException;
            }
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
                BindListUsers();
            }
        }

        /// <summary>
        /// Display user information
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
        /// User search
        /// </summary>
        /// <param name="sender">Button object</param>
        /// <param name="e">Event</param>
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                SearchUser();
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
        protected void rpUsers_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            EUser vEUser = null;

            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    vEUser = (EUser)e.Item.DataItem;

                    (e.Item.FindControl("lblMatricule") as Label).Text = vEUser.Matricule;
                    (e.Item.FindControl("lblNomPrenom") as Label).Text = $"{vEUser.Prenom} {vEUser.Nom}";
                    (e.Item.FindControl("imgInformation") as ImageButton).Attributes.Add("name", vEUser.Matricule);
                    (e.Item.FindControl("lblIsActif") as Label).Text = vEUser.IsActif ? "OUI" : "NON";

                }
            }
            catch(Exception vException)
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                        "alert('" + vException.Message.Replace("'", @"\'").Replace("`", @"\'").Replace("’", @"\'") + "');", true);
            }
        }

        #endregion

        #region Methods

        #endregion

       
    }
}