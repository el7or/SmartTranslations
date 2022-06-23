<%@ Page Title="Tasks Details" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProjectTasksDetails.aspx.cs" Inherits="TranSmart.ProjectTasksDetails" %>

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
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" ><%--OnAjaxRequest="RadAjaxManager1_AjaxRequest"--%>
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManager1" />
                    <telerik:AjaxUpdatedControl ControlID="lblMsgBody" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnSendTask">
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

            // inputs validations
            (function () {
                window.pageLoad = function () {
                    var $ = $telerik.$;
                    var cssSelectors = ["basicInfo", "workflowInfo", "FilesInfo", "taskBrief"];
                    var breadCrumbButtons = $(".rwzBreadCrumb .rwzLI");

                    for (var i = 0; i < cssSelectors.length; i++) {
                        $(breadCrumbButtons[i]).addClass(cssSelectors[i]);
                    }
                }

                window.OnClientLoad = function (sender, args) {
                    for (var i = 1; i < sender.get_wizardSteps().get_count() ; i++) {
                        sender.get_wizardSteps().getWizardStep(i).set_enabled(checkQueryString('taskid'));
                    }
                    calcWords();
                }

                window.OnClientButtonClicking = function (sender, args) {
                    if (!args.get_nextActiveStep().get_enabled()) {
                        args.get_nextActiveStep().set_enabled(true);
                    }
                    console.log(args.get_nextActiveStep());
                    console.log(sender.get_activeWizardStep());

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

            // calculate word count
            var calcWords = function () {
                var projectWords = parseFloat($get("<%= txtProjWords.ClientID %>").value);
                var otherTasksWords = parseFloat($get("<%= txtOtherTasksWords.ClientID %>").value);
                var wordCount = parseFloat($get("<%= txtWordCount.ClientID %>").value);
                var remainingWords = $find('<%=txtRemainingWords.ClientID %>');
                remainingWords.set_value(projectWords - (otherTasksWords + wordCount));
            };
            $(function () {
                $('#ctl00_MainContent_txtWordCount').on('change keyup keypress blur focus', calcWords);
            });

            // load project status
            $(document).ready(function () {
                var taskState = $('#MainContent_hfStatusHeader').val();
                if (taskState == "New") {
                    $('#statusHeader').attr('class', 'btn-block btn-lg btn-primary');
                    $('#statusHeaderIcon').attr('class', 'glyphicon glyphicon-hand-right');
                    $('#statusHeaderTxt').text('New');
                }
                else if (taskState == 'UnderProgress') {
                    $('#statusHeader').attr('class', 'btn-block btn-lg btn-warning');
                    $('#statusHeaderIcon').attr('class', 'glyphicon glyphicon-hand-down');
                    $('#statusHeaderTxt').text('Under Progress');
                }
                else if (taskState == 'Completed') {
                    $('#statusHeader').attr('class', 'btn-block btn-lg btn-success');
                    $('#statusHeaderIcon').attr('class', 'glyphicon glyphicon-thumbs-up');
                    $('#statusHeaderTxt').text('Completed');
                }
                else if (taskState == 'Canceled') {
                    $('#statusHeader').attr('class', 'btn-block btn-lg btn-danger');
                    $('#statusHeaderIcon').attr('class', 'glyphicon glyphicon-ban-circle');
                    $('#statusHeaderTxt').text('Canceled');
                }

                if ($('#MainContent_hfIsTranslatorReceived').val() == "") {
                    $('#translatorReceivedHead').attr('class', 'list-group-item list-group-item-danger');
                    $('#translatorReceivedIcon').attr('class', 'glyphicon glyphicon-minus');
                }
                else {
                    $('#translatorReceivedHead').attr('class', 'list-group-item list-group-item-success');
                    $('#translatorReceivedIcon').attr('class', 'glyphicon glyphicon-ok');
                }
                if ($('#MainContent_hfIsTranslatorInProgress').val() == "") {
                    $('#translatorInProgressHead').attr('class', 'list-group-item list-group-item-danger');
                    $('#translatorInProgressIcon').attr('class', 'glyphicon glyphicon-minus');
                }
                else {
                    $('#translatorInProgressHead').attr('class', 'list-group-item list-group-item-success');
                    $('#translatorInProgressIcon').attr('class', 'glyphicon glyphicon-ok');
                }
                if ($('#MainContent_hfIsTranslatorDone').val() == "") {
                    $('#translatorDoneHead').attr('class', 'list-group-item list-group-item-danger');
                    $('#translatorDoneIcon').attr('class', 'glyphicon glyphicon-minus');
                }
                else {
                    $('#translatorDoneHead').attr('class', 'list-group-item list-group-item-success');
                    $('#translatorDoneIcon').attr('class', 'glyphicon glyphicon-ok');
                }

                if ($('#MainContent_hfIsReviewerReceived').val() == "") {
                    $('#reviewerReceivedHead').attr('class', 'list-group-item list-group-item-danger');
                    $('#reviewerReceivedIcon').attr('class', 'glyphicon glyphicon-minus');
                }
                else {
                    $('#reviewerReceivedHead').attr('class', 'list-group-item list-group-item-success');
                    $('#reviewerReceivedIcon').attr('class', 'glyphicon glyphicon-ok');
                }
                if ($('#MainContent_hfIsReviewerInProgress').val() == "") {
                    $('#reviewerInProgressHead').attr('class', 'list-group-item list-group-item-danger');
                    $('#reviewerInProgressIcon').attr('class', 'glyphicon glyphicon-minus');
                }
                else {
                    $('#reviewerInProgressHead').attr('class', 'list-group-item list-group-item-success');
                    $('#reviewerInProgressIcon').attr('class', 'glyphicon glyphicon-ok');
                }
                if ($('#MainContent_hfIsReviewerDone').val() == "") {
                    $('#reviewerDoneHead').attr('class', 'list-group-item list-group-item-danger');
                    $('#reviewerDoneIcon').attr('class', 'glyphicon glyphicon-minus');
                }
                else {
                    $('#reviewerDoneHead').attr('class', 'list-group-item list-group-item-success');
                    $('#reviewerDoneIcon').attr('class', 'glyphicon glyphicon-ok');
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

                var text = "Are you sure you want to Cancel this Task?";
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

                var text = "Are you sure you want to Re-Activate this Task?";
                radconfirm(text, callBackFunction, 250, 150, null, "Re-Activate !");
                //always prevent the original postback so the RadConfirm can work, it will be initiated again with code in the callback function
                args.set_cancel(true);
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
            function ErrAlert() {
                //swal('Success!', 'Saved !', 'success');
                //sweetAlert("Faild!", "Didn't saved!", "error");
                swal({
                    title: "Faild!",
                    text: "Didn't saved !",
                    type: "error",
                    timer: 3000, showConfirmButton: false
                });
            }
            function MyAlert2(head, msg, typ) {
                //swal('Success!', 'Saved !', 'success');
                //sweetAlert("Faild!", "Didn't saved!", "error");
                console.log('MyAlert2' + head + ',' + msg + ',' + typ);
                try {

                    setTimeout(function () {
                    swal({
                        title: head,
                        text: msg,
                        type: typ,
                        timer: 3000,
                        showConfirmButton: false
                    });
                    }, 500);
                } catch (e) {
                    console.log(e);
                }
            }

            function responseEnd(sender, eventArgs) {
                console.log('Response end initiated by: ' + eventArgs.get_eventTarget());
                if (eventArgs.get_eventTarget().includes("RadAjaxManager1")) {
                    divBody.style.display = 'inherit';
                    divLoading_doc.style.display = 'none';
                }
                else if (eventArgs.get_eventTarget().includes("btnSendTask")) {

                    swal.close();
                }
            }

            function requestStart(sender, eventArgs) {
                console.log('Request start initiated by: ' + eventArgs.get_eventTarget());
                if (eventArgs.get_eventTarget().includes("RadAjaxManager1")) {
                    //divBody.style.display = 'none';
                    //divLoading_doc.style.display = 'inherit';
                }
                else if (eventArgs.get_eventTarget().includes("btnSendTask")) {
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
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadFormDecorator ID="RadFormDecorator3" runat="server"
        DecorationZoneID="zoneTaskDetails" DecoratedControls="All" />
    <div id="zoneTaskDetails" class="zoneEntity" style="margin: 20px;">
        <fieldset class="fsRow" style="width: 100% !important; background-image: linear-gradient(#ebebeb,#fff);">
            <legend class="rdfLegend rfdRoundedCorners ">
                <fieldset style="padding: 8px; font-size: 16px; font-weight: 500;">Task Details</fieldset>
            </legend>
            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                <div class="demo-container">
                    <div class="wizardHeader">
                        <h1>
                            <asp:Label ID="lblTaskSerial" runat="server" Text="1-1-2017"></asp:Label></h1>
                    </div>
                    <telerik:RadWizard RenderMode="Lightweight" ID="RadWizard1" runat="server" OnClientLoad="OnClientLoad" OnClientButtonClicking="OnClientButtonClicking"
                        OnFinishButtonClick="RadWizard1_FinishButtonClick"
                        Localization-Finish="Save">
                        <WizardSteps>
                            <telerik:RadWizardStep ID="stepBasic" Title="Basic Data" runat="server" StepType="Step" ValidationGroup="basicInfo" SpriteCssClass="basicInfo" Active="False" Enabled="True">
                                <div class="row">
                                    <div class="inputWapper col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                        <asp:Label Text="Project Words:" runat="server" AssociatedControlID="txtProjWords" Font-Bold="True" />
                                        <telerik:RadNumericTextBox ID="txtProjWords" runat="server" Font-Bold="true"
                                            NumberFormat-DecimalDigits="0"
                                            RenderMode="Lightweight" Width="100%" Value="0" MinValue="0" Enabled="false" BorderStyle="Outset">
                                        </telerik:RadNumericTextBox>
                                    </div>
                                    <div class="inputWapper col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                        <asp:Label Text="Another Tasks Words:" runat="server" AssociatedControlID="txtOtherTasksWords" Font-Bold="True" />
                                        <telerik:RadNumericTextBox ID="txtOtherTasksWords" runat="server" Font-Bold="true"
                                            NumberFormat-DecimalDigits="0"
                                            RenderMode="Lightweight" Width="100%" Value="0" MinValue="0" Enabled="false" BorderStyle="Outset">
                                        </telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="inputWapper col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                        <asp:Label Text="Task Word Count: *" runat="server" AssociatedControlID="txtWordCount" />
                                        <telerik:RadNumericTextBox ID="txtWordCount" runat="server" DataType="Int32"
                                            NumberFormat-DecimalDigits="0"
                                            RenderMode="Lightweight" ButtonsPosition="Left" ShowSpinButtons="True"
                                            Width="100%" Type="Number" Value="0" MinValue="0">
                                        </telerik:RadNumericTextBox>
                                        <br />
                                        <asp:RequiredFieldValidator ID="txtWordCountRequiredFieldValidator" runat="server" ControlToValidate="txtWordCount" EnableClientScript="true" ValidationGroup="basicInfo" ForeColor="red" ErrorMessage="required field" CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="inputWapper col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                        <asp:Label Text="Remaining Words:" runat="server" AssociatedControlID="txtRemainingWords" Font-Bold="True" />
                                        <telerik:RadNumericTextBox ID="txtRemainingWords" runat="server" Font-Bold="true"
                                            NumberFormat-DecimalDigits="0"
                                            RenderMode="Lightweight" Width="100%" Value="0" MinValue="0" Enabled="false" BorderStyle="Outset">
                                        </telerik:RadNumericTextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="inputWapper col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <asp:Label Text="Task Description:" runat="server" AssociatedControlID="txtTaskDesc" />
                                        <telerik:RadTextBox ID="txtTaskDesc" runat="server" TextMode="MultiLine" Rows="3" Width="100%"></telerik:RadTextBox>
                                    </div>
                                </div>
                            </telerik:RadWizardStep>

                            <telerik:RadWizardStep ID="stepWorkflow" Title="WorkFlow" runat="server" StepType="Start" ValidationGroup="workflowInfo" CausesValidation="true" SpriteCssClass="workflowInfo" Enabled="True">
                                <div class="row">
                                    <div class="inputWapper col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                        <fieldset>
                                            <legend>
                                                <fieldset style="margin: 0px; padding: 10px;">
                                                    Translator
                                                </fieldset>
                                            </legend>
                                            <asp:Label Text="Translator: *" runat="server" AssociatedControlID="ddlTranslatorTask" />
                                            <asp:RequiredFieldValidator ID="ddlTranslatorTaskRequiredFieldValidator" runat="server" ControlToValidate="ddlTranslatorTask" EnableClientScript="true" ValidationGroup="workflowInfo" ForeColor="red" ErrorMessage="required field" CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <telerik:RadComboBox RenderMode="Lightweight" ID="ddlTranslatorTask"
                                                runat="server" Width="100%" EmptyMessage="Choose Translator ..">
                                                <Items>
                                                    <telerik:RadComboBoxItem Text="" Value="" TabIndex="-1" Enabled="False" Selected="True" />
                                                    <telerik:RadComboBoxItem Text="Ali Sayed" Value="1" />
                                                    <telerik:RadComboBoxItem Text="Mohamed Hamdy" Value="2" />
                                                    <telerik:RadComboBoxItem Text="Egy Inc." Value="3" />
                                                </Items>
                                            </telerik:RadComboBox>
                                            <br />

                                            <asp:Label Text="Translator Deadline: *" runat="server" AssociatedControlID="dtTranslatorDeadline" />
                                            <telerik:RadDateTimePicker ID="dtTranslatorDeadline" runat="server"
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
                                            <asp:RequiredFieldValidator ID="dtTranslatorDeadlineRequiredFieldValidator" runat="server" ControlToValidate="dtTranslatorDeadline" EnableClientScript="true" ValidationGroup="workflowInfo" ForeColor="red" ErrorMessage="required field" CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <br />
                                            <asp:Label Text="Translator received At:" runat="server" AssociatedControlID="txtTranslatorReceived" Font-Bold="True" />
                                            <telerik:RadTextBox ID="txtTranslatorReceived" runat="server" Font-Bold="true"
                                                RenderMode="Lightweight" Width="100%" Enabled="false" BorderStyle="Outset">
                                            </telerik:RadTextBox>
                                            <asp:Label Text="Translator Finished At:" runat="server" AssociatedControlID="txtTranslatorDone" Font-Bold="True" />
                                            <telerik:RadTextBox ID="txtTranslatorDone" runat="server" Font-Bold="true"
                                                RenderMode="Lightweight" Width="100%" Enabled="false" BorderStyle="Outset">
                                            </telerik:RadTextBox>

                                        </fieldset>
                                    </div>
                                    <div class="inputWapper col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                        <fieldset>
                                            <legend>
                                                <fieldset style="margin: 0px; padding: 10px;">
                                                    Revisor
                                                </fieldset>
                                            </legend>
                                            <asp:Label Text="Revisor: *" runat="server" AssociatedControlID="ddlReviewerTask" />
                                            <asp:RequiredFieldValidator ID="ddlReviewerTaskRequiredFieldValidator" runat="server" ControlToValidate="ddlReviewerTask" EnableClientScript="true" ValidationGroup="workflowInfo" ForeColor="red" ErrorMessage="required field" CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <telerik:RadComboBox RenderMode="Lightweight" ID="ddlReviewerTask"
                                                runat="server" Width="100%" EmptyMessage="Choose Reviewer ..">
                                                <Items>
                                                    <telerik:RadComboBoxItem Text="" Value="" TabIndex="-1" Enabled="False" Selected="True" />
                                                    <telerik:RadComboBoxItem Text="Ali Sayed" Value="1" />
                                                    <telerik:RadComboBoxItem Text="Mohamed Hamdy" Value="2" />
                                                    <telerik:RadComboBoxItem Text="Egy Inc." Value="3" />
                                                </Items>
                                            </telerik:RadComboBox>
                                            <br />
                                            <asp:Label Text="Revisor Deadline: *" runat="server" AssociatedControlID="dtReviewerDeadline" />
                                            <telerik:RadDateTimePicker ID="dtReviewerDeadline" runat="server"
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
                                            <asp:RequiredFieldValidator ID="dtReviewerDeadlineRequiredFieldValidator" runat="server" ControlToValidate="dtReviewerDeadline" EnableClientScript="true" ValidationGroup="workflowInfo" ForeColor="red" ErrorMessage="required field" CssClass="validator" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <br />

                                            <asp:Label Text="Revisor received At:" runat="server" AssociatedControlID="txtReviewerReceived" Font-Bold="True" />
                                            <telerik:RadTextBox ID="txtReviewerReceived" runat="server" Font-Bold="true"
                                                RenderMode="Lightweight" Width="100%" Enabled="false" BorderStyle="Outset">
                                            </telerik:RadTextBox>
                                            <br />
                                            <asp:Label Text="Revisor Finished At:" runat="server" AssociatedControlID="txtReviewerDone" Font-Bold="True" />
                                            <telerik:RadTextBox ID="txtReviewerDone" runat="server" Font-Bold="true"
                                                RenderMode="Lightweight" Width="100%" Enabled="false" BorderStyle="Outset">
                                            </telerik:RadTextBox>

                                        </fieldset>
                                    </div>
                                    <div class="inputWapper col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                        <asp:Label Text="Project Manager:" runat="server" AssociatedControlID="txtProjectManager" Font-Bold="True" />
                                        <telerik:RadTextBox ID="txtProjectManager" runat="server" Font-Bold="true"
                                            RenderMode="Lightweight" Width="100%" Enabled="false" BorderStyle="Outset">
                                        </telerik:RadTextBox>
                                        <br />
                                        <asp:Label Text="Project Promised Delivery Date:" runat="server" AssociatedControlID="txtProjectPromise" Font-Bold="True" />
                                        <telerik:RadTextBox ID="txtProjectPromise" runat="server" Font-Bold="true"
                                            RenderMode="Lightweight" Width="100%" Enabled="false" BorderStyle="Outset">
                                        </telerik:RadTextBox>
                                    </div>
                                </div>
                                <%--<div class="row">
                                    <div class="inputWapper col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                    </div>
                                    <div class="inputWapper col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                    </div>
                                    <div class="inputWapper col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="inputWapper col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                    </div>
                                    <div class="inputWapper col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                    </div>
                                    <div class="inputWapper col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                    </div>
                                </div>--%>
                                <div class="row">
                                    <div class="inputWapper col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                    </div>
                                </div>
                            </telerik:RadWizardStep>

                            <telerik:RadWizardStep ID="stepFiles" Title="Files" runat="server" StepType="Finish" ValidationGroup="FilesInfo" SpriteCssClass="contactDetails">

                                <div class="row">
                                    <div class="inputWapper col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                        <fieldset>
                                            <legend>
                                                <fieldset style="margin: 0px; padding: 10px;">
                                                    Input Files
                                                </fieldset>
                                            </legend>
                                            <asp:Label Text="Task File:" runat="server" AssociatedControlID="uploadTaskFile" Font-Bold="True" />
                                            <telerik:RadAsyncUpload ID="uploadTaskFile" runat="server" MultipleFileSelection="Automatic" Height="30px" MaxFileInputsCount="1"></telerik:RadAsyncUpload>

                                            <br />
                                            <asp:Label Text="Download Task File:" runat="server" AssociatedControlID="btnTaskDownload" Font-Bold="True" />
                                            <telerik:RadButton ID="btnTaskDownload" runat="server" Text="Download" ButtonType="LinkButton" Enabled="False">
                                                 <Icon PrimaryIconCssClass="rbDownload"></Icon>
                                            </telerik:RadButton>
                                            <br /><br />
                                            <telerik:RadButton ID="btnSendTask" runat="server" Text="Send Task to Translator" OnClick="btnSendTask_Click" Enabled="False">
                                                 <Icon PrimaryIconCssClass="rbMail"></Icon>
                                            </telerik:RadButton>
                                        </fieldset>
                                    </div>



                                    <div class="inputWapper col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                        <fieldset>
                                            <legend>
                                                <fieldset style="margin: 0px; padding: 10px;">
                                                    Output Files
                                                </fieldset>
                                            </legend>
                                            <asp:Label Text="Translator Quality:" runat="server" AssociatedControlID="uploadTaskFile" Font-Bold="True" />
                                            <telerik:RadNumericTextBox ID="txtTranslatorQuality" runat="server" Font-Bold="true"
                                                NumberFormat-DecimalDigits="0" Type="Percent"
                                                RenderMode="Lightweight" Width="60%" Value="0" MinValue="0" MaxValue="100" Enabled="false" BorderStyle="Outset">
                                            </telerik:RadNumericTextBox>
                                            <br />
                                            <br />

                                            <telerik:RadButton ID="btnDownloadTaskTranslator" runat="server" Text="Download Translator File" ButtonType="LinkButton" Enabled="False">
                                                <Icon PrimaryIconCssClass="rbDownload"></Icon>
                                            </telerik:RadButton><br /> <br />

                                            <telerik:RadButton ID="btnDownloadTaskReviewer" runat="server" Text="Download Revisor File" ButtonType="LinkButton" Enabled="False">
                                                <Icon PrimaryIconCssClass="rbDownload"></Icon>
                                            </telerik:RadButton>

                                        </fieldset>
                                    </div>
                                </div>
                            </telerik:RadWizardStep>

                            <%--<telerik:RadWizardStep ID="stepBrief" StepType="Finish" Title="Task brief" ValidationGroup="taskBrief" SpriteCssClass="taskBrief" runat="server">
                            </telerik:RadWizardStep>--%>
                        </WizardSteps>
                    </telerik:RadWizard>
                </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                <div class="demo-container size-custom">
                    <div id="demo">
                        <div class="RadDataForm rdfInlineBlock">
                            <div class="rdfHeader ">
                                <div class="rdfHeaderInner">Task Status</div>
                            </div>
                        </div>
                    </div>
                    <div class="rdfFieldset rdfBorders">
                        <asp:HiddenField ID="hfStatusHeader" runat="server" />
                        <div id="statusHeader" class="btn-block btn-lg btn-primary"><span id="statusHeaderIcon" class="glyphicon glyphicon-hand-right"></span><span id="statusHeaderTxt">Pending</span></div>
                        <ul class="list-group">
                            <asp:HiddenField ID="hfIsTranslatorReceived" runat="server" />
                            <li id="translatorReceivedHead" class="list-group-item list-group-item-danger"><span id="translatorReceivedIcon" class="glyphicon glyphicon-minus"></span><span>Received by Translator</span>
                                <br />
                                <asp:Label ID="lblIsTranslatorReceived" runat="server" CssClass="grayDate" Text=""></asp:Label></li>
                            <asp:HiddenField ID="hfIsTranslatorInProgress" runat="server" />
                            <li id="translatorInProgressHead" class="list-group-item list-group-item-danger"><span id="translatorInProgressIcon" class="glyphicon glyphicon-minus"></span><span>Translation Under Progress</span>
                                <br />
                                <asp:Label ID="lblIsTranslatorInProgress" runat="server" CssClass="grayDate" Text=""></asp:Label></li>
                            <asp:HiddenField ID="hfIsTranslatorDone" runat="server" />
                            <li id="translatorDoneHead" class="list-group-item list-group-item-danger"><span id="translatorDoneIcon" class="glyphicon glyphicon-minus"></span><span>Translation Completed</span>
                                <br />
                                <asp:Label ID="lblIsTranslatorDone" runat="server" CssClass="grayDate" Text=""></asp:Label></li>
                            <asp:HiddenField ID="hfIsReviewerReceived" runat="server" />
                            <li id="reviewerReceivedHead" class="list-group-item list-group-item-danger"><span id="reviewerReceivedIcon" class="glyphicon glyphicon-minus"></span><span>Received by Revisor</span>
                                <br />
                                <asp:Label ID="lblIsReviewerReceived" runat="server" CssClass="grayDate" Text=""></asp:Label></li>
                            <asp:HiddenField ID="hfIsReviewerInProgress" runat="server" />
                            <li id="reviewerInProgressHead" class="list-group-item list-group-item-danger"><span id="reviewerInProgressIcon" class="glyphicon glyphicon-minus"></span><span>Revision Under Progress</span>
                                <br />
                                <asp:Label ID="lblIsReviewerInProgress" runat="server" CssClass="grayDate" Text=""></asp:Label></li>
                            <asp:HiddenField ID="hfIsReviewerDone" runat="server" />
                            <li id="reviewerDoneHead" class="list-group-item list-group-item-danger"><span id="reviewerDoneIcon" class="glyphicon glyphicon-minus"></span><span>Revision Completed</span>
                                <br />
                                <asp:Label ID="lblIsReviewerDone" runat="server" CssClass="grayDate" Text=""></asp:Label></li>
                        </ul>
                        <div class="rdfCommandButtons">
                            <telerik:RadButton RenderMode="Lightweight" ID="btnShowProject" runat="server" ButtonType="SkinnedButton" CausesValidation="False" Text="Project Details" ToolTip="Tasks" Target="_blank" OnClick="btnShowProject_Click" />
                            <telerik:RadButton RenderMode="Lightweight" ID="btnCancelTask" runat="server" ButtonType="SkinnedButton" CausesValidation="False" Text="Cancel" ToolTip="Cancel" OnClientClicking="RadConfirm" OnClick="btnCancelTask_Click" />
                            <telerik:RadButton RenderMode="Lightweight" ID="btnActiveTask" runat="server" ButtonType="SkinnedButton" CausesValidation="False" Text="Re-Activate" ToolTip="Activate" OnClientClicking="RadConfirm2" OnClick="btnActiveTask_Click" Visible="false" />
                        </div>
                    </div>
                </div>
            </div>
        </fieldset>
    </div>
</asp:Content>
