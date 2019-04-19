using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

//using WordCloud;

namespace dsci644
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RenderTagCloud("holder1", "");
            RenderTagCloud("holder2", "");
        }

        public void RenderTagCloud(string id, string entities)
        {
            // Define the name and type of the client scripts on the page.
            String csname1 = "tagcloud" + id;
            Type cstype = this.GetType();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = Page.ClientScript;

            // Check to see if the startup script is already registered.
            if (!cs.IsStartupScriptRegistered(cstype, csname1))
            {
                StringBuilder cstext1 = new StringBuilder();

                cstext1.AppendLine("<script type=text/javascript>");
                cstext1.AppendLine("       $(document).ready(function () {");
                cstext1.AppendLine("            var entries = [");
                cstext1.AppendLine("                { label: 'Dev Blog', url: 'http://niklasknaack.blogspot.de/', target: '_top' },");
                cstext1.AppendLine("                { label: 'Flashforum', url: 'http://www.flashforum.de/', target: '_top' },");
                cstext1.AppendLine("                { label: 'jQueryScript.net', url: 'http://www.jqueryscript.net/', target: '_top' },");
                cstext1.AppendLine("                { label: 'Javascript-Forum', url: 'http://forum.jswelt.de/', target: '_top' },");
                cstext1.AppendLine("                { label: 'JSFiddle', url: 'https://jsfiddle.net/user/NiklasKnaack/fiddles/', target: '_top' },");
                cstext1.AppendLine("                { label: 'CodePen', url: 'http://codepen.io/', target: '_top' },");
                cstext1.AppendLine("                { label: 'three.js', url: 'http://threejs.org/', target: '_top' },");
                cstext1.AppendLine("                { label: 'WebGLStudio.js', url: 'http://webglstudio.org/', target: '_top' },");
                cstext1.AppendLine("                { label: 'JS Compress', url: 'http://jscompress.com/', target: '_top' },");
                cstext1.AppendLine("                { label: 'TinyPNG', url: 'https://tinypng.com/', target: '_top' },");
                cstext1.AppendLine("                { label: 'Can I Use', url: 'http://caniuse.com/', target: '_top' },");
                cstext1.AppendLine("                { label: 'URL shortener', url: 'https://goo.gl/', target: '_top' },");
                cstext1.AppendLine("                { label: 'HTML Encoder', url: 'http://www.opinionatedgeek.com/DotNet/Tools/HTMLEncode/Encode.aspx', target: '_top' },");
                cstext1.AppendLine("                { label: 'Twitter', url: 'https://twitter.com/niklaswebdev', target: '_top' },");
                cstext1.AppendLine("                { label: 'deviantART', url: 'http://nkunited.deviantart.com/', target: '_top' },");
                cstext1.AppendLine("                { label: 'Gulp', url: 'http://gulpjs.com/', target: '_top' },");
                cstext1.AppendLine("                { label: 'Browsersync', url: 'https://www.browsersync.io/', target: '_top' },");
                cstext1.AppendLine("                { label: 'GitHub', url: 'https://github.com/', target: '_top' },");
                cstext1.AppendLine("                { label: 'Shadertoy', url: 'https://www.shadertoy.com/', target: '_top' },");
                cstext1.AppendLine("                { label: 'Starling', url: 'http://gamua.com/starling/', target: '_top' },");
                cstext1.AppendLine("                { label: 'jsPerf', url: 'http://jsperf.com/', target: '_top' },");
                cstext1.AppendLine("                { label: 'Foundation', url: 'http://foundation.zurb.com/', target: '_top' },");
                cstext1.AppendLine("                { label: 'CreateJS', url: 'http://createjs.com/', target: '_top' },");
                cstext1.AppendLine("                { label: 'Velocity.js', url: 'http://julian.com/research/velocity/', target: '_top' },");
                cstext1.AppendLine("                { label: 'TweenLite', url: 'https://greensock.com/docs/#/HTML5/GSAP/TweenLite/', target: '_top' },");
                cstext1.AppendLine("                { label: 'jQuery', url: 'https://jquery.com/', target: '_top' },");
                cstext1.AppendLine("                { label: 'jQuery Rain', url: 'http://www.jqueryrain.com/', target: '_top' },");
                cstext1.AppendLine("                { label: 'jQuery Plugins', url: 'http://jquery-plugins.net/', target: '_top' }");
                cstext1.AppendLine("            ];");
                cstext1.AppendLine("            var settings = {");
                cstext1.AppendLine("                entries: entries,");
                cstext1.AppendLine("                width: 480,");
                cstext1.AppendLine("                height: 480,");
                cstext1.AppendLine("                radius: '65%',");
                cstext1.AppendLine("                radiusMin: 75,");
                cstext1.AppendLine("                bgDraw: true,");
                cstext1.AppendLine("                bgColor: '#fff',");
                cstext1.AppendLine("                opacityOver: 1.00,");
                cstext1.AppendLine("                opacityOut: 0.05,");
                cstext1.AppendLine("                opacitySpeed: 6,");
                cstext1.AppendLine("                fov: 800,");
                cstext1.AppendLine("                speed: 1,");
                cstext1.AppendLine("                fontFamily: 'Oswald, Arial, sans-serif',");
                cstext1.AppendLine("                fontSize: '15',");
                cstext1.AppendLine("                fontColor: '#111',");
                cstext1.AppendLine("                fontWeight: 'normal',//bold");
                cstext1.AppendLine("                fontStyle: 'normal',//italic ");
                cstext1.AppendLine("                fontStretch: 'normal',//wider, narrower, ultra-condensed, extra-condensed, condensed, semi-condensed, semi-expanded, expanded, extra-expanded, ultra-expanded");
                cstext1.AppendLine("                fontToUpperCase: true");
                cstext1.AppendLine("            };");
                cstext1.AppendLine("            //var svg3DTagCloud = new SVG3DTagCloud( document.getElementById( 'holder'  ), settings );");
                cstext1.AppendLine(string.Format("            $('#{0}').svg3DTagCloud(settings);", id));
                cstext1.AppendLine("        });");
                cstext1.AppendLine("</script>");
                cs.RegisterStartupScript(cstype, csname1, cstext1.ToString());

                //set font-size
                //$("[*|href]:not([href])").find("text:contains('DEVIANTART')").attr("font-size","35")
            }
        }
    }
}