using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using model;
using System.Web;

namespace utilities
{
    public class WordCloud
    {
        public enum CloudContext
        {
            Individual,
            HomePage
        }

        public enum PoliticalLeaningContext
        {
            Conservative,
            Liberal
        }

        public static Dictionary<string, S3KeyWordFreqFontMapping> GetLiberalFrequencyMatrixMappingData
        {
            get
            {
                return (Dictionary<string, S3KeyWordFreqFontMapping>)
                  HttpContext.Current.Application["liberalFrequencyMatrixMappingData"];
            }
        }

        public static Dictionary<string, S3KeyWordFreqFontMapping> GetConservativeFrequencyMatrixMappingData
        {
            get
            {
                return (Dictionary<string, S3KeyWordFreqFontMapping>)
                  HttpContext.Current.Application["conservativeFrequencyMatrixMappingData"];
            }
        }

        private static Dictionary<string, S3KeyWordFreqFontMapping> SetLiberalFrequencyMatrixMappingData
        {
            set
            {
                HttpContext.Current.Application["liberalFrequencyMatrixMappingData"] = value;
            }
        }

        private static Dictionary<string, S3KeyWordFreqFontMapping> SetConservativeFrequencyMatrixMappingData
        {
            set
            {
                HttpContext.Current.Application["conservativeFrequencyMatrixMappingData"] = value;
            }
        }

        public static StringBuilder GenerateWordCloud(string WordCloudId, Dictionary<string, double> TagsAndFreqs,
         double MaxFontSize, CloudContext context = CloudContext.HomePage,
         PoliticalLeaningContext leaning = PoliticalLeaningContext.Conservative)
        {
            StringBuilder sbCloud = new StringBuilder();

            sbCloud.Append(StartJsScript());
            sbCloud.Append(SetCloudControlEntitiesJsScript(TagsAndFreqs, context));
            sbCloud.Append(CreateCloudSettingJsScript());
            sbCloud.AppendLine(string.Format("            $('#{0}').svg3DTagCloud(settings);", WordCloudId));

            Dictionary<string, S3KeyWordFreqFontMapping> freqMap = null;

            if (context == CloudContext.HomePage)
            {
                switch (leaning)
                {
                    case PoliticalLeaningContext.Conservative:
                        if (GetConservativeFrequencyMatrixMappingData == null)
                        {
                            freqMap = GenerateWordFrequencies(TagsAndFreqs, MaxFontSize);
                            SetConservativeFrequencyMatrixMappingData = freqMap;
                        }
                        else
                        {
                            freqMap = GetConservativeFrequencyMatrixMappingData;
                        }

                        break;
                    case PoliticalLeaningContext.Liberal:
                        if (GetLiberalFrequencyMatrixMappingData == null)
                        {
                            freqMap = GenerateWordFrequencies(TagsAndFreqs, MaxFontSize);
                            SetLiberalFrequencyMatrixMappingData = freqMap;
                        }
                        else
                        {
                            freqMap = GetLiberalFrequencyMatrixMappingData;
                        }
                        break;
                    default:
                        freqMap = new Dictionary<string, S3KeyWordFreqFontMapping>();
                        break;
                }
            }
            else
            {
                freqMap = GenerateWordFrequencies(TagsAndFreqs, MaxFontSize);
            }

            foreach (var item in freqMap)
            {
                //$("[*|href]:not([href])").find("text:contains('DEVIANTART')").attr("font-size","35")
                sbCloud.AppendLine(
                    string.Format("$('[*|href]:not([href])').find(\"text:contains('{1}')\").attr('font-size','{0}');",
                    item.Value.Font, item.Value.UppercaseKey));
            }

            if (context == CloudContext.HomePage)
            {
                sbCloud.AppendLine("setFrequencies();");
            }

            sbCloud.Append(EndJsScript());

            return sbCloud;
        }

        public static string StartJsScript()
        {
            StringBuilder sbCloud = new StringBuilder();

            sbCloud.AppendLine("<script type=text/javascript>");
            sbCloud.AppendLine("       $(document).ready(function () {");

            return sbCloud.ToString();
        }

        public static string EndJsScript()
        {
            StringBuilder sbCloud = new StringBuilder();
            sbCloud.AppendLine("        });");
            sbCloud.AppendLine("</script>");
            return sbCloud.ToString();
        }

