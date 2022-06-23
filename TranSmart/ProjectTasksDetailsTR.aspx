<%@ Page Title="Tasks Details" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProjectTasksDetailsTR.aspx.cs" Inherits="TranSmart.ProjectTasksDetailsTR" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <link href="Styles/mail.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link href="css/sweetalert.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="js/sweetalert.min.js"></script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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

                input[disabled=disabled], textarea[disabled=disabled] {
                    opacity: 1 !important;
                    background-color: whitesmoke !important;
                }

            h3 {
                padding: 0 15px;
            }

            ul.list-group span.lbl {
                font-weight: bold;
            }

            div.btn-group-vertical {
                width: 100%;
            }

                div.btn-group-vertical span {
                    margin-right: 10px;
                }

                div.btn-group-vertical button {
                    font-size: 18px;
                    font-weight: bold;
                    margin: 10px 0;
                    border-radius: 6px !important;
                    opacity: 1 !important;
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
                    var cssSelectors = ["basicInfo", "FilesInfo"];
                    var breadCrumbButtons = $(".rwzBreadCrumb .rwzLI");

                    for (var i = 0; i < cssSelectors.length; i++) {
                        $(breadCrumbButtons[i]).addClass(cssSelectors[i]);
                    }
                }

                window.OnClientLoad = function (sender, args) {
                    for (var i = 1; i < sender.get_wizardSteps().get_count() ; i++) {
                        sender.get_wizardSteps().getWizardStep(i).set_enabled(checkQueryString('taskid'));
                    }
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

            <%--// calculate word count
            var calcWords = function () {
                var projectWords = parseFloat($get("<%= txtProjWords.ClientID %>").value);
                var otherTasksWords = parseFloat($get("<%= txtOtherTasksWords.ClientID %>").value);
                var wordCount = parseFloat($get("<%= txtWordCount.ClientID %>").value);
                var remainingWords = $find('<%=txtRemainingWords.ClientID %>');
                remainingWords.set_value(projectWords - (otherTasksWords + wordCount));
            };
            $(function () {
                $('#ctl00_MainContent_txtWordCount').on('change keyup keypress blur focus', calcWords);
            });--%>

            $(document).ready(function () {
                //// Change Task status
                //$('div.btn-group-vertical button').click(function () {
                //    $('div.btn-group-vertical button').attr('class', 'btn btn-lg btn-default').find('span').removeAttr('class');
                //    $(this).attr('class', 'btn btn-lg btn-primary').find('span').attr('class', 'glyphicon glyphicon-hand-right');
                //    var status = $(this).text();
                //    $.ajax({
                //        type: "POST",
                //        url: "ProjectTasksDetailsTr.aspx/ChangeStatus",
                //        data: '{status: "' + status + '" }',
                //        contentType: "application/json; charset=utf-8",
                //        dataType: "json",
                //        success: function (response) {
                //            swal({
                //                title: "Success!",
                //                text: "Task Status changed !",
                //                type: "success",
                //                timer: 2000,
                //                showConfirmButton: false
                //            });
                //            //alert(response.d);
                //        },
                //        failure: function (response) {
                //            alert(response.d);
                //        }
                //    });
                //});

                // load Task status
                var taskState = $('#MainContent_hfStatusHeader').val();
                $('div.btn-group-vertical button').attr({ 'class': 'btn btn-lg btn-default', 'disabled': 'disabled' }).find('span').removeAttr('class');
                if (taskState == 'InProgress') {
                    $('div.btn-group-vertical button:nth-of-type(2)').attr('class', 'btn btn-lg btn-primary').find('span').attr('class', 'glyphicon glyphicon-hand-right');
                }
                else if (taskState == 'Completed') {
                    $('div.btn-group-vertical button:nth-of-type(3)').attr('class', 'btn btn-lg btn-primary').find('span').attr('class', 'glyphicon glyphicon-hand-right');
                }
                else {
                    $('div.btn-group-vertical button:nth-of-type(1)').attr('class', 'btn btn-lg btn-primary').find('span').attr('class', 'glyphicon glyphicon-hand-right');
                }
            });


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

            ////RadConfirm
            //function RadConfirm(sender, args) {
            //    var callBackFunction = function (shouldSubmit) {
            //        if (shouldSubmit) {
            //            //initiate the original postback again
            //            sender.click();
            //            if (Telerik.Web.Browser.ff) { //work around a FireFox issue with form submission, see http://www.telerik.com/support/kb/aspnet-ajax/window/details/form-will-not-submit-after-radconfirm-in-firefox
            //                sender.get_element().click();
            //            }
            //        }
            //    };

            //    var text = "Are you sure you want to Cancel this Task?";
            //    radconfirm(text, callBackFunction, 250, 150, null, "Cancel !");
            //    //always prevent the original postback so the RadConfirm can work, it will be initiated again with code in the callback function
            //    args.set_cancel(true);
            //}
            //function RadConfirm2(sender, args) {
            //    var callBackFunction = function (shouldSubmit) {
            //        if (shouldSubmit) {
            //            //initiate the original postback again
            //            sender.click();
            //            if (Telerik.Web.Browser.ff) { //work around a FireFox issue with form submission, see http://www.telerik.com/support/kb/aspnet-ajax/window/details/form-will-not-submit-after-radconfirm-in-firefox
            //                sender.get_element().click();
            //            }
            //        }
            //    };

            //    var text = "Are you sure you want to Re-Activate this Task?";
            //    radconfirm(text, callBackFunction, 250, 150, null, "Re-Activate !");
            //    //always prevent the original postback so the RadConfirm can work, it will be initiated again with code in the callback function
            //    args.set_cancel(true);
            //}
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
                        Localization-Finish="Save & Finish">
                        <WizardSteps>
                            <telerik:RadWizardStep ID="stepBasic" Title="Basic Data" runat="server" StepType="Start" ValidationGroup="basicInfo" SpriteCssClass="basicInfo" Active="true" Enabled="True">
                                <div class="row">
                                    <div class="inputWapper col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                        <asp:Label Text="Job Type:" runat="server" AssociatedControlID="txtJobType" Font-Bold="True" />
                                        <telerik:RadTextBox ID="txtJobType" runat="server" Font-Bold="true"
                                            RenderMode="Lightweight" Width="100%" Enabled="false" BorderStyle="Outset">
                                        </telerik:RadTextBox>
                                    </div>
                                    <div class="inputWapper col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                        <asp:Label Text="Source Language:" runat="server" AssociatedControlID="txtFromLangg" Font-Bold="True" />
                                        <telerik:RadTextBox ID="txtFromLangg" runat="server" Font-Bold="true"
                                            RenderMode="Lightweight" Width="100%" Enabled="false" BorderStyle="Outset">
                                        </telerik:RadTextBox>
                                    </div>
                                    <div class="inputWapper col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                        <asp:Label Text="Target Language:" runat="server" AssociatedControlID="txtToLangg" Font-Bold="True" />
                                        <telerik:RadTextBox ID="txtToLangg" runat="server" Font-Bold="true"
                                            RenderMode="Lightweight" Width="100%" Enabled="false" BorderStyle="Outset">
                                        </telerik:RadTextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="inputWapper col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                        <asp:Label Text="Word Count:" runat="server" AssociatedControlID="txtwordCount" Font-Bold="True" />
                                        <telerik:RadNumericTextBox ID="txtwordCount" runat="server" Font-Bold="true"
                                            NumberFormat-DecimalDigits="0"
                                            RenderMode="Lightweight" Width="100%" Value="0" MinValue="0" Enabled="false" BorderStyle="Outset">
                                        </telerik:RadNumericTextBox>
                                    </div>
                                    <div class="inputWapper col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                        <asp:Label Text="Project Manager:" runat="server" AssociatedControlID="txtProjectManager" Font-Bold="True" />
                                        <telerik:RadTextBox ID="txtProjectManager" runat="server" Font-Bold="true"
                                            RenderMode="Lightweight" Width="100%" Enabled="false" BorderStyle="Outset">
                                        </telerik:RadTextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="inputWapper col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <asp:Label Text="Task Description:" runat="server" AssociatedControlID="txtTaskDesc" />
                                        <telerik:RadTextBox ID="txtTaskDesc" runat="server" TextMode="MultiLine" Rows="3" Width="100%" Enabled="false" BorderStyle="Outset"></telerik:RadTextBox>
                                    </div>
                                </div>
                            </telerik:RadWizardStep>

                            <telerik:RadWizardStep ID="stepFiles" Title="Files" runat="server" StepType="Finish" ValidationGroup="FilesInfo" SpriteCssClass="contactDetails" Enabled="true">


                                <%--  <div class="row">  </div>--%>
                                <div class="inputWapper col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                    <fieldset>
                                        <legend>
                                            <fieldset style="margin: 0px; padding: 10px;">
                                                Input Files
                                            </fieldset>
                                        </legend>
                                        <%--<asp:Label Text="Task File:" runat="server" AssociatedControlID="uploadTaskFile" Font-Bold="True" />--%>
                                        <asp:Label ID="lblDownloadReceivedFile" Text="Download Task File:" runat="server" AssociatedControlID="btnDownloadReceivedFile" Font-Bold="True" />
                                        <telerik:RadButton ID="btnDownloadReceivedFile" runat="server" Text="Download" ButtonType="LinkButton"  OnClick="btnDownloadReceivedFile_Click" Enabled="False">
                                            <Icon PrimaryIconCssClass="rbDownload"></Icon>
                                        </telerik:RadButton>
                                        <br /> <br />
                                        <asp:Label ID="lblQuality" Text="Translator Quality:" runat="server" AssociatedControlID="txtTranslatorQuality" Font-Bold="True" />
                                        <telerik:RadNumericTextBox ID="txtTranslatorQuality" runat="server" Font-Bold="true"
                                            NumberFormat-DecimalDigits="0" Type="Percent"
                                            RenderMode="Lightweight" Width="60%" Value="0" MinValue="0" MaxValue="100">
                                        </telerik:RadNumericTextBox>

                                        <%--<telerik:RadAsyncUpload ID="uploadTaskFile" runat="server" MultipleFileSelection="Automatic" Height="30px" MaxFileInputsCount="1"></telerik:RadAsyncUpload>

                                           
                                            <telerik:RadButton ID="btnTaskDownload" runat="server" Text="Download" ButtonType="LinkButton">
                                            </telerik:RadButton>
                                            <br />
                                            <br />
                                            <telerik:RadButton ID="RadButton1" runat="server" Text="Send Task to Translator" OnClick="btnSendTask_Click">
                                                <Icon PrimaryIconCssClass="rbMail"></Icon>
                                            </telerik:RadButton>--%>
                                    </fieldset>

                                    <%-- 
                                        <fieldset>
                                            <legend>
                                                <fieldset style="margin: 0px; padding: 10px;">
                                                    Translation Quality
                                                </fieldset>  </legend>
                                        </fieldset>--%>
                                </div>



                                <div class="inputWapper col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                    <fieldset>
                                        <legend>
                                            <fieldset style="margin: 0px; padding: 10px;">
                                                Output Files
                                            </fieldset>
                                        </legend>
                                        <%-- <br />
                                            <br />

                                           <telerik:RadButton ID="btnDownloadTaskTranslator" runat="server" Text="Download Translator File" ButtonType="LinkButton">
                                                <Icon PrimaryIconCssClass="rbDownload"></Icon>
                                            </telerik:RadButton>
                                            <br />
                                            <br />

                                            <telerik:RadButton ID="btnDownloadTaskReviewer" runat="server" Text="Download Reviewer File" ButtonType="LinkButton">
                                                <Icon PrimaryIconCssClass="rbDownload"></Icon>
                                            </telerik:RadButton>

                                <h3>My File:</h3>--%>
                                        <div class="row">
                                            <div class="inputWapper col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <asp:Label Text="Upload Finished File:" runat="server" AssociatedControlID="uploadFinishedFile" Font-Bold="True" />
                                                <telerik:RadAsyncUpload ID="uploadFinishedFile" runat="server" MultipleFileSelection="Automatic" MaxFileInputsCount="1"></telerik:RadAsyncUpload>
                                            </div>
                                            <div class="inputWapper col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                <asp:Label Text="Send Finished File:" runat="server" AssociatedControlID="btnSendTask" Font-Bold="True" />
                                                <telerik:RadButton ID="btnSendTask" runat="server" Text="Send Email" Enabled="False"  
                                                    OnClick="btnSendTask_Click" >
                                                    <Icon PrimaryIconCssClass="rbMail"></Icon>
                                                </telerik:RadButton>
                                            </div><br /><br /> 
                                               
                                            <div class="inputWapper col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                               <br /> <asp:Label ID="lblDownloadFinishedFile" Text="Download Finished File:" runat="server" AssociatedControlID="btnDownloadFinishedFile" Font-Bold="True" />
                                                <telerik:RadButton ID="btnDownloadFinishedFile" runat="server" Text="Download" ButtonType="LinkButton" 
                                                      OnClick="btnDownloadFinishedFile_Click" Enabled="False">
                                                    <Icon PrimaryIconCssClass="rbDownload"></Icon>
                                                </telerik:RadButton>
                                                </div>
                                                <%----%>
                                        </div>


                                        <%-- <h3>Translator Quality:</h3>

                                            <telerik:RadNumericTextBox ID="RadNumericTextBox1" runat="server" Font-Bold="true"
                                                NumberFormat-DecimalDigits="0" Type="Percent"
                                                RenderMode="Lightweight" Width="60%" Value="0" MinValue="0" MaxValue="100" Enabled="false" BorderStyle="Outset">
                                            </telerik:RadNumericTextBox>--%>
                                    </fieldset>
                                </div>


                                <%-- <div class="inputWapper col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                    </div>--%>
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
                                <div class="rdfHeaderInner">Task Status</div>
                            </div>
                        </div>
                    </div>
                    <div class="rdfFieldset rdfBorders">
                        <asp:HiddenField ID="hfStatusHeader" runat="server" />
                        <div class="btn-group-vertical">
                            <button type="button" class="btn btn-lg btn-default"><span id="" class=""></span>New</button>
                            <button type="button" class="btn btn-lg btn-default"><span id="" class=""></span>Under Progress</button>
                            <button type="button" class="btn btn-lg btn-default"><span id="" class=""></span>Completed</button>
                        </div>
                        <ul class="list-group">
                            <li class="list-group-item list-group-item-success"><span class="glyphicon glyphicon-minus"></span>
                                <span class="lbl">Start Date : 
                                    <asp:Label ID="txtStartDate" runat="server" Text="Not yet"></asp:Label>
                                </span></li>
                            <li class="list-group-item list-group-item-success"><span class="glyphicon glyphicon-minus"></span>
                                <span class="lbl">Finish Date : 
                                    <asp:Label ID="txtFinishDate" runat="server" Text="Not yet"></asp:Label>
                                </span></li>
                            <li class="list-group-item list-group-item-danger"><span class="glyphicon glyphicon-minus"></span>
                                <span class="lbl">Deadline : 
                                    <asp:Label ID="txtDeadline" runat="server" Text="2017/9/1"></asp:Label>
                                </span></li>
                            <li id="translatorDoneHead" class="list-group-item list-group-item-warning"><span class="glyphicon glyphicon-minus"></span>
                                <span class="lbl">Delay : 
                                    <asp:Label ID="txtDelay" runat="server" Text="None"></asp:Label><asp:Label ID="txtDays" runat="server" Text=""></asp:Label>
                                </span></li>
                        </ul>
                    </div>
                </div>
            </div>
        </fieldset>
    </div>
</asp:Content>
