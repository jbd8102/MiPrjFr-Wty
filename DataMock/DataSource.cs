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
            List<EAgence> vListOfAgence = null;

            try
            {
                vFileName = Path.Combine(this.GetPathName(), "ListAgences.xml");
                vListOfAgence = GetListOfAgences(vFileName);
            }
            catch(Exception vException)
            {
                vMessage = string.Format("Exception fired - Path {0} - Exception : {1}", vFileName, vException.Message);
                throw new Exception(vMessage);
            }

            return vListOfAgence;
        }

        /// <summary>
        /// Get all agence
        /// </summary>
        /// <param name="pFileName">File name</param>
        /// <returns>List of agence</returns>
        public List<EAgence> GetListOfAgences(string pFileName)
        {
            string vMessage = string.Empty;
            XDocument vXDocument = null;
            List<EAgence> vListOfAgence = null;

            try
            {
                vXDocument = XDocument.Load(pFileName);
                vListOfAgence = TransfertRowMapperAgence(vXDocument);
            }
            catch (Exception vException)
            {
                vMessage = string.Format("Exception fired - Path {0} - Exception : {1}", pFileName, vException.Message);
                throw new Exception(vMessage);
            }

            return vListOfAgence;
        }

        /// <summary>
        /// Get all Employee
        /// </summary>
        /// <returns>List of Employee</returns>
        public List<EEmployee> GetListOfEmployees()
        {
            string vMessage = string.Empty;
            string vFileName = string.Empty;
            List<EEmployee> vListOfEmployee = null;

            try
            {
                vFileName = Path.Combine(this.GetPathName(), "ListEmployees.xml");
                vListOfEmployee = GetListOfEmployees(vFileName);
            }
            catch (Exception vException)
            {
                vMessage = string.Format("Exception fired - Path {0} - Exception : {1}", vFileName, vException.Message);
                throw new Exception(vMessage);
            }

            return vListOfEmployee;
        }

        /// <summary>
        /// Get all Employee
        /// </summary>
        /// <param name="pFileName">File name</param>
        /// <returns>List of Employee</returns>
        public List<EEmployee> GetListOfEmployees(string pFileName)
        {
            string vMessage = string.Empty;
            XDocument vXDocument = null;
            List<EEmployee> vListOfEmployee = new List<EEmployee>();

            try
            {
                vXDocument = XDocument.Load(pFileName);
                vListOfEmployee = TransfertRowMapperEmployee(vXDocument);
            }
            catch (Exception vException)
            {
                vMessage = string.Format("Exception fired - Path {0} - Exception : {1}", pFileName, vException.Message);
                throw new Exception(vMessage);
            }

            return vListOfEmployee;
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
        /// Retrive data from xml document Employee
        /// </summary>
        /// <returns>List of Employee</returns>
        private List<EEmployee> TransfertRowMapperEmployee(XDocument pXDocument)
        {
            string vMessage = string.Empty;
            List<EEmployee> vListOfEmployee = new List<EEmployee>();
            EEmployee vEEmployee = null;

            if(pXDocument == null)
            {
                return vListOfEmployee;
            }

            try
            {
                var vList = from Employee in pXDocument.Elements("ListOfEmployees").Descendants("Employee")
                            select new
                            {
                                Matricule = Employee.Element("Matricule").Value,
                                Nom = Employee.Element("Nom").Value,
                                Prenom = Employee.Element("Prenom").Value,
                                Telephone = Employee.Element("Telephone").Value,
                                Email = Employee.Element("Email").Value,
                                AgenceCode = Employee.Element("Agence").Value,
                                IsActif = "1".Equals(Employee.Element("IsActif").Value) ? true : false
                            };

                foreach (var Employee in vList)
                {
                    vEEmployee = new EEmployee();

                    vEEmployee.Matricule = Employee.Matricule;
                    vEEmployee.Nom = Employee.Nom;
                    vEEmployee.Prenom = Employee.Prenom;
                    vEEmployee.Telephone = Employee.Telephone;
                    vEEmployee.Email = Employee.Email;
                    vEEmployee.AgenceCode = Employee.AgenceCode;
                    vEEmployee.IsActif = Employee.IsActif;

                    vListOfEmployee.Add(vEEmployee);
                }
            }
            catch (Exception vException)
            {
                vMessage = string.Format("Exception fired - {0}", vException.Message);
                throw new Exception(vMessage);
            }

            return vListOfEmployee;
        }
    }
}
