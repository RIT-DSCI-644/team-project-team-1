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
            var response = aws.S3CRUD.GetIndividualPageDataByKeyName(strKey + ".txt");
            var qryTop50Tags = response.WordCloud.DistinctWords.Skip(response.WordCloud.DistinctWords.Count - 50).ToList();
            var qryTop50Freqs = response.WordCloud.WordFrequencies.Skip(response.WordCloud.WordFrequencies.Count - 50).ToList();
            var qryBottom50Tags = response.WordCloud.DistinctWords.Take(50).ToList();
            var qryBottom50Freqs = response.WordCloud.WordFrequencies.Take(50).ToList();

            utilities.WordCloud.RenderTagCloud(
                "holder1", qryTop50Tags,
                qryTop50Freqs, this,
                utilities.WordCloud.CloudContext.Individual);
            utilities.WordCloud.RenderTagCloud(
                "holder2", qryBottom50Tags,
                qryBottom50Freqs, this,
                utilities.WordCloud.CloudContext.Individual);
            RenderStats(response);
        }

        private void RenderStats(model.IndividualPage indiv)
        {
            pAge.InnerText = indiv.Stats.Age.ToString();
            pAverageRetweetCount.InnerText = ((int)indiv.Stats.AverageRetweetCount).ToString();
            pName.InnerText = indiv.Stats.Name.ToString();
            pGender.InnerText = indiv.Stats.Gender.ToString();
            pPosition.InnerText = indiv.Stats.Position.ToString();
            pNumberOfFollowers.InnerText = ((int)indiv.Stats.NumberOfFollowers).ToString();
            pTotalNumberOfTweets.InnerText = ((int)indiv.Stats.TotalNumberOfTweets).ToString();
            pNumberOfDistinctWordsUsed.InnerText = ((int)indiv.Stats.NumberOfDistinctWordsUsed).ToString();
            pPercentOfTweetsWithMedia.InnerText = ((int)indiv.Stats.PercentOfTweetsWithMedia).ToString();
            blTopFiveWords.DataSource = indiv.Stats.TopFiveWords;
            blTopFiveWords.DataBind();
            blBottomFiveWords.DataSource = indiv.Stats.BottomFiveWords;
            blBottomFiveWords.DataBind();
        }
    }
}