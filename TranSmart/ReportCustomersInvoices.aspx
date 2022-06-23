<%@ Page Title="Customer Invoices Report" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ReportCustomersInvoices.aspx.cs" Inherits="TranSmart.ReportCustomersInvoices" %>

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

            h3 {
                display: inline-block;
            }
        </style>
        <script type="text/javascript" lang="javascript">
            function RowClick(sender, eventArgs) {
                var grid = sender;
                var MasterTable = grid.get_masterTableView(); var row = MasterTable.get_dataItems()[eventArgs.get_itemIndexHierarchical()];
                var cell = MasterTable.getCellByColumnUniqueName(row, "ProjectID");
                window.location = '/ProjectDetails.aspx?projid=' + cell.innerHTML;
            }
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
                        <asp:Label ID="lblHeader" runat="server" Text="Client invoices"></asp:Label>
                    </fieldset>
                </legend>
                <div class="demo-container no-bg outerMultiPage">
                        <h3>
                            <asp:Label ID="lblPickClint" runat="server" Text="Choose Client:"></asp:Label></h3>&nbsp;&nbsp;
                        <telerik:RadComboBox ID="ddlCustomerProject" RenderMode="Lightweight" runat="server" EmptyMessage=" "
                            AutoPostBack="true" OnSelectedIndexChanged="ddlCustomerProject_SelectedIndexChanged">
                            <Items>
                                <telerik:RadComboBoxItem Text="" Value="" TabIndex="-1" Enabled="False" Selected="True"/>
                            </Items>
                        </telerik:RadComboBox>
                        <br />
                        <br />
                    <telerik:RadButton ID="DownloadPDF" runat="server" Text="Export PDF" OnClick="DownloadPDF_Click">
                        <Icon PrimaryIconCssClass="rbDownload" />
                    </telerik:RadButton>
                    <div class="ingredients qsf-ib">
                        <telerik:RadGrid ID="grdProjList" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="10"
                            CommandItemStyle-HorizontalAlign="Center" OnItemCreated="grdProjList_ItemCreated"
                            GroupHeaderItemStyle-HorizontalAlign="NotSet" HeaderStyle-HorizontalAlign="NotSet">
                            <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
                            <ClientSettings EnableRowHoverStyle="true" AllowKeyboardNavigation="false">
                                <ClientEvents OnRowClick="RowClick" />
                                <Selecting AllowRowSelect="false"></Selecting>
                            </ClientSettings>
                            <ExportSettings IgnorePaging="true" OpenInNewWindow="true">
                                <Pdf PageHeight="210mm" PageWidth="297mm" DefaultFontFamily="Arial Unicode MS" PageTopMargin="45mm"
                                    BorderStyle="Thin" BorderColor="#666666" PageRightMargin="11mm" PageLeftMargin="11mm" BorderType="TopAndBottom">
                                </Pdf>
                            </ExportSettings>
                            <MasterTableView DataKeyNames="ProjectID" TableLayout="Auto">
                                <RowIndicatorColumn Visible="False">
                                </RowIndicatorColumn>
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="#" UniqueName="RowNumber">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblRowNumber" Text='<%# Container.DataSetIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="ProjectID" FilterControlAltText="Filter ProjectID column"
                                        UniqueName="ProjectID" Display="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CustomerName" FilterControlAltText="Filter CustomerName column"
                                        HeaderText="Client" UniqueName="CustomerName">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ProjectSerial" FilterControlAltText="Filter ProjectSerial column"
                                        HeaderText="Project Nr." UniqueName="ProjectSerial">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ProjectTitle" FilterControlAltText="Filter ProjectTitle column"
                                        HeaderText="Name" UniqueName="ProjectTitle">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="LanggFromTo" FilterControlAltText="Filter LanggFromTo column"
                                        HeaderText="Source/Target" UniqueName="LanggFromTo">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="WordCount" FilterControlAltText="Filter WordCount column"
                                        HeaderText="Word Count" UniqueName="WordCount">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="WordPrice" FilterControlAltText="Filter WordPrice column"
                                        HeaderText="Word Price" UniqueName="TotalCost">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="DiscountValue" FilterControlAltText="Filter DiscountValue column"
                                        HeaderText="Discount" UniqueName="DiscountValue">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="VatValue" FilterControlAltText="Filter VatValue column"
                                        HeaderText="Tax" UniqueName="VatValue">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TotalCost" FilterControlAltText="Filter TotalCost column"
                                        HeaderText="Gross Total" UniqueName="TotalCost">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Paid" FilterControlAltText="Filter Paid column"
                                        HeaderText="Advance Payment" UniqueName="Paid">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Due" FilterControlAltText="Filter Due column"
                                        HeaderText="Payable" UniqueName="Due">
                                    </telerik:GridBoundColumn>
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
