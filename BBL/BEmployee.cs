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
    /// Employee BLL
    /// </summary>
    public class BEmployee : IBEmployee
    {
        private IDEmployee _dac;

        /// <summary>
        /// Instance of DataSource
        /// </summary>
        public IDEmployee Dac
        {
            get
            {
                if (_dac == null)
                {
                    _dac = new DEmployee();
                }

                return _dac;
            }
        }

        /// <summary>
        /// Get list of Employee
        /// </summary>
        /// <returns>List of Employee</returns>
        public List<EEmployee> GetListOfEmployees()
        {
            List<EEmployee> vListEmployees = null;

            try
            {
                vListEmployees = Dac.GetListOfEmployees();
            }
            catch (Exception vException)
            {
                throw vException;
            }

            return vListEmployees;
        }

        /// <summary>
        /// Get list of Employee
        /// </summary>
        /// <returns>List of Employee</returns>
        public List<EEmployee> GetListOfEmployees(string pFileName)
        {
            List<EEmployee> vListEmployees = null;

            try
            {
                vListEmployees = Dac.GetListOfEmployees(pFileName);
            }
            catch (Exception vException)
            {
                throw vException;
            }

            return vListEmployees;
        }

        /// <summary>
        /// Search Employees by criteria
        /// </summary>
        /// <param name="pCodeAgence">Code of agence</param>
        /// <param name="pName">Employee first name</param>
        /// <param name="pFileName">file name of data</param>
        /// <returns>List of Employee</returns>
        public List<EEmployee> SearchEmployeesByCriteria(string pCodeAgence, string pName, string pFileName)
        {
            EEmployee vEEmployee = null;
            List<EEmployee> vListEmployees = null;

            try
            {
                // Get all Employee
                vListEmployees = Dac.GetListOfEmployees(pFileName);

                // Filter by criteria
                var vResultat = from Employee in vListEmployees
                                where ((!"0".Equals(pCodeAgence) && Employee.AgenceCode == pCodeAgence) || "0".Equals(pCodeAgence)) &&
                                      ((!string.IsNullOrEmpty(pName) && Employee.Nom.ToLower().Contains(pName.ToLower())) ||
                                        (!string.IsNullOrEmpty(pName) && Employee.Prenom.ToLower().Contains(pName.ToLower())) ||
                                        string.IsNullOrEmpty(pName))
                                select new
                                {
                                    Matricule = Employee.Matricule,
                                    Nom = Employee.Nom,
                                    Prenom = Employee.Prenom,
                                    Telephone = Employee.Telephone,
                                    Email = Employee.Email,
                                    AgenceCode = Employee.AgenceCode,
                                    IsActif = Employee.IsActif
                                };

                // Cast
                vListEmployees = new List<EEmployee>();
                foreach (var Employee in vResultat)
                {
                    vEEmployee = new EEmployee();

                    vEEmployee.Matricule = Employee.Matricule;
                    vEEmployee.Nom = Employee.Nom;
                    vEEmployee.Prenom = Employee.Prenom;
                    vEEmployee.Telephone = Employee.Telephone;
                    vEEmployee.Email = Employee.Email;
                    vEEmployee.AgenceCode = Employee.AgenceCode;
                    vEEmployee.IsActif = Employee.IsActif;

                    vListEmployees.Add(vEEmployee);
                }
            }
            catch (Exception vException)
            {
                throw vException;
            }

            return vListEmployees;
        }

        /// <summary>
        /// Get Employee by matricule
        /// </summary>
        /// <param name="pMatricule">Matricule of Employee</param>
        /// <param name="pFileName">file name of data</param>
        /// <returns>EEmployee</returns>
        public EEmployee GetEmployeeByMatricule(string pMatricule, string pFileName)
        {
            EEmployee vEEmployee = null;
            List<EEmployee> vListEmployees = null;

            try
            {
                // Get all Employee
                vListEmployees = Dac.GetListOfEmployees(pFileName);
                if (vListEmployees != null && vListEmployees.Count > 0)
                {
                    vEEmployee = vListEmployees.Single(s => s.Matricule == pMatricule);
                }
            }
            catch (Exception vException)
            {
                throw vException;
            }

            return vEEmployee;
        }
    }
}
