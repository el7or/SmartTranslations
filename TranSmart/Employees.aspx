<%@ Page Title="Staff" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="Employees.aspx.cs" Inherits="TranSmart.Employees" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <link href="Styles/mail.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="FolderContent" runat="Server">
    <telerik:RadCalendar runat="server" ID="RadCalendar1" Skin="Metro" EnableMultiSelect="false" DayNameFormat="FirstTwoLetters" 
        SelectedDate="09/01/2015"  ShowRowHeaders="false" Width="220px"></telerik:RadCalendar>
    <nav:FolderNavigationControl runat="server" ID="FolderNavigationControl" />
    <nav:MobileNavigation runat="server" ID="MobileNavigation"></nav:MobileNavigation>
</asp:Content>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--<telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>--%>
    <telerik:RadWindowManager ID="RadWindowManager1" ShowContentDuringLoad="false" VisibleStatusbar="false"
        ReloadOnShow="true" runat="server" EnableShadow="true">
        <Windows>
            <telerik:RadWindow ID="RadWindow1" runat="server" Behaviors="Close"
                OnClientClose="OnClientClose"
                NavigateUrl="UsersPopup.aspx">
            </telerik:RadWindow>
            <%-- OnClientAutoSizeEnd="autoSizeWithCalendar"--%>
            <%--<telerik:RadWindow RenderMode="Lightweight" ID="RadWindow2" runat="server" Width="650" Height="480" Modal="true" NavigateUrl="Dialog2.aspx">
            </telerik:RadWindow>--%>
        </Windows>
    </telerik:RadWindowManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManager1" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="grdEmpList" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadCodeBlock1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManager1" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdEmpList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManager1" UpdatePanelCssClass="" />
                    <telerik:AjaxUpdatedControl ControlID="grdEmpList" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <style>
            .RadGrid {
                border-radius: 10px;
                /*overflow: hidden;*/
            }

            .fsRow {
                display: inline-block !important;
                /*width: 385px !important;*/
                vertical-align: top !important;
                margin-top: 0px !important;
                margin-left: 5px !important;
                margin-right: 5px !important;
                padding: 10px !important;
                border-radius: 4px;
                border-radius: 10px;
            }

            .rdfLabel {
                width: 130px;
                vertical-align: middle;
            }

            .rdfRow {
                white-space: nowrap !important;
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

            /*legend fieldset {
                    background-color: white !important;
                }*/

            textarea {
                width: 100% !important;
            }

            button.RadCheckBox {
                display: inline-block !important;
                margin-right: 15px;
            }

                button.RadCheckBox span {
                    padding-left: 1.2em !important;
                }

            .div33 {
                width: 32% !important;
                padding: 0px;
                margin: 5px;
                margin-top: 10px;
                border-radius: 10px;
            }
        </style>
        <script type="text/javascript" lang="javascript">
            var empID;
            function popup_emp_login(arg) {
                console.log(arg);
                empID = arg;
                var ajaxManager = $find("<%= RadAjaxManager1.ClientID %>");
                //ajaxManager.ajaxRequest('popup_emp_login,' + arg);
                //var oWnd = radopen("UsersPopup.aspx?type=emp&id=" + arg, "RadWindow1");
                //var oWnd = GetRadWindowManager().open("UsersPopup.aspx?type=emp&id=" + arg, "RadWindow1");
                ////
                var oWnd = $find("<%=RadWindow1.ClientID%>");
                oWnd.setUrl("UsersPopup.aspx?type=emp&id=" + arg);
                oWnd.show();
                console.log(arg);
            }
            function OnClientClose(oWnd, args) {
                //get the transferred arguments
                var arg = args.get_argument();
                if (arg) {
                    //var UserName = arg.UserName;
                    //var Password = arg.Password;
                    var ajaxManager = $find("<%= RadAjaxManager1.ClientID %>");
                    ajaxManager.ajaxRequest('popup_emp_login,' + arg.UserName + ',' + arg.Password + ',' + arg.chkActivated + ',' + empID);
                    // $get("order").innerHTML = "You chose to fly to <strong>" + cityName + "</strong> on <strong>" + seldate + "</strong>";
                }
            }
            function autoSizeWithCalendar(oWindow) {
                console.log('autoSizeWithCalendar 0');
                var iframe = oWindow.get_contentFrame();
                var body = iframe.contentWindow.document.body;

                var height = body.scrollHeight;
                var width = body.scrollWidth;

                var iframeBounds = $telerik.getBounds(iframe);
                var heightDelta = height - iframeBounds.height;
                var widthDelta = width - iframeBounds.width;

                if (heightDelta > 0) oWindow.set_height(oWindow.get_height() + heightDelta);
                if (widthDelta > 0) oWindow.set_width(oWindow.get_width() + widthDelta);
                console.log('autoSizeWithCalendar 99');
                oWindow.center();
            }
            window.onclick = function (e) {
                // parent.close_combo();
                // console.log(e);
            }

        </script>
    </telerik:RadCodeBlock>
    <telerik:RadFormDecorator ID="RadFormDecorator2" RenderMode="Lightweight" runat="server"
        DecorationZoneID="zoneEmployee" DecoratedControls="All" />
    <div id="zoneEmployee" class="zoneEntity" style="width: 100% !important; padding: 0px; margin: 0px;">
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"></telerik:RadAjaxLoadingPanel>
        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 div33">
            <fieldset class="fsRow" style="width: 100% !important;">
                <legend class="rdfLegend rfdRoundedCorners ">
                    <fieldset style="padding: 8px; font-size: 16px; font-weight: 500;">Staff</fieldset>
                </legend>
                <telerik:RadGrid ID="grdEmpList" runat="server" AutoGenerateColumns="False"
                    OnDeleteCommand="grdEmpList_DeleteCommand" OnItemCommand="grdEmpList_ItemCommand"
                    OnItemDeleted="grdEmpList_ItemDeleted" Width="100%">
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
                                HeaderText="Staff" UniqueName="FullName">
                            </telerik:GridBoundColumn>
                            <telerik:GridHyperLinkColumn AllowSorting="False" FilterControlAltText="Filter Details column"
                                DataTextFormatString="<img src='Content/Images/app.png' width='20' height='20' border='0' alt='Details' title='Details' />" DataNavigateUrlFields="EmployeeID"
                                DataNavigateUrlFormatString="Employees.aspx?id={0}"
                                DataTextField="EmployeeID" UniqueName="Details" HeaderStyle-Width="48px">
                                <ItemStyle HorizontalAlign="Center" />
                            </telerik:GridHyperLinkColumn>
                            <telerik:GridHyperLinkColumn AllowSorting="False" FilterControlAltText="Filter login column"
                                DataTextFormatString="<img src='Content/Images/{0}.png' width='20' height='20' border='0' alt='login' title='login' />"
                                DataNavigateUrlFields="EmployeeID,StrHasLogin"
                                DataNavigateUrlFormatString="javascript:popup_emp_login('{0}');"
                                DataTextField="StrHasLogin" UniqueName="login" HeaderStyle-Width="48px">
                                <ItemStyle HorizontalAlign="Center" />
                            </telerik:GridHyperLinkColumn>
                            <telerik:GridButtonColumn ConfirmText="Delete this item?" ConfirmDialogType="RadWindow"
                                ConfirmTitle="Delete" ButtonType="FontIconButton" CommandName="Delete" HeaderStyle-Width="48px"
                                ItemStyle-HorizontalAlign="Center" />
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </fieldset>
        </div>
        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 div33">

            <fieldset class="fsRow">
                <legend class="rdfLegend rfdRoundedCorners ">
                    <fieldset style="padding: 8px; font-size: 16px; font-weight: 500;">Basic</fieldset>
                </legend>

                <telerik:RadTextBox ID="txtEmployeeID" runat="server" ReadOnly="true"
                    RenderMode="Lightweight" Visible="false"
                    Label="Staff ID" LabelWidth="130px" Width="100%" />

                <telerik:RadTextBox ID="txtFullName" runat="server" RenderMode="Lightweight"
                    Width="100%" Label="Full Name" LabelWidth="130px" />
                <asp:RequiredFieldValidator ControlToValidate="txtFullName" ID="RequiredFieldValidator2" runat="server"
                    EnableClientScript="true" ForeColor="red" ErrorMessage="*" CssClass="validator"
                    Display="Dynamic"></asp:RequiredFieldValidator>

                <telerik:RadComboBox ID="cmbRoleID" runat="server" RenderMode="Lightweight"
                    Width="100%" Label="Role" LabelCssClass="rdfLabel" EmptyMessage="Choose a Role...">
                    <Items>
                        <telerik:RadComboBoxItem Text="aaaa" />
                        <telerik:RadComboBoxItem Text="aaaa" />
                        <telerik:RadComboBoxItem Text="aaaa" />

                    </Items>
                </telerik:RadComboBox>
                <asp:RequiredFieldValidator ControlToValidate="cmbRoleID" ID="RequiredFieldValidator1" runat="server" EnableClientScript="true" ForeColor="red" ErrorMessage="*" CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>

                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="130px">
                            <asp:Label ID="lblJobStartDate" runat="server" AssociatedControlID="dtJobStartDate"
                                Width="130px" Text="Job Start"></asp:Label>
                        </td>
                        <td width="100%">
                            <telerik:RadDateTimePicker ID="dtJobStartDate" runat="server"
                                RenderMode="Lightweight" Culture="en-US" SkipMinMaxDateValidationOnServer="True"
                                Width="100%">
                                <TimeView CellSpacing="-1" RenderMode="Lightweight"></TimeView>
                                <TimePopupButton ImageUrl="" HoverImageUrl="" Visible="False"></TimePopupButton>
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;" RenderMode="Lightweight"></Calendar>
                                <DateInput DisplayDateFormat="yyyy/M/d" DateFormat="yyyy/M/d" SkipMinMaxDateValidationOnServer="True" LabelWidth="40%" RenderMode="Lightweight">
                                    <EmptyMessageStyle Resize="None"></EmptyMessageStyle>
                                    <ReadOnlyStyle Resize="None"></ReadOnlyStyle>
                                    <FocusedStyle Resize="None"></FocusedStyle>
                                    <DisabledStyle Resize="None"></DisabledStyle>
                                    <InvalidStyle Resize="None"></InvalidStyle>
                                    <HoveredStyle Resize="None"></HoveredStyle>
                                    <EnabledStyle Resize="None"></EnabledStyle>
                                </DateInput>
                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDateTimePicker>
                        </td>
                    </tr>
                </table>
                <asp:RequiredFieldValidator ControlToValidate="dtJobStartDate" ID="RequiredFieldValidator3" runat="server" EnableClientScript="true" ForeColor="red" ErrorMessage="*" CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>
                <%--<div class="rdfRow"> 
                </div>--%>

                <telerik:RadComboBox ID="cmbWorkMethodID" runat="server" RenderMode="Lightweight"
                    Label="Work Method" LabelCssClass="rdfLabel" Width="100%" EmptyMessage="Choose a Method...">
                    <Items>
                        <telerik:RadComboBoxItem Text="aaaa" />
                        <telerik:RadComboBoxItem Text="aaaa" />
                        <telerik:RadComboBoxItem Text="aaaa" />
                    </Items>
                </telerik:RadComboBox>
                <asp:RequiredFieldValidator ControlToValidate="cmbWorkMethodID" ID="RequiredFieldValidator4" runat="server" EnableClientScript="true" ForeColor="red" ErrorMessage="*" CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>
                <br />
                <telerik:RadLabel ID="RadLabel1" runat="server" AssociatedControlID="chkLanguages" Text="Languages" Width="130px"></telerik:RadLabel>
                <telerik:RadCheckBoxList ID="chkLanguages" runat="server" AutoPostBack="False"></telerik:RadCheckBoxList>

                <telerik:RadNumericTextBox ID="txtWordPrice" runat="server" DataType="System.Decimal"
                    NumberFormat-DecimalDigits="2"
                    RenderMode="Lightweight" ButtonsPosition="Left" ShowSpinButtons="True"
                    Label="Word Price" LabelWidth="130px" Width="100%" Type="Currency" />
                <asp:RequiredFieldValidator ControlToValidate="txtWordPrice" ID="RequiredFieldValidator6" runat="server"
                    EnableClientScript="true" ForeColor="red" ErrorMessage="*" CssClass="validator"
                    Display="Dynamic"></asp:RequiredFieldValidator>

                <telerik:RadNumericTextBox ID="txtBasicSalary" runat="server" DataType="Int16"
                    NumberFormat-DecimalDigits="0"
                    RenderMode="Lightweight" ButtonsPosition="Left" ShowSpinButtons="True"
                    Label="Basic Salary" LabelWidth="130px" Width="100%" Type="Currency" />


                <telerik:RadNumericTextBox ID="txtCommission" runat="server" RenderMode="Lightweight"
                    Label="Commission (%)" LabelWidth="130px" Width="100%" NumberFormat-DecimalDigits="2"
                    ButtonsPosition="Left" ShowSpinButtons="True" Type="Percent" />

                <telerik:RadTextBox ID="txtEmail" runat="server" RenderMode="Lightweight"
                    Label="Email" LabelWidth="130px" Width="100%" />
                <asp:RequiredFieldValidator ControlToValidate="txtEmail" ID="RequiredFieldValidator5" runat="server"
                    EnableClientScript="true" ForeColor="red" ErrorMessage="*" CssClass="validator"
                    Display="Dynamic"></asp:RequiredFieldValidator>

                <telerik:RadTextBox ID="txtPhone" runat="server" RenderMode="Lightweight"
                    Label="Phone" LabelWidth="130px" Width="100%" />

                <telerik:RadTextBox ID="txtAddress" runat="server" RenderMode="Lightweight"
                    Label="Address" TextMode="MultiLine" Resize="Vertical" Rows="5"
                    LabelWidth="130px" Width="100%" />
                <telerik:RadTextBox ID="txtNote" runat="server" RenderMode="Lightweight"
                    Label="Notes" TextMode="MultiLine" Resize="Vertical" Rows="5"
                    LabelWidth="130px" Width="100%" />
            </fieldset>
        </div>
        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 div33" style="margin: 0px; margin-top: 10px;">
            <fieldset class="fsRow">
                <legend class="rdfLegend rfdRoundedCorners ">
                    <fieldset style="padding: 8px; font-size: 16px; font-weight: 500;">Admin</fieldset>
                </legend>


                <telerik:RadCheckBox ID="chkActivated" runat="server" Text="Activate" AutoPostBack="false"></telerik:RadCheckBox>

                <telerik:RadTextBox ID="txtCreatedBy" runat="server" ReadOnly="true"
                    RenderMode="Lightweight"
                    Label="Created" LabelWidth="130px" Width="100%" />
                <telerik:RadTextBox ID="txtCreatedDate" runat="server" ReadOnly="true"
                    RenderMode="Lightweight"
                    Label="Date" LabelWidth="130px" Width="100%" />
                <telerik:RadTextBox ID="txtEditedBy" runat="server" ReadOnly="true"
                    RenderMode="Lightweight"
                    Label="Edited" LabelWidth="130px" Width="100%" />
                <telerik:RadTextBox ID="txtEditedDate" runat="server" ReadOnly="true"
                    RenderMode="Lightweight"
                    Label="Date" LabelWidth="130px" Width="100%" />

                <div style="height: 130px; display: block;"></div>
            </fieldset>

        </div>
        <div id="btnsEmp" class="btnsSubmit col-lg-4 col-md-4 col-sm-12 col-xs-12  div33" style="margin: 0px; margin-top: 10px;">

            <fieldset class="fsRow">
                <%--style="width: 500px !important;"--%>
                <asp:Button ID="Btn_Update" runat="server" Text="Update" OnClick="Btn_Update_Click" Visible="False" />
                <asp:Button ID="Btn_Add" runat="server" Text="New" OnClick="Btn_Add_Click" Visible="False" />
                <asp:Button ID="Btn_Save" runat="server" Text="Save" OnClick="Btn_Save_Click" />
            </fieldset>
        </div>
    </div>

</asp:Content>
