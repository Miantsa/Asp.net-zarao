using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Web.Services;
using Desktop_zarao;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data.SQLite;
using System.Configuration;
namespace Web_Zarao
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        
      
        protected void Page_Load(object sender, EventArgs e)
        {
           
            try
            {
                var httpPostedImage = HttpContext.Current.Request.Files["image"];
                var httpPostedVideo = HttpContext.Current.Request.Files["video"];
                var httpPostedMusique = HttpContext.Current.Request.Files["musique"];
                var httpPostedDocument = HttpContext.Current.Request.Files["document"];
                var httpPostedLogiciel = HttpContext.Current.Request.Files["logiciel"];
                var httpPostedAutre = HttpContext.Current.Request.Files["autre"];
               // Console.WriteLine(HttpContext.Current.Server.MapPath("~\test\\Zara"));
               // var fileSavePAth = Path.Combine(HttpContext.Current.Server.MapPath("~/test/Zara"), httpPostedFile.FileName);
                if (httpPostedImage != null) {
                    Console.WriteLine(Singleton.GetImagePath() + "\\" + httpPostedImage.FileName);
                    String ImageSave = Singleton.GetImagePath() + "\\" + httpPostedImage.FileName;
                    httpPostedImage.SaveAs(ImageSave);
                    Console.WriteLine("Image téléchargé");
                
                }
                if (httpPostedVideo != null)
                {
                    Console.WriteLine(Singleton.GetVideoPath() + "\\" + httpPostedVideo.FileName);
                    String VideoSave = Singleton.GetVideoPath() + "\\" + httpPostedVideo.FileName;
                    httpPostedVideo.SaveAs(VideoSave);
                    Console.WriteLine("Video téléchargé");

                }
                if (httpPostedMusique != null)
                {
                    Console.WriteLine(Singleton.GetMusiquePath() + "\\" + httpPostedMusique.FileName);
                    String MusiqueSave = Singleton.GetMusiquePath() + "\\" + httpPostedMusique.FileName;
                    httpPostedMusique.SaveAs(MusiqueSave);
                    Console.WriteLine("Musique téléchargé");

                }
                if (httpPostedDocument != null)
                {
                    Console.WriteLine(Singleton.GetDocumentPath() + "\\" + httpPostedDocument.FileName);
                    String DocumentSave = Singleton.GetDocumentPath() + "\\" + httpPostedDocument.FileName;
                    httpPostedDocument.SaveAs(DocumentSave);
                    Console.WriteLine("Document téléchargé");

                }
                if (httpPostedLogiciel != null)
                {
                    Console.WriteLine(Singleton.GetLogicielPath() + "\\" + httpPostedLogiciel.FileName);
                    String LogicielSave = Singleton.GetLogicielPath() + "\\" + httpPostedLogiciel.FileName;
                    httpPostedLogiciel.SaveAs(LogicielSave);
                    Console.WriteLine("Logiciel téléchargé");

                }
                if (httpPostedAutre != null)
                {
                    Console.WriteLine(Singleton.GetAutrePath() + "\\" + httpPostedAutre.FileName);
                    String AutreSave = Singleton.GetAutrePath() + "\\" + httpPostedAutre.FileName;
                    httpPostedAutre.SaveAs(AutreSave);
                    Console.WriteLine("Autre téléchargé");

                }
            }
            catch (Exception ex) { }

           /* String[] title = Directory.GetFiles(Singleton.GetDocumentPath());
            Console.WriteLine(Singleton.GetDocumentPath());
            foreach (var i in title)
            {
                Console.WriteLine(i);
            }
            DocumentInfo doc = new DocumentInfo(title[0]);
            Console.WriteLine(doc.GetSize()+"|"+doc.GetTitle()+"|"+doc.GetLastModif()+"|"+doc.GetIconName());*/
        }
        protected void btn_click(object sender,EventArgs e) {

        }
        public String getWinInfo()
        {
            OperatingSystem os = Environment.OSVersion;
            Version vs = os.Version;
            String sp = os.ServicePack;
            String WinInfo = "";
            if (os.Platform == PlatformID.Win32NT)
            {
                switch (vs.Major)
                {
                    case 3:
                        WinInfo = "NT 3.51";
                        break;
                    case 4:
                        WinInfo = "NT 4.0";
                        break;
                    case 5:
                        if (vs.Minor == 0)
                            WinInfo = "2000";
                        else
                            WinInfo = "XP";
                        break;
                    case 6:
                        if (vs.Minor == 0)
                            WinInfo = "Vista";
                        else if (vs.Minor == 1)
                            WinInfo = "7";
                        else
                            WinInfo = "8";
                        break;
                    case 10:
                        if (vs.Minor == 0)
                            WinInfo = "10";
                        break;
                    default:
                        break;
                }
            }
            WinInfo = "Windows" + WinInfo + " " + os.ServicePack;
            return WinInfo;
        }
        private static String[] GetLienNorme(String[] LienLong){
            String[] sortie=new String[LienLong.Length];
            int i = 0;
            foreach(var l1 in LienLong){
               // String[] s = l1.Split('\\');
                FileInfo f = new FileInfo(l1);
                sortie[i] = f.Name;
                i++;
            }
            return sortie;
        } 
        //Image
        [WebMethod]
        public static String[] GetImageListe() {
            return  GetLienNorme( Directory.GetFiles(Singleton.GetImagePath()));
        }
        [WebMethod]
        public static String DeleteImage(String listeimage){
            Boolean test=true;
            JObject json = JObject.Parse(listeimage);
            foreach (var i in json)
            {
                Console.WriteLine(Singleton.GetImagePath() + "\\" + i.Value);
                try
                {
                    File.Delete(Singleton.GetImagePath() + "\\" + i.Value);
                }
                catch (Exception e)
                {
                    test = false;
                }
            }
            if(test)
            Console.WriteLine("Fichier supprimé");

            return test.ToString();
        }
        [WebMethod]
        public static String DeleteImageSolo(String image) {
            Boolean test = true;
            Console.WriteLine(image);
            try
            {
                File.Delete(Singleton.GetImagePath() + "\\" + image);
            }
            catch (Exception e)
            {
                test = false;
            }
            if (test)
            Console.WriteLine("Fichier supprimé");
           /* if (FileUpload1.HasFile)
            {
                Console.WriteLine(FileUpload1.FileName);
            }*/
            return test.ToString();
        }
        //Video
        [WebMethod]
        public static String[] GetVideoListe() {
            return GetLienNorme(Directory.GetFiles(Singleton.GetVideoPath()));
            
        }
        [WebMethod]
        public static String DeleteVideo(String listevideo)
        {
            Boolean test = true;
            JObject json = JObject.Parse(listevideo);
            Console.WriteLine(json);
            foreach (var i in json)
            {
                Console.WriteLine(Singleton.GetVideoPath() + "\\" + i.Value);
                try
                {
                    File.Delete(Singleton.GetVideoPath() + "\\" + i.Value);
                }
                catch (Exception e)
                {
                    test = false;
                }
            }
            if (test)
                Console.WriteLine("Fichier supprimé");

            return test.ToString();
        }
        [WebMethod]
        public static String DeleteVideoSolo(String video)
        {
            Boolean test = true;
            Console.WriteLine(video);
            try
            {
                File.Delete(Singleton.GetVideoPath() + "\\" + video);
            }
            catch (Exception e)
            {
                test = false;
            }
            if (test)
                Console.WriteLine("Fichier supprimé");
           
            return test.ToString();
        }
        //Login
        [WebMethod]
        public static String Login(String pseudo) {
           // Console.WriteLine(pseudo);
            Boolean test = true;
            SQLiteCommand cmd = new SQLiteCommand("select * from Personne;", BD.Req());
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["Pseudo"]);
                if (reader["Pseudo"].ToString() == pseudo) {
                    test = false;
                    Console.WriteLine("Misy mitovy");
                    break;
                }   
            }
            if(test){
                SQLiteCommand cmd2 = new SQLiteCommand("Insert into Personne values(null,'" + pseudo + "','');",BD.Req());
                cmd2.ExecuteNonQuery();
                cmd2.Dispose();
            }
            cmd.Dispose();
            return test.ToString();
        }
        //Chat
      [WebMethod]
        public static String GetMessage()
        {
          List<Message> Messages=new List<Message>();
            SQLiteCommand cmd = new SQLiteCommand("select * from Message where Perso in(Select Pseudo from Personne) ;", BD.Req());
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Message msg = new Message();
                msg.Msg = Crypto.DeCrypt_mot(reader["Msg"].ToString()); //Console.WriteLine(reader["Msg"]);
                msg.Perso = reader["Perso"].ToString(); //Console.WriteLine(reader["Perso"]);
                msg.Avatar = reader["Avatar"].ToString(); //Console.WriteLine(reader["Avatar"]);
                Messages.Add(msg);
            }
            cmd.Dispose();
         //  String json= JsonConvert.SerializeObject(Messages);
           // JObject json = JObject.Parse(Messages.ToString());
           // Console.WriteLine(json);
            return JsonConvert.SerializeObject(Messages);
        }
        [WebMethod]
        public static void SetMessage(String msgInfo) {
            JObject json = JObject.Parse(msgInfo);
            Console.WriteLine(msgInfo);
            SQLiteCommand cmd = new SQLiteCommand("Insert into Message values(null,'" + Crypto.Crypt_mot(json["0"].ToString()) + "','" + json["1"] + "','" + json["2"] + "');", BD.Req());
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            
        }
        //Musique
        [WebMethod]
        public static String GetMusique() {
            List<Musique> Musiques = new List<Musique>();
            foreach (String item in Directory.GetFiles(Singleton.GetMusiquePath())) {
                MusiqueInfo info = new MusiqueInfo(item);
                Musique musique = new Musique();
                musique.Titre = info.GetTitle();
                musique.Artiste = info.GetArtist();
                musique.Duree = info.GetDuration();
                musique.Format = info.GetFormat();
                musique.Taille = info.GetSize();
                musique.Lien = info.GetLien();
                Musiques.Add(musique);
            }
            return JsonConvert.SerializeObject(Musiques);
        }
        [WebMethod]
        public static String DeleteMusique(String listemusique)
        {
            Boolean test = true;
            JObject json = JObject.Parse(listemusique);
            Console.WriteLine(json);
            foreach (var i in json)
            {
                Console.WriteLine(Singleton.GetMusiquePath()+ "\\" + i.Value);
                try
                {
                    File.Delete(Singleton.GetMusiquePath() + "\\" + i.Value);
                }
                catch (Exception e)
                {
                    test = false;
                }
            }
            if (test)
                Console.WriteLine("Fichier supprimé");

            return test.ToString();
        }
        [WebMethod]
        public static String DeleteMusiqueSolo(String musique)
        {
            Boolean test = true;
            Console.WriteLine(musique);
            try
            {
                File.Delete(Singleton.GetMusiquePath() + "\\" + musique);
            }
            catch (Exception e)
            {
                test = false;
            }
            if (test)
                Console.WriteLine("Fichier supprimé");

            return test.ToString();
        }
        //Document
        [WebMethod]
        public static String GetDocument() {
            List<Document> documents = new List<Document>();
            foreach(String item in Directory.GetFiles(Singleton.GetDocumentPath())){
                DocumentInfo info = new DocumentInfo(item);
                Document document = new Document();
                document.Icon = info.GetIconName();
                document.Titre = info.GetTitle();
                document.Taille = info.GetSize();
                document.DateModif = info.GetLastModif();
                documents.Add(document);
            }
            return JsonConvert.SerializeObject(documents);
        }
        [WebMethod]
        public static String DeleteDocument(String listedocument)
        {
            Boolean test = true;
            JObject json = JObject.Parse(listedocument);
            Console.WriteLine(json);
            foreach (var i in json)
            {
                Console.WriteLine(Singleton.GetDocumentPath() + "\\" + i.Value);
                try
                {
                    File.Delete(Singleton.GetDocumentPath() + "\\" + i.Value);
                }
                catch (Exception e)
                {
                    test = false;
                }
            }
            if (test)
                Console.WriteLine("Fichier supprimé");

            return test.ToString();
        }
        [WebMethod]
        public static String DeleteDocumentSolo(String document)
        {
            Boolean test = true;
            Console.WriteLine(document);
            try
            {
                File.Delete(Singleton.GetDocumentPath() + "\\" + document);
            }
            catch (Exception e)
            {
                test = false;
            }
            if (test)
                Console.WriteLine("Fichier supprimé");

            return test.ToString();
        }
        //Logiciel
        [WebMethod]
        public static String GetLogiciel()
        {
            List<Logiciel> logiciels = new List<Logiciel>();
            foreach (String item in Directory.GetFiles(Singleton.GetLogicielPath()))
            {
                LogicielInfo info = new LogicielInfo(item);
                Logiciel logiciel = new Logiciel();
                logiciel.Nom = info.GetTitle();
                logiciel.Taille = info.GetSize();
                logiciel.Icon = info.GetIconName();
                logiciels.Add(logiciel);
            }
            return JsonConvert.SerializeObject(logiciels);
        }
       /* [WebMethod]
        public static String DeleteLogiciel(String listelogiciel)
        {
            Boolean test = true;
            JObject json = JObject.Parse(listelogiciel);
            Console.WriteLine(json);
            foreach (var i in json)
            {
                Console.WriteLine(Singleton.GetLogicielPath() + "\\" + i.Value);
                try
                {
                    File.Delete(Singleton.GetLogicielPath() + "\\" + i.Value);
                }
                catch (Exception e)
                {
                    test = false;
                }
            }
            if (test)
                Console.WriteLine("Fichier supprimé");

            return test.ToString();
        }*/
        [WebMethod]
        public static String DeleteLogicielSolo(String logiciel)
        {
            Boolean test = true;
            Console.WriteLine(logiciel);
            try
            {
                File.Delete(Singleton.GetLogicielPath() + "\\" + logiciel);
            }
            catch (Exception e)
            {
                test = false;
            }
            if (test)
                Console.WriteLine("Fichier supprimé");

            return test.ToString();
        }
        //Autres
        [WebMethod]
        public static String GetAutre()
        {
            List<Autre> autres = new List<Autre>();
            foreach (String item in Directory.GetFiles(Singleton.GetAutrePath()))
            {
                AutreInfo info = new AutreInfo(item);
                Autre autre = new Autre();
                autre.Icon = info.GetIconName();
                autre.Titre = info.GetTitle();
                autre.Taille = info.GetSize();
                autre.DateModif = info.GetLastModif();
                autres.Add(autre);
            }
            return JsonConvert.SerializeObject(autres);
        }
       /* [WebMethod]
       public static String DeleteAutre(String listedocument)
        {
            Boolean test = true;
            JObject json = JObject.Parse(listedocument);
            Console.WriteLine(json);
            foreach (var i in json)
            {
                Console.WriteLine(Singleton.GetDocumentPath() + "\\" + i.Value);
                try
                {
                    File.Delete(Singleton.GetDocumentPath() + "\\" + i.Value);
                }
                catch (Exception e)
                {
                    test = false;
                }
            }
            if (test)
                Console.WriteLine("Fichier supprimé");

            return test.ToString();
        }*/
        [WebMethod]
        public static String DeleteAutreSolo(String dossier)
        {
            Boolean test = true;
            Console.WriteLine(dossier);
            try
            {
                File.Delete(Singleton.GetAutrePath() + "\\" + dossier);
            }
            catch (Exception e)
            {
                test = false;
            }
            if (test)
                Console.WriteLine("Fichier supprimé");

            return test.ToString();
        }
    }
}