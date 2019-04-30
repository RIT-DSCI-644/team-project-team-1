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
            //var response = aws.S3CRUD.GetMainPageData;
            utilities.WordCloud.RenderTagCloud(
                "holder1", aws.S3CRUD.GetConservativeFrequencyData, this,
                 utilities.WordCloud.CloudContext.HomePage, utilities.WordCloud.PoliticalLeaningContext.Conservative);
            utilities.WordCloud.RenderTagCloud(
                "holder2", aws.S3CRUD.GetLiberalFrequencyData, this,
                utilities.WordCloud.CloudContext.HomePage, utilities.WordCloud.PoliticalLeaningContext.Liberal);
        }

        private void RenderStats() {
            //aws.S3CRUD.GetMainPageData.WordCloud
        }
    }
}