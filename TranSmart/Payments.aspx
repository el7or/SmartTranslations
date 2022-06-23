<%@ Page Title="Finance" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Payments.aspx.cs" Inherits="TranSmart.Payments" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <link href="Styles/notes.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
        <style>
            .fsRow {
                display: inline-block !important;
                vertical-align: top !important;
                margin-top: 0px !important;
                margin-left: 5px !important;
                margin-right: 5px !important;
                padding: 10px !important;
                border-radius: 4px;
            }

            .rdfLabel {
                width: 90px;
                vertical-align: middle;
            }

            .rdfInput {
                width: 240px !important;
                vertical-align: middle;
                border-radius: 4px !important;
            }

            .lblrdfLabel {
                margin: 2px 5px 2px 5px;
                padding: 2px 5px 2px 5px;
                vertical-align: middle;
            }

            .cmbWidth {
                width: 240px !important;
            }

            legend, .rdfLegend {
                margin-left: 20px !important;
                margin-right: 20px !important;
            }

            .demo-container {
                background-color: whitesmoke;
            }

            .outerMultiPage {
                min-height: 387px;
                margin-left: 15px;
                margin-top: 30px;
            }

            .RadButton {
                margin-left: 15px;
            }

            .demo-container .innerMultiPage {
                display: inline-block;
                *display: inline;
                zoom: 1;
                position: relative;
                margin-bottom: -3px;
            }

            .demo-container .qsf-ib {
                display: inline-block;
                *display: inline;
                zoom: 1;
            }

            .demo-container ul {
                margin: 0;
                padding: 0;
            }

            .ingredients.qsf-ib {
                vertical-align: top;
                position: relative;
                top: -19px;
                *top: 0px;
                width: 100%;
            }

            .ingredients p {
                font: Segoe UI;
                color: #d80033;
                text-transform: uppercase;
                font-size: 18px;
                white-space: normal;
                width: 230px;
                margin-top: 13px;
            }

            .ingredients ul {
                font: Segoe UI;
                color: #444444;
                font-size: 13px;
                list-style-type: none;
            }

            .recipeImage.qsf-ib {
                vertical-align: top;
                margin: 0 15px;
            }

            .demo-container .subtitle {
                font: Segoe UI;
                color: #444444;
                font-size: 13px;
                text-transform: uppercase;
            }

            .disclaimer p {
                font: Segoe UI;
                color: #888888;
                font-size: 12px;
                left: 1px;
                margin: 0;
                position: relative;
                top: -12px;
                width: 390px;
                word-wrap: break-word;
                white-space: normal;
            }

            .demo-container .RadTabStrip.rtsHorizontal .rtsLevel .rtsLink {
                text-align: center;
            }

            .demo-container .RadTabStrip.rtsVertical .rtsLevel1 .rtsSelected .rtsLink {
                background-color: #cccccc;
            }

            .demo-container .RadTabStrip .rtsImg,
            .demo-container .RadTabStripVertical .rtsImg {
                border: 0 none;
                margin-left: -2px;
                margin-top: 7px;
                vertical-align: middle;
            }

            .demo-container .RadRating {
                margin-bottom: 22px;
                position: relative;
                top: 15px;
                *top: -3px;
            }

            .rtsTxt {
                font-weight: bold;
            }

            #MainContent_RadPageView2 div {
                text-align: center;
            }

            #MainContent_RadPageView2 input, #MainContent_RadPageView2 textarea, #MainContent_RadPageView2 label {
                font-size: medium;
            }

            #MainContent_RadPageView2 input, #MainContent_RadPageView2 textarea {
                -webkit-border-radius: 5px;
                -moz-border-radius: 5px;
                border-radius: 5px;
            }

            #MainContent_RadPageView2 label {
                font-weight: bold;
                width: 35%;
                text-align: left;
                margin-bottom: 15px;
            }

            #MainContent_RadPageView2 textarea {
                margin-bottom: 15px;
            }

            .rbHelp16 {
                background-position: -356px 0 !important;
            }

            .text-3d {
                text-align: center;
                font-size: 50px;
                color: #FFFF00;
                font-family: Arial Black, Gadget, sans-serif;
                font-weight: bold;
                text-shadow: 0px 0px 0 rgb(214,214,-41),-1px 1px 0 rgb(191,191,-64),-2px 2px 0 rgb(168,168,-87),-3px 3px 0 rgb(145,145,-110),-4px 4px 0 rgb(121,121,-134),-5px 5px 0 rgb(98,98,-157),-6px 6px 0 rgb(75,75,-180),-7px 7px 0 rgb(52,52,-203), -8px 8px 0 rgb(29,29,-226),-9px 9px 8px rgba(0,0,0,0.5),-9px 9px 1px rgba(0,0,0,0.5),0px 0px 8px rgba(0,0,0,.2)
            }
            .text-3d span{
                color:#FF7F50;
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
                    <fieldset style="padding: 8px; font-size: 16px; font-weight: 500;">Financial Transactions</fieldset>
                </legend>
                <div class="text-3d">Balance:
                    <asp:Label ID="lblBalance" runat="server" Text="100.00"></asp:Label>
                </div>                
                <telerik:RadButton ID="btnNew" runat="server" Text="New Transaction" Font-Bold="True" Font-Size="Medium" PostBackUrl="~/PaymentDetails.aspx"></telerik:RadButton>
                <div class="demo-container no-bg outerMultiPage">
                    <div class="ingredients qsf-ib">
                        <telerik:RadGrid ID="grdPayList" runat="server" AutoGenerateColumns="False" AllowPaging="True" CommandItemStyle-HorizontalAlign="Center" GroupHeaderItemStyle-HorizontalAlign="NotSet" HeaderStyle-HorizontalAlign="NotSet">
                            <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
                            <ClientSettings EnableRowHoverStyle="true" AllowKeyboardNavigation="false">
                                <%--<ClientEvents OnRowClick="RowClick" />--%>
                                <Selecting AllowRowSelect="false"></Selecting>
                            </ClientSettings>
                            <MasterTableView DataKeyNames="ProjectID" TableLayout="Auto">
                                <RowIndicatorColumn Visible="False">
                                </RowIndicatorColumn>
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="#" UniqueName="RowNumber">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblRowNumber" Text='<%# Container.DataSetIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="PaymentID" FilterControlAltText="Filter PaymentID column"
                                        UniqueName="PaymentID" Display="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ProjectID" FilterControlAltText="Filter ProjectID column"
                                        UniqueName="ProjectID" Display="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Title" FilterControlAltText="Filter Title column"
                                        HeaderText="Title" UniqueName="Title">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Type" FilterControlAltText="Filter Type column"
                                        HeaderText="Type" UniqueName="Type">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PaymentDirection" FilterControlAltText="Filter PaymentDirection column"
                                        HeaderText="In/Out" UniqueName="PaymentDirection">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Paid" FilterControlAltText="Filter Paid column"
                                        HeaderText="Value" UniqueName="Paid">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridDateTimeColumn DataField="PaymentDateTime" FilterControlAltText="Filter PaymentDateTime column"
                                        HeaderText="Date" UniqueName="PaymentDateTime" DataType="System.DateTime" DataFormatString="{0:yyyy/MM/dd}" HtmlEncode="false">
                                    </telerik:GridDateTimeColumn>
                                    <telerik:GridDateTimeColumn DataField="PaymentDateTime" FilterControlAltText="Filter PaymentDateTime column"
                                        HeaderText="Time" UniqueName="PaymentDateTime" DataType="System.DateTime" DataFormatString="{0:hh:mm}" HtmlEncode="false">
                                    </telerik:GridDateTimeColumn>
                                    <telerik:GridBoundColumn DataField="By" FilterControlAltText="Filter By column"
                                        HeaderText="By" UniqueName="By">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn HeaderText="Note">
                                        <ItemTemplate>
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Images/info.png" Height="20" Width="20" ImageAlign="Middle" />
                                            <telerik:RadToolTip RenderMode="Lightweight" ID="RadToolTip1" runat="server" TargetControlID="Image1"
                                                RelativeTo="Element" Position="MiddleRight">
                                                <%# DataBinder.Eval(Container, "DataItem.Note") %>
                                            </telerik:RadToolTip>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridHyperLinkColumn DataTextField="isProject" HeaderText="" AllowSorting="False" FilterControlAltText="Filter isProject column"
                                        DataNavigateUrlFields="ProjectID" DataNavigateUrlFormatString="ProjectDetails.aspx?projid={0}"
                                        UniqueName="isProject" ItemStyle-ForeColor="Blue">
                                    </telerik:GridHyperLinkColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>
</asp:Content>

