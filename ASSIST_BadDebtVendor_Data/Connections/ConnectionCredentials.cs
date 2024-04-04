using ASSIST_Security;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSIST_BadDebtVendor_Data
{
    /// <summary>
    /// This is class used to create the database connection.
    /// </summary>
    /// TODO Replace ProjectScaffold with the name of the csdl file after you import 
    public static class ConnectionCredentials
    {
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static string DBCatalog { get; set; } = "ASSIST_Bad_Debt_Vendor_Mgmt";
        public static string Server { get; set; } = "AR8994SqlSrv01\\GSTSQL";
        public static string Datasource { get; set; } 
        public static string MetaData { get; set; } = "res://*/Models.BadDebtVendorModel.csdl|res://*/Models.BadDebtVendorModel.ssdl|res://*/Models.BadDebtVendorModel.msl";


        /// <summary>
        /// Gets the creds via process name
        /// </summary>
        /// <param name="processName"></param>
        public static void GetPassManagerCredentials(string processName)
        {
            try
            {
                ManagePass passMngr = new ManagePass();
                var proc = passMngr.GetRijnPass(processName);
                UserName = proc?.Rows[0].ItemArray[3].ToString();
                Password = proc?.Rows[0].ItemArray[2].ToString().Trim('\0');
                Datasource = proc?.Rows[0].ItemArray[5].ToString();
                DBCatalog = proc?.Rows[0].ItemArray[6].ToString();
                Server = proc?.Rows[0].ItemArray[7].ToString();

            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Gets the creds via process id
        /// </summary>
        /// <param name="processID"></param>
        public static void GetPassManagerCredentials(int processID)
        {
            try
            {
                ManagePass passMngr = new ManagePass();
                var proc = passMngr.GetRijnPass(processID);
                UserName = proc?.Rows[0].ItemArray[3].ToString();
                Password = proc?.Rows[0].ItemArray[2].ToString().Trim('\0');
                Datasource = proc?.Rows[0].ItemArray[5].ToString();
                DBCatalog = proc?.Rows[0].ItemArray[6].ToString();
                Server = proc?.Rows[0].ItemArray[7].ToString();
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void GetPassManagerCredentials(string processName, out string username, out string pw, out string dbCatalog, out string server)
        {
            try
            {
                ManagePass passMngr = new ManagePass();
                var proc = passMngr.GetRijnPass(processName);
                username = proc.Rows[0].ItemArray[3].ToString();
                pw = proc.Rows[0].ItemArray[2].ToString().Trim('\0');
                dbCatalog = proc.Rows[0].ItemArray[6].ToString();
                server = proc.Rows[0].ItemArray[7].ToString();
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void GetPassManagerCredentials(int processID, out string username, out string pw, out string dbCatalog, out string server)
        {
            try
            {
                ManagePass passMngr = new ManagePass();
                var proc = passMngr.GetRijnPass(processID);
                username = proc.Rows[0].ItemArray[3].ToString();
                pw = proc.Rows[0].ItemArray[2].ToString().Trim('\0');
                dbCatalog = proc.Rows[0].ItemArray[6].ToString();
                server = proc.Rows[0].ItemArray[7].ToString();
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }



    public static class ConnectionCreator
    {
        public static string CreateConnectionString(string dataSource, string metaData, string initialCatalog, string userid, string pw)
        {
            const string appName = "EntityFramework";
            const string providerName = "System.Data.SqlClient";

            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder
            {
                DataSource = dataSource,
                InitialCatalog = initialCatalog,
                MultipleActiveResultSets = true,
                IntegratedSecurity = false,
                TrustServerCertificate = true,
                UserID = userid,
                Password = pw,
                ApplicationName = appName
            };

            EntityConnectionStringBuilder efBuilder = new EntityConnectionStringBuilder
            {
                Metadata = metaData,
                Provider = providerName,
                ProviderConnectionString = sqlBuilder.ConnectionString
            };

            return efBuilder.ConnectionString;
        }
        public static string CreateConnectionString(string dataSource, string metaData, string initialCatalog)
        {
            const string appName = "EntityFramework";
            const string providerName = "System.Data.SqlClient";

            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder
            {
                DataSource = dataSource,
                InitialCatalog = initialCatalog,
                MultipleActiveResultSets = true,
                IntegratedSecurity = true,
                ApplicationName = appName
            };

            EntityConnectionStringBuilder efBuilder = new EntityConnectionStringBuilder
            {
                Metadata = metaData,
                Provider = providerName,
                ProviderConnectionString = sqlBuilder.ConnectionString
            };

            return efBuilder.ConnectionString;
        }

    }
}
