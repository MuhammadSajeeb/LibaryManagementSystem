<%@ Page Title="" Language="C#" MasterPageFile="~/Librarian/Librarian.Master" AutoEventWireup="true" CodeBehind="ChangeStatus.aspx.cs" Inherits="LibaryManagementSystem.Librarian.Categories.ChangeStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server" style="height: 100%">
        <br />
        <h4>Change Status</h4>
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>

        <div class="form-horizontal">
            <hr />
            <div class="card" style="border-top-color: red;border-top-style: solid;border-width:2px">
                <div class="card-body card-block">
                    <div class="form-group">
                        <div class="col-md-7">
                            <asp:Label runat="server" ID="lblCategoryCode" AssociatedControlID="txtCategoryCode" CssClass="control-label" Text="Category Code"></asp:Label>
                            <asp:TextBox runat="server" ID="txtCategoryCode" CssClass="form-control" ReadOnly="true" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCategoryCode"
                                CssClass="text-danger" ErrorMessage="This field is required." />
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-7">
                            <asp:Label runat="server" ID="lblCategoryNamne" AssociatedControlID="txtCategoryName" CssClass="control-label" Text="Category Name"></asp:Label>
                            <asp:TextBox runat="server" ID="txtCategoryName" CssClass="form-control" ReadOnly="true" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCategoryName"
                                CssClass="text-danger" ErrorMessage="This field is required." />
                            <asp:HiddenField ID="IdHiddenField" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-7">
                            <asp:Label runat="server" ID="lblStatus" AssociatedControlID="txtStatus" CssClass="control-label" Text="Status"></asp:Label>
                            <asp:TextBox runat="server" ID="txtStatus" CssClass="form-control" ReadOnly="true" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtStatus"
                                CssClass="text-danger" ErrorMessage="This field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" ID="StatusButton" Text="Running" CssClass="btn btn-info btn-md" Width="120px" OnClick="StatusButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <link href="../../Content/GridviewStyle.css" rel="stylesheet" />
</asp:Content>
