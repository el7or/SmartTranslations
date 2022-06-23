﻿<%@ Page Title="Project Tasks" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProjectTasks.aspx.cs" Inherits="TranSmart.ProjectTasks" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <link href="Styles/notes.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
        <style>
          /* */   .fsRow {
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

            .rgAltRow, .rgRow {
                cursor: pointer !important;
            }

            .rbHelp16 {
                background-position: -356px 0 !important;
            }           
           .rgHeader a
            {
                color:inherit !important;
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
            function getQueryStringValue(key) {
                return decodeURIComponent(window.location.search.replace(new RegExp("^(?:.*[&\\?]" + encodeURIComponent(key).replace(/[\.\+\*]/g, "\\$&") + "(?:\\=([^&]*))?)?.*$", "i"), "$1"));
            }
        </script>
    </telerik:RadCodeBlock>

    <telerik:RadFormDecorator ID="RadFormDecorator3" runat="server"
        DecorationZoneID="zoneTasks" DecoratedControls="All" />
    <div id="zoneTasks" class="zoneEntity" style="margin: 30px;">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <fieldset class="fsRow" style="width: 100% !important; background-image: linear-gradient(#ebebeb,#fff);">
                <legend class="rdfLegend rfdRoundedCorners ">
                    <fieldset style="padding: 8px; font-size: 16px; font-weight: 500;">Tasks</fieldset>
                </legend>
                <telerik:RadButton ID="btnNew" runat="server" Text="Add Task" Font-Bold="True" Font-Size="Medium"></telerik:RadButton>
                <div class="demo-container no-bg outerMultiPage"><%----%>
                    <div class="ingredients qsf-ib"><%----%>
                        <telerik:RadGrid ID="grdTaskList" runat="server" AutoGenerateColumns="False" 
                            AllowPaging="True" CommandItemStyle-HorizontalAlign="Center" 
                            GroupHeaderItemStyle-HorizontalAlign="NotSet" HeaderStyle-HorizontalAlign="NotSet" 
                            AllowFilteringByColumn="True" AllowSorting="true"
                            EnableHeaderContextFilterMenu="True" EnableHeaderContextMenu="True" EnableHeaderContextAggregatesMenu="false">
                            <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
                            <ClientSettings EnableRowHoverStyle="true" AllowKeyboardNavigation="false">
                                <ClientEvents OnRowClick="RowClick" />
                                <Selecting AllowRowSelect="false"></Selecting>
                            </ClientSettings>
                            <MasterTableView DataKeyNames="TaskID" TableLayout="Auto">
                                <RowIndicatorColumn Visible="False">
                                </RowIndicatorColumn>
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="#" UniqueName="RowNumber" HeaderStyle-Width="50px" 
                                         ItemStyle-Width="50px"  FilterControlWidth="50px" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true">
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
                                        HeaderText="Project Nr." UniqueName="ProjectSerial"  FilterControlWidth="80%"  CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" >
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TaskSerial" FilterControlAltText="Filter TaskSerial column"
                                        HeaderText="Task Nr." UniqueName="TaskSerial"  FilterControlWidth="80%"  CurrentFilterFunction="Contains" AutoPostBackOnFilter="true">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TaskStatus" FilterControlAltText="Filter TaskStatus column"
                                        HeaderText="Status" UniqueName="TaskStatus"  FilterControlWidth="80%"  CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" >
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TranslatorName" FilterControlAltText="Filter TranslatorName column"
                                        HeaderText="Translator" UniqueName="TranslatorName"  FilterControlWidth="80%"  CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" >
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ReviewerName" FilterControlAltText="Filter ReviewerName column"
                                        HeaderText="Revisor" UniqueName="ReviewerName"  FilterControlWidth="80%" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" >
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="WordCount" FilterControlAltText="Filter WordCount column"
                                        HeaderText="Word Count" UniqueName="WordCount"  FilterControlWidth="80%" CurrentFilterFunction="GreaterThanOrEqualTo" AutoPostBackOnFilter="true" >
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn HeaderStyle-Width="50px" AllowFiltering="false">
                                        <ItemTemplate>
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Images/info.png" Height="20" Width="20" ImageAlign="Middle" />
                                            <telerik:RadToolTip RenderMode="Lightweight" ID="RadToolTip1" runat="server" TargetControlID="Image1"
                                                RelativeTo="Element" Position="MiddleRight">
                                                <b>Created:</b> <%# DataBinder.Eval(Container, "DataItem.CreatedBy") %>
                                                <br />
                                                <b>Date:</b>  <%# DataBinder.Eval(Container, "DataItem.CreatedDate") %>
                                                <br />
                                                <b>Edited:</b> <%# DataBinder.Eval(Container, "DataItem.LastEditedBy") %>
                                                <br />
                                                <b>Date:</b> <%# DataBinder.Eval(Container, "DataItem.LastEditedDate") %>
                                                <br />
                                            </telerik:RadToolTip>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>
</asp:Content>
