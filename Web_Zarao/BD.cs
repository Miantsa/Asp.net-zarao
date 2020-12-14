using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;
namespace Web_Zarao
{
   static public class BD
    {
        
        private static SQLiteConnection connexion=null; 
       static BD() {

           connexion = new SQLiteConnection("Data Source=" + Singleton.GetWebPath() + "\\BD\\Chat.s3db");
           connexion.Open();
       }
       public static SQLiteConnection Req() {
           return connexion;
       }
    }
}