<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="ViewGatePass.aspx.cs" Inherits="Hostel_Managment.Views.ViewGatePass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link href="../css/gatepass.css" rel="stylesheet" />
    <link href="../css/Bootstrap/bootstrap.min.css" rel="stylesheet" />
    <script src="../js/Bootstrap/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

    
    <div style="height:5%"></div>
     <div class="row">
                            <div class="col-xl-3 col-md-6">
                                <div class="card bg-primary text-white mb-4">
                                    <div class="card-body"> All Gate Passes  
                                        <asp:Label ID="allcount" runat="server" Text=""></asp:Label>
                                    </div>
                                   
                                    <div class="card-footer d-flex align-items-center justify-content-between">
                                        <asp:LinkButton ID="allgatepass" CssClass="small text-white stretched-link" OnClick="allgatepass_Click" runat="server">View Details</asp:LinkButton>
                                        <div class="small text-white"><i class="fas fa-angle-right"></i></div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-3 col-md-6">
                                <div class="card bg-warning text-white mb-4">
                                    <div class="card-body">Pending Gate Passes
                                        <asp:Label ID="pendingcount" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="card-footer d-flex align-items-center justify-content-between">
                                         <asp:LinkButton ID="pendinggatepass" CssClass="small text-white stretched-link" OnClick="pendinggatepass_Click" runat="server">View Details</asp:LinkButton>
                                        <div class="small text-white"><i class="fas fa-angle-right"></i></div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-3 col-md-6">
                                <div class="card bg-success text-white mb-4">
                                    <div class="card-body">Approved Gate Passes
                                        <asp:Label ID="approvecount" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="card-footer d-flex align-items-center justify-content-between">
                                      <asp:LinkButton ID="approved" CssClass="small text-white stretched-link" OnClick="approved_Click" runat="server">View Details</asp:LinkButton>
                                        <div class="small text-white"><i class="fas fa-angle-right"></i></div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-3 col-md-6">
                                <div class="card bg-danger text-white mb-4">
                                    <div class="card-body">Rejected Gate Passes
                                        <asp:Label ID="rejectcount" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="card-footer d-flex align-items-center justify-content-between">
                                      <asp:LinkButton ID="rejectedgatepass" CssClass="small text-white stretched-link" OnClick="rejectedgatepass_Click" runat="server">View Details</asp:LinkButton>
                                        <div class="small text-white"><i class="fas fa-angle-right"></i></div>
                                    </div>
                                </div>
                            </div>
                        </div>
      
    <div runat="server" id="tablerequests">
 
        <h1 >Gate Passes</h1>

        <div>
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
        </div>
        <asp:GridView ID="passrequests" runat="server" CssClass="table table-stripped table-bordered" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="RollNo" HeaderText="RollNo" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:BoundField DataField="Duration" HeaderText="Duration" />
            <asp:BoundField DataField="Status" HeaderText="Status" />
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
        <h2 style="text-align:center; color:green">No Gate Passes</h2>
    </div>

</asp:Content>
