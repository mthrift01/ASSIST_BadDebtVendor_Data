using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASSIST_BadDebtVendor_Data.Models;

namespace ASSIST_BadDebtVendor_Data.Models
{
    public partial class ASSIST_Bad_Debt_Vendor_MgmtEntities : DbContext
    {
        public ASSIST_Bad_Debt_Vendor_MgmtEntities(string connectionstring)
            : base(connectionstring) { }

    }
}

