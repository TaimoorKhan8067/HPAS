<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Student.Master" AutoEventWireup="true" CodeBehind="StudentViewMessBill.aspx.cs" Inherits="Hostel_Managment.Views.StudentViewMessBill" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/gatepass.css" rel="stylesheet" />
    <link href="../css/Bootstrap/bootstrap.min.css" rel="stylesheet" />
    <script src="../js/Bootstrap/bootstrap.min.js"></script>
<style type="text/css">
    .auto-style3 {
        margin-top: 0px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

    <div class="row align-items-center">
    <div class="col-lg-6 col-md-12">
     <h1>Students Mess Bill</h1>
        <asp:GridView ID="studentGetData" runat="server" AutoGenerateColumns="False" ItemStyle-HorizontalAlign="Right" CellPadding="4" ForeColor="#333333" GridLines="None" Width="972px" CssClass="auto-style3">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="dateGenerated" HeaderText="Date Generated">
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="deadline" HeaderText="Deadline" >
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="billAmount" HeaderText="Bill Amount" >
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="fine" HeaderText="Fine" >
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
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
  </div>
</asp:Content>
