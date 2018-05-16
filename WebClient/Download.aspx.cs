using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Web_Client
{
    public partial class Download : System.Web.UI.Page
    {
        private string fileName = "";
        private Byte[] file;
        private event EventHandler FileReady;
        private HttpResponse curr;
        protected void Page_Load(object sender, EventArgs e)
        {
            curr = Response;
            fileName = Request.QueryString["dl"];
            if (string.IsNullOrEmpty(fileName))
            {
                MessageBox.Show("Improper access!");
            }
            else
            {
                FileReady += EnableButtonEvent;
                Label1.Load += StartNewThread;
                var f = new Web_Client.FileTransmute.FileHandlerSoapClient();
                file = f.GetFile(fileName);
                if (file != null)
                {
                    DownloadFile();
                }
            }
        }

        protected void StartNewThread(object sender, EventArgs e)
        {
            this.Label1.Text = "File still being created...";
            FileReady += new EventHandler(EnableButtonEvent);
            Thread t = new Thread(CheckForFile);
            t.Start();
        }
        protected void EnableButtonEvent(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Redirect(Request.RawUrl);
        }
        protected void CheckForFile()
        {
            var f = new Web_Client.FileTransmute.FileHandlerSoapClient();
            while (file==null)
            {
                file = f.GetFile(fileName);
            }
            FileReady(Label1,new EventArgs());
        }

        protected void DownloadFile()
        {
            Response.Clear();
            Response.ClearHeaders();
            Response.ClearContent();
            if (fileName != "example")
                fileName = "ProcessedFiles";
            Response.AddHeader("Content-Disposition", "attachment; filename="+ fileName+".zip");
            Response.AddHeader("Content-Length", file.Length.ToString());
            Response.ContentType = "application/x-zip-compressed";

            Response.Flush();
            Response.BinaryWrite(file); 
            Response.End();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DownloadFile();
        }
    }
}