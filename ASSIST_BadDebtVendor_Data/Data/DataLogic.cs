using ASSIST_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASSIST_BadDebtVendor_Data.Models;
using System.Data.SqlClient;
using System.Data.Entity.Validation;

namespace ASSIST_BadDebtVendor_Data
{
    public class BadDebtVendorData : IDisposable
    {
        public ASSIST_Bad_Debt_Vendor_MgmtEntities entityContext;
        private static ASSIST_ReferenceEntities refEntities = ASSIST_ReferenceEntities.ConnectionHelper.CreateConnection();
        public BadDebtVendorData(bool debug = false)
        {
            //TODO: set default debug false when moving to prod
            entityContext = CreateConnection(debug);
        }
        #region Connection
        private ASSIST_Bad_Debt_Vendor_MgmtEntities CreateConnection(bool debug = false)
        {
            try
            {
                ConnectionCredentials.Server = debug ? "AR8994SQLDEV01" : ConnectionCredentials.Server;
                return new ASSIST_Bad_Debt_Vendor_MgmtEntities(
                    ConnectionCreator.CreateConnectionString(ConnectionCredentials.Server,
                        ConnectionCredentials.MetaData,
                        ConnectionCredentials.DBCatalog));
            }
            catch (SqlException sqlEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
        #region Queryies
        #endregion
        #region Updates
        public List<bad_debt_placements> WritePlacements(List<bad_debt_placements> placements, string vendor, DateTime? dateSent, string file = "")
        {
            try
            {
                var master = new bad_debt_placement_master
                {
                    vendor = vendor,
                    fileName = file,
                    dateSent = dateSent,
                    createdBy = Environment.UserName,
                    dateCreated = DateTime.Now
                };
                placements.ForEach(x => x.bad_debt_placement_master = master);
                entityContext.bad_debt_placement_master.Add(master);
                entityContext.SaveChanges();
                return placements;
            }
            catch(DbEntityValidationException dbEx)
            {
                var entityEx = new EntityValException("Error saving inserting bad_debt_placement_master records.", dbEx);
                throw dbEx;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        #endregion
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
