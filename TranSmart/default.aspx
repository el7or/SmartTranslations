<%@ Page Title=" Home" MetaDescription="Telerik WebMail" MetaKeywords="TranSmart Home,TransTec,Translation inspired app"
    Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TranSmart.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Styles/calendar.css" rel="stylesheet" />
    <style type="text/css">
        html .RadGrid .rgMasterTable {
            height: auto;
        }

        .RadGrid {
            border-radius: 10px;
            overflow: hidden;
        }

        .div33 {
            width: 32% !important;
            padding: 0px;
            margin: 5px;
            margin-top: 10px;
            border-radius: 10px;
        }

        svg, g, .cg {
            background-color: transparent !important;
        }

        .subject {
            position: relative;
        }

        .well-sm {
            border-radius: 9px;
        }

        .hero-widget {
            text-align: center;
            padding-top: 10px;
            padding-bottom: 10px;
            margin: 10px;
        }

            .hero-widget .icon {
                display: block;
                font-size: 76px;
                line-height: 76px;
                margin-bottom: 10px;
                text-align: center;
            }

            .hero-widget var {
                display: block;
                height: 54px;
                font-size: 54px;
                line-height: 54px;
                font-style: normal;
            }

            .hero-widget label {
                font-size: 15px;
            }

            .hero-widget .options {
                margin-top: 10px;
            }

        .wrapper h2 {
            margin: 0px !important;
            padding: 0px !important;
            font: normal 40px Arial;
            text-shadow: 0 1px 0 #ccc, 0 2px 0 #c9c9c9, 0 3px 0 #bbb, 0 4px 0 #b9b9b9, 0 5px 0 #aaa, 0 6px 1px rgba(0,0,0,.1), 0 0 5px rgba(0,0,0,.1), 0 1px 3px rgba(0,0,0,.3), 0 3px 5px rgba(0,0,0,.2), 0 5px 10px rgba(0,0,0,.25), 0 10px 10px rgba(0,0,0,.2), 0 20px 20px rgba(0,0,0,.15);
        }
        /*--color: #FFFFFF;*/
        /*#wrapper p {
            margin:0px !important;
            padding:0px !important;
            font: normal 70px Arial;
            --color: #FFFFFF;
            text-shadow: 0 1px 0 #ccc, 0 2px 0 #c9c9c9, 0 3px 0 #bbb, 0 4px 0 #b9b9b9, 0 5px 0 #aaa, 0 6px 1px rgba(0,0,0,.1), 0 0 5px rgba(0,0,0,.1), 0 1px 3px rgba(0,0,0,.3), 0 3px 5px rgba(0,0,0,.2), 0 5px 10px rgba(0,0,0,.25), 0 10px 10px rgba(0,0,0,.2), 0 20px 20px rgba(0,0,0,.15);
        }*/
        .wrapper p, .wrapper label {
            margin: 0px !important;
            padding: 0px !important;
            font: normal 30px Arial;
            font-weight: bold;
            text-shadow: 0px 1px 0 #ccc, 1px 2px 0 #b9b9b9, 2px 3px 1px rgba(0,0,0,.1), 2px 0 3px rgba(0,0,0,.1), 2px 2px 4px rgba(0,0,0,.2), 2px 4px 8px rgba(0,0,0,.25), 2px 8px 8px rgba(0,0,0,.2);
        }

        .icon, .text, .col-sm-4, .row {
            padding: 0px !important;
            margin: 0px !important;
        }

        .hero-widget {
            height: 410px;
        }

        .glyphicon a {
            /*margin:5px !important;*/
        }

        /*.glyphicon {
            font-size:40px;
        }*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FolderContent" runat="Server">
    <%--  <nav:FolderNavigationControl runat="server" ID="FolderNavigationControl" />
    <nav:MobileNavigation runat="server" ID="MobileNavigation"></nav:MobileNavigation>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="width: 100%; height: 5px; background-color: white;   ">
        <div id="divReload" style="width: 0%; height: 5px; background-color: red; transition: all 1s linear;"></div>
    </div>
    <script type="text/javascript">
        var i = 0;
        pageLoad();
        function pageLoad()
        {
            console.log(i);
          var intrvl= setInterval(function () {
                i = i + 1; //console.log(i);
                if (i > 99) {
                    window.location.href = window.location.href;
                    //i = i - 1; 
                    clearInterval(intrvl);
                }
                divReload.style.width = i + '%';
            }, 1000);
            
        }
    </script>
    <telerik:RadFormDecorator ID="RadFormDecorator2" RenderMode="Lightweight" runat="server"
        DecorationZoneID="zoneEmployee" DecoratedControls="All" />
    <div id="zoneEmployee" class="zoneEntity" style="width: 100% !important; padding: 0px; margin: 0px;">

        <%--<div class="col-lg-1 col-md-1 col-sm-4 col-xs-4 div33">
            <fieldset class="fsRow" style="width: 100% !important;">
                <legend class="rdfLegend rfdRoundedCorners ">
                    <fieldset style="padding: 8px; font-size: 16px; font-weight: 500;">Employees</fieldset>
                </legend>
            </fieldset>
        </div>--%>
        <%--<div class="icon" style="font-size:20px;">
            <i class="glyphicon glyphicon-adjust"></i>
            <i class="glyphicon glyphicon-arrow-down"></i>
            <i class="glyphicon glyphicon-arrow-up"></i>
            <i class="glyphicon glyphicon-backward"></i>
            <i class="glyphicon glyphicon-bell"></i>
            <i class="glyphicon glyphicon-ban-circle"></i>
            <i class="glyphicon glyphicon-bold"></i>
            <i class="glyphicon glyphicon-bullhorn"></i>
            <i class="glyphicon glyphicon-briefcase"></i>
            <i class="glyphicon glyphicon-calendar"></i>
            <i class="glyphicon glyphicon-camera"></i>
            <i class="glyphicon glyphicon-certificate"></i>
            <i class="glyphicon glyphicon-check"></i>
            <i class="glyphicon glyphicon-chevron-down"></i>
            <i class="glyphicon glyphicon-circle-arrow-down"></i>
            <i class="glyphicon glyphicon-cloud"></i>
            <i class="glyphicon glyphicon-cloud-download"></i>
            <i class="glyphicon glyphicon-cog"></i>
            <i class="glyphicon glyphicon-collapse-down"></i>
            <i class="glyphicon glyphicon-comment"></i>
            <i class="glyphicon glyphicon-compressed"></i>
            <i class="glyphicon glyphicon-copyright-mark"></i>
            <i class="glyphicon glyphicon-credit-card"></i>
            <i class="glyphicon glyphicon-cutlery"></i>
            <i class="glyphicon glyphicon-dashboard"></i>
            <i class="glyphicon glyphicon-download"></i>
            <i class="glyphicon glyphicon-download-alt"></i>
            <i class="glyphicon glyphicon-earphone"></i>
            <i class="glyphicon glyphicon-edit"></i>
            <i class="glyphicon glyphicon-eject"></i>
            <i class="glyphicon glyphicon-envelope"></i>
            <i class="glyphicon glyphicon-euro"></i>
            <i class="glyphicon glyphicon-expand"></i>
            <i class="glyphicon glyphicon-export"></i>
            <i class="glyphicon glyphicon-eye-close"></i>
            <i class="glyphicon glyphicon-eye-open"></i>
            <i class="glyphicon glyphicon-facetime-video"></i>
            <i class="glyphicon glyphicon-fast-backward"></i>
            <i class="glyphicon glyphicon-fast-forward"></i>
            <i class="glyphicon glyphicon-file"></i>
            <i class="glyphicon glyphicon-film"></i>
            <i class="glyphicon glyphicon-filter"></i>
            <i class="glyphicon glyphicon-fire"></i>
            <i class="glyphicon glyphicon-flag"></i>
            <i class="glyphicon glyphicon-flash"></i>
            <i class="glyphicon glyphicon-floppy-disk"></i>
            <i class="glyphicon glyphicon-folder-close"></i>
            <i class="glyphicon glyphicon-font"></i>
            <i class="glyphicon glyphicon-forward"></i>
            <i class="glyphicon glyphicon-fullscreen"></i>
            <i class="glyphicon glyphicon-gbp"></i>
            <i class="glyphicon glyphicon-gift"></i>
            <i class="glyphicon glyphicon-glass"></i>
            <i class="glyphicon glyphicon-globe"></i>
            <i class="glyphicon glyphicon-hand-down"></i>
            <i class="glyphicon glyphicon-hd-video"></i>
            <i class="glyphicon glyphicon-hdd"></i>
            <i class="glyphicon glyphicon-header"></i>
            <i class="glyphicon glyphicon-heart"></i>
            <i class="glyphicon glyphicon-home"></i>
            <i class="glyphicon glyphicon-import"></i>
            <i class="glyphicon glyphicon-inbox"></i>
            <i class="glyphicon glyphicon-info-sign"></i>
            <i class="glyphicon glyphicon-leaf"></i>
            <i class="glyphicon glyphicon-link"></i>
            <i class="glyphicon glyphicon-list"></i>
            <i class="glyphicon glyphicon-lock"></i>
            <i class="glyphicon glyphicon-log-in"></i>
            <i class="glyphicon glyphicon-log-out"></i>
            <i class="glyphicon glyphicon-ok"></i>
            <i class="glyphicon glyphicon-ok-circle"></i>
            <i class="glyphicon glyphicon-ok-sign"></i>
            <i class="glyphicon glyphicon-open"></i>
            <i class="glyphicon glyphicon-paperclip"></i>
            <i class="glyphicon glyphicon-phone"></i>
            <i class="glyphicon glyphicon-plus"></i>
            <i class="glyphicon glyphicon-random"></i>
            <i class="glyphicon glyphicon-refresh"></i>
            <i class="glyphicon glyphicon-record"></i>
            <i class="glyphicon glyphicon-registration-mark"></i>
            <i class="glyphicon glyphicon-remove"></i>
            <i class="glyphicon glyphicon-remove-circle"></i>
            <i class="glyphicon glyphicon-remove-sign"></i>
            <i class="glyphicon glyphicon-repeat"></i>
            <i class="glyphicon glyphicon-resize-full"></i>
            <i class="glyphicon glyphicon-road"></i>
            <i class="glyphicon glyphicon-save"></i>
            <i class="glyphicon glyphicon-saved"></i>
            <i class="glyphicon glyphicon-screenshot"></i>
            <i class="glyphicon glyphicon-search"></i>
            <i class="glyphicon glyphicon-send"></i>
            <i class="glyphicon glyphicon-share"></i>
            <i class="glyphicon glyphicon-share-alt"></i>
            <i class="glyphicon glyphicon-shopping-cart"></i>
            <i class="glyphicon glyphicon-signal"></i>
            <i class="glyphicon glyphicon-sort"></i>
            <i class="glyphicon glyphicon-sort-by-alphabet"></i>
            <i class="glyphicon glyphicon-sort-by-attributes"></i>
            <i class="glyphicon glyphicon-sort-by-order"></i>
            <i class="glyphicon glyphicon-sound-5-1"></i>
            <i class="glyphicon glyphicon-sound-stereo"></i>
            <i class="glyphicon glyphicon-star"></i>
            <i class="glyphicon glyphicon-star-empty"></i>
            <i class="glyphicon glyphicon-stats"></i>
            <i class="glyphicon glyphicon-step-forward"></i>
            <i class="glyphicon glyphicon-stop"></i>
            <i class="glyphicon glyphicon-subtitles"></i>
            <i class="glyphicon glyphicon-tag"></i>
            <i class="glyphicon glyphicon-tags"></i>
            <i class="glyphicon glyphicon-tasks"></i>
            <i class="glyphicon glyphicon-text-height"></i>
            <i class="glyphicon glyphicon-th"></i>
            <i class="glyphicon glyphicon-th-large"></i>
            <i class="glyphicon glyphicon-time"></i>
            <i class="glyphicon glyphicon-tower"></i>
            <i class="glyphicon glyphicon-transfer"></i>
            <i class="glyphicon glyphicon-trash"></i>
            <i class="glyphicon glyphicon-tree-conifer"></i>
            <i class="glyphicon glyphicon-tree-deciduous"></i>
            <i class="glyphicon glyphicon-unchecked"></i>
            <i class="glyphicon glyphicon-upload"></i>
            <i class="glyphicon glyphicon-user"></i>
            <i class="glyphicon glyphicon-volume-up"></i>
            <i class="glyphicon glyphicon-warning-sign"></i>
            <i class="glyphicon glyphicon-wrench"></i>
            <i class="glyphicon glyphicon-zoom-in"></i>
            <i class="glyphicon glyphicon-zoom-out"></i>
        </div>--%>

        <div class="container" align="center">
            <div class="row" align="center">
                <div class="col-sm-4" style="color: #d70e0e;">
                    <div class="hero-widget well well-sm wrapper">
                        <div class="icon">
                            <h2><i class="glyphicon glyphicon-bell "></i></h2>
                        </div>
                        <div class="text">
                            <p>
                                <var>
                                    <asp:Label ID="lblSoonProjectsCount" runat="server" Text="3"></asp:Label>
                                    <label style="color: #d70e0e;">Pending</label>

                                </var>
                            </p>
                        </div>
                        <div>
                            <telerik:RadGrid ID="grdSoonProjects" runat="server" AutoGenerateColumns="False" PageSize="4" AllowPaging="True"
                                Width="100%" Visible="false">
                                <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
                                <ClientSettings AllowKeyboardNavigation="false" EnableRowHoverStyle="True" EnableClientPrint="True">
                                    <Selecting AllowRowSelect="false"></Selecting>
                                </ClientSettings>
                                <MasterTableView DataKeyNames="ProjectID" PagerStyle-Mode="NumericPages">
                                    <RowIndicatorColumn Visible="False">
                                    </RowIndicatorColumn>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="ProjectID" FilterControlAltText="Filter ProjectID column"
                                            HeaderText="ProjectID" UniqueName="ProjectID" Visible="False">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="ProjectSerial" FilterControlAltText="Filter ProjectSerial column"
                                            HeaderText="Serial" UniqueName="ProjectSerial" Visible="False">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="CustomerName" FilterControlAltText="Filter CustomerName column"
                                            HeaderText="Client" UniqueName="CustomerName">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="ProjectTitle" FilterControlAltText="Filter ProjectTitle column"
                                            HeaderText="Project" UniqueName="ProjectTitle">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="PromiseDeliveryDate" FilterControlAltText="Filter PromiseDeliveryDate column"
                                            HeaderText="Deadline" UniqueName="PromiseDeliveryDate" DataFormatString="{0:dd/MM/yyyy}">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridHyperLinkColumn AllowSorting="False" FilterControlAltText="Filter Details column"
                                            DataTextFormatString="<img src='Content/Images/app.png' width='20' height='20' border='0' alt='Details' title='Details' />" DataNavigateUrlFields="ProjectID"
                                            DataNavigateUrlFormatString="ProjectDetails.aspx?projid={0}"
                                            DataTextField="ProjectID" UniqueName="Details" HeaderStyle-Width="48px">
                                        </telerik:GridHyperLinkColumn>
                                    </Columns>

                                </MasterTableView>
                            </telerik:RadGrid>
                        </div>
                        <div class="options">
                            <a href="Projects.aspx" class="btn btn-default btn-lg"><i class="glyphicon glyphicon-search"></i>View More</a>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="hero-widget well well-sm wrapper" style="color: #f49c4f">
                        <%--EC6807--%>
                        <div class="icon">
                            <h2><i class="glyphicon glyphicon-cog"></i></h2>
                            <%--fire--%>
                        </div>
                        <div class="text">
                            <p>
                                <var>
                                    <asp:Label ID="lblProgressProjectsCount" runat="server" Text="9"></asp:Label>
                                    <label class="text-muted" style="color: #f49c4f;">Under Progress</label></var>
                            </p>
                        </div>
                        <telerik:RadGrid ID="grdProgressProjects" runat="server" AutoGenerateColumns="False" PageSize="4" AllowPaging="True"
                            Width="100%" Visible="false">
                            <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
                            <ClientSettings AllowKeyboardNavigation="false" EnableRowHoverStyle="True" EnableClientPrint="True">
                                <Selecting AllowRowSelect="false"></Selecting>
                            </ClientSettings>
                            <MasterTableView DataKeyNames="ProjectID" PagerStyle-Mode="NumericPages">
                                <RowIndicatorColumn Visible="False">
                                </RowIndicatorColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="ProjectID" FilterControlAltText="Filter ProjectID column"
                                        HeaderText="ProjectID" UniqueName="ProjectID" Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ProjectSerial" FilterControlAltText="Filter ProjectSerial column"
                                        HeaderText="Serial" UniqueName="ProjectSerial" Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CustomerName" FilterControlAltText="Filter CustomerName column"
                                        HeaderText="Client" UniqueName="CustomerName">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ProjectTitle" FilterControlAltText="Filter ProjectTitle column"
                                        HeaderText="Project" UniqueName="ProjectTitle">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PromiseDeliveryDate" FilterControlAltText="Filter PromiseDeliveryDate column"
                                        HeaderText="Deadline" UniqueName="PromiseDeliveryDate" DataFormatString="{0:dd/MM/yyyy}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridHyperLinkColumn AllowSorting="False" FilterControlAltText="Filter Details column"
                                        DataTextFormatString="<img src='Content/Images/app.png' width='20' height='20' border='0' alt='Details' title='Details' />" DataNavigateUrlFields="ProjectID"
                                        DataNavigateUrlFormatString="ProjectDetails.aspx?projid={0}"
                                        DataTextField="ProjectID" UniqueName="Details" HeaderStyle-Width="48px">
                                    </telerik:GridHyperLinkColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>

                        <div class="options">
                            <a href="Projects.aspx" class="btn btn-default btn-lg"><i class="glyphicon glyphicon-search"></i>View More</a>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="hero-widget well well-sm wrapper" style="color: #34AFE9;">
                        <div class="icon">
                            <h2><i class="glyphicon glyphicon-time"></i></h2>
                            <%--book--%>
                        </div>
                        <div class="text">
                            <p>
                                <var>
                                    <asp:Label ID="lblSoonTranslationsCount" runat="server" Text="15"></asp:Label>
                                    <label class="text-muted" style="color: #34AFE9;">Tasks</label></var>
                            </p>
                        </div>
                        <telerik:RadGrid ID="grdSoonTasks" runat="server" AutoGenerateColumns="False" PageSize="4" AllowPaging="True"
                            Width="100%" Visible="false">
                            <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
                            <ClientSettings AllowKeyboardNavigation="false" EnableRowHoverStyle="True" EnableClientPrint="True">
                                <Selecting AllowRowSelect="false"></Selecting>
                            </ClientSettings>
                            <MasterTableView DataKeyNames="TaskID" PagerStyle-Mode="NumericPages">
                                <RowIndicatorColumn Visible="False">
                                </RowIndicatorColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="TaskID" FilterControlAltText="Filter TaskID column"
                                        HeaderText="TaskID" UniqueName="TaskID" Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TaskSerial" FilterControlAltText="Filter TaskSerial column"
                                        HeaderText="Serial" UniqueName="TaskSerial">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TranslatorName" FilterControlAltText="Filter TranslatorName column"
                                        HeaderText="Translator" UniqueName="TranslatorName">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TaskStatus" FilterControlAltText="Filter TaskStatus column"
                                        HeaderText="Status" UniqueName="TaskStatus">
                                    </telerik:GridBoundColumn>
                                    <%--<telerik:GridBoundColumn DataField="PromiseDeliveryDate" FilterControlAltText="Filter PromiseDeliveryDate column"
                                            HeaderText="Deadline" UniqueName="PromiseDeliveryDate" DataFormatString="{0:dd/MM/yyyy}">
                                        </telerik:GridBoundColumn>--%>
                                    <telerik:GridHyperLinkColumn AllowSorting="False" FilterControlAltText="Filter Details column"
                                        DataTextFormatString="<img src='Content/Images/app.png' width='20' height='20' border='0' alt='Details' title='Details' />"
                                        DataNavigateUrlFields="TaskID" DataNavigateUrlFormatString="ProjectTasksDetails.aspx?taskid={0}"
                                        DataTextField="TaskID" UniqueName="Details" HeaderStyle-Width="48px">
                                    </telerik:GridHyperLinkColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                        <div class="options">
                            <a href="ProjectTasks.aspx" class="btn btn-default btn-lg"><i class="glyphicon glyphicon-search"></i>View Details</a>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="hero-widget well well-sm wrapper " style="color: #f1f121">
                        <div class="icon">
                            <h2><i class="glyphicon glyphicon-star-empty"></i></h2>
                            <%--send--%>
                        </div>
                        <div class="text">
                            <p>
                                <var>
                                    <asp:Label ID="lblPendingProjectsCount" runat="server" Text="9"></asp:Label>
                                    <label class="text-muted" style="color: #f1f121;">New</label></var>
                            </p>
                        </div>
                        <telerik:RadGrid ID="grdPendingProjects" runat="server" AutoGenerateColumns="False" PageSize="4" AllowPaging="True"
                            Width="100%" Visible="false">
                            <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
                            <ClientSettings AllowKeyboardNavigation="false" EnableRowHoverStyle="True" EnableClientPrint="True">
                                <Selecting AllowRowSelect="false"></Selecting>
                            </ClientSettings>
                            <MasterTableView DataKeyNames="ProjectID" PagerStyle-Mode="NumericPages">
                                <RowIndicatorColumn Visible="False">
                                </RowIndicatorColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="ProjectID" FilterControlAltText="Filter ProjectID column"
                                        HeaderText="ProjectID" UniqueName="ProjectID" Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ProjectSerial" FilterControlAltText="Filter ProjectSerial column"
                                        HeaderText="Serial" UniqueName="ProjectSerial" Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CustomerName" FilterControlAltText="Filter CustomerName column"
                                        HeaderText="Client" UniqueName="CustomerName">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ProjectTitle" FilterControlAltText="Filter ProjectTitle column"
                                        HeaderText="Project" UniqueName="ProjectTitle">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PromiseDeliveryDate" FilterControlAltText="Filter PromiseDeliveryDate column"
                                        HeaderText="Deadline" UniqueName="PromiseDeliveryDate" DataFormatString="{0:dd/MM/yyyy}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridHyperLinkColumn AllowSorting="False" FilterControlAltText="Filter Details column"
                                        DataTextFormatString="<img src='Content/Images/app.png' width='20' height='20' border='0' alt='Details' title='Details' />" DataNavigateUrlFields="ProjectID"
                                        DataNavigateUrlFormatString="ProjectDetails.aspx?projid={0}"
                                        DataTextField="ProjectID" UniqueName="Details" HeaderStyle-Width="48px">
                                    </telerik:GridHyperLinkColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>

                        <div class="options">
                            <a href="ProjectDetails.aspx" class="btn btn-primary btn-lg"><i class="glyphicon glyphicon-plus"></i>New Project</a>
                            <a href="Projects.aspx" class="btn btn-default btn-lg"><i class="glyphicon glyphicon-search"></i>View More</a>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="hero-widget well well-sm wrapper" style="color: #79AC47">
                        <div class="icon">
                            <h2><i class="glyphicon glyphicon-ok"></i></h2>
                        </div>
                        <div class="text">
                            <p>
                                <var>
                                    <asp:Label ID="lblDoneProjectsCount" runat="server" Text="9"></asp:Label>
                                    <label class="text-muted" style="color: #79AC47;">Completed</label></var>
                            </p>
                        </div>
                        <telerik:RadGrid ID="grdDoneProjects" runat="server" AutoGenerateColumns="False" PageSize="4" AllowPaging="True"
                            Width="100%" Visible="false">
                            <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
                            <ClientSettings AllowKeyboardNavigation="false" EnableRowHoverStyle="True" EnableClientPrint="True">
                                <Selecting AllowRowSelect="false"></Selecting>
                            </ClientSettings>
                            <MasterTableView DataKeyNames="ProjectID" PagerStyle-Mode="NumericPages">
                                <RowIndicatorColumn Visible="False">
                                </RowIndicatorColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="ProjectID" FilterControlAltText="Filter ProjectID column"
                                        HeaderText="ProjectID" UniqueName="ProjectID" Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ProjectSerial" FilterControlAltText="Filter ProjectSerial column"
                                        HeaderText="Serial" UniqueName="ProjectSerial" Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CustomerName" FilterControlAltText="Filter CustomerName column"
                                        HeaderText="Client" UniqueName="CustomerName">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ProjectTitle" FilterControlAltText="Filter ProjectTitle column"
                                        HeaderText="Project" UniqueName="ProjectTitle">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PromiseDeliveryDate" FilterControlAltText="Filter PromiseDeliveryDate column"
                                        HeaderText="Deadline" UniqueName="PromiseDeliveryDate" DataFormatString="{0:dd/MM/yyyy}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridHyperLinkColumn AllowSorting="False" FilterControlAltText="Filter Details column"
                                        DataTextFormatString="<img src='Content/Images/app.png' width='20' height='20' border='0' alt='Details' title='Details' />" DataNavigateUrlFields="ProjectID"
                                        DataNavigateUrlFormatString="ProjectDetails.aspx?projid={0}"
                                        DataTextField="ProjectID" UniqueName="Details" HeaderStyle-Width="48px">
                                    </telerik:GridHyperLinkColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>

                        <div class="options">
                            <a href="Projects.aspx" class="btn btn-default btn-lg"><i class="glyphicon glyphicon-search"></i>View More</a>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="hero-widget well well-sm wrapper" style="color: #79AC47">
                        <div class="icon">
                            <h2><i class="glyphicon glyphicon-usd"></i></h2>
                        </div>
                        <div class="text">
                            <p>
                                <var>
                                    <asp:Label ID="lblSoonPaymentsCount" runat="server" Text="9"></asp:Label>
                                    <label class="text-muted" style="color: #79AC47;">Receivables</label></var>
                            </p>
                        </div>
                        <telerik:RadGrid ID="grdSoonPayments" runat="server" AutoGenerateColumns="False" PageSize="4" AllowPaging="True"
                            Width="100%" Visible="false">
                            <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
                            <ClientSettings AllowKeyboardNavigation="false" EnableRowHoverStyle="True" EnableClientPrint="True">
                                <Selecting AllowRowSelect="false"></Selecting>
                            </ClientSettings>
                            <MasterTableView DataKeyNames="ProjectID" PagerStyle-Mode="NumericPages">
                                <RowIndicatorColumn Visible="False">
                                </RowIndicatorColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="ProjectID" FilterControlAltText="Filter ProjectID column"
                                        HeaderText="ProjectID" UniqueName="ProjectID" Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ProjectSerial" FilterControlAltText="Filter ProjectSerial column"
                                        HeaderText="Serial" UniqueName="ProjectSerial" Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CustomerName" FilterControlAltText="Filter CustomerName column"
                                        HeaderText="Client" UniqueName="CustomerName">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ProjectTitle" FilterControlAltText="Filter ProjectTitle column"
                                        HeaderText="Project" UniqueName="ProjectTitle">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PromiseDeliveryDate" FilterControlAltText="Filter PromiseDeliveryDate column"
                                        HeaderText="Deadline" UniqueName="PromiseDeliveryDate" DataFormatString="{0:dd/MM/yyyy}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridHyperLinkColumn AllowSorting="False" FilterControlAltText="Filter Details column"
                                        DataTextFormatString="<img src='Content/Images/app.png' width='20' height='20' border='0' alt='Details' title='Details' />" DataNavigateUrlFields="ProjectID"
                                        DataNavigateUrlFormatString="ProjectDetails.aspx?projid={0}"
                                        DataTextField="ProjectID" UniqueName="Details" HeaderStyle-Width="48px">
                                    </telerik:GridHyperLinkColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                        <div class="options">
                            <a href="javascript:;" class="btn btn-default btn-lg"><i class="glyphicon glyphicon-search"></i>View More</a>
                        </div>
                    </div>
                </div>

                <%--                <div class="col-sm-6">
                    <div class="hero-widget well well-sm">
                        <telerik:RadGrid ID="grdEmpList" runat="server" AutoGenerateColumns="False"
                            Width="100%" Height="350">
                            <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
                            <ClientSettings AllowKeyboardNavigation="false" EnableRowHoverStyle="True" EnableClientPrint="True">
                                <Selecting AllowRowSelect="false"></Selecting>
                            </ClientSettings>
                            <MasterTableView DataKeyNames="EmployeeID">
                                <RowIndicatorColumn Visible="False">
                                </RowIndicatorColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="EmployeeID" FilterControlAltText="Filter EmployeeID column"
                                        HeaderText="EmployeeID" UniqueName="EmployeeID" Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FullName" FilterControlAltText="Filter FullName column"
                                        HeaderText="Employees" UniqueName="FullName">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridHyperLinkColumn AllowSorting="False" FilterControlAltText="Filter Details column"
                                        DataTextFormatString="<img src='Content/Images/app.png' width='20' height='20' border='0' alt='Details' title='Details' />" DataNavigateUrlFields="EmployeeID"
                                        DataNavigateUrlFormatString="Employees.aspx?id={0}"
                                        DataTextField="EmployeeID" UniqueName="Details" HeaderStyle-Width="48px">
                                    </telerik:GridHyperLinkColumn>
                                    <telerik:GridHyperLinkColumn AllowSorting="False" FilterControlAltText="Filter login column"
                                        DataTextFormatString="<img src='Content/Images/{0}.png' width='20' height='20' border='0' alt='login' title='login' />"
                                        DataNavigateUrlFields="EmployeeID,StrHasLogin"
                                        DataNavigateUrlFormatString="javascript:popup_emp_login('{0}');"
                                        DataTextField="StrHasLogin" UniqueName="login" HeaderStyle-Width="48px">
                                    </telerik:GridHyperLinkColumn>
                                    <telerik:GridButtonColumn ConfirmText="Delete this item?" ConfirmDialogType="RadWindow"
                                        ConfirmTitle="Delete" ButtonType="FontIconButton" CommandName="Delete" HeaderStyle-Width="48px" />
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="hero-widget well well-sm">
                        <telerik:RadHtmlChart CssClass="cg" runat="server" ID="ColumnChart" Width="100%" Height="350" Transitions="true" Skin="Silk" BackColor="Transparent">
                            <PlotArea>
                                <Series>
                                    <telerik:ColumnSeries Name="Wooden Table" Stacked="false" Gap="1.5" Spacing="0.4">
                                        <Appearance>
                                            <FillStyle></FillStyle>
                                        </Appearance>
                                        <LabelsAppearance DataFormatString="{0} sales" Position="OutsideEnd"></LabelsAppearance>
                                        <TooltipsAppearance DataFormatString="{0} sales" Color="White"></TooltipsAppearance>
                                        <SeriesItems>
                                            <telerik:CategorySeriesItem Y="25000"></telerik:CategorySeriesItem>
                                            <telerik:CategorySeriesItem Y="12000"></telerik:CategorySeriesItem>
                                            <telerik:CategorySeriesItem Y="39000"></telerik:CategorySeriesItem>
                                        </SeriesItems>
                                    </telerik:ColumnSeries>
                                    <telerik:ColumnSeries Name="Lounge">
                                        <Appearance>
                                            <FillStyle></FillStyle>
                                        </Appearance>
                                        <LabelsAppearance DataFormatString="{0} sales" Position="OutsideEnd"></LabelsAppearance>
                                        <TooltipsAppearance DataFormatString="{0} sales" Color="White"></TooltipsAppearance>
                                        <SeriesItems>
                                            <telerik:CategorySeriesItem Y="15000"></telerik:CategorySeriesItem>
                                            <telerik:CategorySeriesItem Y="23000"></telerik:CategorySeriesItem>
                                            <telerik:CategorySeriesItem Y="10000"></telerik:CategorySeriesItem>
                                        </SeriesItems>
                                    </telerik:ColumnSeries>
                                    <telerik:ColumnSeries Name="Grey Sofa">
                                        <Appearance>
                                            <FillStyle></FillStyle>
                                        </Appearance>
                                        <LabelsAppearance DataFormatString="{0} sales" Position="OutsideEnd"></LabelsAppearance>
                                        <TooltipsAppearance DataFormatString="{0} sales" Color="White"></TooltipsAppearance>
                                        <SeriesItems>
                                            <telerik:CategorySeriesItem Y="35000"></telerik:CategorySeriesItem>
                                            <telerik:CategorySeriesItem Y="10000"></telerik:CategorySeriesItem>
                                            <telerik:CategorySeriesItem Y="20000"></telerik:CategorySeriesItem>
                                        </SeriesItems>
                                    </telerik:ColumnSeries>
                                </Series>
                                <Appearance>
                                    <FillStyle BackgroundColor="Transparent"></FillStyle>
                                </Appearance>
                                <XAxis AxisCrossingValue="0" Color="black" MajorTickType="Outside" MinorTickType="Outside"
                                    Reversed="false">
                                    <Items>
                                        <telerik:AxisItem LabelText="1"></telerik:AxisItem>
                                        <telerik:AxisItem LabelText="2"></telerik:AxisItem>
                                        <telerik:AxisItem LabelText="3"></telerik:AxisItem>
                                    </Items>
                                    <LabelsAppearance DataFormatString="Q{0}" RotationAngle="0" Skip="0" Step="1"></LabelsAppearance>
                                    <TitleAppearance Position="Center" RotationAngle="0" Text="Quarters">
                                    </TitleAppearance>
                                </XAxis>
                                <YAxis AxisCrossingValue="0" Color="black" MajorTickSize="1" MajorTickType="Outside"
                                    MinorTickType="None" Reversed="false">
                                    <LabelsAppearance DataFormatString="{0} sales" RotationAngle="0" Skip="0" Step="1"></LabelsAppearance>
                                    <TitleAppearance Position="Center" RotationAngle="0" Text="Sales">
                                    </TitleAppearance>
                                </YAxis>
                            </PlotArea>
                            <Appearance>
                                <FillStyle BackgroundColor="Transparent"></FillStyle>
                            </Appearance>
                            <ChartTitle Text="Product sales for 2011">
                                <Appearance Align="Center" BackgroundColor="Transparent" Position="Top">
                                </Appearance>
                            </ChartTitle>
                            <Legend>
                                <Appearance BackgroundColor="Transparent" Position="Bottom">
                                </Appearance>
                            </Legend>
                        </telerik:RadHtmlChart>
                    </div>
                </div>--%>
            </div>

        </div>
    </div>

</asp:Content>
