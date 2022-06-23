using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Telerik.Web.UI;

namespace TranSmart.Static
{
    public class Files
    {
        public static void DirectoryConfirm(string strDirectory)
        {
            if (!Directory.Exists(strDirectory))
                Directory.CreateDirectory(strDirectory);
        }

       public static void SaveFile(UploadedFile f, string path)
        {
            try
            {
                if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(path)))
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path));
                f.SaveAs(path, true);
            }
            catch (Exception ex) { Global.Log.Error(ex); }
        }
       public static  void DownloadFile(string filePath, HttpResponse Response,HttpServerUtility Server)
        {
            System.IO.FileInfo file = new System.IO.FileInfo(Server.MapPath(filePath));
            Response.Clear();
            Response.ClearHeaders();
            Response.ClearContent();
            Response.AddHeader("Content-Disposition", "attachment; filename=\"" + file.Name + "\"");
            Response.AddHeader("Content-Length", file.Length.ToString());
            Response.ContentType = "text/plain";
            Response.Flush();

            //Response.AddHeader("Content-Disposition", "attachment; filename=\"" + taskDetails.TaskFile + "\"");
            Response.TransmitFile(filePath);
            Response.End();
        }

    }
}