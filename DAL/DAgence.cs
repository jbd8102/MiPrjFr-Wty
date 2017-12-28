﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using Demo.WhoIs.CDL;
using Demo.WhoIs.DataMock;

namespace Demo.WhoIs.DAL
{
    /// <summary>
    /// Agence DAL
    /// </summary>
    public class DAgence : IDAgence
    {
        private IDataSource _dataSource;

        /// <summary>
        /// Instance of DataSource
        /// </summary>
        public IDataSource DataSource
        {
            get
            {
                if (_dataSource == null)
                {
                    _dataSource = new DataSource();
                }

                return _dataSource;
            }
        }             

        /// <summary>
        /// Get list of agence
        /// </summary>
        /// <returns>List of agence</returns>
        public List<EAgence> GetListOfAgences()
        {
            List<EAgence> vListAgences = null;
            string vKey = "GetListOfAgences";

            try
            {
                // Get list from cache
                vListAgences = MemoryCache.Default[vKey] as List<EAgence>;

                // Get list from data source
                if(vListAgences == null)
                {
                    vListAgences = DataSource.GetListOfAgences();
                    MemoryCache.Default.Add(vKey, vListAgences, new DateTimeOffset(DateTime.Now.AddMinutes(TConstants.EXPIRATION_TIME)));
                }
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
            List<EAgence> vListAgences = null;
            EAgence vEAgence = null;

            try
            {
                vListAgences = this.GetListOfAgences();
                vEAgence = vListAgences.Single(s => s.Code == pCode);
            }
            catch (Exception vException)
            {
                throw vException;
            }

            return vEAgence;
        }
    }
}