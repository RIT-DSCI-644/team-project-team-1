using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
namespace dsci644
{
    public partial class helper : System.Web.UI.Page
    {
        public static model.MainPage mainPageData;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static string GetConservativeData()
        {
            if (mainPageData== null)
                mainPageData = aws.S3CRUD.GetMainPageData();

            Dictionary<string, double> dic = mainPageData.WordCloud.Conservative.Tags.Zip(
                mainPageData.WordCloud.Conservative.Frequencies, (k, v) => new { k, v })
              .ToDictionary(x => x.k, x => x.v);
            return Newtonsoft.Json.JsonConvert.SerializeObject(dic);
        }

        [WebMethod]
        public static string GetLiberalData()
        {
            if (mainPageData == null)
                mainPageData = aws.S3CRUD.GetMainPageData();

            Dictionary<string, double> dic = mainPageData.WordCloud.Liberal.Tags.Zip(
                mainPageData.WordCloud.Liberal.Frequencies, (k, v) => new { k, v })
              .ToDictionary(x => x.k, x => x.v);
            return Newtonsoft.Json.JsonConvert.SerializeObject(dic);
        }
    }
}