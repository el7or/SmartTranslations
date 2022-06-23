<%@ Page Title="Project Details" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind=".aspx.cs" Inherits="TranSmart.ProjectDetails" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <link href="Styles/mail.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="js/sweetalert.min.js"></script>
    <link href="css/sweetalert.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server"  ></telerik:RadAjaxPanel>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default"></telerik:RadAjaxLoadingPanel>--%>

    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManager1" />
                    <telerik:AjaxUpdatedControl ControlID="lblMsgBody" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnSendOffer">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManager1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
        <ClientEvents OnResponseEnd="responseEnd" OnRequestStart="requestStart" />
    </telerik:RadAjaxManager>

    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
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
            }

                .demo-container .inputWapper.first {
                    margin-right: 35px;
                }

                .demo-container .inputWapper label {
                    display: block;
                    margin: 5px 0 0;
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
        </style>
        <script type="text/javascript" lang="javascript">
            // check if new project or not
            function checkQueryString(field) {
                var url = window.location.href;
                if (url.indexOf('?' + field + '=') != -1)
                    return true;
                else if (url.indexOf('&' + field + '=') != -1)
                    return true;
                return false
            } 
            function responseEnd(sender, eventArgs) {
                console.log('Response end initiated by: ' + eventArgs.get_eventTarget());
                if (eventArgs.get_eventTarget().includes("RadAjaxManager1")) {
                    divBody.style.display = 'inherit';
                    divLoading_doc.style.display = 'none';
                }
                else if (eventArgs.get_eventTarget().includes("btnSendOffer")) {
                    
                    swal.close();
                }
            }

            function requestStart(sender, eventArgs) {
                console.log('Request start initiated by: ' + eventArgs.get_eventTarget());
                if (eventArgs.get_eventTarget().includes("RadAjaxManager1")) {
                    divBody.style.display = 'none';
                    divLoading_doc.style.display = 'inherit';
                }
                else if (eventArgs.get_eventTarget().includes("btnSendOffer")) {
                    swal({
                        title: "Sending ... ",
                        text: "Please wait !",

                        imageUrl: "Content/Images/sending.gif",
                        showConfirmButton: false
                    });
                    //<img src="Content/Images/sending.gif" />type: "info",
                    //if (swalll != null) swalll.close();
                }
            }
            function AlertDone(msg) {
                try {
                    //swal('Success!', 'Saved !', 'success');
                    setTimeout(function () {
                        swal({
                            title: "Success!",
                            text: msg,
                            type: "success",
                            timer: 3000,
                            showConfirmButton: false
                        });
                    }, 500);
                }
                catch (e) {
                    console.log(e);
                }
                //window.location.href = "Payments.aspx";
            }
            function AlertErr(msg) {
                try {
                    //swal('Success!', 'Saved !', 'success');
                    setTimeout(function () {
                        swal({
                            title: "Error!",
                            text: msg,
                            type: "warning",
                            timer: 3000,
                            showConfirmButton: false
                        });
                    }, 500);
                }
                catch (e) {
                    console.log(e);
                }
                //window.location.href = "Payments.aspx";
            }
            var OfferUsername = '';//[RECEPIENT.NAME]
            var OfferMessage = '';// [MESSAGE]
            // inputs validations
            (function () {
                window.pageLoad = function () {
                    var $ = $telerik.$;
                    var cssSelectors = ["basicInfo", "FinanceInfo", "FilesInfo", "confirmation"];
                    var breadCrumbButtons = $(".rwzBreadCrumb .rwzLI");

                    for (var i = 0; i < cssSelectors.length; i++) {
                        $(breadCrumbButtons[i]).addClass(cssSelectors[i]);
                    }
                }

                window.OnClientLoad = function (sender, args) {
                    for (var i = 1; i < sender.get_wizardSteps().get_count(); i++) {
                        sender.get_wizardSteps().getWizardStep(i).set_enabled(checkQueryString('projid'));
                    }
                    sumTotals();
                }

                window.OnClientButtonClicking = function (sender, args) {
                    if (!args.get_nextActiveStep().get_enabled()) {
                        args.get_nextActiveStep().set_enabled(true);
                    }
                    console.log(args.get_nextActiveStep());
                    console.log(sender.get_activeWizardStep());
                    //SetOfferValues();
                    try {
                        var ajaxManager = $find("<%= RadAjaxManager1.ClientID %>");
                        ajaxManager.ajaxRequest(args.get_nextActiveStep()._index);

                    }
                    catch (e) {
                        console.log(e);
                    }
                }

                function SetOfferValues() {
                    var combo = $find("<%= ddlCustomerProject.ClientID %>");
                    //var item = combo.findItemByText(text);
                    //var title = 'Translation Offer';//[TITLE]
                    var OfferUsername = combo.get_text();// '';//[RECEPIENT.NAME]
                    var OfferMessage = 'test test';// [MESSAGE]
                    //var ButtonText = '';// [BUTTON.TEXT]
                    //var LinkText = '';//[LINK.TEXT]
                    //var elMyElement =  $find("<%= lblMsgBody.ClientID %>");
                    lblOffer_RECEPIENT_NAME.innerHTML = 'Mr. ' + OfferUsername;
                    lblOffer_MESSAGE.innerHTML = 'Test Message Body for ' + OfferUsername;
                    //divlblMsgBody.innerHTML = divlblMsgBody.innerHTML.replace('[RECEPIENT.NAME]', OfferUsername);


                }

                window.AcceptTermsCheckBoxValidation = function (source, args) {
                    var termsChecked = $telerik.$("input[id*='AcceptTermsCheckBox']")[0].checked;
                    args.IsValid = termsChecked;
                }

                window.UserNameLenghthValidation = function (source, args) {
                    var userNameConditions = $telerik.$(".conditions")[0];
                    var isValid = (args.Value.length >= 4 && args.Value.length <= 15);
                    args.IsValid = isValid;
                    $telerik.$(userNameConditions).toggleClass("redColor", !isValid);

                }

                window.PasswordLenghthValidation = function (source, args) {
                    var passwordConditions = $telerik.$(".conditions")[1];
                    var isValid = args.Value.length >= 6;
                    args.IsValid = isValid;
                    $telerik.$(passwordConditions).toggleClass("redColor", !isValid);
                }
            })();

            // calculate invoice
            var sumTotals = function () {
                var wordCount = parseFloat($get("<%= txtWordCount.ClientID %>").value);
                var wordPrice = parseFloat($get("<%= txtWordPrice.ClientID %>").value);
                var discount = parseFloat($get("<%= txtDiscount.ClientID %>").value);
                var vatValue = parseFloat($get("<%= txtVatValue.ClientID %>").value);
                var prevPaid = parseFloat($get("<%= txtPrevPay.ClientID %>").value);
                var currentPaid = parseFloat($get("<%= txtCurrentPay.ClientID %>").value);
                var netTotal = $find('<%=txtNetTotal.ClientID %>');
                var grossTotal = $find('<%=txtGrossTotal.ClientID %>');
                var duePayment = $find('<%=txtDuePay.ClientID %>');
                if (wordCount == "" || wordPrice == "") {
                    netTotal.set_value(0.00);
                }
                else {
                    netTotal.set_value(wordCount * wordPrice);
                    discount = ((wordCount * wordPrice) * discount) / 100;
                    grossTotal.set_value((wordCount * wordPrice) - discount + vatValue);
                    duePayment.set_value(((wordCount * wordPrice) - discount + vatValue) - prevPaid - currentPaid);
                }
            };
            $(function () {
                $('#ctl00_MainContent_txtWordCount, #ctl00_MainContent_txtWordPrice, #ctl00_MainContent_txtDiscount, #ctl00_MainContent_txtVatValue, #ctl00_MainContent_txtCurrentPay')
                    .on('change keyup keypress blur focus', sumTotals);
            });

            // load project status
            $(document).ready(function () {
                var projState = $('#MainContent_hfStatusHeader').val();
                if (projState == "CustomerRequest" || projState == "OfferSent" || projState == "CustomerApproved" || projState == "New") {
                    $('#statusHeader').attr('class', 'btn-block btn-lg btn-primary');
                    $('#statusHeaderIcon').attr('class', 'glyphicon glyphicon-hand-right');
                    $('#statusHeaderTxt').text('New');
                }
                else if (projState == 'UnderProgress') {
                    $('#statusHeader').attr('class', 'btn-block btn-lg btn-warning');
                    $('#statusHeaderIcon').attr('class', 'glyphicon glyphicon-hand-down');
                    $('#statusHeaderTxt').text('Under Progress');
                }
                else if (projState == 'Completed' || projState == 'ProjectDelivered') {
                    $('#statusHeader').attr('class', 'btn-block btn-lg btn-success');
                    $('#statusHeaderIcon').attr('class', 'glyphicon glyphicon-thumbs-up');
                    $('#statusHeaderTxt').text('Completed');
                }
                else if (projState == 'ProjectCanceled') {
                    $('#statusHeader').attr('class', 'btn-block btn-lg btn-danger');
                    $('#statusHeaderIcon').attr('class', 'glyphicon glyphicon-ban-circle');
                    $('#statusHeaderTxt').text('Canceled');
                }

                if ($('#MainContent_hfIsCustomerRequest').val() == "") {
                    $('#customerRequestHead').attr('class', 'list-group-item list-group-item-danger');
                    $('#customerRequestIcon').attr('class', 'glyphicon glyphicon-minus');
                }
                else {
                    $('#customerRequestHead').attr('class', 'list-group-item list-group-item-success');
                    $('#customerRequestIcon').attr('class', 'glyphicon glyphicon-ok');
                }
                if ($('#MainContent_hfIsOfferSent').val() == "") {
                    $('#offerSentHead').attr('class', 'list-group-item list-group-item-danger');
                    $('#offerSentIcon').attr('class', 'glyphicon glyphicon-minus');
                }
                else {
                    $('#offerSentHead').attr('class', 'list-group-item list-group-item-success');
                    $('#offerSentIcon').attr('class', 'glyphicon glyphicon-ok');
                }
                if ($('#MainContent_hfIsCustomerApproved').val() == "") {
                    $('#customerApprovedHead').attr('class', 'list-group-item list-group-item-danger');
                    $('#customerApprovedIcon').attr('class', 'glyphicon glyphicon-minus');
                }
                else {
                    $('#customerApprovedHead').attr('class', 'list-group-item list-group-item-success');
                    $('#customerApprovedIcon').attr('class', 'glyphicon glyphicon-ok');
                }
                if ($('#MainContent_hfIsTasksSent').val() == "") {
                    $('#tasksSentHead').attr('class', 'list-group-item list-group-item-danger');
                    $('#tasksSentIcon').attr('class', 'glyphicon glyphicon-minus');
                }
                else {
                    $('#tasksSentHead').attr('class', 'list-group-item list-group-item-success');
                    $('#tasksSentIcon').attr('class', 'glyphicon glyphicon-ok');
                }
                if ($('#MainContent_hfIsTasksInProgress').val() == "") {
                    $('#tasksInProgressHead').attr('class', 'list-group-item list-group-item-danger');
                    $('#tasksInProgressIcon').attr('class', 'glyphicon glyphicon-minus');
                }
                else {
                    $('#tasksInProgressHead').attr('class', 'list-group-item list-group-item-success');
                    $('#tasksInProgressIcon').attr('class', 'glyphicon glyphicon-ok');
                }
                if ($('#MainContent_hfIsTasksDone').val() == "") {
                    $('#tasksDoneHead').attr('class', 'list-group-item list-group-item-danger');
                    $('#tasksDoneIcon').attr('class', 'glyphicon glyphicon-minus');
                }
                else {
                    $('#tasksDoneHead').attr('class', 'list-group-item list-group-item-success');
                    $('#tasksDoneIcon').attr('class', 'glyphicon glyphicon-ok');
                }
                if ($('#MainContent_hfIsProjectDelivered').val() == "") {
                    $('#projectDeliveredHead').attr('class', 'list-group-item list-group-item-danger');
                    $('#projectDeliveredIcon').attr('class', 'glyphicon glyphicon-minus');
                }
                else {
                    $('#projectDeliveredHead').attr('class', 'list-group-item list-group-item-success');
                    $('#projectDeliveredIcon').attr('class', 'glyphicon glyphicon-ok');
                }
            });

            //RadConfirm
            function RadConfirm(sender, args) {
                var callBackFunction = function (shouldSubmit) {
                    if (shouldSubmit) {
                        //initiate the original postback again
                        sender.click();
                        if (Telerik.Web.Browser.ff) { //work around a FireFox issue with form submission, see http://www.telerik.com/support/kb/aspnet-ajax/window/details/form-will-not-submit-after-radconfirm-in-firefox
                            sender.get_element().click();
                        }
                    }
                };

                var text = "Are you sure you want to Cancel this project?";
                radconfirm(text, callBackFunction, 250, 150, null, "Cancel !");
                //always prevent the original postback so the RadConfirm can work, it will be initiated again with code in the callback function
                args.set_cancel(true);
            }

            function RadConfirm2(sender, args) {
                var callBackFunction = function (shouldSubmit) {
                    if (shouldSubmit) {
                        //initiate the original postback again
                        sender.click();
                        if (Telerik.Web.Browser.ff) { //work around a FireFox issue with form submission, see http://www.telerik.com/support/kb/aspnet-ajax/window/details/form-will-not-submit-after-radconfirm-in-firefox
                            sender.get_element().click();
                        }
                    }
                };

                var text = "Are you sure you want to Re-Activate this project?";
                radconfirm(text, callBackFunction, 250, 150, null, "Re-Activate !");
                //always prevent the original postback so the RadConfirm can work, it will be initiated again with code in the callback function
                args.set_cancel(true);
            }

            // validation of comparing languages
            var langgFrom, langgTo;
            function OnClientSelectedLanggFrom(sender, eventArgs) {
                var item = eventArgs.get_item();
                langgFrom = item.get_text();
                if (langgFrom == langgTo) {
                    $('#lblCompareLangg').show();
                }
                else { $('#lblCompareLangg').hide(); }
            }
            function OnClientSelectedLanggTo(sender, eventArgs) {
                var item = eventArgs.get_item();
                langgTo = item.get_text();
                if (langgFrom == langgTo) {
                    $('#lblCompareLangg').show();
                }
                else { $('#lblCompareLangg').hide(); }
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadFormDecorator ID="RadFormDecorator3" runat="server"
        DecorationZoneID="zoneProjDetails" DecoratedControls="All" />
    <div id="zoneProjDetails" class="zoneEntity" style="margin: 20px;">
        <fieldset class="fsRow" style="width: 100% !important; background-image: linear-gradient(#ebebeb,#fff);">
            <legend class="rdfLegend rfdRoundedCorners ">
                <fieldset style="padding: 8px; font-size: 16px; font-weight: 500;">Project Details</fieldset>
            </legend>
            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                <div class="demo-container">
                    <div class="wizardHeader">
                        <h1>
                            <asp:Label ID="lblProjSerial" runat="server"></asp:Label></h1>
                    </div>
                    <%-- OnNextButtonClick="RadWizard1_NextButtonClick" --%>
                    <telerik:RadWizard RenderMode="Lightweight" ID="RadWizard1" runat="server" OnClientLoad="OnClientLoad"
                        OnClientButtonClicking="OnClientButtonClicking"
                        OnFinishButtonClick="RadWizard1_FinishButtonClick"
                        Localization-Finish="Save">
                        <WizardSteps>
                            <telerik:RadWizardStep ID="stepBasic" Title="Basic Data" runat="server" StepType="Start" ValidationGroup="basicInfo" CausesValidation="true" SpriteCssClass="basicInfo" Enabled="True">
                                <div class="row">
                                    <div class="inputWapper col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                        <asp:Label Text="Project Title: *" runat="server" AssociatedControlID="txtTitleProject" />
                                        <telerik:RadTextBox RenderMode="Lightweight" ID="txtTitleProject" runat="server" ValidationGroup="basicInfo" Width="100%"></telerik:RadTextBox>
                                        <br />
                                        <asp:RequiredFieldValidator ID="txtTitleProjectRequiredFieldValidator" runat="server" ControlToValidate="txtTitleProject" EnableClientScript="true" ValidationGroup="basicInfo" ForeColor="red" ErrorMessage="required field" CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <%--<span class="conditions">Minimum 4 characters, maximum 15 characters.</span>--%>
                                    </div>
                                    <div class="inputWapper col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                        <asp:Label Text="Source: *" runat="server" AssociatedControlID="ddlFromLangg" />
                                        <telerik:RadComboBox RenderMode="Lightweight" ID="ddlFromLangg" OnClientSelectedIndexChanged="OnClientSelectedLanggFrom"
                                            runat="server" Width="100%" EmptyMessage="Choose language ..">
                                            <Items>
                                                <telerik:RadComboBoxItem Text="" Value="" TabIndex="-1" Enabled="False" Selected="True" />
                                                <telerik:RadComboBoxItem Text="EN" Value="1" />
                                                <telerik:RadComboBoxItem Text="AR" Value="2" />
                                                <telerik:RadComboBoxItem Text="FR" Value="3" />
                                            </Items>
                                        </telerik:RadComboBox>
                                        <br />
                                        <asp:RequiredFieldValidator ID="ddlFromLanggRequiredFieldValidator" runat="server" ControlToValidate="ddlFromLangg" EnableClientScript="true" ValidationGroup="basicInfo" ForeColor="red" ErrorMessage="required field" CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="inputWapper col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                        <asp:Label Text="Target:" runat="server" AssociatedControlID="ddlToLangg" />
                                        <telerik:RadComboBox RenderMode="Lightweight" ID="ddlToLangg" OnClientSelectedIndexChanged="OnClientSelectedLanggTo"
                                            runat="server" Width="100%" EmptyMessage="Choose language ..">
                                            <Items>
                                                <telerik:RadComboBoxItem Text="" Value="" TabIndex="-1" Enabled="False" Selected="True" />
                                                <telerik:RadComboBoxItem Text="EN" Value="1" />
                                                <telerik:RadComboBoxItem Text="AR" Value="2" />
                                                <telerik:RadComboBoxItem Text="FR" Value="3" />
                                            </Items>
                                        </telerik:RadComboBox>
                                        <br />
                                        <label id="lblCompareLangg" style="color: red; display: none;">choose another language!</label>
                                        <asp:RequiredFieldValidator ID="ddlToLanggRequiredFieldValidator" runat="server" ControlToValidate="ddlToLangg" EnableClientScript="true" ValidationGroup="basicInfo" ForeColor="red" ErrorMessage="required field" CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="inputWapper col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                        <asp:Label Text="Client: *" runat="server" AssociatedControlID="ddlCustomerProject" />
                                        <telerik:RadComboBox RenderMode="Lightweight" ID="ddlCustomerProject"
                                            runat="server" Width="100%" EmptyMessage="Choose Customer ..">
                                            <Items>
                                                <telerik:RadComboBoxItem Text="" Value="" TabIndex="-1" Enabled="False" Selected="True" />
                                                <telerik:RadComboBoxItem Text="Ali Sayed" Value="1" />
                                                <telerik:RadComboBoxItem Text="Mohamed Hamdy" Value="2" />
                                                <telerik:RadComboBoxItem Text="Egy Inc." Value="3" />
                                            </Items>
                                        </telerik:RadComboBox>
                                        <br />
                                        <asp:RequiredFieldValidator ID="ddlCustomerProjectRequiredFieldValidator" runat="server" ControlToValidate="ddlCustomerProject" EnableClientScript="true" ValidationGroup="basicInfo" ForeColor="red" ErrorMessage="required field" CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="inputWapper col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                        <asp:Label Text="Date: *" runat="server" AssociatedControlID="dtRequestCustomer" />
                                        <telerik:RadDateTimePicker ID="dtRequestCustomer" runat="server"
                                            RenderMode="Lightweight" Culture="en-US" SkipMinMaxDateValidationOnServer="True"
                                            Width="100%" OnSelectedDateChanged="dtRequestCustomer_SelectedDateChanged" AutoPostBackControl="Both">
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
                                        <br />
                                        <asp:RequiredFieldValidator ID="dtRequestCustomerRequiredFieldValidator" runat="server" ControlToValidate="dtRequestCustomer" EnableClientScript="true" ValidationGroup="basicInfo" ForeColor="red" ErrorMessage="required field" CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="inputWapper col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                        <asp:Label Text="Quotation Sent:" runat="server" AssociatedControlID="txtOfferSent" Font-Bold="True" />
                                        <telerik:RadTextBox ID="txtOfferSent" runat="server" Font-Bold="true"
                                            RenderMode="Lightweight" Width="100%" Enabled="false" BorderStyle="Outset">
                                        </telerik:RadTextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="inputWapper col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                        <asp:Label Text="Client Approved At:" runat="server" AssociatedControlID="txtCustomerApproved" Font-Bold="True" />
                                        <telerik:RadTextBox ID="txtCustomerApproved" runat="server" Font-Bold="true"
                                            RenderMode="Lightweight" Width="100%" Enabled="false" BorderStyle="Outset">
                                        </telerik:RadTextBox>
                                    </div>
                                    <div class="inputWapper col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                        <asp:Label Text="Deadline: *" runat="server" AssociatedControlID="dtPromiseCustomer" />
                                        <telerik:RadDateTimePicker ID="dtPromiseCustomer" runat="server"
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
                                        <br />
                                        <asp:RequiredFieldValidator ID="dtPromiseCustomerRequiredFieldValidator" runat="server" ControlToValidate="dtPromiseCustomer" EnableClientScript="true" ValidationGroup="basicInfo" ForeColor="red" ErrorMessage="required field" CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="inputWapper col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                        <asp:Label Text="Actual Delivery Date:" runat="server" AssociatedControlID="txtDeliveredDate" Font-Bold="True" />
                                        <telerik:RadTextBox ID="txtDeliveredDate" runat="server" Font-Bold="true"
                                            RenderMode="Lightweight" Width="100%" Enabled="false" BorderStyle="Outset">
                                        </telerik:RadTextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="inputWapper col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <asp:Label Text="Delivery:" runat="server" AssociatedControlID="txtDelivery" />
                                        <telerik:RadTextBox ID="txtDelivery" runat="server" TextMode="MultiLine" Rows="2" Width="100%"
                                            Text="20 days from the date of confirmation to proceed.">
                                        </telerik:RadTextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="inputWapper col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <asp:Label Text="Payment Method:" runat="server" AssociatedControlID="txtPaymentMethod" />
                                        <telerik:RadTextBox ID="txtPaymentMethod" runat="server" TextMode="MultiLine" Rows="2" Width="100%"
                                            Text="%50 down payment , Bank transfer / Cash / Cheque">
                                        </telerik:RadTextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="inputWapper col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <asp:Label Text="Notes:" runat="server" AssociatedControlID="txtNoteProject" />
                                        <telerik:RadTextBox ID="txtNoteProject" runat="server" TextMode="MultiLine" Rows="3" Width="100%"></telerik:RadTextBox>
                                    </div>
                                </div>
                            </telerik:RadWizardStep>

                            <telerik:RadWizardStep ID="stepFinance" Title="Finance" runat="server" StepType="Step" ValidationGroup="FinanceInfo" SpriteCssClass="FinanceInfo" Active="False" Enabled="True">
                                <div class="row">
                                    <div class="inputWapper col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                        <asp:Label Text="Word Count: *" runat="server" AssociatedControlID="txtWordCount" />
                                        <telerik:RadNumericTextBox ID="txtWordCount" runat="server" DataType="Decimal"
                                            NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator=""
                                            RenderMode="Lightweight" ButtonsPosition="Left" ShowSpinButtons="True"
                                            Width="100%" Type="Number" Value="1" MinValue="1">
                                        </telerik:RadNumericTextBox>
                                        <br />
                                        <asp:RequiredFieldValidator ID="txtWordCountRequiredFieldValidator" runat="server" ControlToValidate="txtWordCount" EnableClientScript="true" ValidationGroup="FinanceInfo" ForeColor="red" ErrorMessage="required field" CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="inputWapper col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                        <asp:Label Text="Word Price: *" runat="server" AssociatedControlID="txtWordPrice" />
                                        <telerik:RadNumericTextBox ID="txtWordPrice" runat="server" DataType="Decimal"
                                            NumberFormat-DecimalDigits="2" NumberFormat-GroupSeparator=""
                                            RenderMode="Lightweight" ButtonsPosition="Left" ShowSpinButtons="True"
                                            Width="100%" Type="Currency" Value="0" MinValue="0">
                                        </telerik:RadNumericTextBox>
                                        <br />
                                        <asp:RequiredFieldValidator ID="txtWordPriceRequiredFieldValidator" runat="server" ControlToValidate="txtWordPrice" EnableClientScript="true" ValidationGroup="FinanceInfo" ForeColor="red" ErrorMessage="required field" CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="inputWapper col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                        <asp:Label Text="Net Total:" runat="server" AssociatedControlID="txtNetTotal" Font-Bold="True" />
                                        <telerik:RadNumericTextBox ID="txtNetTotal" runat="server" DataType="Decimal"
                                            NumberFormat-DecimalDigits="2" Font-Bold="true" NumberFormat-GroupSeparator=""
                                            RenderMode="Lightweight" Width="100%" Type="Currency" Value="0" MinValue="0" Enabled="false" BorderStyle="Outset">
                                        </telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="inputWapper col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                        <asp:Label Text="Discount:" runat="server" AssociatedControlID="txtDiscount" />
                                        <telerik:RadNumericTextBox ID="txtDiscount" runat="server" DataType="Int32"
                                            NumberFormat-DecimalDigits="1" NumberFormat-GroupSeparator=""
                                            RenderMode="Lightweight" ButtonsPosition="Left" ShowSpinButtons="True"
                                            Width="100%" Type="Percent" Value="0" MinValue="0">
                                        </telerik:RadNumericTextBox>
                                    </div>
                                    <div class="inputWapper col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                        <asp:Label Text="VAT:" runat="server" AssociatedControlID="txtVatValue" />
                                        <telerik:RadNumericTextBox ID="txtVatValue" runat="server" DataType="Decimal"
                                            NumberFormat-DecimalDigits="2" NumberFormat-GroupSeparator=""
                                            RenderMode="Lightweight" ButtonsPosition="Left" ShowSpinButtons="True"
                                            Width="100%" Type="Currency" Value="0" MinValue="0">
                                        </telerik:RadNumericTextBox>
                                    </div>
                                    <div class="inputWapper col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                        <asp:Label Text="Gross Total:" runat="server" AssociatedControlID="txtGrossTotal" Font-Bold="True" />
                                        <telerik:RadNumericTextBox ID="txtGrossTotal" runat="server" DataType="Decimal"
                                            NumberFormat-DecimalDigits="2" Font-Bold="true" NumberFormat-GroupSeparator=""
                                            RenderMode="Lightweight" Width="100%" Type="Currency" Value="0" MinValue="0" Enabled="false" BorderStyle="Outset">
                                        </telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="inputWapper col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                        <asp:Label Text="Advance Payment:" runat="server" AssociatedControlID="txtPrevPay" Font-Bold="True" />
                                        <telerik:RadNumericTextBox ID="txtPrevPay" runat="server" DataType="Decimal"
                                            NumberFormat-DecimalDigits="2" Font-Bold="true" NumberFormat-GroupSeparator=""
                                            RenderMode="Lightweight" Width="100%" Type="Currency" Value="0" MinValue="0" Enabled="false" BorderStyle="Outset">
                                        </telerik:RadNumericTextBox>
                                    </div>
                                    <div class="inputWapper col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                        <asp:Label Text="New Payment:" runat="server" AssociatedControlID="txtCurrentPay" />
                                        <telerik:RadNumericTextBox ID="txtCurrentPay" runat="server" DataType="Decimal"
                                            NumberFormat-DecimalDigits="2" NumberFormat-GroupSeparator=""
                                            RenderMode="Lightweight" ButtonsPosition="Left" ShowSpinButtons="True"
                                            Width="100%" Type="Currency" Value="0" MinValue="0">
                                        </telerik:RadNumericTextBox>
                                        <br />
                                        <asp:RequiredFieldValidator ID="txtCurrentPayRequiredFieldValidator" runat="server" ControlToValidate="txtCurrentPay" EnableClientScript="true" ValidationGroup="FinanceInfo" ForeColor="red" ErrorMessage="required field" CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="inputWapper col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                        <asp:Label Text="Payable:" runat="server" AssociatedControlID="txtDuePay" Font-Bold="True" />
                                        <telerik:RadNumericTextBox ID="txtDuePay" runat="server" DataType="Decimal"
                                            NumberFormat-DecimalDigits="2" Font-Bold="true" NumberFormat-GroupSeparator=""
                                            RenderMode="Lightweight" Width="100%" Type="Currency" Value="0" MinValue="0" Enabled="false" BorderStyle="Outset">
                                        </telerik:RadNumericTextBox>
                                    </div>
                                    <div class="inputWapper col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                        <asp:Label Text="Next Payment Date:" runat="server" AssociatedControlID="dtNextPayment" />
                                        <telerik:RadDateTimePicker ID="dtNextPayment" runat="server"
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
                                    </div>
                                </div>
                            </telerik:RadWizardStep>

                            <telerik:RadWizardStep ID="stepOffer" Title="Quotation" runat="server" StepType="Step" ValidationGroup="FilesInfo" SpriteCssClass="contactDetails">

                                <%--   <div class="row">
                                    <div class="inputWapper col-lg-6 col-md-6 col-sm-6 col-xs-6" align="center">DDD9DC D8D4D7#DAD7DA--%>

                                <div id="divlblMsgBody" align="center" style="width: 100%;">
                                    <div id="divLoading_doc" align="center" style="padding-top: 150px; padding-bottom: 150px; width: 100%; display: normal; background-color: #E8E4E7;">
                                        <img src="Content/Images/loading_doc.gif" />
                                    </div>
                                    <div id="divBody" align="center" style="width: 100%; display: none;">
                                        <asp:Label ID="lblMsgBody" runat="server" Text=""></asp:Label>
                                        <div align="right">
                                            <telerik:RadButton ID="btnSendOffer" runat="server" Text="Send to Client"
                                                OnClick="btnSendOffer_Click">
                                                <Icon PrimaryIconCssClass="rbMail"></Icon>
                                            </telerik:RadButton>
                                        </div>
                                    </div>

                                </div>
                                <%-- </div>

                                </div>--%>
                            </telerik:RadWizardStep>
                            <telerik:RadWizardStep ID="stepFiles" Title="Files" runat="server" StepType="Step" ValidationGroup="FilesInfo" SpriteCssClass="contactDetails">
                                <div class="row">

                                    <div class="inputWapper col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                        <fieldset>
                                            <legend>
                                                <fieldset style="margin: 0px; padding: 10px;">
                                                    Received File
                                                </fieldset>
                                            </legend>
                                            <asp:Label Text="Customer File:" runat="server" AssociatedControlID="uploadCustomerFile" Font-Bold="True" />

                                            <telerik:RadAsyncUpload ID="uploadCustomerFile" runat="server" MultipleFileSelection="Automatic" MaxFileInputsCount="1"></telerik:RadAsyncUpload>
                                            <%--<telerik:RadUpload ID="uploadCustomerFile" runat="server" ControlObjectsVisibility="ClearButtons" TargetFolder="~/ProjectsFiles"></telerik:RadUpload>--%>
                                            <br />
                                            <br />
                                            <telerik:RadButton ID="btnOfferDownload" runat="server" Text="Download" ButtonType="LinkButton" Enabled="False"></telerik:RadButton>
                                        </fieldset>
                                    </div>

                                    <div class="inputWapper col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                        <fieldset>
                                            <legend>
                                                <fieldset style="margin: 0px; padding: 10px;">
                                                    Final File
                                                </fieldset>
                                            </legend>

                                            <asp:Label Text="Final File:" runat="server" AssociatedControlID="uploadFinalFile" Font-Bold="True" />

                                            <telerik:RadAsyncUpload ID="uploadFinalFile" runat="server" MultipleFileSelection="Automatic" MaxFileInputsCount="1"></telerik:RadAsyncUpload>
                                            <%--<telerik:RadUpload ID="uploadFinalFile" runat="server" ControlObjectsVisibility="ClearButtons"></telerik:RadUpload>--%>
                                            <br />
                                            <br />
                                            <telerik:RadButton ID="btnDownloadFinalFile" runat="server" Text="Download" ButtonType="LinkButton" Enabled="False"></telerik:RadButton>
                                            <telerik:RadButton ID="btnSendFinalFile" runat="server" Text="Send File to Customer" Enabled="False"></telerik:RadButton>
                                        </fieldset>
                                    </div>
                                </div>
                            </telerik:RadWizardStep>

                            <telerik:RadWizardStep ID="stepTeam" StepType="Finish" Title="Project Team" ValidationGroup="Confirmation" SpriteCssClass="confirmation" runat="server">
                                <h3>Project Manager:</h3>
                                <ul>
                                    <li>
                                        <asp:Label ID="lblProjectManager" runat="server"></asp:Label></li>
                                </ul>
                                <h3>
                                    <asp:Label ID="lblTranslatorsHead" runat="server" Text="Translators:"></asp:Label></h3>
                                <asp:BulletedList ID="ulTranslators" runat="server"></asp:BulletedList>
                                <h3>
                                    <asp:Label ID="lblReviewersHead" runat="server" Text="Revisors:"></asp:Label></h3>
                                <asp:BulletedList ID="ulRevewers" runat="server"></asp:BulletedList>
                            </telerik:RadWizardStep>
                        </WizardSteps>
                    </telerik:RadWizard>
                </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                <div class="demo-container size-custom">
                    <div id="demo">
                        <div class="RadDataForm rdfInlineBlock">
                            <div class="rdfHeader ">
                                <div class="rdfHeaderInner">Project Status</div>
                            </div>
                        </div>
                    </div>
                    <div class="rdfFieldset rdfBorders">
                        <asp:HiddenField ID="hfStatusHeader" runat="server" />
                        <div id="statusHeader" class="btn-block btn-lg btn-primary"><span id="statusHeaderIcon" class="glyphicon glyphicon-hand-right"></span><span id="statusHeaderTxt">New</span></div>
                        <ul class="list-group">
                            <asp:HiddenField ID="hfIsCustomerRequest" runat="server" />
                            <li id="customerRequestHead" class="list-group-item list-group-item-danger"><span id="customerRequestIcon" class="glyphicon glyphicon-minus"></span><span>Project Requested</span>
                                <br />
                                <asp:Label ID="lblIsCustomerRequest" runat="server" CssClass="grayDate" Text=""></asp:Label>
                            </li>
                            <asp:HiddenField ID="hfIsOfferSent" runat="server" />
                            <li id="offerSentHead" class="list-group-item list-group-item-danger"><span id="offerSentIcon" class="glyphicon glyphicon-minus"></span><span>Quotation Sent</span>
                                <br />
                                <asp:Label ID="lblIsOfferSent" runat="server" CssClass="grayDate" Text=""></asp:Label></li>
                            <asp:HiddenField ID="hfIsCustomerApproved" runat="server" />
                            <li id="customerApprovedHead" class="list-group-item list-group-item-danger"><span id="customerApprovedIcon" class="glyphicon glyphicon-minus"></span><span>Project Approved</span>
                                <br />
                                <asp:Label ID="lblIsCustomerApproved" runat="server" CssClass="grayDate" Text=""></asp:Label></li>
                            <asp:HiddenField ID="hfIsTasksSent" runat="server" />
                            <li id="tasksSentHead" class="list-group-item list-group-item-danger"><span id="tasksSentIcon" class="glyphicon glyphicon-minus"></span><span>Tasks Sent</span>
                                <br />
                                <asp:Label ID="lblIsTasksSent" runat="server" CssClass="grayDate" Text=""></asp:Label></li>
                            <asp:HiddenField ID="hfIsTasksInProgress" runat="server" />
                            <li id="tasksInProgressHead" class="list-group-item list-group-item-danger"><span id="tasksInProgressIcon" class="glyphicon glyphicon-minus"></span><span>Under Progress</span>
                                <br />
                                <asp:Label ID="lblIsTasksInProgress" runat="server" CssClass="grayDate" Text=""></asp:Label></li>
                            <asp:HiddenField ID="hfIsTasksDone" runat="server" />
                            <li id="tasksDoneHead" class="list-group-item list-group-item-danger"><span id="tasksDoneIcon" class="glyphicon glyphicon-minus"></span><span>Tasks Completed</span>
                                <br />
                                <asp:Label ID="lblIsTasksDone" runat="server" CssClass="grayDate" Text=""></asp:Label></li>
                            <asp:HiddenField ID="hfIsProjectDelivered" runat="server" />
                            <asp:HiddenField ID="hfProjID" runat="server" />
                            <li id="projectDeliveredHead" class="list-group-item list-group-item-danger"><span id="projectDeliveredIcon" class="glyphicon glyphicon-minus"></span><span>Project Delivered</span>
                                <br />
                                <asp:Label ID="lblIsProjectDelivered" runat="server" CssClass="grayDate" Text=""></asp:Label></li>
                        </ul>
                        <div class="rdfCommandButtons">
                            <telerik:RadButton RenderMode="Lightweight" ID="btnShowTasks" runat="server" ButtonType="SkinnedButton" CausesValidation="False" Text="Task Details" ToolTip="Tasks" Target="_blank" OnClick="btnShowTasks_Click" />
                            <telerik:RadButton RenderMode="Lightweight" ID="btnCancelProject" runat="server" ButtonType="SkinnedButton" CausesValidation="False" Text="Cancel" ToolTip="Cancel" OnClientClicking="RadConfirm" OnClick="btnCancelProject_Click" />
                            <telerik:RadButton RenderMode="Lightweight" ID="btnActiveProject" runat="server" ButtonType="SkinnedButton" CausesValidation="False" Text="Re-Activate" ToolTip="Activate" OnClientClicking="RadConfirm2" OnClick="btnActiveProject_Click" Visible="false" />
                        </div>
                    </div>
                </div>
            </div>
        </fieldset>
    </div>
</asp:Content>
