<%@ Page Title="Individual Twitter Feed Analytics" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Individual.aspx.cs" Inherits="dsci644.Individual" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphStyle" runat="server">
    <style>
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="column">
            <div class="header">
                <h2>
                    <asp:Label ID="lblName" runat="server"></asp:Label></h2>
            </div>
            <!-- -->
            <div id='holder1' class="col-md-4"></div>
        </div>
        <div class="column">
            <div class="header">
                <h2>Individual Twitter Statistics</h2>
            </div>
            <div class="row">
                <div class="column">
                    <div class="blockquote offset">
                        <p>name</p>
                    </div>
                </div>
                <div class="column">
                    <div class="statsOutput">

                        <p id="pName" runat="server" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="column">
                    <div class="blockquote offset">
                        <p>age</p>
                    </div>
                </div>
                <div class="column">
                    <div class="statsOutput">

                        <p id="pAge" runat="server" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="column">
                    <div class="blockquote offset">
                        <p>gender</p>
                    </div>
                </div>
                <div class="column">
                    <div class="statsOutput">

                        <p id="pGender" runat="server" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="column">
                    <div class="blockquote offset">
                        <p>position</p>
                    </div>
                </div>
                <div class="column">
                    <div class="statsOutput">

                        <p id="pPosition" runat="server" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="column">
                    <div class="blockquote offset">
                        <p>number of followers</p>
                    </div>
                </div>
                <div class="column">
                    <div class="statsOutput">

                        <p id="pNumberOfFollowers" runat="server" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="column">
                    <div class="blockquote offset">
                        <p>total number of tweets</p>
                    </div>
                </div>
                <div class="column">
                    <div class="statsOutput">

                        <p id="pTotalNumberOfTweets" runat="server" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="column">
                    <div class="blockquote offset">
                        <p>number of distinct words used</p>
                    </div>
                </div>
                <div class="column">
                    <div class="statsOutput">

                        <p id="pNumberOfDistinctWordsUsed" runat="server" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="column">
                    <div class="blockquote offset">
                        <p>top 5 words</p>
                    </div>
                </div>
                <div class="column">
                    <div class="statsOutput">
                        <asp:BulletedList ID="blTopFiveWords" CssClass="custom recursive" runat="server"></asp:BulletedList>

                    </div>
                </div>
            </div>
            <div class="row">
                <div class="column">
                    <div class="blockquote offset">
                        <p>bottom 5 words</p>
                    </div>
                </div>
                <div class="column">
                    <div class="statsOutput">

                        <asp:BulletedList ID="blBottomFiveWords" CssClass="custom recursive" runat="server"></asp:BulletedList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="column">
                    <div class="blockquote offset">
                        <p>average retweet count</p>
                    </div>
                </div>
                <div class="column">
                    <div class="statsOutput">

                        <p id="pAverageRetweetCount" runat="server" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="column">
                    <div class="blockquote offset">
                        <p>percent of tweets with media</p>
                    </div>
                </div>
                <div class="column">
                    <div class="statsOutput">

                        <p id="pPercentOfTweetsWithMedia" runat="server" />
                    </div>
                </div>
            </div>
            <!--
            <div class="blockquote offset">
                <p>Some have called Cornell the “first American university.”</p>
            </div>
            <p>
                Integer posuere erat a ante venenatis dapibus posuere velit aliquet. Aenean eu leo quam. Pellentesque ornare sem lacinia quam venenatis vestibulum. 
                    Aenean eu leo quam. Pellentesque ornare sem lacinia quam venenatis vestibulum. Donec sed odio dui. Sed posuere consectetur est at lobortis. 
                    Nulla vitae elit libero, a pharetra augue. Nullam quis risus eget urna mollis ornare vel eu leo. Integer posuere erat a ante venenatis dapibus
                    posuere velit aliquet. Curabitur blandit tempus porttitor. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum 
                    massa justo sit amet risus. Cras justo odio, dapibus ac facilisis in, egestas eget quam. Aenean lacinia bibendum nulla sed consectetur.
            </p>
            <div class="blockquote offset">
                <p>Some have called Cornell the “first American university.”</p>
            </div>
            <p>
                Integer posuere erat a ante venenatis dapibus posuere velit aliquet. Aenean eu leo quam. Pellentesque ornare sem lacinia quam venenatis vestibulum. 
                    Aenean eu leo quam. Pellentesque ornare sem lacinia quam venenatis vestibulum. Donec sed odio dui. Sed posuere consectetur est at lobortis. 
                    Nulla vitae elit libero, a pharetra augue. Nullam quis risus eget urna mollis ornare vel eu leo. Integer posuere erat a ante venenatis dapibus
                    posuere velit aliquet. Curabitur blandit tempus porttitor. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum 
                    massa justo sit amet risus. Cras justo odio, dapibus ac facilisis in, egestas eget quam. Aenean lacinia bibendum nulla sed consectetur.
            </p>
            <div class="blockquote offset">
                <p>Some have called Cornell the “first American university.”</p>
            </div>
            <ul class="custom recursive">
                <li>List item ipsum dolor sit amet, consectetur adipiscing elit. Morbi aliquam fermentum lacus, ut sagittis dui porttitor vitae.</li>
                <li>List Item</li>
                <li>Nested Ordered: 
								<ol>
                                    <li>Nested List Item
										<ul>
                                            <li>Nested Unordered List Item</li>
                                            <li>Nested Unordered List Item</li>
                                        </ul>
                                    </li>
                                    <li>Nested List Item</li>
                                </ol>
                </li>
                <li>List Item</li>
            </ul>-->
            <div class="two-col margined">
            </div>
            <div class="footer"></div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" runat="server">
</asp:Content>
