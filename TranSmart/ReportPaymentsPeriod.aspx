﻿<%@ Page Title="Payments Period Report" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ReportPaymentsPeriod.aspx.cs" Inherits="TranSmart.ReportPaymentsPeriod" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <link href="Styles/notes.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadWindowManager ID="RadWindowManager2" runat="server">
    </telerik:RadWindowManager>
    <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
        <style>
            .navbar-brand-centered {
                position: absolute;
                left: 50%;
                display: block;
                text-align: center;
                background-color: transparent;
            }

                .navbar-brand-centered a {
                    font-weight: bold;
                }

            .navbar > .container .navbar-brand-centered,
            .navbar > .container-fluid .navbar-brand-centered {
                margin-left: -80px;
            }
            h3{
                display:inline-block;
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
        DecorationZoneID="zoneProjects" DecoratedControls="All" />
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" UpdateInitiatorPanelsOnly="true">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="grdProjList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdProjList" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="ConfiguratorPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ConfiguratorPanel">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdProjList" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>    
    <div id="zoneProjects" class="zoneEntity" style="margin: 30px;">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <fieldset class="fsRow" style="width: 100% !important; background-image: linear-gradient(#ebebeb,#fff);">
                <legend class="rdfLegend rfdRoundedCorners ">
                    <fieldset style="padding: 8px; font-size: 16px; font-weight: 500;">
                        <asp:Label ID="lblHeader" runat="server" Text="Financial Daily Report"></asp:Label>
                    </fieldset>
                </legend>
                <div class="demo-container no-bg outerMultiPage">
                        <h3><asp:Label ID="lblPickDay" runat="server" Text="Pick a day:  " Visible="false"></asp:Label></h3>
                        <telerik:RadDatePicker ID="RadDatePicker1" runat="server" AutoPostBack="true" OnSelectedDateChanged="RadDatePicker1_SelectedDateChanged" Visible="false">
                            <DateInput runat="server" DateFormat="yyyy/MM/dd">
                            </DateInput>
                        </telerik:RadDatePicker>
                        <h3><asp:Label ID="lblPickMonth" runat="server" Text="Pick a month:  " Visible="false"></asp:Label></h3>                        
                        <telerik:RadMonthYearPicker ID="RadDatePicker2" runat="server" AutoPostBack="true" OnSelectedDateChanged="RadDatePicker2_SelectedDateChanged" Visible="false">
                        </telerik:RadMonthYearPicker>
                        <br />
                        <br />
                    <telerik:RadButton ID="DownloadPDF" runat="server" Text="Export PDF" OnClick="DownloadPDF_Click">
                        <Icon PrimaryIconCssClass="rbDownload" />
                    </telerik:RadButton>
                    <div class="ingredients qsf-ib">
                        <telerik:RadGrid ID="grdPayList" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="10"
                            CommandItemStyle-HorizontalAlign="Center" OnItemCreated="grdPayList_ItemCreated"
                            GroupHeaderItemStyle-HorizontalAlign="NotSet" HeaderStyle-HorizontalAlign="NotSet">
                            <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
                            <ClientSettings EnableRowHoverStyle="true" AllowKeyboardNavigation="false">
                                <%--<ClientEvents OnRowClick="RowClick" />--%>
                                <Selecting AllowRowSelect="false"></Selecting>
                            </ClientSettings>
                            <ExportSettings IgnorePaging="true" OpenInNewWindow="true">
                                <Pdf PageHeight="210mm" PageWidth="297mm" DefaultFontFamily="Arial Unicode MS" PageTopMargin="45mm"
                                    BorderStyle="Thin" BorderColor="#666666" PageRightMargin="11mm" PageLeftMargin="11mm" BorderType="TopAndBottom">
                                </Pdf>
                            </ExportSettings>
                            <MasterTableView DataKeyNames="PaymentID" TableLayout="Auto">
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
                                        HeaderText="Name" UniqueName="Title">
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
                                    <telerik:GridTemplateColumn HeaderText="Note" Exportable="false">
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
                                        UniqueName="isProject" ItemStyle-ForeColor="Blue" Exportable="false">
                                    </telerik:GridHyperLinkColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </div>
                </div>
                <nav class="navbar navbar-default">
                    <div class="container-fluid">
                        <div class="navbar-header" style="padding-left: 10px">
                            <div class="navbar-text navbar-brand-centered">
                                <a href="Reports.aspx" class="btn btn-default navbar-btn pull-left">
                                    <span class="glyphicon glyphicon-chevron-left"></span>All Reports
                                </a>
                            </div>
                        </div>
                    </div>
                </nav>
            </fieldset>
        </div>
    </div>
</asp:Content>
