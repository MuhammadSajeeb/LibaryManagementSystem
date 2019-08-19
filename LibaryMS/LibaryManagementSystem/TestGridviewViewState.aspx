<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestGridviewViewState.aspx.cs" Inherits="LibaryManagementSystem.TestGridviewViewState" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h2>Librarian Login</h2>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <div class="col-md-10">
                <div class="messagealert" id="alert_container">
                </div>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="lblname" AssociatedControlID="txtusername" CssClass="col-md-2 control-label">Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtusername" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtusername"
                    CssClass="text-danger" ErrorMessage="The UserName field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="lblRoll" AssociatedControlID="txtRoll" CssClass="col-md-2 control-label">Roll</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtRoll" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtRoll"
                    CssClass="text-danger" ErrorMessage="The UserName field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="lblGender" AssociatedControlID="txtGender" CssClass="col-md-2 control-label">Gender</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtGender" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtGender"
                    CssClass="text-danger" ErrorMessage="The UserName field is required." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-2"></div>
            <div class="col-md-6">
                <asp:CheckBox ID="RememeberCheckBox" runat="server" />
                <asp:Label runat="server" ID="lblRememberme" CssClass="control-label">Rememeber me ?</asp:Label>
            </div>
        </div>
        <%--        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <a class="nav-link" id="ForgetPassword" href="ForgetPassword.aspx">forgotten password ? </a>
            </div>
        </div>--%>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" ID="AddButton" Text="Add" CssClass="btn btn-info" OnClick="AddButton_Click" />
                <asp:Button runat="server" ID="ClearButton" Text="Clear" CssClass="btn btn-warning" OnClick="ClearButton_Click" />
            </div>
        </div>
        <br />
            <div class="form-group">
                <div class="col-md-offset-1 col-md-12">
                    <br />
                    <asp:GridView ID="DetailsGridView" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="true" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="10" ForeColor="Black" GridLines="Horizontal" AllowPaging="True" PageSize="10" CellSpacing="10">
                    </asp:GridView>
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
    <link href="Content/GridviewStyle.css" rel="stylesheet" />
</asp:Content>
