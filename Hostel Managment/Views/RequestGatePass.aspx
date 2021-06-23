<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Student.Master" AutoEventWireup="true" CodeBehind="RequestGatePass.aspx.cs" Inherits="Hostel_Managment.Views.RequestGatePass" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/gatepass.css" rel="stylesheet" />
    <link href="../css/Bootstrap/bootstrap.min.css" rel="stylesheet" />
    <script src="../js/Bootstrap/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <div style="height=50%;">

    </div>
<div class="row align-items-center">
    <div class="col-lg-6 col-md-12">
        <div runat="server" id="formdiv">
      <h2>Request Gate Pass Details</h2>
                <form>
                    <div>
                   <asp:Label ID="Label1" runat="server" Text="Description"></asp:Label>
                    <asp:TextBox ID="Description" CssClass="form-control" placeholder="Enter Description" runat="server"></asp:TextBox>
                     </div>
                    <asp:Label ID="Label2" runat="server" Text="Duration"></asp:Label>
                  <asp:DropDownList ID="Duration" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:Button ID="btn_submit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="submit_Click"/>
                </form>
            </div>
        <div runat="server" id="notallowed">
            <h2>You have submitted today's request<br /> Come back tomorrow</h2>
            </div>
        <div runat="server" id="blacklisted">
            <h2>You are unable to request Gatepass<br />You are blacklisted by admin</h2>
            </div>
    </div>
    <div class="col-lg-6 col-md-12">
     <h1>Previous Gate Pass</h1>
        <asp:GridView ID="passdata" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="passdata_RowDataBound" Width="488px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Time Requested" HeaderText="Time Requested" />
                <asp:BoundField DataField="Description" HeaderText="Description">
                </asp:BoundField>
                <asp:BoundField DataField="reason" HeaderText="Comments" NullDisplayText="50%" />
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

  
