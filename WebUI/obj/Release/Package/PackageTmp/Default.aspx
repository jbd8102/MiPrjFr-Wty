<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Demo.WhoIs.WebUI._Default" %>
<%@ Register Src="~/Controls/ucEmployeeDetails.ascx" TagName="ucEmployeeDetails" TagPrefix="ucEmployeeDetails" %>
<%@ Import Namespace="Demo.WhoIs.WebUI.Controls" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Collaborateurs</h3>
    <div class="form-group">
        <label class="col-form-label" for="formGroupStructureRattachement">Structure de rattachement</label>
        <asp:DropDownList ID="ddlAgence" runat="server" CssClass="form-control" />
    </div>
    <div class="form-group">
        <label class="col-form-label" for="formGroupNom">Nom ou Prénom</label>
        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
    </div>
    <div class="form-group">
        <asp:Button ID="btnFilter" runat="server" Text="Filtrer" OnClick="btnFilter_Click" CssClass="btn btn-info" />
    </div>
    <br />
    <div>
        <asp:Repeater ID="rpUsers" runat="server" OnItemDataBound="rpUsers_ItemDataBound">
            <HeaderTemplate>
                <table class="table table-sm">
                    <tr>
                        <th scope="col">Matricule</th>
                        <th scope="col">Nom & Prénom</th>
                        <th scope="col">Actif</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="lblMatricule" runat="server" />
                        </td>
                        <td>
                            <asp:Label ID="lblNomPrenom" runat="server" />
                            <asp:ImageButton ID="imgInformation" OnClick="imgInformation_Click" runat="server" ImageUrl="~/Images/InfoGray.png"/>
                        </td>
                        <td>
                            <asp:Label ID="lblIsActif" runat="server" />
                        </td>
                    </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <div>
        <div id="pnlEmployeeDetails" class="notDisplayed">
            <ucEmployeeDetails:ucEmployeeDetails ID="ucEmployeeDetails" runat="server" />
        </div>
    </div>
</asp:Content>
