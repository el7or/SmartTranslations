<%@ Page Title="Reports" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" 
    CodeBehind="Reports.aspx.cs" Inherits="TranSmart.Reports" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <link href="Styles/notes.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
        <style>
            @import url(https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css);
            @import url(https://fonts.googleapis.com/css?family=Lato:300,400,700);

            body {
                font-family: 'Lato', sans-serif;
                background: #353535;
                color: black;
            }

            .jumbotron h1 {
                color: #353535;
            }

            footer {
                margin-bottom: 0 !important;
                margin-top: 80px;
            }

                footer p {
                    margin: 0;
                    padding: 0;
                }

            span.icon {
                margin: 0 5px;
                color: #D64541;
            }

            h2 {
                color: #BDC3C7;
                text-transform: uppercase;
                letter-spacing: 1px;
            }

            .mrng-60-top {
                margin-top: 60px;
            }
            /* Global Button Styles */
            a.animated-button:link, a.animated-button:visited {
                position: relative;
                display: block;
                margin: 30px auto 0;
                padding: 14px 15px;
                color: black;
                font-size: 18px;
                font-weight: bolder;
                text-align: center;
                text-decoration: none;
                overflow: hidden;
                letter-spacing: .08em;
                border-radius: 0;
                text-shadow: 0 0 1px rgba(0, 0, 0, 0.2), 0 1px 0 rgba(0, 0, 0, 0.2);
                -webkit-transition: all 1s ease;
                -moz-transition: all 1s ease;
                -o-transition: all 1s ease;
                transition: all 1s ease;
            }

                a.animated-button:link:after, a.animated-button:visited:after {
                    content: "";
                    position: absolute;
                    height: 0%;
                    left: 50%;
                    top: 50%;
                    width: 150%;
                    z-index: -1;
                    -webkit-transition: all 0.75s ease 0s;
                    -moz-transition: all 0.75s ease 0s;
                    -o-transition: all 0.75s ease 0s;
                    transition: all 0.75s ease 0s;
                }

                a.animated-button:link:hover, a.animated-button:visited:hover {
                    color: black;
                    text-shadow: none;
                }

                    a.animated-button:link:hover:after, a.animated-button:visited:hover:after {
                        height: 450%;
                    }

            a.animated-button:link, a.animated-button:visited {
                position: relative;
                display: block;
                margin: 30px auto 0;
                padding: 14px 15px;
                color: black;
                font-size: 18px;
                border-radius: 0;
                font-weight: bolder;
                text-align: center;
                text-decoration: none;
                overflow: hidden;
                letter-spacing: .08em;
                text-shadow: 0 0 1px rgba(0, 0, 0, 0.2), 0 1px 0 rgba(0, 0, 0, 0.2);
                -webkit-transition: all 1s ease;
                -moz-transition: all 1s ease;
                -o-transition: all 1s ease;
                transition: all 1s ease;
            }

            /* redHover Buttons */

            h2.redHover {
                color: #D24D57;
                text-shadow: -1px 0 black, 0 1px black, 1px 0 black, 0 -1px black;
            }

            a.animated-button.redHover-one {
                border: 2px solid #D24D57;
            }

                a.animated-button.redHover-one:after {
                    background: #D24D57;
                    -moz-transform: translateX(-50%) translateY(-50%) rotate(-25deg);
                    -ms-transform: translateX(-50%) translateY(-50%) rotate(-25deg);
                    -webkit-transform: translateX(-50%) translateY(-50%) rotate(-25deg);
                    transform: translateX(-50%) translateY(-50%) rotate(-25deg);
                }

            a.animated-button.redHover-two {
                border: 2px solid #D24D57;
            }

                a.animated-button.redHover-two:after {
                    background: #D24D57;
                    -moz-transform: translateX(-50%) translateY(-50%) rotate(25deg);
                    -ms-transform: translateX(-50%) translateY(-50%) rotate(25deg);
                    -webkit-transform: translateX(-50%) translateY(-50%) rotate(25deg);
                    transform: translateX(-50%) translateY(-50%) rotate(25deg);
                }

            /* greenHover Buttons */

            h2.greenHover {
                color: #65b37a;
                text-shadow: -1px 0 black, 0 1px black, 1px 0 black, 0 -1px black;
            }

            a.animated-button.greenHover-one {
                border: 2px solid #65b37a;
            }

                a.animated-button.greenHover-one:after {
                    background: #65b37a;
                    -moz-transform: translateX(-50%) translateY(-50%) rotate(-25deg);
                    -ms-transform: translateX(-50%) translateY(-50%) rotate(-25deg);
                    -webkit-transform: translateX(-50%) translateY(-50%) rotate(-25deg);
                    transform: translateX(-50%) translateY(-50%) rotate(-25deg);
                }

            a.animated-button.greenHover-two {
                border: 2px solid #65b37a;
            }

                a.animated-button.greenHover-two:after {
                    background: #65b37a;
                    -moz-transform: translateX(-50%) translateY(-50%) rotate(25deg);
                    -ms-transform: translateX(-50%) translateY(-50%) rotate(25deg);
                    -webkit-transform: translateX(-50%) translateY(-50%) rotate(25deg);
                    transform: translateX(-50%) translateY(-50%) rotate(25deg);
                }
                

            /* purpleHover Buttons */

            h2.purpleHover{
                color:#AEA8D3;
                text-shadow: -1px 0 black, 0 1px black, 1px 0 black, 0 -1px black;
            }

            a.animated-button.purpleHover-one {
                border: 2px solid #AEA8D3;
            }

                a.animated-button.purpleHover-one:after {
                    background: #AEA8D3;
                    -moz-transform: translateX(-50%) translateY(-50%) rotate(-25deg);
                    -ms-transform: translateX(-50%) translateY(-50%) rotate(-25deg);
                    -webkit-transform: translateX(-50%) translateY(-50%) rotate(-25deg);
                    transform: translateX(-50%) translateY(-50%) rotate(-25deg);
                }

            a.animated-button.purpleHover-two {
                border: 2px solid #AEA8D3;
            }

                a.animated-button.purpleHover-two:after {
                    background: #AEA8D3;
                    -moz-transform: translateX(-50%) translateY(-50%) rotate(25deg);
                    -ms-transform: translateX(-50%) translateY(-50%) rotate(25deg);
                    -webkit-transform: translateX(-50%) translateY(-50%) rotate(25deg);
                    transform: translateX(-50%) translateY(-50%) rotate(25deg);
                }

            /* blueHover Buttons */

            h2.blueHover {
                color: #00a1ff;
                text-shadow: -1px 0 black, 0 1px black, 1px 0 black, 0 -1px black;
            }

            a.animated-button.blueHover-one {
                border: 2px solid #00a1ff;
            }

                a.animated-button.blueHover-one:after {
                    background: #00a1ff;
                    -moz-transform: translateX(-50%) translateY(-50%) rotate(-25deg);
                    -ms-transform: translateX(-50%) translateY(-50%) rotate(-25deg);
                    -webkit-transform: translateX(-50%) translateY(-50%) rotate(-25deg);
                    transform: translateX(-50%) translateY(-50%) rotate(-25deg);
                }

            a.animated-button.blueHover-two {
                border: 2px solid #00a1ff;
            }

                a.animated-button.blueHover-two:after {
                    background: #00a1ff;
                    -moz-transform: translateX(-50%) translateY(-50%) rotate(25deg);
                    -ms-transform: translateX(-50%) translateY(-50%) rotate(25deg);
                    -webkit-transform: translateX(-50%) translateY(-50%) rotate(25deg);
                    transform: translateX(-50%) translateY(-50%) rotate(25deg);
                }

            /* pinkHover Buttons */

            h2.pinkHover {
                color: #fd52ff;
                text-shadow: -1px 0 black, 0 1px black, 1px 0 black, 0 -1px black;
            }

            a.animated-button.pinkHover-one {
                border: 2px solid #fd52ff;
            }

                a.animated-button.pinkHover-one:after {
                    background: #fd52ff;
                    -moz-transform: translateX(-50%) translateY(-50%) rotate(-25deg);
                    -ms-transform: translateX(-50%) translateY(-50%) rotate(-25deg);
                    -webkit-transform: translateX(-50%) translateY(-50%) rotate(-25deg);
                    transform: translateX(-50%) translateY(-50%) rotate(-25deg);
                }

            a.animated-button.pinkHover-two {
                border: 2px solid #fd52ff;
            }

                a.animated-button.pinkHover-two:after {
                    background: #fd52ff;
                    -moz-transform: translateX(-50%) translateY(-50%) rotate(25deg);
                    -ms-transform: translateX(-50%) translateY(-50%) rotate(25deg);
                    -webkit-transform: translateX(-50%) translateY(-50%) rotate(25deg);
                    transform: translateX(-50%) translateY(-50%) rotate(25deg);
                }

            /* orangeHover Buttons */

            h2.orangeHover {
                color: #fb7c03;
                text-shadow: -1px 0 black, 0 1px black, 1px 0 black, 0 -1px black;
            }

            a.animated-button.orangeHover-one {
                border: 2px solid #fb7c03;
            }

                a.animated-button.orangeHover-one:after {
                    background: #fb7c03;
                    -moz-transform: translateX(-50%) translateY(-50%) rotate(-25deg);
                    -ms-transform: translateX(-50%) translateY(-50%) rotate(-25deg);
                    -webkit-transform: translateX(-50%) translateY(-50%) rotate(-25deg);
                    transform: translateX(-50%) translateY(-50%) rotate(-25deg);
                }

            a.animated-button.orangeHover-two {
                border: 2px solid #fb7c03;
            }

                a.animated-button.orangeHover-two:after {
                    background: #fb7c03;
                    -moz-transform: translateX(-50%) translateY(-50%) rotate(25deg);
                    -ms-transform: translateX(-50%) translateY(-50%) rotate(25deg);
                    -webkit-transform: translateX(-50%) translateY(-50%) rotate(25deg);
                    transform: translateX(-50%) translateY(-50%) rotate(25deg);
                }

            /* yellowHover Buttons */

            h2.yellowHover{
                color:#F7CA18;
                text-shadow: -1px 0 black, 0 1px black, 1px 0 black, 0 -1px black;
            }

            a.animated-button.yellowHover-one {
                border: 2px solid #F7CA18;
            }

                a.animated-button.yellowHover-one:after {
                    background: #F7CA18;
                    -moz-transform: translateX(-50%) translateY(-50%) rotate(-25deg);
                    -ms-transform: translateX(-50%) translateY(-50%) rotate(-25deg);
                    -webkit-transform: translateX(-50%) translateY(-50%) rotate(-25deg);
                    transform: translateX(-50%) translateY(-50%) rotate(-25deg);
                }

            a.animated-button.yellowHover-two {
                border: 2px solid #F7CA18;
            }

                a.animated-button.yellowHover-two:after {
                    background: #F7CA18;
                    -moz-transform: translateX(-50%) translateY(-50%) rotate(25deg);
                    -ms-transform: translateX(-50%) translateY(-50%) rotate(25deg);
                    -webkit-transform: translateX(-50%) translateY(-50%) rotate(25deg);
                    transform: translateX(-50%) translateY(-50%) rotate(25deg);
                }

            a.animated-button.yellowHover-three {
                cursor: pointer;
                display: block;
                position: relative;
                border: 2px solid #F7CA18;
                transition: all 0.4s cubic-bezier(0.42, 0, 0.58, 1);
            }

                a.animated-button.yellowHover-three:hover {
                    color: #000 !important;
                    background-color: transparent;
                    text-shadow: nthree;
                }

                    a.animated-button.yellowHover-three:hover:before {
                        left: 0%;
                        right: auto;
                        width: 100%;
                    }

                a.animated-button.yellowHover-three:before {
                    display: block;
                    position: absolute;
                    top: 0px;
                    right: 0px;
                    height: 100%;
                    width: 0px;
                    z-index: -1;
                    content: '';
                    color: #000 !important;
                    background: #F7CA18;
                    transition: all 0.4s cubic-bezier(0.42, 0, 0.58, 1);
                }

            a.animated-button.yellowHover-four {
                cursor: pointer;
                display: block;
                position: relative;
                border: 2px solid #F7CA18;
                transition: all 0.4s cubic-bezier(0.42, 0, 0.58, 1);
            }

                a.animated-button.yellowHover-four:hover {
                    color: #000 !important;
                    background-color: transparent;
                    text-shadow: nfour;
                }

                    a.animated-button.yellowHover-four:hover:before {
                        right: 0%;
                        left: auto;
                        width: 100%;
                    }

                a.animated-button.yellowHover-four:before {
                    display: block;
                    position: absolute;
                    top: 0px;
                    left: 0px;
                    height: 100%;
                    width: 0px;
                    z-index: -1;
                    content: '';
                    color: #000 !important;
                    background: #F7CA18;
                    transition: all 0.4s cubic-bezier(0.42, 0, 0.58, 1);
                }
                .navbar-brand-centered {
                position: absolute;
                left: 50%;
                display: block;
                text-align: center;
                background-color: transparent;
            }

                .navbar-brand-centered a {
                    font-weight: bold;
                    font-size:large;
                }

            .navbar > .container .navbar-brand-centered,
            .navbar > .container-fluid .navbar-brand-centered {
                margin-left: -80px;
            }
        </style>
        <script type="text/javascript" lang="javascript">
            //function RowClick(sender, eventArgs) {
            //    var grid = sender;
            //    var MasterTable = grid.get_masterTableView(); var row = MasterTable.get_dataItems()[eventArgs.get_itemIndexHierarchical()];
            //    var cell = MasterTable.getCellByColumnUniqueName(row, "ProjectID");
            //    window.location = '/ProjectDetails.aspx?projid=' + cell.innerHTML;
            //}
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadFormDecorator ID="RadFormDecorator3" runat="server"
        DecorationZoneID="zonePayments" DecoratedControls="All" />
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" UpdateInitiatorPanelsOnly="true">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="grdPayList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdPayList" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="ConfiguratorPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ConfiguratorPanel">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdPayList" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <div id="zonePayments" class="zoneEntity" style="margin: 30px;">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <fieldset class="fsRow" style="width: 100% !important; background-image: linear-gradient(#ebebeb,#fff);">
                <legend class="rdfLegend rfdRoundedCorners ">
                    <fieldset style="padding: 8px; font-size: 16px; font-weight: 500;">Reports</fieldset>
                </legend>
                <div class="demo-container">

                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12 text-center">
                            <h2 class="redHover">Projects</h2>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><a href="ReportProjects.aspx?type=now" class="btn btn-sm animated-button redHover-one">Current Projects</a> </div>
                                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><a href="ReportProjects.aspx?type=done" class="btn btn-sm animated-button redHover-two">Finished Projects</a> </div>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12 text-center">
                            <h2 class="greenHover">Tasks</h2>
                            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><a href="ReportTasks.aspx?type=now" class="btn btn-sm animated-button greenHover-one">Current Tasks</a> </div>
                            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><a href="ReportTasks.aspx?type=done" class="btn btn-sm animated-button greenHover-two">Finished Tasks</a> </div>
                        </div>
                    </div>
                                        
                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12 text-center">
                            <h2 class="purpleHover">Clients</h2>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><a href="ReportCustomersProjects.aspx" class="btn btn-sm animated-button purpleHover-one">Projects Count</a> </div>
                                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><a href="ReportCustomersRequests.aspx" class="btn btn-sm animated-button purpleHover-two">Pending Requests</a> </div>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12 text-center">
                            <h2 class="orangeHover">Projects Managers</h2>
                            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><a href="ReportManagersProjects.aspx?type=pm" class="btn btn-sm animated-button orangeHover-one">Projects Count</a> </div>
                            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><a href="ReportManagersDelays.aspx?type=pm" class="btn btn-sm animated-button orangeHover-two">Projects Delays</a> </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12 text-center">
                            <h2 class="blueHover">Translators</h2>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><a href="ReportManagersProjects.aspx?type=tr" class="btn btn-sm animated-button blueHover-one">Tasks Count</a> </div>
                                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><a href="ReportManagersDelays.aspx?type=tr" class="btn btn-sm animated-button blueHover-two">Tasks Delays</a> </div>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12 text-center">
                            <h2 class="pinkHover">Revisors</h2>
                            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><a href="ReportManagersProjects.aspx?type=rev" class="btn btn-sm animated-button pinkHover-one">Tasks Count</a> </div>
                            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><a href="ReportManagersDelays.aspx?type=rev" class="btn btn-sm animated-button pinkHover-two">Tasks Delays</a> </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center">
                            <h2 class="yellowHover">Financial</h2>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12 text-center"><a href="ReportPaymentsPeriod.aspx?type=d" class="btn btn-sm animated-button yellowHover-one">Daily Financial</a> </div>
                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12 text-center"><a href="ReportPaymentsPeriod.aspx?type=m" class="btn btn-sm animated-button yellowHover-one">Monthly Financial</a> </div>
                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12 text-center"><a href="ReportCustomersInvoices.aspx" class="btn btn-sm animated-button yellowHover-two">Clients Invoices</a> </div>
                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12 text-center"><a href="ReportTranslatorInvoices.aspx" class="btn btn-sm animated-button yellowHover-two">Staff Invoices</a> </div>
                    </div>
                </div>
                <nav class="navbar navbar-default">
                    <div class="container-fluid">
                        <div class="navbar-header" style="padding-left: 10px">
                            <div class="navbar-text navbar-brand-centered">
                                <a href="default.aspx" class="btn btn-default navbar-btn pull-left">
                                    <span class="glyphicon glyphicon-chevron-left"></span>Home
                                </a>
                            </div>
                        </div>
                    </div>
                </nav>
            </fieldset>
        </div>
    </div>
</asp:Content>
