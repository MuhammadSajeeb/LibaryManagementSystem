<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentPanel.Master" AutoEventWireup="true" CodeBehind="Issue.aspx.cs" Inherits="LibaryManagementSystem.Student.Book.Issue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h2>Books Issue</h2>
        <hr />
        <div class="form-group">
            <asp:Label runat="server" ID="Label1" AssociatedControlID="CategoryDropDownList" CssClass="col-md-2 control-label"></asp:Label>
            <div class="col-md-10">
                <div class="messagealert" id="alert_container">
                </div>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="lblCategory" AssociatedControlID="CategoryDropDownList" CssClass="col-md-2 control-label">Select Category </asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="CategoryDropDownList" runat="server" CssClass="form-control"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="CategoryDropDownList"
                    CssClass="text-danger" ErrorMessage="This field is required." />
                <asp:HiddenField ID="HiddenField1" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="lblBook" AssociatedControlID="BookDropDownList" CssClass="col-md-2 control-label">Select Book </asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="BookDropDownList" runat="server" CssClass="form-control"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="BookDropDownList"
                    CssClass="text-danger" ErrorMessage="This field is required." />
                <asp:HiddenField ID="HiddenField2" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="lblBookImage" AssociatedControlID="BookImage" CssClass="col-md-2 control-label">Book Image</asp:Label>
            <div class="col-md-10">
                <asp:Image ID="BookImage" runat="server" CssClass="user-avatar rounded-circle" AlternateText="Book Image" ImageUrl="~/Student/Book/Images/programming-C.jpg" Height="150px" Width="150px" />

            </div>
        </div>
        <div class="form-group">
            <div class="col-md-2"></div>
            <div class="col-md-6">
                <asp:Label runat="server" CssClass="control-label" Font-Bold="true" Font-Size="Medium" ForeColor="#33ccff">Available Qty : </asp:Label>
                <asp:Label runat="server" ID="lblAvailableQty" CssClass="control-label" Font-Bold="true" Font-Size="Medium" ForeColor="#ff0066">10</asp:Label>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" ID="BookIssueButton" Text="Issue" CssClass="btn btn-info" OnClick="BookIssueButton_Click" />
            </div>
        </div>

        <br />
        <div class="form-group">
            <div class="col-md-offset-1 col-md-10">
                <a class="nav-link" id="registerlink" href="Register.aspx">Back To Book List</a>
            </div>
        </div>
    </div>
    <style type="text/css">
        .messagealert {
            width: 280px;
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
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" rel="stylesheet" />
    <script>
        $('#<%=CategoryDropDownList.ClientID%>').chosen();
        $('#<%=BookDropDownList.ClientID%>').chosen();
    </script>
</asp:Content>
