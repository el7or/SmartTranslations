<%@ Page Title="Projects Report" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ReportProjects.aspx.cs" Inherits="TranSmart.ReportProjects" %>

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
                        <asp:Label ID="lblHeader" runat="server" Text="Projects Report"></asp:Label>
                    </fieldset>
                </legend>
                <div class="demo-container no-bg outerMultiPage">
                    <telerik:RadButton ID="DownloadPDF" runat="server" Text="Export PDF" OnClick="DownloadPDF_Click">
                        <Icon PrimaryIconCssClass="rbDownload" />
                    </telerik:RadButton>
                    <div class="ingredients qsf-ib">
                        <%--AllowSorting="true" AllowFilteringByColumn="true" OnItemCommand="grdProjList_ItemCommand"--%>
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
                            <MasterTableView DataKeyNames="ProjectID" TableLayout="Auto" PagerStyle-Mode="NumericPages">
                                <RowIndicatorColumn Visible="False">
                                </RowIndicatorColumn>
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="#" UniqueName="RowNumber">
                                          <HeaderStyle width="40px" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblRowNumber" Text='<%# Container.DataSetIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="ProjectID" FilterControlAltText="Filter ProjectID column"
                                        UniqueName="ProjectID" Display="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CustomerID" FilterControlAltText="Filter CustomerID column"
                                        UniqueName="CustomerID" Display="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ManagerID" FilterControlAltText="Filter ManagerID column"
                                        UniqueName="ManagerID" Display="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ProjectSerial" FilterControlAltText="Filter ProjectSerial column"
                                        HeaderText="Project Nr." UniqueName="ProjectSerial">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ProjectTitle" FilterControlAltText="Filter ProjectTitle column"
                                        HeaderText="Name" UniqueName="ProjectTitle">
                                    </telerik:GridBoundColumn>
                                    <%--<telerik:GridBoundColumn DataField="CustomerName" FilterControlAltText="Filter CustomerName column"
                                        HeaderText="Customer Name" UniqueName="CustomerName">
                                    </telerik:GridBoundColumn>--%>
                                    <telerik:GridHyperLinkColumn DataTextField="CustomerName" HeaderText="Client" AllowSorting="False" FilterControlAltText="Filter CustomerName column" DataNavigateUrlFields="CustomerID"
                                        DataNavigateUrlFormatString="Projects.aspx?clintid={0}"
                                        UniqueName="CustomerName" ItemStyle-ForeColor="Blue">
                                    </telerik:GridHyperLinkColumn>
                                    <telerik:GridHyperLinkColumn DataTextField="ProjectManager" HeaderText="PM" AllowSorting="False" FilterControlAltText="Filter ProjectManager column" DataNavigateUrlFields="ManagerID"
                                        DataNavigateUrlFormatString="Projects.aspx?pmid={0}" Exportable="false"
                                        UniqueName="ProjectManager" ItemStyle-ForeColor="Blue">
                                    </telerik:GridHyperLinkColumn>
                                    <telerik:GridBoundColumn DataField="CurrentStatus" FilterControlAltText="Filter CurrentStatus column"
                                        HeaderText="Status" UniqueName="CurrentStatus">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="LanggFromTo" FilterControlAltText="Filter LanggFromTo column"
                                        HeaderText="Source/Target" UniqueName="LanggFromTo">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TotalCost" FilterControlAltText="Filter TotalCost column"
                                        HeaderText="Total Cost" UniqueName="TotalCost">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridHyperLinkColumn AllowSorting="False" Exportable="false" FilterControlAltText="Filter Tasks column" DataNavigateUrlFields="ProjectID"
                                        DataNavigateUrlFormatString="ProjectTasks.aspx?projid={0}"
                                        UniqueName="Tasks" Text="Tasks" ItemStyle-ForeColor="Blue">
                                    </telerik:GridHyperLinkColumn>
                                    <telerik:GridTemplateColumn Exportable="false">
                                        <ItemTemplate>
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Images/info.png" Height="20" Width="20" ImageAlign="Middle" />
                                            <telerik:RadToolTip RenderMode="Lightweight" ID="RadToolTip1" runat="server" TargetControlID="Image1"
                                                RelativeTo="Element" Position="MiddleRight">
                                                <b>Created in:</b>  <%# DataBinder.Eval(Container, "DataItem.CreatedDate") %>
                                                <br />
                                                <b>Created By:</b> <%# DataBinder.Eval(Container, "DataItem.CreatedBy") %>
                                                <br />
                                                <b>Last Update in:</b> <%# DataBinder.Eval(Container, "DataItem.LastEditedDate") %>
                                                <br />
                                                <b>Last Update By:</b> <%# DataBinder.Eval(Container, "DataItem.LastEditedBy") %>
                                                <br />
                                            </telerik:RadToolTip>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
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

