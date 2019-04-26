using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace dsci644
{
    public partial class Individual : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strKey = Request.QueryString["id"];
            if (string.IsNullOrEmpty(strKey))
                Response.Redirect("~/");
            lblName.Text = strKey;
            var response = aws.S3CRUD.GetIndividualPageDataByKeyName(strKey+".txt");
            RenderTagCloud("holder1", response.WordCloud.DistinctWords);
        }

        public void RenderTagCloud(string id, List<string> Tags)
        {
            // Define the name and type of the client scripts on the page.
            String csname1 = "tagcloud" + id;
            Type cstype = this.GetType();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = Page.ClientScript;

            // Check to see if the startup script is already registered.
            if (!cs.IsStartupScriptRegistered(cstype, csname1))
            {
                StringBuilder cstext1 = utilities.WordCloud.GenerateWordCloud(id, Tags, utilities.WordCloud.CloudContext.Individual);
                cs.RegisterStartupScript(cstype, csname1, cstext1.ToString());
            }
        }
    }
}