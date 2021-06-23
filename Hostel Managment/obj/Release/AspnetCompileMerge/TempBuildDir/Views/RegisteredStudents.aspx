<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="RegisteredStudents.aspx.cs" Inherits="Hostel_Managment.Views.RegisteredStudents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/gatepass.css" rel="stylesheet" />
    <link href="../css/Bootstrap/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <script src="../js/Bootstrap/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <h1 >Registered Students</h1>
     <div class="row">  
         <div class="col-sm-8">

         </div>
         <div class="col-sm-4">
             <div class="search-box" >
                 <div style="float:left" >
                     <asp:TextBox ID="TextBox1"  placeholder="Roll No"   runat="server" ></asp:TextBox>
                 </div>
                 <div style="float:left; margin-right:auto" >
                     <asp:Button ID="Button1" CssClass="btn-dark" runat="server" Text="search" ></asp:Button>
                 </div>
             </div>
         </div>
     </div>

    <div runat="server" id="tablerequests">
        <asp:GridView ID="passrequests" runat="server" CssClass="table table-stripped table-bordered" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="passrequests_RowCommand" OnSelectedIndexChanged="passrequests_SelectedIndexChanged" OnRowDataBound="passrequests_RowDataBound">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="rollNo" HeaderText="RollNo" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="studentName" HeaderText="Student Name" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:ButtonField CommandName="reject" HeaderText="Status" DataTextField="status" Text="aaa">
            <ItemStyle BackColor="Red" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:ButtonField>
            <asp:BoundField DataField="black" HeaderText="black" Visible="False" />
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
</asp:Content>
