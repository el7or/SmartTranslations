<%@ Page Title="Payment Details" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PaymentDetails.aspx.cs" Inherits="TranSmart.PaymentDetails" %>


<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <link href="Styles/notes.css" rel="stylesheet" />
    <link href="css/sweetalert.css" rel="stylesheet" />
    <script src="js/sweetalert.min.js"></script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
        <style>
            .fsRow {
                display: inline-block !important;
                vertical-align: top !important;
                margin-top: 0px !important;
                margin-left: 5px !important;
                margin-right: 5px !important;
                padding: 30px !important;
                border-radius: 4px;
            }

            .rdfLabel {
                width: 90px;
                vertical-align: middle;
            }

            legend, .rdfLegend {
                margin-left: 20px !important;
                margin-right: 20px !important;
            }

            .demo-container {
                background-color: whitesmoke;
            }

            #demo .RadDataForm {
                position: relative;
                overflow: visible;
                width: 100%;
            }

            #demo .RadDataForm {
                padding-top: 62px;
            }

            #demo .rdfHeader {
                position: absolute;
                top: -5px;
                left: -16px;
                width: 110%;
                height: 79px;
                background: url('images/header.png') 0 0 no-repeat;
            }

            #demo .rdfHeaderInner {
                height: 63px;
                margin: 4px;
                font-size: 20px;
                line-height: 60px;
                padding-left: 20px;
                text-align: center;
                color: black;
                font-weight: bold;
            }

            #demo .rdfBorders {
                border-top: 0 none;
            }

            #demo .rdfBlock {
                display: block;
            }

            #demo .rdfFieldValue {
                font-size: 1.5em;
            }

            #demo .rdfHr {
                width: 220px !important;
                height: 1px;
            }

            * + html div.RadDataForm .rdfFieldset,
            * + html div.RadDataForm .rdfCommandButtons {
                width: auto;
            }

            .size-custom {
                max-width: 450px;
            }

            .rdfCommandButtons {
                text-align: center;
                padding-bottom: 20px;
            }

            html .demo-container .redColor {
                color: red;
            }

            /*Wizard wrapper*/
            #example .demo-container {
                width: 725px;
                margin: 40px auto 80px;
                padding: 0 80px;
                border: 0;
                background: url(Images/shadow.png) no-repeat 0 bottom;
            }

            .demo-container .wizardHeader {
                width: 100%;
                height: 50px;
            }

            /*Wizard*/
            .demo-container .RadWizard {
                padding: 20px;
                border: 1px solid #f1f1f1;
                border-bottom: 0;
                box-shadow: 0 0 0 1px #fff;
            }

            .background-black .demo-container .RadWizard,
            .background-blackmetrotouch .demo-container .RadWizard,
            .background-glow .demo-container .RadWizard,
            .background-office2010black .demo-container .RadWizard {
                border: 0;
                box-shadow: 0;
            }

            .demo-container .RadWizard_Material .rwzBreadCrumb .rwzText:before {
                display: none;
            }

            .demo-container .RadWizard_Material .rwzBreadCrumb .rwzLink {
                padding-left: 0;
            }

            /*Wizard content*/
            .demo-container .inputWapper {
                display: inline-block;
                *display: inline;
                position: relative;
                zoom: 1;
                font-size: 18px;
                width:50%;
            }

                .demo-container .inputWapper.first {
                    margin-right: 35px;
                }

                .demo-container .inputWapper label {
                    display: block;
                    margin: 5px 0 0;
                    text-align:left;
                }

            .demo-container .validator {
                color: #ff0000;
                top: 10px;
                right: 0;
            }

            .demo-container .conditions {
                display: block;
                color: #a7a7a7;
                font-size: 0.857em;
            }

            .demo-container .RadWizard .complete {
                height: auto;
                padding: 75px 0;
                text-align: center;
            }

            .rwzContent {
                height: auto !important;
            }

            textarea {
                width: 100% !important;
            }

            input[disabled=disabled] {
                opacity: 1 !important;
                background-color: whitesmoke !important;
            }

            h3 {
                padding: 0 15px;
            }

            .ruBrowse, .ruFakeInput {
                height: 30px !important;
            }
            .demo-container input {
                border-radius:0.28571429em;
            }
        </style>
        <script type="text/javascript" lang="javascript">
            function MyAlert() {
                //swal('Success!', 'Saved !', 'success');
                swal({
                    title: "Success!",
                    text: "Saved !",
                    type: "success",
                    timer: 3000,
                    showConfirmButton: false
                });
                window.location.href = "Payments.aspx";
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadFormDecorator ID="RadFormDecorator3" runat="server"
        DecorationZoneID="zonePaymentDetails" DecoratedControls="All" />
    <div id="zonePaymentDetails" class="zoneEntity" style="margin: 20px; text-align:center;">
        <fieldset class="fsRow" style="width: 100% !important; background-image: linear-gradient(#ebebeb,#fff);">
            <legend class="rdfLegend rfdRoundedCorners ">
                <fieldset style="padding: 8px; font-size: 20px; font-weight: 500;">New Transaction</fieldset>
            </legend>
            <div class="demo-container">
                <div class="row">
                    <div class="inputWapper">
                        <asp:Label Text="In/Out: *" runat="server" AssociatedControlID="ddlDirection" />
                        <telerik:RadComboBox RenderMode="Lightweight" ID="ddlDirection"
                            runat="server" Width="100%" EmptyMessage="Choose Direction ..">
                            <Items>
                                <telerik:RadComboBoxItem Text="" Value="" TabIndex="-1" Enabled="False" Selected="True" />
                                <telerik:RadComboBoxItem Text="In" Value="1" />
                                <telerik:RadComboBoxItem Text="Out" Value="0" />
                            </Items>
                        </telerik:RadComboBox>
                        <br />
                        <asp:RequiredFieldValidator ID="ddlDirectionRequiredFieldValidator" runat="server" ControlToValidate="ddlDirection" EnableClientScript="true" ValidationGroup="basicInfo" ForeColor="red" ErrorMessage="required field" CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="inputWapper">
                        <asp:Label Text="Cash money: *" runat="server" AssociatedControlID="txtCashPaid" />
                        <telerik:RadNumericTextBox ID="txtCashPaid" runat="server" DataType="Decimal"
                            NumberFormat-DecimalDigits="2"
                            RenderMode="Lightweight" ButtonsPosition="Left" ShowSpinButtons="True"
                            Width="100%" Type="Currency" Value="1" MinValue="1">
                        </telerik:RadNumericTextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="txtCashPaidRequiredFieldValidator" runat="server" ControlToValidate="txtCashPaid" EnableClientScript="true" ValidationGroup="basicInfo" ForeColor="red" ErrorMessage="required field" CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="inputWapper">
                        <asp:Label Text="Item Title: *" runat="server" AssociatedControlID="txtTitleItem" />
                        <telerik:RadTextBox RenderMode="Lightweight" ID="txtTitleItem" runat="server" ValidationGroup="basicInfo" Width="100%"></telerik:RadTextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="txtTitleItemRequiredFieldValidator" runat="server" ControlToValidate="txtTitleItem" EnableClientScript="true" ValidationGroup="basicInfo" ForeColor="red" ErrorMessage="required field" CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>
                        <%--<span class="conditions">Minimum 4 characters, maximum 15 characters.</span>--%>
                    </div>
                </div>
                <div class="row">
                    <div class="inputWapper">
                        <asp:Label Text="Description:" runat="server" AssociatedControlID="txtNote" />
                        <telerik:RadTextBox ID="txtNote" runat="server" Resize="Vertical" TextMode="MultiLine" Rows="3" Width="100%"></telerik:RadTextBox>
                    </div>
                </div>
            </div>
            <fieldset class="fsRow" style="width: 300px; margin-top:20px !important">
                <asp:Button ID="Btn_Save" runat="server" Text="Save" OnClick="Btn_Save_Click" CssClass="btn btn-success" CausesValidation="true" ValidationGroup="basicInfo" Font-Size="Large" />
                <asp:Button ID="Btn_Cancel" runat="server" Text="Cancel" OnClick="Btn_Cancel_Click" CssClass="btn btn-danger" Font-Size="Large" />
            </fieldset>
        </fieldset>
    </div>
</asp:Content>