        public static string SetCloudControlEntitiesJsScript(Dictionary<string, double> TagsAndFreqs,
            CloudContext context = CloudContext.HomePage)
        {
            StringBuilder sbCloud = new StringBuilder();
            sbCloud.AppendLine("            var entries = [");
            if (context == CloudContext.HomePage)
            {
                foreach (var KeyValue in TagsAndFreqs)
                {
                    sbCloud.AppendLine(
                        string.Format("                {{ label: '{0}', url: '../Individual.aspx?id={0}', target: '_top' }},",
                        KeyValue.Key));
                }
            }
            else
            {
                foreach (var KeyValue in TagsAndFreqs)
                {
                    sbCloud.AppendLine(
                        string.Format("                {{ label: '{0}', url: '#{0}', target: '_self' }},",
                        KeyValue.Key));
                }
            }
            sbCloud.AppendLine("            ];");
            return sbCloud.ToString();
        }

        public static Dictionary<string, S3KeyWordFreqFontMapping> GenerateWordFrequencies(
            Dictionary<string, double> KeyValues, double MaxFontSize)
        {
            StringBuilder sbWordFrequencies = new StringBuilder();
            Dictionary<string, S3KeyWordFreqFontMapping> freqMap = new Dictionary<string, S3KeyWordFreqFontMapping>();

            var maxFreq = KeyValues.Max(t => t.Value);
            double maxFont = MaxFontSize;
            double minFont = 2.0;

            //set font-size
            foreach (var keyValue in KeyValues)
            {
                var key = keyValue.Key;
                double value = keyValue.Value;
                int computedFont = (int)(((maxFont * ((value * 100) / maxFreq)) / 100) + minFont) * 2;

                freqMap.Add(key, new S3KeyWordFreqFontMapping()
                {
                    OrigKey = key,
                    UppercaseKey = key.ToUpper(),
                    Frequency = value,
                    Font = computedFont
                });
            }

            return freqMap;
        }

        public static void RenderTagCloud(string id, Dictionary<string, double> TagsAndFreqs, System.Web.UI.Page page,
            CloudContext context, PoliticalLeaningContext leaning, double MaxFontSize= 15.0)
        {

            // Define the name and type of the client scripts on the page.
            String csname1 = "tagcloud" + id;
            Type cstype = page.GetType();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = page.ClientScript;

            // Check to see if the startup script is already registered.
            if (!cs.IsStartupScriptRegistered(cstype, csname1))
            {
                cs.RegisterStartupScript(cstype, csname1, utilities.WordCloud.GenerateWordCloud(
                id, TagsAndFreqs, MaxFontSize, context, leaning).ToString());
            }
        }

        private static string CreateCloudSettingJsScript()
        {
            StringBuilder sbCloudSettings = new StringBuilder();

            sbCloudSettings.AppendLine("            var settings = {");
            sbCloudSettings.AppendLine("                entries: entries,");
            sbCloudSettings.AppendLine("                width: 480,");
            sbCloudSettings.AppendLine("                height: 480,");
            sbCloudSettings.AppendLine("                radius: '65%',");
            sbCloudSettings.AppendLine("                radiusMin: 75,");
            sbCloudSettings.AppendLine("                bgDraw: true,");
            sbCloudSettings.AppendLine("                bgColor: '#fff',");
            sbCloudSettings.AppendLine("                opacityOver: 1.00,");
            sbCloudSettings.AppendLine("                opacityOut: 0.05,");
            sbCloudSettings.AppendLine("                opacitySpeed: 6,");
            sbCloudSettings.AppendLine("                fov: 800,");
            sbCloudSettings.AppendLine("                speed: 1,");
            sbCloudSettings.AppendLine("                fontFamily: 'Oswald, Arial, sans-serif',");
            sbCloudSettings.AppendLine("                fontSize: '15',");
            sbCloudSettings.AppendLine("                fontColor: '#111',");
            sbCloudSettings.AppendLine("                fontWeight: 'normal',//bold");
            sbCloudSettings.AppendLine("                fontStyle: 'normal',//italic ");
            sbCloudSettings.AppendLine("                fontStretch: 'normal',//wider, narrower, ultra-condensed, extra-condensed, condensed, semi-condensed, semi-expanded, expanded, extra-expanded, ultra-expanded");
            sbCloudSettings.AppendLine("                fontToUpperCase: true");
            sbCloudSettings.AppendLine("            };");
            return sbCloudSettings.ToString();
        }
    }

    public class S3KeyWordFreqFontMapping
    {
        public string OrigKey { get; set; }
        public string UppercaseKey { get; set; }
        public double Frequency { get; set; }
        public int Font { get; set; }
    }
}
