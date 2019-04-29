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
            utilities.WordCloud.RenderTagCloud(
                "holder1", response.WordCloud.Conservative.Tags, response.WordCloud.Conservative.Frequencies,this,
                 utilities.WordCloud.CloudContext.HomePage);
            utilities.WordCloud.RenderTagCloud(
                "holder2", response.WordCloud.Liberal.Tags, response.WordCloud.Liberal.Frequencies,this,
                utilities.WordCloud.CloudContext.HomePage);
        }
    }
}