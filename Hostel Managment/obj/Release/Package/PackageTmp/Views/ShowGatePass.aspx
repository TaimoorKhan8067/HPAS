<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Parent.Master" AutoEventWireup="true" CodeBehind="ShowGatePass.aspx.cs" Inherits="Hostel_Managment.Views.ShowGatePass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/gatepass.css" rel="stylesheet" />
    <link href="../css/Bootstrap/bootstrap.min.css" rel="stylesheet" />
    <script src="../js/Bootstrap/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row align-items-center">
    <div class="col-lg-6 col-md-12">
     <h1>Students Gate Pass</h1>
        <asp:GridView ID="passdata" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="passdata_RowDataBound" Width="670px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Description" HeaderText="Description">
                <HeaderStyle Width="50%" />
                </asp:BoundField>
                <asp:BoundField DataField="Status" HeaderText="Status" NullDisplayText="50%" />
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
