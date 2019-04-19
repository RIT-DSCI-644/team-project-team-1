<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="dsci644._Default" %>

<%@ Register TagPrefix="wcl" Namespace="WordCloud" %>
<asp:Content ID="Scripts" ContentPlaceHolderID="cphScripts" runat="server">
</asp:Content>
<asp:Content ID="Style" ContentPlaceHolderID="cphStyle" runat="server">
    <style>
        /* Style the header */
        .header {
            background-color: #f1f1f1;
            padding: 30px;
            text-align: center;
            font-size: 35px;
        }

        /* Create three equal columns that floats next to each other */
        .column {
            float: left;
            width: 50%;
            padding: 10px;
        }

        /* Clear floats after the columns */
        .row:after {
            content: "";
            display: table;
            clear: both;
        }

        /* Style the footer */
        .footer {
            clear: both;
            background-color: #f1f1f1;
            padding: 10px;
            text-align: center;
        }

        /* Responsive layout - makes the three columns stack on top of each other instead of next to each other */
        @media (max-width: 600px) {
            .column {
                width: 100%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="column">
            <div class="header">
                <h2>Header</h2>
            </div>
            <!-- -->
            <div id='holder1' class="col-md-4"></div>
            <div class="footer">
                <p>Footer</p>
            </div>
        </div>
        <div class="column">
            <div class="header">
                <h2>Header</h2>
            </div>
            <!-- -->
            <div id='holder2' class="col-md-4"></div>
            <div class="footer">
                <p>Footer</p>
            </div>
        </div>
    </div>
</asp:Content>
