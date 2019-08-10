<%@ Page Title="" Language="C#" MasterPageFile="~/Librarian/Librarian.Master" AutoEventWireup="true" CodeBehind="Status.aspx.cs" Inherits="LibaryManagementSystem.Librarian.Categories.Status" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <div class="form-horizontal">
            <h3>View Categories Status</h3>
            <hr />
            <div class="form-group">
                <div class="col-md-offset-1 col-md-12">
                    <br />
                    <asp:GridView ID="CategoiresGridView" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover " AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="10" ForeColor="Black" GridLines="Horizontal" AllowPaging="True" PageSize="2" CellSpacing="10" OnPageIndexChanging="CategoiresGridView_PageIndexChanging" OnSelectedIndexChanged="CategoiresGridView_SelectedIndexChanged">
                        <Columns>
                            <asp:TemplateField HeaderText="Serial No" ItemStyle-Width="130">
                                <ItemTemplate>
                                    <asp:Label ID="lblSerialNo" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="130px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Code" HeaderText="Category Code" />
                            <asp:BoundField DataField="Name" HeaderText="Category Name" />
                            <asp:BoundField DataField="Status" HeaderText="Category Status" />
                            <asp:CommandField HeaderText="Action" SelectText="Change" ShowSelectButton="True">
                                <ItemStyle ForeColor="#CC0000" />
                            </asp:CommandField>
                        </Columns>
                        <PagerStyle Font-Bold="true" Font-Size="Small" ForeColor="#3399FF" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
    <link href="../../Content/GridviewStyle.css" rel="stylesheet" />
</asp:Content>
