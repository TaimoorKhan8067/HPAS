<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="GatePassLimits.aspx.cs" Inherits="Hostel_Managment.Views.GatePassLimits" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="../css/gatepass.css" rel="stylesheet" />
    <link href="../css/Bootstrap/bootstrap.min.css" rel="stylesheet" />
    <script src="../js/Bootstrap/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <div class="alert alert-warning alert-dismissible" id="pending" runat="server">
  <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
  <strong>Pending!</strong> The Limit is saved and  will be updated tomorrow.
</div>
     <h1 >GATE PASS LIMITS</h1>
    <div runat="server" id="tablelimits">
        <asp:GridView ID="inventory" runat="server"   CssClass="table table-stripped table-bordered" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="inventory_RowCommand">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID" />
            <asp:BoundField DataField="day" HeaderText="Day" />
            <asp:BoundField DataField="limit" HeaderText="Limit" />
            <asp:ButtonField CommandName="edit_details" HeaderText="Edit" Text="Edit">
            <ItemStyle BackColor="#009933" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:ButtonField>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
        </div>
    <div runat="server" id="norecords">
    </div>
    
    <div id="update_div" runat="server">
        <div id="headerdiv">
            <h1>Update Limits</h1>
            <asp:Label ID="Label2" runat="server" Text="Enter -1 for No Limit Set" ForeColor="Green"></asp:Label>
        </div>
        <div id="contentdiv">
            <div id="id_update">
            <asp:Label ID="Label4" runat="server" Text="ID:"></asp:Label>
            <asp:Label ID="id_lbl" runat="server" Text=""></asp:Label>
                </div>
            <div id="name_update">
            <asp:Label ID="Label1" runat="server" Text="Day:"></asp:Label>
            <asp:Label ID="name_lbl" runat="server" Text=""></asp:Label>
                </div>
            <div id="limit_update">
            <asp:Label ID="Label3" runat="server" Text="Limit"></asp:Label>
            <asp:TextBox ID="limit_txt_update" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
        </div>
        <div id="footerdiv">
            <asp:Button ID="update" runat="server" CssClass="btn btn-success"  Text="Update" OnClick="update_Click"  />
            <asp:Button ID="close" runat="server"  CssClass="btn btn-danger" Text="Close" OnClick="close_Click" />
           
        </div>
    </div>
</asp:Content>
