using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Qrcms.Common
{
    public class pageHelper : System.Web.UI.Page
    {
        public static void WriteEnd(string cont)
        {
            HttpContext.Current.Response.ContentType = "application/json";
            HttpContext.Current.Response.Write(cont);
            HttpContext.Current.Response.End();
        }
       
        public static void WriteLog(string cont)
        {
            HttpContext context = HttpContext.Current;
            string realPath = context.Server.MapPath("/Log/" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
            FileStream fsWriter = null;
            if (!Directory.Exists(context.Server.MapPath("/Log/")))
            {
                Directory.CreateDirectory(context.Server.MapPath("/Log/"));
            }
            if (!File.Exists(realPath))
            {
                fsWriter = new FileStream(realPath, FileMode.Create);
            }
            else
            {
                fsWriter = new FileStream(realPath, FileMode.Append);
            }
            StreamWriter sw = new StreamWriter(fsWriter);
            sw.WriteLine(cont);
            sw.Close();
            fsWriter.Close();
        }
    }
}
