<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TranSmart.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
            </Scripts>
        </telerik:RadScriptManager>

        <div>
            <table>
                <tr>
                    <td valign="top">
                        <telerik:RadComboBox ID="cbSite" runat="server" EmptyMessage="Select" Height="200" Width="200" ValidationGroup="cbSiteValidate">
                            <Items>
                                <telerik:RadComboBoxItem Text="Item1" />
                                <telerik:RadComboBoxItem Text="Item2" />
                            </Items>
                        </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="cbSite" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="cbSiteValidate">
                        </asp:RequiredFieldValidator>


                        <br />
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TextBox1" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="cbSiteValidate">
                        </asp:RequiredFieldValidator>

                        <br />
                        <asp:Button ID="test" runat="server" Text="test" ValidationGroup="cbSiteValidate" />
                    </td>
                    <td style="text-align: left"></td>
                    <td valign="bottom">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="cbSiteValidate" />
                    </td>
                </tr>
            </table>



                 <telerik:RadTabStrip runat="server" ID="RadTabStrip1" MultiPageID="RadMultiPage1" SelectedIndex="0"
                       RenderMode="Lightweight"   CausesValidation="False">
                        <Tabs>
                            <telerik:RadTab Text="Clients list" Width="200px" Selected="True" ></telerik:RadTab>
                            <telerik:RadTab Text="Add new Client" Width="200px"></telerik:RadTab>
                        </Tabs>
                    </telerik:RadTabStrip>
                    <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" CssClass="outerMultiPage">
                        <telerik:RadPageView runat="server" ID="RadPageView1">
                            <div class="ingredients qsf-ib">
                                
                                Clients data grid
                            </div>
                        </telerik:RadPageView>
                        <telerik:RadPageView runat="server" ID="RadPageView2">                               
                                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                    <fieldset class="fsRow">
                                        <legend class="rdfLegend rfdRoundedCorners "></legend>

                                        <telerik:RadTextBox ID="txtCustomerID" runat="server" ReadOnly="true"
                                            RenderMode="Lightweight" Label="Client ID" Visible="False" />

                                        <telerik:RadTextBox ID="txtCustomerName" runat="server" 
                                            Width="90%" Label="Full Name:" ValidationGroup="customerDetails"  AutoPostBack="False" ClientIDMode="Static" />
                                        <asp:RequiredFieldValidator ControlToValidate="txtCustomerName"  ValidationGroup="customerDetails" ID="RequiredFieldValidator3" runat="server" ForeColor="red" ErrorMessage="required field" CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>

                                        <telerik:RadComboBox ID="cmbTypeID" runat="server" RenderMode="Lightweight"
                                            Width="88%" Label="Client Type:" LabelCssClass="rdfLabel" EmptyMessage="Choose a Type...">
                                            <Items>
                                                <telerik:RadComboBoxItem Text="aaaa" />
                                                <telerik:RadComboBoxItem Text="aaaa" />
                                                <telerik:RadComboBoxItem Text="aaaa" />
                                            </Items>
                                        </telerik:RadComboBox>
                                        <asp:RequiredFieldValidator ControlToValidate="cmbTypeID" ValidationGroup="customerDetails" ID="RequiredFieldValidator4" runat="server" EnableClientScript="true" ForeColor="red" ErrorMessage="required field" CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>

                                        <telerik:RadTextBox ID="txtEmail" runat="server" RenderMode="Lightweight"
                                            Label="Email:" Width="90%" />
                                        <asp:RequiredFieldValidator ControlToValidate="txtEmail" ID="RequiredFieldValidator5" runat="server" EnableClientScript="true" ForeColor="red" ErrorMessage="required field" CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>

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
                                
                                <div id="btnsEmp" class="btnsSubmit col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <fieldset class="fsRow" style="width: 300px !important;">
                                        <asp:Button ID="Btn_Save" runat="server" Text="Save"   CssClass="btn btn-success" CausesValidation="true"  ValidationGroup="customerDetails"/>
                                        <asp:Button ID="Btn_Cancel" runat="server" Text="Cancel"  CssClass="btn btn-danger" />
                                    </fieldset>
                                </div>
                        </telerik:RadPageView>
                    </telerik:RadMultiPage>

        </div>
    </form>
</body>
</html>
