<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersPopup.aspx.cs" Inherits="TranSmart.UsersPopup" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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

</head>
<body onload="AdjustRadWidow();">
    <form id="Form2" method="post" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">
                function GetRadWindow() {
                    var oWindow = null;
                    if (window.radWindow) oWindow = window.radWindow;
                    else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
                    return oWindow;
                }

                //function openWin2() {
                //    var parentPage = GetRadWindow().BrowserWindow;
                //    var parentRadWindowManager = parentPage.GetRadWindowManager();
                //    window.setTimeout(function () {
                //        parentRadWindowManager.open("Dialog2.aspx", "RadWindow2");
                //    }, 0);
                //}

                //function populateCityName(arg) {
                //    var cityName = document.getElementById("cityName");
                //    cityName.value = arg;
                //}

                function AdjustRadWidow() {
                    var oWindow = GetRadWindow();
                    setTimeout(function () {
                        oWindow.autoSize(true);
                    }, 320);
                }
                function validateData() {
                    if (OK) {
                        return true;
                    } else {
                        return false;
                    }
                }
                function performCheck() {
                    Page_ClientValidate("user");
                    if (Page_IsValid) {
                        alert('it is valid');
                        return true;
                    }
                    else {
                        alert('No valid');
                        return false;
                    }
                }

                function returnToParent() {

                    //create the argument that will be returned to the parent page
                    var oArg = new Object();

                    //get the city's name            
                    oArg.UserName = document.getElementById("txtUserName").value;
                    oArg.Password = document.getElementById("txtPassword").value;
                    oArg.Confirm = document.getElementById("txtConfirm").value;

                    var chkActivated = $find("<%= chkActivated.ClientID %>");
            //alert(chkActivated.get_checked());alert(oArg.chkActivated);
            if (chkActivated.get_checked())
                oArg.chkActivated = "1";
            else
                oArg.chkActivated = "0";

            //get the selected date from RadDatePicker
            <%--var datePicker = $find("<%= Datepicker1.ClientID %>");
            oArg.selDate = datePicker.get_selectedDate().toLocaleDateString();--%>

            //get a reference to the current RadWindow
            var oWnd = GetRadWindow();

            //Close the RadWindow and send the argument to the parent page
            if (oArg.Confirm != oArg.Password) {
                validateData();
                //Page_ClientValidate("user");
                // alert("Password not matched!");
            }
            else if (!oArg.UserName || !oArg.Password) {
                // alert("Please fill all fields");
                //Page_ClientValidate("user");
                validateData();
            }
            else {
                oWnd.close(oArg);
            }
        }
            </script>
        </telerik:RadCodeBlock>
        <telerik:RadSkinManager ID="RadSkinManager1" runat="server" EnableViewState="False"
            PersistenceMode="Cookie" ViewStateMode="Disabled">
        </telerik:RadSkinManager>

        <telerik:RadFormDecorator RenderMode="Lightweight" ID="RadFormDecorator1" DecoratedControls="All" runat="server" />
        <div style="width: 350px; height: 190px;">
            <fieldset class="fsRow">
                <legend class="rdfLegend rfdRoundedCorners "></legend>
                <%--  <input type="text" style="width: 100px;" id="txtUserName" value="Sofia" />
                <input type="text" style="width: 100px;" id="txtPassword" value="Sofia" />
                <input type="text" style="width: 100px;" id="txtConfirm" value="Sofia" />--%>

                <telerik:RadTextBox ID="txtUserName" runat="server" RenderMode="Lightweight"
                    Width="300px" LabelWidth="140px" Label="User Name:" ValidationGroup="user" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                    ControlToValidate="txtUserName" ValidationGroup="user" ForeColor="Red"></asp:RequiredFieldValidator>

                <telerik:RadTextBox ID="txtPassword" runat="server" RenderMode="Lightweight"
                    Label="Password:" Width="300px" LabelWidth="140px" ValidationGroup="user" TextMode="Password" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="*" ControlToValidate="txtPassword" ValidationGroup="user"></asp:RequiredFieldValidator>

                <telerik:RadTextBox ID="txtConfirm" runat="server" RenderMode="Lightweight" TextMode="Password"
                    Label="Confirm Password:" Width="300px" LabelWidth="140px" ValidationGroup="user" />
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToCompare="txtConfirm" ControlToValidate="txtPassword" ValidationGroup="user"></asp:CompareValidator>

                <br />
                <telerik:RadCheckBox ID="chkActivated" runat="server" Text="Activated"
                    Checked="True" AutoPostBack="false">
                </telerik:RadCheckBox>

            </fieldset>
            <div style="margin-top: 4px; text-align: right; margin-right: 0px; padding-right: 0px; width: 100%;">
                <%--<telerik:RadButton ID="RadButton1" runat="server" Text="RadButton" ValidationGroup="user">
                </telerik:RadButton>--%>
                <%-- onClientClick="returnToParent();return false;"--%>
                <button title="Submit" id="close" onclick="returnToParent();return false; ">
                    Submit</button>
                <%--<asp:Button ID="Btn_Save" runat="server" Text="Save" CssClass="btn btn-success" ValidationGroup="user" />--%>
            </div>
        </div>
    </form>
</body>
</html>
