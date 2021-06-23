<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Employee.Master" AutoEventWireup="true" CodeBehind="ViewAttandence.aspx.cs" Inherits="Hostel_Managment.Views.ViewAttandence" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../css/gatepass.css" rel="stylesheet" />
    <link href="../css/Bootstrap/bootstrap.min.css" rel="stylesheet" />
    <script src="../js/Bootstrap/bootstrap.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
  
   <div class="row align-items-center">
    <div class="col-lg-6 col-md-12">
     <h1>Monthly Attandence</h1>
        <asp:GridView ID="passdata" runat="server" AutoGenerateColumns="False" ItemStyle-HorizontalAlign="Right" CellPadding="4" ForeColor="#333333" GridLines="None" Width="670px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Date" HeaderText="Date">
                </asp:BoundField>
                <asp:BoundField DataField="Bill Amount" HeaderText="Bill Amount" />
                <asp:BoundField DataField="Amount Paid" HeaderText="Amount Paid" />
                <asp:BoundField DataField="Remaining Amount" HeaderText="Remaining Amount" />
                <asp:BoundField DataField="Fine" HeaderText="Fine" />
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
