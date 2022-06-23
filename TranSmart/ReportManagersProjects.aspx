<%@ Page Title="Manager Projects Report" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ReportManagersProjects.aspx.cs" Inherits="TranSmart.ReportManagersProjects" %>

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
                        <asp:Label ID="lblHeader" runat="server" Text="Number Projects of Managers"></asp:Label>
                    </fieldset>
                </legend>
                <div class="demo-container no-bg outerMultiPage">
                    <telerik:RadButton ID="DownloadPDF" runat="server" Text="Export PDF" OnClick="DownloadPDF_Click">
                        <Icon PrimaryIconCssClass="rbDownload" />
                    </telerik:RadButton>
                    <div class="ingredients qsf-ib">
                        <telerik:RadGrid ID="grdManagersList" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="10"
                            CommandItemStyle-HorizontalAlign="Center" OnItemCreated="grdManagersList_ItemCreated"
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
                            <MasterTableView DataKeyNames="EmployeeID" TableLayout="Auto">
                                <RowIndicatorColumn Visible="False">
                                </RowIndicatorColumn>
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="#" UniqueName="RowNumber">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblRowNumber" Text='<%# Container.DataSetIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="EmployeeID" FilterControlAltText="Filter EmployeeID column"
                                        UniqueName="EmployeeID" Visible="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FullName" FilterControlAltText="Filter FullName column"
                                        HeaderText="Name" UniqueName="FullName">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Email" FilterControlAltText="Filter Email column"
                                        HeaderText="Email" UniqueName="Email">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Phone" FilterControlAltText="Filter Phone column"
                                        HeaderText="Phone" UniqueName="Phone">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="JobStartDate" FilterControlAltText="Filter JobStartDate column"
                                        HeaderText="Job Start Date" UniqueName="JobStartDate">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ProjectsCount" FilterControlAltText="Filter ProjectsCount column"
                                        HeaderText="Count" UniqueName="ProjectsCount">
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
