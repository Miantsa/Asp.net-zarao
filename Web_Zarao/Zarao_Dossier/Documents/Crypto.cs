using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;
namespace Desktop_zarao
{
        public static class Crypto
         {
            private static String password = "miniproj";
             static Crypto()
             {
             }
             
        /* public static void Crypt_fichier(string name, String destination) {
             string skey="1234567812345678";
             try 
             {

                 using (RijndaelManaged aes = new RijndaelManaged()) 
                 {
                     byte[] key = ASCIIEncoding.UTF8.GetBytes(skey);
                     byte[] IV = ASCIIEncoding.UTF8.GetBytes(skey);
                     using (FileStream fsCrypt = new FileStream(@""+destination+"\\test.enc", FileMode.Create)) 
                     {
                         using (ICryptoTransform encryptor = aes.CreateEncryptor(key, IV))
                         {
                             using(CryptoStream cs=new CryptoStream(fsCrypt,encryptor,CryptoStreamMode.Write))
                             {
                                 using (FileStream fsln = new FileStream(name, FileMode.Open))
                                 {
                                 int data;
                                     while ((data = fsln.ReadByte()) != -1) 
                                     { 
                                        cs.WriteByte((byte)data);
                                     }
                                 }
                             }
                         }
                     }
                 
                 }
             }
             catch (Exception e){
                 Console.WriteLine(e.Message);
             }
         }
        /* public static void DeCrypt_fichier(String nom, String destination) {
             string skey = "1234567812345678";
             try 
             {
                 using (RijndaelManaged aes = new RijndaelManaged())
                 {
                     byte[] key = ASCIIEncoding.UTF8.GetBytes(skey);
                     byte[] IV = ASCIIEncoding.UTF8.GetBytes(skey);
                     using(FileStream fsCrypt=new FileStream(nom,FileMode.Open))
                     {
                         using (FileStream fsOut = new FileStream(@"" + destination + "\\okay.enc", FileMode.Create))
                         {
                             using (ICryptoTransform decryptor = aes.CreateDecryptor(key, IV)) 
                             {
                                using(CryptoStream cs=new CryptoStream(fsCrypt,decryptor,CryptoStreamMode.Read))
                                {
                                    int data;
                                    while((data=cs.ReadByte())!=-1)
                                    {
                                        fsOut.WriteByte((byte)data);
                                    }
                                }
                             }
                         }
                     }
                 }
             
             }catch(Exception e){
                 Console.WriteLine(e.Message); Console.WriteLine("decryptage fail");
             }
         }*/

             //cryptage mot
             public static String Crypt_mot(String mot)
             {
                 if(mot=="")
                     return "";
               // String password = key;
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);
                byte[] motbyte = Encoding.ASCII.GetBytes(mot);
                RijndaelManaged rjndl = new RijndaelManaged();
                 MemoryStream memoryStream =new MemoryStream();
               // rjndl.Mode = CipherMode.CBC;
              ICryptoTransform encryptor = rjndl.CreateEncryptor(key,key);
              CryptoStream cryptoStream = new CryptoStream(memoryStream,encryptor,CryptoStreamMode.Write);
              cryptoStream.Write(motbyte, 0, motbyte.Length);
              cryptoStream.FlushFinalBlock();
              byte[] sortiebyte = memoryStream.ToArray();
              memoryStream.Close();
              cryptoStream.Close();
              String sortie = Convert.ToBase64String(sortiebyte, 0, sortiebyte.Length);
                 return sortie;
             }
             //decryptage mot
             public static String DeCrypt_mot(String mot)
             {
                // String password = "12345678";
                 UnicodeEncoding UE = new UnicodeEncoding();
                 byte[] key = UE.GetBytes(password);
                 byte[] motbyte = Convert.FromBase64String(mot);
                 RijndaelManaged rjndl = new RijndaelManaged();
                 MemoryStream memoryStream = new MemoryStream();
                 ICryptoTransform decryptor = rjndl.CreateDecryptor(key, key);
                 CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Write);
                 cryptoStream.Write(motbyte, 0, motbyte.Length);
                 cryptoStream.FlushFinalBlock();
                 String sortie;
                 try
                 {
                     byte[] sortiebyte = memoryStream.ToArray();
                     sortie = Encoding.ASCII.GetString(sortiebyte, 0, sortiebyte.Length);
                 }
                 finally
                 {
                     memoryStream.Close();
                     cryptoStream.Close();
                 }


                 return sortie;
             }

             //cryptage fichier
        public static void Crypt_fichier(string name,String destination){
            try
            {
               // String password = "12345678";
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);
                String cryptFile = destination+"\\crypt.miantsa";
                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);
                RijndaelManaged RMCrypto = new RijndaelManaged();
                CryptoStream cs = new CryptoStream(fsCrypt, RMCrypto.CreateEncryptor(key, key), CryptoStreamMode.Write);
                FileStream fsln = new FileStream(name, FileMode.Open);
                int data;
               int i = 0;
               byte[] buffer = new byte[65536];
               while ((data = fsln.Read(buffer, 0, buffer.Length)) != 0) {
                   cs.Write(buffer, 0, data);
               }
                Console.WriteLine(fsln.Length);
               /* while ((data = fsln.ReadByte()) != -1) {
                    cs.WriteByte((byte)data);
                  // Console.WriteLine(fsln.Length);
                   i+=10;
                }*/
                   
                fsln.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch(Exception ex) {
                Console.WriteLine("Erreur cryptage");
                Console.WriteLine(ex.Message);
            }
        }
        public static void DeCrypt_fichier(String nom, String destination) {
           // String password = "12345678";*
            try {
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);
                FileStream fsCrypt = new FileStream(nom, FileMode.Open);
                RijndaelManaged RMCrypto = new RijndaelManaged();
                CryptoStream cs = new CryptoStream(fsCrypt, RMCrypto.CreateDecryptor(key, key), CryptoStreamMode.Read);
                FileStream fsOut = new FileStream(@"" + destination + "\\gg.g", FileMode.Create);
                int data;
                int i = 0;
                byte[] buffer = new byte[65536];
                while ((data = cs.Read(buffer, 0, buffer.Length)) != 0)
                {
                    fsOut.WriteByte((byte)data);
                }

                fsOut.Close();
                cs.Close();
                fsCrypt.Close();
            }catch(Exception ex){
                Console.WriteLine("Erreur décryptage");
                Console.WriteLine(ex.Message);
            }
            
        
        }
     
    }
}
