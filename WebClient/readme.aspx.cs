using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Client
{
    public partial class readme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority +
                         this.TemplateSourceDirectory;
            this.Label1.Text = "<a href=" + url + "/Main.aspx>Back to main page</a>";
            this.Label2.Text = "<a href=" + url + "/Download.aspx?dl=example>here</a>";

        }
    }
}