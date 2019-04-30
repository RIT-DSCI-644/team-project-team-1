<%@ Page Title="Conservative and Liberal Leaning Twitter Feed Analysis" Language="C#"
    MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs"
    Inherits="dsci644._Default" %>

<asp:Content ID="Scripts" ContentPlaceHolderID="cphScripts" runat="server">
    <script type="text/javascript">   
        //Called this method on any button click  event for Testing
        var conservFreqData;
        var libFreqData;
        function setFrequencies(Param1, Param2) {
            //setLiberalFrequencies();
            //setConservativeFrequencies();
        }
        function setLiberalFrequencies() {
            $.ajax({
                type: "POST",
                url: '<%= ResolveUrl("helper.aspx/GetLiberalData") %>',
                data: "{}",
                contentType: "application/json; charset=utf-8",
                //dataType: "json",
                async: "true",
                cache: "false",
                success: function (msg) {
                    // On success
                    libFreqData = msg.d;
                    //alert(msg.d);
                },
                Error: function (x, e) {
                    alert(msg);
                    // On Error
                }
            });
        }
        function setConservativeFrequencies() {
            $.ajax({
                type: "POST",
                url: '<%= ResolveUrl("helper.aspx/GetConservativeData") %>',
                data: "{}",
                contentType: "application/json; charset=utf-8",
                //dataType: "json",
                async: "true",
                cache: "false",
                success: function (msg) {
                    // On success
                    conservFreqData = msg.d;
                    //alert(msg.d);
                },
                Error: function (x, e) {
                    alert(msg);
                    // On Error
                }
            });
        }
        var opts = {
            lines: 13, // The number of lines to draw
            length: 38, // The length of each line
            width: 17, // The line thickness
            radius: 45, // The radius of the inner circle
            scale: 1, // Scales overall size of the spinner
            corners: 0.9, // Corner roundness (0..1)
            color: '#ffffff', // CSS color or array of colors
            fadeColor: 'transparent', // CSS color or array of colors
            speed: 1, // Rounds per second
            rotate: 0, // The rotation offset
            animation: 'spinner-line-fade-quick', // The CSS animation name for the lines
            direction: 1, // 1: clockwise, -1: counterclockwise
            zIndex: 2e9, // The z-index (defaults to 2000000000)
            className: 'spinner', // The CSS class to assign to the spinner
            top: '50%', // Top position relative to parent
            left: '50%', // Left position relative to parent
            shadow: '0 0 1px transparent', // Box-shadow for the lines
            position: 'absolute' // Element positioning
        };

        function startSpinner() {
            //alert(this);
        }
        var target1 = document.getElementById('holder1');
        var spinner1;
        var target2 = document.getElementById('holder2');
        var spinner2;
        $("#holder1").ready(function () { spinner1 = new Spinner(opts).spin(target1); })
        $(document).ready(function () {

            spinner2 = new Spinner(opts).spin(target2);

        });

        $(window).on("load", function () {
            spinner1.stop();
            spinner2.stop();
        });

    </script>
</asp:Content>
<asp:Content ID="Style" ContentPlaceHolderID="cphStyle" runat="server">
    <style>
        @keyframes spinner-line-fade-more {
            0%, 100% {
                opacity: 0; /* minimum opacity */
            }

            1% {
                opacity: 1;
            }
        }

        @keyframes spinner-line-fade-quick {
            0%, 39%, 100% {
                opacity: 0.25; /* minimum opacity */
            }

            40% {
                opacity: 1;
            }
        }

        @keyframes spinner-line-fade-default {
            0%, 100% {
                opacity: 0.22; /* minimum opacity */
            }

            1% {
                opacity: 1;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="column">
            <div class="header">
                <h2>Conservative Leaning</h2>
            </div>
            <!-- -->
            <div id='holder1' class="col-md-4 cloud">
            </div>
            <div class="footer">
            </div>
        </div>
        <div class="column">
            <div class="header">
                <h2>Liberal Leaning</h2>
            </div>
            <!-- -->
            <div id='holder2' class="col-md-4 cloud">
            </div>
            <div class="footer">
            </div>
        </div>
    </div>
</asp:Content>
