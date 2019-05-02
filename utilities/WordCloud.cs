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
            get { return (Dictionary<string, S3KeyWordFreqFontMapping>)
                    HttpContext.Current.Application["liberalFrequencyMatrixMappingData"]; }
        }

        public static Dictionary<string, S3KeyWordFreqFontMapping> GetConservativeFrequencyMatrixMappingData
        {
            get { return (Dictionary<string, S3KeyWordFreqFontMapping>)
                    HttpContext.Current.Application["conservativeFrequencyMatrixMappingData"]; }
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

        public static List<WordFrequencyMatrix> MainPageWordFrequencyMatrix = new List<WordFrequencyMatrix>() {
            new WordFrequencyMatrix(){ Max = 200, Min = 0, FontSize = 2 },
            new WordFrequencyMatrix(){ Max = 400, Min = 201, FontSize = 4 },
            new WordFrequencyMatrix(){ Max = 600, Min = 401, FontSize = 6 },
            new WordFrequencyMatrix(){ Max = 800, Min = 601, FontSize = 8 },
            new WordFrequencyMatrix(){ Max = 1000, Min = 801, FontSize = 20 },
            new WordFrequencyMatrix(){ Max = 1200, Min = 1001, FontSize = 22 },
            new WordFrequencyMatrix(){ Max = 1400, Min = 1201, FontSize = 24 },
            new WordFrequencyMatrix(){ Max = 1600, Min = 1401, FontSize = 26 },
            new WordFrequencyMatrix(){ Max = 1800, Min = 1601, FontSize = 28 },
            new WordFrequencyMatrix(){ Max = 2000, Min = 1801, FontSize = 30 },
            new WordFrequencyMatrix(){ Max = 99999, Min = 2001, FontSize = 32 },
        };

        public static StringBuilder GenerateWordCloud(string WordCloudId, List<string> Tags,
            CloudContext context = CloudContext.HomePage, List<double> Frequencies = null,
         PoliticalLeaningContext leaning = PoliticalLeaningContext.Conservative)
        {
            StringBuilder sbCloud = new StringBuilder();

            Dictionary<string, double> dic = Tags.Zip(Frequencies, (k, v) => new { k, v })
              .ToDictionary(x => x.k, x => x.v);

            sbCloud.AppendLine("<script type=text/javascript>");
            sbCloud.AppendLine("       $(document).ready(function () {");
            sbCloud.AppendLine("            var entries = [");

            if (context == CloudContext.HomePage)
            {
                foreach (var KeyValue in dic)
                {
                    sbCloud.AppendLine(
                        string.Format("                {{ label: '{0}', url: '../Individual.aspx?id={0}', target: '_top' }},",
                        KeyValue.Key));
                }
            }
            else
            {
                foreach (var KeyValue in dic)
                {
                    sbCloud.AppendLine(
                        string.Format("                {{ label: '{0}', url: '#{0}', target: '_self' }},",
                        KeyValue.Key));
                }
            }

            sbCloud.AppendLine("            ];");
            sbCloud.AppendLine("            var settings = {");
            sbCloud.AppendLine("                entries: entries,");
            sbCloud.AppendLine("                width: 480,");
            sbCloud.AppendLine("                height: 480,");
            sbCloud.AppendLine("                radius: '65%',");
            sbCloud.AppendLine("                radiusMin: 75,");
            sbCloud.AppendLine("                bgDraw: true,");
            sbCloud.AppendLine("                bgColor: '#fff',");
            sbCloud.AppendLine("                opacityOver: 1.00,");
            sbCloud.AppendLine("                opacityOut: 0.05,");
            sbCloud.AppendLine("                opacitySpeed: 6,");
            sbCloud.AppendLine("                fov: 800,");
            sbCloud.AppendLine("                speed: 1,");
            sbCloud.AppendLine("                fontFamily: 'Oswald, Arial, sans-serif',");
            sbCloud.AppendLine("                fontSize: '15',");
            sbCloud.AppendLine("                fontColor: '#111',");
            sbCloud.AppendLine("                fontWeight: 'normal',//bold");
            sbCloud.AppendLine("                fontStyle: 'normal',//italic ");
            sbCloud.AppendLine("                fontStretch: 'normal',//wider, narrower, ultra-condensed, extra-condensed, condensed, semi-condensed, semi-expanded, expanded, extra-expanded, ultra-expanded");
            sbCloud.AppendLine("                fontToUpperCase: true");
            sbCloud.AppendLine("            };");
            sbCloud.AppendLine("            //var svg3DTagCloud = new SVG3DTagCloud( document.getElementById( 'holder'  ), settings );");
            sbCloud.AppendLine(string.Format("            $('#{0}').svg3DTagCloud(settings);", WordCloudId));

            if (context == CloudContext.HomePage)
            {
                sbCloud.AppendLine(GenerateWordFrequencies(dic, MainPageWordFrequencyMatrix, leaning).ToString());
                sbCloud.AppendLine("setFrequencies();");
            }

            sbCloud.AppendLine("        });");
            sbCloud.AppendLine("</script>");

            return sbCloud;
        }

        public static StringBuilder GenerateWordCloud(string WordCloudId, Dictionary<string, double> TagsAndFreqs,
         CloudContext context = CloudContext.HomePage,
         PoliticalLeaningContext leaning = PoliticalLeaningContext.Conservative)
        {
            StringBuilder sbCloud = new StringBuilder();

            sbCloud.AppendLine("<script type=text/javascript>");
            sbCloud.AppendLine("       $(document).ready(function () {");
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
            sbCloud.AppendLine("            var settings = {");
            sbCloud.AppendLine("                entries: entries,");
            sbCloud.AppendLine("                width: 480,");
            sbCloud.AppendLine("                height: 480,");
            sbCloud.AppendLine("                radius: '65%',");
            sbCloud.AppendLine("                radiusMin: 75,");
            sbCloud.AppendLine("                bgDraw: true,");
            sbCloud.AppendLine("                bgColor: '#fff',");
            sbCloud.AppendLine("                opacityOver: 1.00,");
            sbCloud.AppendLine("                opacityOut: 0.05,");
            sbCloud.AppendLine("                opacitySpeed: 6,");
            sbCloud.AppendLine("                fov: 800,");
            sbCloud.AppendLine("                speed: 1,");
            sbCloud.AppendLine("                fontFamily: 'Oswald, Arial, sans-serif',");
            sbCloud.AppendLine("                fontSize: '15',");
            sbCloud.AppendLine("                fontColor: '#111',");
            sbCloud.AppendLine("                fontWeight: 'normal',//bold");
            sbCloud.AppendLine("                fontStyle: 'normal',//italic ");
            sbCloud.AppendLine("                fontStretch: 'normal',//wider, narrower, ultra-condensed, extra-condensed, condensed, semi-condensed, semi-expanded, expanded, extra-expanded, ultra-expanded");
            sbCloud.AppendLine("                fontToUpperCase: true");
            sbCloud.AppendLine("            };");
            sbCloud.AppendLine("            //var svg3DTagCloud = new SVG3DTagCloud( document.getElementById( 'holder'  ), settings );");
            sbCloud.AppendLine(string.Format("            $('#{0}').svg3DTagCloud(settings);", WordCloudId));

            if (context == CloudContext.HomePage)
            {
                Dictionary<string, S3KeyWordFreqFontMapping> freqMap;
                switch (leaning)
                {
                    case PoliticalLeaningContext.Conservative:
                        if (GetConservativeFrequencyMatrixMappingData == null)
                        {
                            freqMap = GenerateWordFrequencies(TagsAndFreqs, MainPageWordFrequencyMatrix, leaning);
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
                            freqMap = GenerateWordFrequencies(TagsAndFreqs, MainPageWordFrequencyMatrix, leaning);
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
                foreach (var item in freqMap)
                {

                    //$("[*|href]:not([href])").find("text:contains('DEVIANTART')").attr("font-size","35")
                    sbCloud.AppendLine(
                        string.Format("$('[*|href]:not([href])').find(\"text:contains('{1}')\").attr('font-size','{0}');",
                        item.Value.Front, item.Value.UppercaseKey));
                }
                //sbCloud.AppendLine(GenerateWordFrequencies(TagsAndFreqs, MainPageWordFrequencyMatrix, leaning).ToString());
                sbCloud.AppendLine("setFrequencies();");
            }

            sbCloud.AppendLine("        });");
            sbCloud.AppendLine("</script>");

            return sbCloud;
        }

        public static Dictionary<string, S3KeyWordFreqFontMapping> GenerateWordFrequencies(
            Dictionary<string, double> KeyValues,
            List<WordFrequencyMatrix> Matrix, PoliticalLeaningContext leaning)
        {
            StringBuilder sbWordFrequencies = new StringBuilder();
            Dictionary<string, S3KeyWordFreqFontMapping> freqMap = new Dictionary<string, S3KeyWordFreqFontMapping>();

            //set font-size
            foreach (var keyValue in KeyValues)
            {
                var key = keyValue.Key;
                double value = keyValue.Value;
                for (int j = 0; j < Matrix.Count; j++)
                {
                    var min = Matrix[j].Min;
                    var max = Matrix[j].Max;
                    var font = Matrix[j].FontSize;

                    if ((value >= min && value <= max) || (value >= max && j == (Matrix.Count - 1)))
                    {
                        //found or set to max matrix value
                        freqMap.Add(key, new S3KeyWordFreqFontMapping()
                        {
                            OrigKey = key,
                            UppercaseKey = key.ToUpper(),
                            Frequency = value,
                            Front = font
                        });
                    }
                }
            }

            return freqMap;
        }

        public static void RenderTagCloud(string id, Dictionary<string, double> TagsAndFreqs, System.Web.UI.Page page,
            CloudContext context, PoliticalLeaningContext leaning)
        {
            RenderCloud(utilities.WordCloud.GenerateWordCloud(
                id, TagsAndFreqs,context, leaning).ToString(), page, id);
        }

        public static void RenderTagCloud(string id, List<string> Tags, List<double> Frequencies, System.Web.UI.Page page,
        CloudContext context)
        {
            RenderCloud(utilities.WordCloud.GenerateWordCloud(
                id, Tags, context, Frequencies).ToString(), page, id);
        }

        private static void RenderCloud(string jsRenderScript, System.Web.UI.Page page, string id) {
            // Define the name and type of the client scripts on the page.
            String csname1 = "tagcloud" + id;
            Type cstype = page.GetType();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = page.ClientScript;

            // Check to see if the startup script is already registered.
            if (!cs.IsStartupScriptRegistered(cstype, csname1))
            {
                cs.RegisterStartupScript(cstype, csname1, jsRenderScript);
            }
        }

    }

    public class S3KeyWordFreqFontMapping
    {
        public string OrigKey { get; set; }
        public string UppercaseKey { get; set; }
        public double Frequency { get; set; }
        public int Front { get; set; }
    }
}
