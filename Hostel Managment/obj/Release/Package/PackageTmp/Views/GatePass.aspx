<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="GatePass.aspx.cs" Inherits="Hostel_Managment.Views.GatePass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/gatepass.css" rel="stylesheet" />
    <link href="../css/Bootstrap/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <script src="../js/Bootstrap/bootstrap.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
      <h1 >Gate Pass Requests</h1>
    <div id="table_div" runat="server">
     <div class="row">  
         <div class="col-sm-8">

         </div>
         <div class="col-sm-4">
             <div class="search-box" >
                 <div style="float:left" >
                     <asp:TextBox ID="TextBox1"  placeholder="Roll No"   runat="server" ></asp:TextBox>
                 </div>
                 <div style="float:left; margin-right:auto" >
                     <asp:Button ID="Button1" CssClass="btn-dark" runat="server" Text="search" OnClick="Button1_Click"></asp:Button>
                 </div>
             </div>
         </div>
     </div>

    <div runat="server" id="tablerequests">
        <asp:GridView ID="passrequests" runat="server" CssClass="table table-stripped table-bordered" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="passrequests_RowCommand" OnSelectedIndexChanged="passrequests_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="gatepass_id" HeaderText="ID" />
            <asp:BoundField DataField="user_id" HeaderText="RollNo" />
            <asp:BoundField DataField="username" HeaderText="Name" />
            <asp:BoundField DataField="description" HeaderText="Description" />
            <asp:BoundField DataField="duration" HeaderText="Duration" />
            <asp:ButtonField CommandName="approve" HeaderText="Approve" Text="Approve">
            <ItemStyle BackColor="#009933" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="reject" HeaderText="Reject" Text="Reject">
            <ItemStyle BackColor="Red" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
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
        </div>
    <div runat="server" id="norecords">
        <h2 style="text-align:center; color:green">No Pending Requests</h2>
    </div>
    <div id="reject_reason" runat="server" >
         <div id="headerdiv">
            <h4 >Reject Reason</h4>
        </div>
        <div id="contentdiv">
             <div id="name_update">
             <asp:Label ID="Label2" runat="server" Text="ID: "></asp:Label>
              <asp:Label ID="id_labl" runat="server" Text="ID" ForeColor="Red"></asp:Label>
                </div>
             <div id="id_update">
             <asp:Label ID="Label4" runat="server" Text="Name: "></asp:Label>
              <asp:Label ID="name" runat="server" Text="name"></asp:Label>
                </div>
               <div id="rollno_update">
             <asp:Label ID="Label3" runat="server" Text="RollNo: "></asp:Label>
              <asp:Label ID="rollno" runat="server" Text="roll"></asp:Label>
                </div>
            <div id="reason_update">
             <asp:Label ID="Label1" runat="server" Text="Reason"></asp:Label>
            <asp:TextBox ID="reason" runat="server"></asp:TextBox>
              <asp:Label ID="error" runat="server" Text="Please Provide a Valid Reason" ForeColor="Red"></asp:Label>
                </div>
            
           
        </div>
        <div id="footerdiv">
            <asp:Button ID="update" runat="server" CssClass="btn btn-danger"  Text="Reject" OnClick="update_Click" />
            <asp:Button ID="close" runat="server"  CssClass="btn btn-primary" Text="Close" OnClick="close_Click" />
        </div>
    </div>

</asp:Content>