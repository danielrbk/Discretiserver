using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Client.FileTransmute;

namespace Web_Client
{
    public partial class Main : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority +
                         this.TemplateSourceDirectory + "/readme.aspx";
            this.Label1.Text = "<a href=" + url + ">readme</a>";

        }

        protected void TextBoxEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxEmail.Text))
            {
                e.Cancel = true;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=\"JavaScript\">alert(\"Discretisation Recieved!\")</SCRIPT>");
            var ft = new FileTransmute.FileHandlerSoapClient();
            /*
            Byte[] fileByteStream, string documentName, string emailAddress, string downloadURL, string abstractionMethod, string classSeperator, 
            int binsNumber, bool abstractedSeries, string datasetName, Byte[] vmap
            */
            Byte[] fb = FileUploadTargetFile.FileBytes;
            Byte[] vmap;
            if (FileUploadVariableMap.HasFile)
                vmap = FileUploadVariableMap.FileBytes;
            else
                vmap = null;

            string url = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority +
                         this.TemplateSourceDirectory + "/Download.aspx";
            string completedRequest = "";
            try
            {
                ArrayOfString abstractionMethods = GetMethods();
                completedRequest = ft.RunTD4C(fb, FileUploadTargetFile.FileName, TextBoxEmail.Text, url, abstractionMethods, TextBoxClassSearator.Text,
                    System.Convert.ToInt32(TextBoxBinsNumber.Text), CheckBoxAbstractedTimeSeries.Checked, TextBoxDatasetName.Text, vmap);
            }
            catch (Exception exception)
            {

            }


            if (!string.IsNullOrEmpty(completedRequest))
                this.Label1.Text = "<a href=" + url + "/?dl=" + completedRequest + ">Your file can be found here</a>";
            else
                this.Label1.Text = "A link to your file will be sent to you via the email you provided";
            this.Label1.Visible = true;
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private ArrayOfString GetMethods()
        {
            ArrayOfString arr = new ArrayOfString();

            if (CheckBoxEQW.Checked)
                arr.Add("EQW");
            if (CheckBoxSAX.Checked)
                arr.Add("SAX");
            if (CheckBoxTD4CCos.Checked)
                arr.Add("TD4C_Cos");
            if (CheckBoxTD4CDEnt.Checked)
                arr.Add("TD4C_DEnt");
            if (CheckBoxTD4CDiffSum.Checked)
                arr.Add("TD4C_DiffSum");
            if (CheckBoxTD4CDiffSumMax.Checked)
                arr.Add("TD4C_DiffSumMax");
            if (CheckBoxTD4CEnt.Checked)
                arr.Add("TD4C_Ent");
            if (CheckBoxTD4CKL.Checked)
                arr.Add("TD4C_KL");

            return arr;
        }
    }
}