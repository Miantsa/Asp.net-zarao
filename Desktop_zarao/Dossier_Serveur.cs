using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Desktop_zarao
{
    public static class Dossier_Serveur
    {
        public static String Source { get; set; }
        public static List<DirectoryInfo> Dossier_Fils;
        static Dossier_Serveur() {
            Dossier_Fils = new List<DirectoryInfo>();
        }
        public static DirectoryInfo Creer(String destination) {
            Dossier_Serveur.Source = destination;
            DirectoryInfo di= Directory.CreateDirectory(destination);
           // di.Attributes = FileAttributes.Directory | FileAttributes.Encrypted;
            return di;

        }
        public static void CreerEnfant(String nom) {
           Dossier_Fils.Add(Directory.CreateDirectory(Source + "\\"+nom));
        }
    }
}
