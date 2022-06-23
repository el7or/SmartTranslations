<%@ Page Title="Tasks Report" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ReportTasks.aspx.cs" Inherits="TranSmart.ReportTasks" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <link href="Styles/notes.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
                var cellProject = MasterTable.getCellByColumnUniqueName(row, "ProjectID");
                var cellTask = MasterTable.getCellByColumnUniqueName(row, "TaskID");
                window.location = '/ProjectTasksDetails.aspx?projid=' + cellProject.innerHTML + '&taskid=' + cellTask.innerHTML;
            }
            //function getQueryStringValue(key) {
            //    return decodeURIComponent(window.location.search.replace(new RegExp("^(?:.*[&\\?]" + encodeURIComponent(key).replace(/[\.\+\*]/g, "\\$&") + "(?:\\=([^&]*))?)?.*$", "i"), "$1"));
            //}
        </script>
    </telerik:RadCodeBlock>

    <telerik:RadFormDecorator ID="RadFormDecorator3" runat="server"
        DecorationZoneID="zoneTasks" DecoratedControls="All" />
    <div id="zoneTasks" class="zoneEntity" style="margin: 30px;">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <fieldset class="fsRow" style="width: 100% !important; background-image: linear-gradient(#ebebeb,#fff);">
                <legend class="rdfLegend rfdRoundedCorners ">
                    <fieldset style="padding: 8px; font-size: 16px; font-weight: 500;">
                        <asp:Label ID="lblHeader" runat="server" Text="Tasks Report"></asp:Label>
                    </fieldset>
                </legend>
                <div class="demo-container no-bg outerMultiPage">
                    <telerik:RadButton ID="DownloadPDF" runat="server" Text="Export PDF" OnClick="DownloadPDF_Click">
                        <Icon PrimaryIconCssClass="rbDownload" />
                    </telerik:RadButton>
                    <div class="ingredients qsf-ib">
                        <telerik:RadGrid ID="grdTaskList" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="10"
                            CommandItemStyle-HorizontalAlign="Center" OnItemCreated="grdTaskList_ItemCreated"
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
                            <MasterTableView DataKeyNames="TaskID" TableLayout="Auto">
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
                                    <telerik:GridBoundColumn DataField="TaskID" FilterControlAltText="Filter TaskID column"
                                        UniqueName="TaskID" Display="False">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ProjectSerial" FilterControlAltText="Filter ProjectSerial column"
                                        HeaderText="Project Nr." UniqueName="ProjectSerial">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TaskSerial" FilterControlAltText="Filter TaskSerial column"
                                        HeaderText="Task Nr." UniqueName="TaskSerial">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TaskStatus" FilterControlAltText="Filter TaskStatus column"
                                        HeaderText="Status" UniqueName="TaskStatus">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TranslatorName" FilterControlAltText="Filter TranslatorName column"
                                        HeaderText="Translator" UniqueName="TranslatorName">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ReviewerName" FilterControlAltText="Filter ReviewerName column"
                                        HeaderText="Revisor" UniqueName="ReviewerName">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="WordCount" FilterControlAltText="Filter WordCount column"
                                        HeaderText="Word Count" UniqueName="WordCount">
                                    </telerik:GridBoundColumn>
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