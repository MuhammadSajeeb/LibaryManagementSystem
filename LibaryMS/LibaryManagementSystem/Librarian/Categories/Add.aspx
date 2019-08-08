<%@ Page Title="" Language="C#" MasterPageFile="~/Librarian/Librarian.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="LibaryManagementSystem.Librarian.Categories.Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<form runat="server">
        <br/>
        <h4>Add a new Category</h4>
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
                <div class="col-md-12">
                    <asp:Label runat="server" ID="lblCategoryCode" AssociatedControlID="txtCategoryCode" CssClass="control-label" Text="Category Code"></asp:Label>
                    <asp:TextBox runat="server" ID="txtCategoryCode" CssClass="form-control" ReadOnly="true" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCategoryCode"
                        CssClass="text-danger" ErrorMessage="This field is required." />
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-12">
                    <asp:Label runat="server" ID="lblCategoryNamne" AssociatedControlID="txtCategoryName" CssClass="control-label" Text="Category Name"></asp:Label>
                    <asp:TextBox runat="server" ID="txtCategoryName" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCategoryName"
                        CssClass="text-danger" ErrorMessage="This field is required." />
                    <asp:HiddenField ID="IdHiddenField" runat="server" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" ID="AddButton" Text="Add" CssClass="btn btn-info btn-lg" Width="200px" />
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
