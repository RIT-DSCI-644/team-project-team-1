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
            return Newtonsoft.Json.JsonConvert.SerializeObject(aws.S3CRUD.GetConservativeFrequencyData);
        }

        [WebMethod]
        public static string GetLiberalData()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(aws.S3CRUD.GetLiberalFrequencyData);
        }
    }
}