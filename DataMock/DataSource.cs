using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using Demo.WhoIs.CDL;

namespace Demo.WhoIs.DataMock
{
    /// <summary>
    /// Get data source from xml file
    /// </summary>
    public class DataSource : IDataSource
    {
        /// <summary>
        /// Get path name for source data mock
        /// </summary>
        /// <returns></returns>
        private string GetPathName()
        {
            string vFilePath = string.Empty;
            
            // TODO : replace WebUI, App_Data and Ressources with the constants
            if (AppDomain.CurrentDomain.BaseDirectory.Contains("WebUI"))
            {
                vFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data");
            }
            else
            {
                vFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Ressources");
            }

            return vFilePath;
        }

        /// <summary>
        /// Get all agence
        /// </summary>
        /// <returns>List of agence</returns>
        public List<EAgence> GetListOfAgences()
        {
            string vMessage = string.Empty;
            string vFileName = string.Empty;
            XDocument vXDocument = null;
            List<EAgence> vListOfAgence = new List<EAgence>();

            try
            {
                vFileName = Path.Combine(this.GetPathName(), "ListAgences.xml");
                vXDocument = XDocument.Load(vFileName);
                vListOfAgence = TransfertRowMapperAgence(vXDocument);
            }
            catch(Exception vException)
            {
                vMessage = string.Format("Exception fired - Path {0} - Exception : {1}", vFileName, vException.Message);
                throw new Exception(vMessage);
            }

            return vListOfAgence;
        }

        /// <summary>
        /// Get all user
        /// </summary>
        /// <returns>List of user</returns>
        public List<EUser> GetListOfUsers()
        {
            string vMessage = string.Empty;
            string vFileName = string.Empty;
            XDocument vXDocument = null;
            List<EUser> vListOfUser = new List<EUser>();

            try
            {
                vFileName = Path.Combine(this.GetPathName(), "ListUsers.xml");
                vXDocument = XDocument.Load(vFileName);
                vListOfUser = TransfertRowMapperUser(vXDocument);
            }
            catch (Exception vException)
            {
                vMessage = string.Format("Exception fired - Path {0} - Exception : {1}", vFileName, vException.Message);
                throw new Exception(vMessage);
            }

            return vListOfUser;
        }

        /// <summary>
        /// Retrive data from xml document agence
        /// </summary>
        /// <returns>List of agence</returns>
        private List<EAgence> TransfertRowMapperAgence(XDocument pXDocument)
        {
            string vMessage = string.Empty;
            List<EAgence> vListOfAgence = new List<EAgence>();
            EAgence vEAgence = null;

            if (pXDocument == null)
            {
                return vListOfAgence;
            }

            try
            {
                
                var vList = from agence in pXDocument.Elements("ListOfAgences").Descendants("Agence")
                            select new
                            {
                                Code = agence.Attribute("code").Value.ToString(),
                                Libelle = agence.Value
                            };

                foreach (var agence in vList)
                {
                    vEAgence = new EAgence();

                    vEAgence.Code = agence.Code;
                    vEAgence.Libelle = agence.Libelle;
                    vListOfAgence.Add(vEAgence);
                }
            }
            catch (Exception vException)
            {
                vMessage = string.Format("Exception fired {0}", vException.Message);
                throw new Exception(vMessage);
            }

            return vListOfAgence;
        }

        /// <summary>
        /// Retrive data from xml document user
        /// </summary>
        /// <returns>List of user</returns>
        private List<EUser> TransfertRowMapperUser(XDocument pXDocument)
        {
            string vMessage = string.Empty;
            List<EUser> vListOfUser = new List<EUser>();
            EUser vEUser = null;

            if(pXDocument == null)
            {
                return vListOfUser;
            }

            try
            {
                var vList = from user in pXDocument.Elements("ListOfUsers").Descendants("User")
                            select new
                            {
                                Matricule = user.Element("Matricule").Value,
                                Nom = user.Element("Nom").Value,
                                Prenom = user.Element("Prenom").Value,
                                Telephone = user.Element("Telephone").Value,
                                Email = user.Element("Email").Value,
                                AgenceCode = user.Element("Agence").Value,
                                IsActif = "1".Equals(user.Element("IsActif").Value) ? true : false
                            };

                foreach (var user in vList)
                {
                    vEUser = new EUser();

                    vEUser.Matricule = user.Matricule;
                    vEUser.Nom = user.Nom;
                    vEUser.Prenom = user.Prenom;
                    vEUser.Telephone = user.Telephone;
                    vEUser.Email = user.Email;
                    vEUser.AgenceCode = user.AgenceCode;
                    vEUser.IsActif = user.IsActif;

                    vListOfUser.Add(vEUser);
                }
            }
            catch (Exception vException)
            {
                vMessage = string.Format("Exception fired - {0}", vException.Message);
                throw new Exception(vMessage);
            }

            return vListOfUser;
        }
    }
}
