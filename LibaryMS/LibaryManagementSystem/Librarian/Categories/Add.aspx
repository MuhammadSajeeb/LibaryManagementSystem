<%@ Page Title="" Language="C#" MasterPageFile="~/Librarian/Librarian.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="LibaryManagementSystem.Librarian.Categories.Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server" style="height:100%">
        <br />
        <h4>Add a new Category</h4>
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>

        <div class="form-horizontal">
            <hr />
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
                    <asp:Button runat="server" ID="AddButton" Text="Add" CssClass="btn btn-info btn-md" Width="120px" OnClick="AddButton_Click1" />
                    <asp:Button runat="server" ID="DeleteButton" Text="Delete" CssClass="btn btn-info btn-md" Width="120px" OnClick="DeleteButton_Click"/>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-offset-1 col-md-12">
                    <br />
                    <asp:GridView ID="CategoiresGridView" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="10" ForeColor="Black" GridLines="Horizontal" AllowPaging="True" PageSize="2" CellSpacing="10" OnPageIndexChanging="CategoiresGridView_PageIndexChanging" OnSelectedIndexChanged="CategoiresGridView_SelectedIndexChanged">
                        <Columns>
                            <asp:TemplateField HeaderText="Serial No" ItemStyle-Width="130">
                                <ItemTemplate>
                                    <asp:Label ID="lblSerialNo" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="130px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Code" HeaderText="Category Code" />
                            <asp:BoundField DataField="Name" HeaderText="Category Name" />
                            <asp:CommandField HeaderText="Action" SelectText="Edit" ShowSelectButton="True">
                                <ItemStyle ForeColor="#CC0000" />
                            </asp:CommandField>
                        </Columns>
                        <PagerStyle Font-Bold="true" Font-Size="Small" ForeColor="#3399FF" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
