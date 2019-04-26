using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace dsci644
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var response = aws.S3CRUD.GetMainPageData();
            RenderTagCloud("holder1", response.WordCloud.Conservative.Tags, response.WordCloud.Conservative.Frequencies);
            RenderTagCloud("holder2", response.WordCloud.Liberal.Tags, response.WordCloud.Liberal.Frequencies);
        }

        public void RenderTagCloud(string id, List<string> Tags, List<double> Frequencies)
        {
            // Define the name and type of the client scripts on the page.
            String csname1 = "tagcloud" + id;
            Type cstype = this.GetType();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = Page.ClientScript;

            // Check to see if the startup script is already registered.
            if (!cs.IsStartupScriptRegistered(cstype, csname1))
            {
                
                StringBuilder cstext1 = utilities.WordCloud.GenerateWordCloud(id, Tags, 
                    utilities.WordCloud.CloudContext.HomePage, Frequencies);
                cs.RegisterStartupScript(cstype, csname1, cstext1.ToString());

                //set font-size
                //$("[*|href]:not([href])").find("text:contains('DEVIANTART')").attr("font-size","35")
            }
        }
    }
}