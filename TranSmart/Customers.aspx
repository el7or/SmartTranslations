<%@ Page Title="Clients" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="Customers.aspx.cs" Inherits="TranSmart.Customers"  %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <link href="Styles/contacts.css" rel="stylesheet" />
    <link href="css/sweetalert.css" rel="stylesheet" />
    <script src="js/sweetalert.min.js"></script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadWindowManager ID="RadWindowManager2" runat="server">
    </telerik:RadWindowManager>
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

                .demo-container .outerMultiPage {
                    min-height: 387px;
                    margin-left: 15px;
                    margin-top: 30px;
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
        </style>
        <script type="text/javascript" lang="javascript">
            //window.onclick = function (e) {
            //    try {
            //        parent.close_combo();
            //    } catch (e) {
            //        console.log(e);
            //    }
            //}

            function OnClientTabSelected(sender, eventArgs) {
                console.log('OnClientTabSelected 0');
                //var tab = eventArgs.get_tab();
                //var tabStrip = $find("<%= RadTabStrip1.ClientID %>");
                //var tab = tabStrip.findTabByText("Edit Client");
                //tab.set_text("Add new Client");
                //$('input, textarea').not('.btn').val('');
                //window.history.pushState("object or string", "Title", "/Clients");
                console.log('OnClientTabSelected 1');
            }
            function OnClientMouseOver(sender, eventArgs) {

                console.log('OnClientMouseOver 0');
            }
            function OnClientTabSelecting(sender, eventArgs) {
                console.log('OnClientTabSelecting 0');
               <%-- var tab = eventArgs.get_tab();
                var tabStrip = $find("<%= RadTabStrip1.ClientID %>");
                var tab = tabStrip.findTabByText("Edit Client");
                tab.set_text("Add new Client");
                $('input, textarea').not('.btn').val('');
                window.history.pushState("object or string", "Title", "/Clients");--%>
                console.log('OnClientTabSelecting 1');
            }
            function MyAlert() {
                //swal('Success!', 'Saved !', 'success');
                swal({
                    title: "Success!",
                    text: "Saved !",
                    type: "success",
                    timer: 2000,
                    showConfirmButton: false
                });
            }
        </script>
    </telerik:RadCodeBlock>

    <telerik:RadFormDecorator ID="RadFormDecorator3" runat="server"
        DecorationZoneID="zoneCustomers" DecoratedControls="All" />
    <div id="zoneCustomers" class="zoneEntity" style="margin: 30px;">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <fieldset class="fsRow" style="width: 100% !important; background-image: linear-gradient(#ebebeb,#fff);">
                <legend class="rdfLegend rfdRoundedCorners ">
                    <fieldset style="padding: 8px; font-size: 16px; font-weight: 500;">Clients</fieldset>
                </legend>
                <div class="demo-container no-bg">
                    <telerik:RadTabStrip runat="server" ID="RadTabStrip1" MultiPageID="RadMultiPage1" SelectedIndex="0"
                        ClickSelectedTab="True" OnClientTabSelected="OnClientTabSelected"  RenderMode="Lightweight" 
                        OnClientTabSelecting="OnClientTabSelecting" OnClientMouseOver="OnClientMouseOver" CausesValidation="False">
                        <Tabs>
                            <telerik:RadTab Text="Client list" Width="200px" Selected="True" ></telerik:RadTab>
                            <telerik:RadTab Text="Add new" Width="200px"></telerik:RadTab>
                        </Tabs>
                    </telerik:RadTabStrip>
                    <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" CssClass="outerMultiPage">
                        <telerik:RadPageView runat="server" ID="RadPageView1">
                            <div class="ingredients qsf-ib">
                                <telerik:RadGrid ID="grdClientList" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnDeleteCommand="grdClientList_DeleteCommand">
                                    <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
                                    <ClientSettings AllowKeyboardNavigation="false">
                                        <Selecting AllowRowSelect="false"></Selecting>
                                    </ClientSettings>
                                    <MasterTableView DataKeyNames="CustomerID" TableLayout="Auto">
                                        <RowIndicatorColumn Visible="False">
                                        </RowIndicatorColumn>
                                        <Columns>
                                            <telerik:GridTemplateColumn HeaderText="#" UniqueName="RowNumber">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblRowNumber" Text='<%# Container.DataSetIndex+1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="CustomerID" FilterControlAltText="Filter CustomerID column"
                                                UniqueName="CustomerID" Visible="False">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CustomerName" FilterControlAltText="Filter CustomerName column"
                                                HeaderText="Name" UniqueName="CustomerName">
                                            </telerik:GridBoundColumn>

                                            <telerik:GridBoundColumn DataField="CustomerType" FilterControlAltText="Filter CustomerType column"
                                                HeaderText="Type" UniqueName="CustomerType">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CustomerEmail" FilterControlAltText="Filter CustomerEmail column"
                                                HeaderText="Email" UniqueName="CustomerEmail">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CustomerPhone" FilterControlAltText="Filter CustomerPhone column"
                                                HeaderText="Phone" UniqueName="CustomerPhone">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CustomerCountry" FilterControlAltText="Filter CustomerCountry column"
                                                HeaderText="Country" UniqueName="CustomerCountry">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CustomerAddress" FilterControlAltText="Filter CustomerAddress column"
                                                HeaderText="Address" UniqueName="CustomerAddress">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="FirstContactDate" FilterControlAltText="Filter FirstContactDate column"
                                                HeaderText="Start Date" UniqueName="FirstContactDate">
                                            </telerik:GridBoundColumn>
                                            <%--<telerik:GridHyperLinkColumn AllowSorting="False" FilterControlAltText="Filter Projects column" DataNavigateUrlFields="CustomerID"
                                                DataNavigateUrlFormatString="Projects.aspx?id={0}"
                                                UniqueName="Projects" Text="Projects" ItemStyle-ForeColor="Blue">
                                            </telerik:GridHyperLinkColumn>--%>
                                            <telerik:GridHyperLinkColumn AllowSorting="False" FilterControlAltText="Filter Details column"
                                                DataTextFormatString="<img src='Content/Images/edit.png' width='20' height='20' border='0' alt='Edit' title='Edit' />" DataNavigateUrlFields="CustomerID"
                                                DataNavigateUrlFormatString="Customers.aspx?id={0}"
                                                DataTextField="CustomerID" UniqueName="Edit" HeaderStyle-Width="48px">
                                            </telerik:GridHyperLinkColumn>
                                            <telerik:GridButtonColumn ConfirmText="Delete this item?" ConfirmDialogType="RadWindow"
                                                ConfirmTitle="Delete" ButtonType="FontIconButton" CommandName="Delete" />
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>
                            </div>
                        </telerik:RadPageView>
                        <telerik:RadPageView runat="server" ID="RadPageView2">                               
                                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                    <fieldset class="fsRow">
                                        <legend class="rdfLegend rfdRoundedCorners "></legend>

                                        <telerik:RadTextBox ID="txtCustomerID" runat="server" ReadOnly="true"
                                            RenderMode="Lightweight" Label="Client ID" Visible="False" />

                                        <telerik:RadTextBox ID="txtCustomerName" runat="server" 
                                            Width="90%" Label="Name:" ValidationGroup="customerDetails"  AutoPostBack="False" ClientIDMode="Static" />
                                        <asp:RequiredFieldValidator ControlToValidate="txtCustomerName"  ValidationGroup="customerDetails" ID="RequiredFieldValidator1" 
                                            runat="server" ForeColor="red" ErrorMessage="*" CssClass="validator" Display="Dynamic"
                                            Font-Size="18" Font-Bold="True"></asp:RequiredFieldValidator>

                                        <telerik:RadComboBox ID="cmbTypeID" runat="server" RenderMode="Lightweight"
                                            Width="88%" Label="Client Type:" LabelCssClass="rdfLabel" EmptyMessage="Choose a Type...">
                                            <Items>
                                                <telerik:RadComboBoxItem Text="aaaa" />
                                                <telerik:RadComboBoxItem Text="aaaa" />
                                                <telerik:RadComboBoxItem Text="aaaa" />
                                            </Items>
                                        </telerik:RadComboBox>
                                        <asp:RequiredFieldValidator ControlToValidate="cmbTypeID" ValidationGroup="customerDetails" ID="RequiredFieldValidator3" 
                                            runat="server" EnableClientScript="true" ForeColor="red" ErrorMessage="*" CssClass="validator" Display="Dynamic"
                                            Font-Size="18" Font-Bold="True"></asp:RequiredFieldValidator>

                                        <telerik:RadTextBox ID="txtEmail" runat="server" RenderMode="Lightweight"
                                            Label="Email:" Width="90%" />
                                        <asp:RequiredFieldValidator ControlToValidate="txtEmail" ID="RequiredFieldValidator2"  ValidationGroup="customerDetails" runat="server" 
                                            EnableClientScript="true" ForeColor="red" ErrorMessage="*" CssClass="validator" Display="Dynamic" 
                                            Font-Size="18" Font-Bold="True"></asp:RequiredFieldValidator>

                                        <telerik:RadTextBox ID="txtPhone" runat="server" RenderMode="Lightweight"
                                            Label="Phone:" Width="90%" />

                                        <telerik:RadComboBox ID="cmbCountryID" runat="server" RenderMode="Lightweight"
                                            Width="88%" Label="Country:" LabelCssClass="rdfLabel" EmptyMessage="Choose a Country...">
                                            <Items>
                                                <telerik:RadComboBoxItem Text="aaaa" />
                                                <telerik:RadComboBoxItem Text="aaaa" />
                                                <telerik:RadComboBoxItem Text="aaaa" />
                                            </Items>
                                        </telerik:RadComboBox>

                                        <telerik:RadTextBox ID="txtAddress" runat="server" RenderMode="Lightweight"
                                            Label="Address:" Width="90%" />
                                        <br />
                                        <telerik:RadTextBox ID="txtNote" runat="server" RenderMode="Lightweight"
                                            Label="Note:" TextMode="MultiLine" Rows="3" Width="90%" />
                                    </fieldset>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                    <fieldset class="fsRow">
                                        <legend class="rdfLegend rfdRoundedCorners "></legend>

                                        <telerik:RadTextBox ID="txtCreatedBy" runat="server" ReadOnly="true"
                                            RenderMode="Lightweight"
                                            Label="Created:" Width="90%" />
                                        <telerik:RadTextBox ID="txtCreatedDate" runat="server" ReadOnly="true"
                                            RenderMode="Lightweight"
                                            Label="Date:" Width="90%" />
                                        <telerik:RadTextBox ID="txtEditedBy" runat="server" ReadOnly="true"
                                            RenderMode="Lightweight"
                                            Label="Edited:" Width="90%" />
                                        <telerik:RadTextBox ID="txtEditedDate" runat="server" ReadOnly="true"
                                            RenderMode="Lightweight"
                                            Label="Date:" Width="90%" />

                                        <div style="height: 90px; display: block;"></div>
                                    </fieldset>
                                </div>
                                <div id="btnsEmp" class="btnsSubmit col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <fieldset class="fsRow" style="width: 300px !important;">
                                        <asp:Button ID="Btn_Save" runat="server" Text="Save" OnClick="Btn_Save_Click" CssClass="btn btn-success" CausesValidation="true"  ValidationGroup="customerDetails"/>
                                        <asp:Button ID="Btn_Cancel" runat="server" Text="Cancel" OnClick="Btn_Cancel_Click" CssClass="btn btn-danger" />
                                    </fieldset>
                                </div>
                        </telerik:RadPageView>
                    </telerik:RadMultiPage>
                </div>
            </fieldset>
        </div>
    </div>
</asp:Content>
