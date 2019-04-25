using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utilities
{
    public class WordCloud
    {
        public enum CloudContext
        {
            Individual,
            HomePage
        }

        public static StringBuilder GenerateWordCloud(string WordCloudId, List<string> Tags,
            CloudContext context = CloudContext.HomePage)
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
            sbCloud.AppendLine("        });");
            sbCloud.AppendLine("</script>");

            return sbCloud;
        }
    }
}
