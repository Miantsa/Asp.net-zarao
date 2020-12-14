using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Zarao
{
    /// <summary>
    /// Summary description for FileHandler
    /// </summary>
    public class FileHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                if (context.Request.Files.Count > 0)
                {
                    HttpFileCollection files = context.Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFile file = files[i];
                        Console.WriteLine(file.FileName);
                    }
                }


            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
           
              
               
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}