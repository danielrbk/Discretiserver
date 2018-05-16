using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Client
{
    public partial class PatternRecognition : System.Web.UI.Page
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
            var ft = new FileTransmute.FileHandlerSoapClient();
            /*
            Byte[] fileByteStream, string documentName, string emailAddress, string downloadURL, string abstractionMethod, string classSeperator, 
            int binsNumber, bool abstractedSeries, string datasetName, Byte[] vmap
            */
            Byte[] fb = FileUploadTargetFile.FileBytes;
            Byte[] vmap;

            string url = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority +
                         this.TemplateSourceDirectory + "/Download.aspx";
            string completedRequest = "";
            try
            {
                completedRequest = ft.RunKarmaLego(fb, TextBoxDatasetName.Text, TextBoxEmail.Text, url, 
                    System.Int32.Parse(TextBoxMinVSup.Text), System.Int32.Parse(TextBoxMaxGap.Text), System.Int32.Parse(TextBoxEpsilon.Text),CheckBoxHSup.Checked);
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
    }
}