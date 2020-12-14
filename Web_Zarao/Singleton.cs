using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Web_Zarao
{
     static class Singleton
    {
         private static String FPath= Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())));
         private static String WebPath ;
         private static String ImagePath="";
         private static String VideoPath="";
         private static String MusiquePath="";
         private static String DocumentPath="";
         private static String LogicielPath="";
         private static String AutrePath = "";
         static Singleton(){
             WebPath = FPath + "\\Web_Zarao";
             FPath += "\\Web_Zarao\\Zarao_Dossier";
             foreach(var l in Directory.GetDirectories(FPath)){
                 Console.WriteLine(l);
                 String[] arbre = l.Split('\\');
                if(arbre[arbre.Length-1]=="Images")
                {
                    ImagePath=l;
                }
                else if (arbre[arbre.Length - 1]=="Videos")
                {
                    VideoPath = l;
                }
                else if (arbre[arbre.Length - 1]=="Musiques")
                {
                    MusiquePath =l;
                }
                else if (arbre[arbre.Length - 1]=="Documents")
                {
                    DocumentPath =l;
                    Console.WriteLine(l+"100");
                }
                else if (arbre[arbre.Length - 1]=="Logiciels")
                {
                    LogicielPath =l;
                }
                else if (arbre[arbre.Length - 1] == "Autres")
                {
                    AutrePath = l;
                }
             }
         }
        
         public static String[] Get() {
             String[] p = Directory.GetDirectories(FPath);
             return p;
         }
         public static String GetWebPath(){
             return WebPath;
         }
         public static String GetZaraoDossierPath() {
            return FPath;
        }
        public static String GetImagePath(){
            return ImagePath;
        }
        public static String GetVideoPath()
        {
            return VideoPath;
        }
        public static String GetMusiquePath()
        {
            return MusiquePath;
        }
        public static String GetDocumentPath(){
            return DocumentPath;
        }
        public static String GetLogicielPath(){
            return LogicielPath;
        }
        public static String GetAutrePath()
        {
            return AutrePath;
        }
    }
}