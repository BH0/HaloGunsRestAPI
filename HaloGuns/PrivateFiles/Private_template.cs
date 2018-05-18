using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/* Rename this file to Private.cs after you have set your MySQLPassword so the database connection procedure will succeed */ 
/* You should also make sure this file is specified within the ".gitignore" file if you are using a public Github repository */ 
namespace HaloGuns.PrivateFiles 
{
    public class PrivateFiles 
    {
        public string MySqlPassword; 
        public PrivateFiles()
        {
            this.MySqlPassword = "yourpasswordgoeshere"; 
        }
    }
}