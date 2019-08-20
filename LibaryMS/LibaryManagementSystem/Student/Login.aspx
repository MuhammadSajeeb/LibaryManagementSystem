<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LibaryManagementSystem.Student.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <br/>
    <br/>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h2>Student Login</h2>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <div class="col-md-10">
                <div class="messagealert" id="alert_container">
                </div>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="lblEnrollId" AssociatedControlID="txtEnrollId" CssClass="col-md-2 control-label">Enroll Id</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtEnrollId" CssClass="form-control" TextMode="Number" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEnrollId"
                    CssClass="text-danger" ErrorMessage="The Enroll Id field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="lblpassword" AssociatedControlID="txtpassword" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtpassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtpassword"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-2"></div>
            <div class="col-md-6">
                <asp:CheckBox ID="RememeberCheckBox" runat="server" />
                <asp:Label runat="server" ID="lblRememberme" CssClass="control-label">Rememeber me ?</asp:Label>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <a class="nav-link" id="ForgetPassword" href="ForgetPassword.aspx">forgotten password ? </a>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" ID="LoginButton" Text="Login" CssClass="btn btn-info" OnClick="LoginButton_Click"/>
            </div>
        </div>
        <br/>
        <div class="form-group">
            <div class="col-md-offset-1 col-md-10">
                <a class="nav-link" id="registerlink" href="Register.aspx">you have no account ? then register</a>
            </div>
        </div>
    </div>
    <style type="text/css">
        .messagealert {
            width: 358px;
            margin-left: 120px;
        }
    </style>
    <script type="text/javascript">
        function ShowMessage(message, messagetype) {
            var cssclass;
            switch (messagetype) {
                case 'Success':
                    cssclass = 'alert-success'
                    break;
                case 'Failed':
                    cssclass = 'alert-danger'
                    break;
                case 'Error':
                    cssclass = 'alert-danger'
                    break;
                case 'Warning':
                    cssclass = 'alert-warning'
                    break;
                default:
                    cssclass = 'alert-info'
            }
            $('#alert_container').append('<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert fade in ' + cssclass + '"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>' + messagetype + '!</strong> <span>' + message + '</span></div>');
        }
    </script>
</asp:Content>
