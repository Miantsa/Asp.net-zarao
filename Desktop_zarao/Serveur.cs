using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CassiniDev;
using System.IO;
using System.Net;
namespace Desktop_zarao
{
   public static class Serveur
    {
       private static Server s=null;
       private static String S_WebAp_Path { get; set; }
       public static int S_Port { get; set; }
       private static String S_Hostname { get; set; }
       private static int S_Timeout { get; set; }
       public static String S_Ip { get; set; }
       private static String S_VPath { get; set; }
       private static Boolean Probleme = false;
       public static Boolean Actif { get; set; }
      // private static Boolean Actif = false;
        static Serveur(){
           
          
            
       }
       public static void Init(){
           S_Port = 81;
           S_VPath = "/";
           S_WebAp_Path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())));
           S_WebAp_Path += "\\Web_Zarao";
           S_Ip = "127.0.0.0";
           S_Hostname = "Client";
           S_Timeout=86400000;
           Actif = false;
       }
       public static int Lancer_Serveur() {
           Probleme = false;
           try
           {
               s = new Server(S_Port, S_VPath, S_WebAp_Path, IPAddress.Parse(S_Ip), S_Hostname, S_Timeout);
               s.Start();
               Actif = true;
           }
           catch (Exception) {
               Probleme = true;
           }
           if (Probleme)
           {
               return -1;
              // MessageBox.Show("Impossible de lancer le Serveur");
           }
           else {
               return 1;
              // MessageBox.Show("Serveur lancé");
           }
         

       }
       public static void Arreter_Serveur() {
           if (Actif) {
               s.ShutDown();
               Serveur.Actif = false;
              // MessageBox.Show("Serveur arrété");
           }
          
       }
    }
}
