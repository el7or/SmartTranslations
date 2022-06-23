<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TranSmart.login" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        html, body, .styleFull {
            width: 100%;
            height: 100%;
            padding: 0px;
            margin: 0px;
        }

        .grad {
            background: white !important; /* For browsers that do not support gradients */
            background: -webkit-radial-gradient(circle, rgba(212, 9, 86, 0.9), rgba(136, 3, 102, 0.3), rgba(255, 200, 200, 0.01)) !important; /* Safari */
            background: -o-radial-gradient(circle, rgba(212, 9, 86, 0.9), rgba(136, 3, 102, 0.3), rgba(255, 200, 200, 0.01)) !important; /* Opera 11.6 to 12.0 */
            background: -moz-radial-gradient(circle, rgba(212, 9, 86, 0.9), rgba(136, 3, 102, 0.3), rgba(255, 200, 200, 0.01)) !important; /* Firefox 3.6 to 15 */
            background: radial-gradient(circle,white, gray, rgba(136, 3, 102, 0.3), rgba(111, 111, 111, 0.01)) !important; /* Standard syntax */
        }
    </style>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
</head>
<body>
    <form id="form1" runat="server" class="styleFull grad">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>


        <telerik:RadFormDecorator ID="RadFormDecorator2" runat="server"
            DecorationZoneID="zonesupport" DecoratedControls="All" PersistenceMode="Cookie" />
<%--background-image: url('/TranSmart/Content/Images/TranSmart2.png');--%>
        <table id="zonesupport" cellpadding="0" border="0" cellspacing="0" width="100%"
            style=" height: 100%">
            <tr>
                <td align="center">
                    <img src="Content/Images/logo.png" />
                    <div style="height: 50px"></div>
                    <fieldset style="width: 450px; height: 250px; vertical-align: middle;">
                        <legend style="font-size: 18px; font-weight: bold;">
                            <fieldset>
                                <img src="Content/Images/TranSmart0.png" width="200" />
                                <%--TranSmart--%>
                            </fieldset>

                        </legend>
                        <br />
                        <asp:Panel ID="Panel1" runat="server" DefaultButton="RadButton1">
                            <table width="450px">

                                <tr>
                                    <td>
                                        <telerik:RadTextBox ID="txtUser" runat="server" Label="User Name" Width="420px" LabelWidth="100px"
                                            ValidationGroup="vgsupport" Skin="MetroTouch">
                                        </telerik:RadTextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                            ControlToValidate="txtUser" ErrorMessage="*" Font-Bold="True" Font-Size="12pt"
                                            ForeColor="Red" ValidationGroup="vgsupport"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadTextBox ID="txtPassword" runat="server" LabelWidth="100px"
                                            Skin="MetroTouch" TextMode="Password" Label="Password"
                                            ValidationGroup="vgsupport" Width="420px">
                                        </telerik:RadTextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                            ControlToValidate="txtPassword" ErrorMessage="*" Font-Bold="True"
                                            Font-Size="12pt" ForeColor="Red" ValidationGroup="vgsupport"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top">
                                        <label>
                                            <asp:Label ID="lblError" runat="server" ForeColor="Red" Width="100%"></asp:Label>
                                        </label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <telerik:RadButton ID="RadButton1" runat="server"
                                            OnClick="btnContactSubmit_Click" Skin="MetroTouch" Style="margin-right: 16px;"
                                            Text="Login" ValidationGroup="vgsupport">
                                        </telerik:RadButton>
                                    </td>
                                </tr>

                            </table>
                        </asp:Panel>

                    </fieldset>
                </td>
            </tr>
        </table>

        <%--  <footer>
                <p>&copy; <%: DateTime.Now.Year %> - LinkMesr</p>
            </footer>
        </div>--%>
    </form>
</body>
</html>
