using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Web_Zarao
{
    public class AutreInfo
    {
          private String NomImage;
        private FileInfo file;
        public AutreInfo(String pt) {
            file = new FileInfo(pt);
            Icon ico = Icon.ExtractAssociatedIcon(file.FullName);
            Bitmap bmp = ico.ToBitmap();
            NomImage = file.Name + ".png";
            bmp.Save(@""+Singleton.GetWebPath()+"\\IconAutre\\"+NomImage, ImageFormat.Png);
           // Console.WriteLine("sauver le izy");
        }
        public String GetTitle() {
            return file.Name;
        }
        public String GetSize() {
            float taille = (float)Math.Round((file.Length / 1024f) / 1024f, 2);
            return taille.ToString() + "MB";
        }
        public String GetLastModif() {
            return file.LastWriteTime.ToString();
        }
        public String GetIconName() {
            return NomImage;
        }
    }
}