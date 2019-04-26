using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace utilities
{
    public class WordCloud
    {
        public enum CloudContext
        {
            Individual,
            HomePage
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
            CloudContext context = CloudContext.HomePage, List<double> Frequencies = null)
        {
            StringBuilder sbCloud = new StringBuilder();

            sbCloud.AppendLine("<script type=text/javascript>");
            sbCloud.AppendLine("       $(document).ready(function () {");
            sbCloud.AppendLine("            var entries = [");
            foreach (string Tag in Tags)
            {
                if (context == CloudContext.HomePage)
                {
                    sbCloud.AppendLine(string.Format("                {{ label: '{0}', url: '../Individual.aspx?id={0}', target: '_top' }},", Tag));
                }
                else
                {
                    sbCloud.AppendLine(string.Format("                {{ label: '{0}', url: '#{0}', target: '_self' }},", Tag));
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
                sbCloud.AppendLine(GenerateWordFrequencies(Tags, Frequencies, MainPageWordFrequencyMatrix).ToString());
            }

            sbCloud.AppendLine("        });");
            sbCloud.AppendLine("</script>");

            return sbCloud;
        }

        public static StringBuilder GenerateWordFrequencies(List<string> Tags, List<double> Frequencies, List<WordFrequencyMatrix> Matrix)
        {
            StringBuilder sbWordFrequencies = new StringBuilder();
            //set font-size
            for (int i = 0; i < Tags.Count; i++)
            {
                var tag = Tags[i];
                double freq = Frequencies[i];
                for (int j = 0; j < Matrix.Count; j++)
                {
                    var min = Matrix[j].Min;
                    var max = Matrix[j].Max;
                    var font = Matrix[j].FontSize;
                    
                    if ((freq >= min && freq <= max) || (freq >= max && j == (Matrix.Count - 1)))
                    {
                        //found or set to max matrix value
                        
                        sbWordFrequencies.AppendLine(
                            string.Format(            "$('[*|href]:not([href])').find(\"text:contains('{1}')\").attr('font-size','{0}');",
                            font,tag.ToUpper()));
                        
                    }
                }
            }
            //$("[*|href]:not([href])").find("text:contains('DEVIANTART')").attr("font-size","35")
            return sbWordFrequencies;
        }
    }
}
