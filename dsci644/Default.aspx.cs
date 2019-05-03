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
            double dblMaxFontSize = 17.0;
            //var response = aws.S3CRUD.GetMainPageData;
            utilities.WordCloud.RenderTagCloud(
                "holder1", aws.S3CRUD.GetConservativeFrequencyData, this,
                 utilities.WordCloud.CloudContext.HomePage, utilities.WordCloud.PoliticalLeaningContext.Conservative,
                 dblMaxFontSize);
            utilities.WordCloud.RenderTagCloud(
                "holder2", aws.S3CRUD.GetLiberalFrequencyData, this,
                utilities.WordCloud.CloudContext.HomePage, utilities.WordCloud.PoliticalLeaningContext.Liberal,
                dblMaxFontSize);
        }

        private void RenderStats() {
            //aws.S3CRUD.GetMainPageData.WordCloud
        }
    }
}