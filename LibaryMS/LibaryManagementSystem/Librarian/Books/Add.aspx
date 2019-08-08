<%@ Page Title="" Language="C#" MasterPageFile="~/Librarian/Librarian.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="LibaryManagementSystem.Librarian.Books.Add1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <form runat="server">
        <br/>
        <h4>Add a new Book
        </h4>
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>

        <div class="form-horizontal">
            <hr />
            <%--<asp:ValidationSummary runat="server" CssClass="text-danger" />--%>
            <div class="form-group">
                <div class="col-md-10">
                    <div class="messagealert" id="alert_container">
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-5">
                    <asp:Label runat="server" ID="lblCategory" AssociatedControlID="CategoryDropDownList" CssClass="control-label" Text="Book Category"></asp:Label>
                    <asp:DropDownList ID="CategoryDropDownList" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="CategoryDropDownList"
                        CssClass="text-danger" ErrorMessage="This field is required." />
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-5">
                    <asp:Label runat="server" ID="lblBookNamne" AssociatedControlID="txtBookName" CssClass="control-label" Text="Book Name"></asp:Label>
                    <asp:TextBox runat="server" ID="txtBookName" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtBookName"
                        CssClass="text-danger" ErrorMessage="This field is required." />
                    <asp:HiddenField ID="IdHiddenField" runat="server" />
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-5">
                    <asp:Label runat="server" ID="lblBooksAuthorName" AssociatedControlID="txtBookAuthorName" CssClass="control-label" Text="Author Name"></asp:Label>
                    <asp:TextBox runat="server" ID="txtBookAuthorName" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtBookAuthorName"
                        CssClass="text-danger" ErrorMessage="This field is required." />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-5">
                    <asp:Label runat="server" ID="lblBookQty" AssociatedControlID="txtBookQty" CssClass="control-label" Text="Available Quantity"></asp:Label>
                    <asp:TextBox runat="server" ID="txtBookQty" CssClass="form-control" TextMode="Number" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtBookQty"
                        CssClass="text-danger" ErrorMessage="This field is required." />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-5">
                    <asp:Label runat="server" ID="lblImageUpload" AssociatedControlID="ImageFileUpload" CssClass="control-label" Text="Book Image"></asp:Label>
                    <asp:FileUpload ID="ImageFileUpload" runat="server" CssClass="form-control" onchange="ImagePreview(this);" />
                    <asp:RequiredFieldValidator runat="server" ID="RfvImageUpload" ControlToValidate="ImageFileUpload"
                        CssClass="text-danger" ErrorMessage="This field is required." />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2">
                    <asp:Image ID="ShowImage" runat="server" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" ID="AddButton" Text="Add" CssClass="btn btn-info btn-lg" Width="200px" />
                </div>
            </div>
        </div>
        <script src="http://code.jquery.com/jquery-1.10.2.min.js" type="text/javascript"></script>
        <script type="text/javascript">
            function ImagePreview(input) {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('#<%=ShowImage.ClientID%>').prop('src', e.target.result)
                            .width(100)
                            .height(100);
                    };
                    reader.readAsDataURL(input.files[0]);
                }
            }
        </script>
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
                    case 'Warning':
                        cssclass = 'alert-warning'
                        break;
                    default:
                        cssclass = 'alert-info'
                }
                $('#alert_container').append('<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert fade in ' + cssclass + '"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>' + messagetype + '!</strong> <span>' + message + '</span></div>');
            }
        </script>
    </form>
</asp:Content>
