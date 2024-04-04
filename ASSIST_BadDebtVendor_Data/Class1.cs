using ASSIST_ClassLibraryProjectScaffold.Logic;
using Assist_MailSend;
using ASSIST_Security;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSIST_ClassLibraryProjectScaffold
{
    /// <summary>
    /// This is a basic project scaffold that should be used for the starting point for most ASSIST console applications.
    /// It provides the folder structure for applications to ensure the file location and contents of each file are consistent between processes.
    /// </summary>
    /// Included reference libraries
    /// <see cref="PowerTerm"/>
    /// <see cref="ASSIST_Security"/>
    /// <see cref="Assist_MailSend"/>
    /// <see cref="NLog">
    ///     <remarks>Please see the NLog.config or https://nlog-project.org/ for configuration and path settings.</remarks>
    /// </see>
    /// <see cref="EntityFramework"/>
    /// TODO: Rebuild the project immediately after creation. This will restore any missing NuGet packages.
    /// TODO: Please see the Connections/ConnectionCredentials.cs and Connections/ProjectScaffoldConnection.cs for more instructions.
    public class Class1
    {
        internal static Logic.Logic Dal { get; } = new Logic.Logic();
        internal static MailSend SendMail = new MailSend();
        internal static ManagePass AssistSecurity = new ManagePass();
        //Any command lines arguments are processed in Main and the appropriate methods should be called.
        //No functional processing should be done at this point. Decision makings is acceptable. 
        public void ClassLibraryMethod(string firstArg)
        {
            //TODO: Remove this demo code after starting your project

            var result = Dal.FirstMethod(firstArg);
            Debug.WriteLine($"Is firstArg null or empty: {result}");
            Debug.WriteLine(firstArg);
            SendMail.SendUploadEmail("Scaffold Email", "This is the default email included in the ASSIST scaffold template", recipient: "Users");
            //This returns a datatable and is used as demonstrated below.
            var hmsDataByname = AssistSecurity.GetRijnPass("HMS");
            string userName = hmsDataByname?.Rows[0].ItemArray[3].ToString();
            string password = hmsDataByname?.Rows[0].ItemArray[2].ToString().Trim('\0');
            string datasource = hmsDataByname?.Rows[0].ItemArray[5].ToString();
            string dbCatalog = hmsDataByname?.Rows[0].ItemArray[6].ToString();
            string server = hmsDataByname?.Rows[0].ItemArray[7].ToString();

            //Follows the same pattern as above but using the id from PassManager rather than the name.
            var hmsDataById = AssistSecurity.GetRijnPass(2);
        }
    }
}
