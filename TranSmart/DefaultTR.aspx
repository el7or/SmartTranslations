<%@ Page Title="Home" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DefaultTR.aspx.cs" Inherits="TranSmart.DefaultTR" %>

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

        /*.hero-widget {
            height: 410px;
        }*/

        .glyphicon a {
            /*margin:5px !important;*/
        }

        /*.glyphicon {
            font-size:40px;
        }*/
        th {
            text-align: center !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FolderContent" runat="Server">
    <%--  <nav:FolderNavigationControl runat="server" ID="FolderNavigationControl" />
    <nav:MobileNavigation runat="server" ID="MobileNavigation"></nav:MobileNavigation>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="width: 100%; height: 5px; background-color: white;">
        <div id="divReload" style="width: 0%; height: 5px; background-color: red; transition: all 1s linear;"></div>
    </div>
    <script type="text/javascript">
        var i = 0;
        pageLoad();
        function pageLoad() {
            console.log(i);
            var intrvl = setInterval(function () {
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
        <div class="container" align="center">
            <div class="row" align="center">
                <div class="">
                    <div class="hero-widget well well-sm wrapper " style="color: #f1f121">
                        <div class="icon">
                            <h2><i class="glyphicon glyphicon-star-empty"></i></h2>
                            <%--send--%>
                        </div>
                        <div class="text">
                            <p>
                                <var>
                                    <asp:Label ID="lblNewTasksCount" runat="server" Text="9"></asp:Label>
                                    <label class="text-muted" style="color: #f1f121;">New Tasks</label></var>
                            </p>
                        </div>
                        <telerik:RadGrid ID="grdNewTasks" runat="server" AutoGenerateColumns="False" PageSize="5"
                            Width="100%">
                            <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
                            <ClientSettings AllowKeyboardNavigation="false" EnableRowHoverStyle="True" EnableClientPrint="True">
                                <Selecting AllowRowSelect="false"></Selecting>
                            </ClientSettings>
                            <MasterTableView DataKeyNames="TaskID">
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
                                    <telerik:GridBoundColumn DataField="ReviewerName" FilterControlAltText="Filter ReviewerName column"
                                        HeaderText="Reviewer" UniqueName="ReviewerName">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TaskStatus" FilterControlAltText="Filter TaskStatus column"
                                        HeaderText="Status" UniqueName="TaskStatus">
                                    </telerik:GridBoundColumn>
                                    <%--<telerik:GridBoundColumn DataField="PromiseDeliveryDate" FilterControlAltText="Filter PromiseDeliveryDate column"
                                            HeaderText="Promise" UniqueName="PromiseDeliveryDate" DataFormatString="{0:dd/MM/yyyy}">
                                        </telerik:GridBoundColumn>--%>
                                    <telerik:GridHyperLinkColumn AllowSorting="False" FilterControlAltText="Filter Details column"
                                        DataTextFormatString="<img src='Content/Images/app.png' width='20' height='20' border='0' alt='Details' title='Details' />"
                                        DataNavigateUrlFields="TaskID" DataNavigateUrlFormatString="ProjectTasksDetailsTR.aspx?taskid={0}"
                                        DataTextField="TaskID" UniqueName="Details" HeaderStyle-Width="48px">
                                    </telerik:GridHyperLinkColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </div>
                </div>
                <div class="">
                    <div class="hero-widget well well-sm wrapper" style="color: #f49c4f">
                        <%--EC6807--%>
                        <div class="icon">
                            <h2><i class="glyphicon glyphicon-cog"></i></h2>
                            <%--fire--%>
                        </div>
                        <div class="text">
                            <p>
                                <var>
                                    <asp:Label ID="lblProgressTasksCount" runat="server" Text="9"></asp:Label>
                                    <label class="text-muted" style="color: #f49c4f;">Progress Tasks</label></var>
                            </p>
                        </div>
                        <telerik:RadGrid ID="grdProgressTasks" runat="server" AutoGenerateColumns="False" PageSize="5"
                            Width="100%">
                            <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
                            <ClientSettings AllowKeyboardNavigation="false" EnableRowHoverStyle="True" EnableClientPrint="True">
                                <Selecting AllowRowSelect="false"></Selecting>
                            </ClientSettings>
                            <MasterTableView DataKeyNames="TaskID">
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
                                    <telerik:GridBoundColumn DataField="ReviewerName" FilterControlAltText="Filter ReviewerName column"
                                        HeaderText="Reviewer" UniqueName="ReviewerName">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TaskStatus" FilterControlAltText="Filter TaskStatus column"
                                        HeaderText="Status" UniqueName="TaskStatus">
                                    </telerik:GridBoundColumn>
                                    <%--<telerik:GridBoundColumn DataField="PromiseDeliveryDate" FilterControlAltText="Filter PromiseDeliveryDate column"
                                            HeaderText="Promise" UniqueName="PromiseDeliveryDate" DataFormatString="{0:dd/MM/yyyy}">
                                        </telerik:GridBoundColumn>--%>
                                    <telerik:GridHyperLinkColumn AllowSorting="False" FilterControlAltText="Filter Details column"
                                        DataTextFormatString="<img src='Content/Images/app.png' width='20' height='20' border='0' alt='Details' title='Details' />"
                                        DataNavigateUrlFields="TaskID" DataNavigateUrlFormatString="ProjectTasksDetailsTR.aspx?taskid={0}"
                                        DataTextField="TaskID" UniqueName="Details" HeaderStyle-Width="48px">
                                    </telerik:GridHyperLinkColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>

                    </div>
                </div>
                <div class="">
                    <div class="hero-widget well well-sm wrapper" style="color: #79AC47">
                        <div class="icon">
                            <h2><i class="glyphicon glyphicon-ok"></i></h2>
                        </div>
                        <div class="text">
                            <p>
                                <var>
                                    <asp:Label ID="lblDoneTasksCount" runat="server" Text="9"></asp:Label>
                                    <label class="text-muted" style="color: #79AC47;">Done Tasks</label></var>
                            </p>
                        </div>
                        <telerik:RadGrid ID="grdDoneTasks" runat="server" AutoGenerateColumns="False" PageSize="5"
                            Width="100%">
                            <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
                            <ClientSettings AllowKeyboardNavigation="false" EnableRowHoverStyle="True" EnableClientPrint="True">
                                <Selecting AllowRowSelect="false"></Selecting>
                            </ClientSettings>
                            <MasterTableView DataKeyNames="TaskID">
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
                                    <telerik:GridBoundColumn DataField="ReviewerName" FilterControlAltText="Filter ReviewerName column"
                                        HeaderText="Reviewer" UniqueName="ReviewerName">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TaskStatus" FilterControlAltText="Filter TaskStatus column"
                                        HeaderText="Status" UniqueName="TaskStatus">
                                    </telerik:GridBoundColumn>
                                    <%--<telerik:GridBoundColumn DataField="PromiseDeliveryDate" FilterControlAltText="Filter PromiseDeliveryDate column"
                                            HeaderText="Promise" UniqueName="PromiseDeliveryDate" DataFormatString="{0:dd/MM/yyyy}">
                                        </telerik:GridBoundColumn>--%>
                                    <telerik:GridHyperLinkColumn AllowSorting="False" FilterControlAltText="Filter Details column"
                                        DataTextFormatString="<img src='Content/Images/app.png' width='20' height='20' border='0' alt='Details' title='Details' />"
                                        DataNavigateUrlFields="TaskID" DataNavigateUrlFormatString="ProjectTasksDetailsTR.aspx?taskid={0}"
                                        DataTextField="TaskID" UniqueName="Details" HeaderStyle-Width="48px">
                                    </telerik:GridHyperLinkColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
