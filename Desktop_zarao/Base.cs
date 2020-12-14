using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.IO;
namespace Desktop_zarao
{
    static class Base
    {
        private static String BD_Path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())));
         private static SQLiteConnection connexion=null; 
       static Base() {
           BD_Path += "\\Web_Zarao";
           Console.WriteLine(BD_Path);
           connexion = new SQLiteConnection("Data Source=" + BD_Path + "\\BD\\Chat.s3db");
           connexion.Open();
       }
       public static SQLiteConnection Req() {
           return connexion;
       }
    }
}
