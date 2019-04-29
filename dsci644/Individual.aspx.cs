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
            utilities.WordCloud.RenderTagCloud(
                "holder1", response.WordCloud.DistinctWords, response.WordCloud.WordFrequencies,this,
                utilities.WordCloud.CloudContext.Individual);
        }
    }
}