using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TagLib;
using System.IO;
namespace Web_Zarao
{
    public class MusiqueInfo
    {
        private TagLib.File file;
        private FileInfo fl;
        public MusiqueInfo(String pt) { 
           this.file=TagLib.File.Create(pt);
           fl = new FileInfo(pt);
        }
        public String GetArtist() {
            String artiste="";
            if (file.Tag.Artists.Length > 0)
                artiste = file.Tag.Artists[0];
            else
                artiste = "inconnu";
            return artiste;
        }
        public String GetTitle() {
            if (file.Tag.Title == null){
                String[] title=fl.Name.Split('.');
                 return title[0];
            }   
            return file.Tag.Title;
        }
        public String GetDuration(){
            int min=file.Properties.Duration.Minutes;
            int sec=file.Properties.Duration.Seconds;
            String duree="";
             if(min.ToString().Length==1){
                duree+="0"+min+":";
             }
             else{
                duree+=""+min+":";
             }
             if(sec.ToString().Length==1){
                duree+="0"+sec;
             }
             else{
                duree+=""+sec;
             }
            return duree;
        }
        public String GetFormat() {
            String[] format=file.MimeType.Split('/');
            return format[1];
        }
        public String GetSize() {
            float taille = (float)Math.Round((fl.Length / 1024f) / 1024f, 2);
            return taille.ToString()+"MB";
        }
        public String GetLien() {
           return fl.Name;
        }
    }
}