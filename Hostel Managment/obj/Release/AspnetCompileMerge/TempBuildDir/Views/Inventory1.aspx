<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="Inventory1.aspx.cs" Inherits="Hostel_Managment.Views.Inventory1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/gatepass.css" rel="stylesheet" />
    <link href="../css/Bootstrap/bootstrap.min.css" rel="stylesheet" />
    <script src="../js/Bootstrap/bootstrap.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
     <%-- <div class="col-xl-7">  
<asp:TextBox ID="txtSearch" runat="server" />
<asp:Button Text="Search" runat="server" OnClick="Unnamed_Click" />
          </div>--%>
      <h1 >Inventory</h1>
    <asp:Button ID="add_new" runat="server" Text="Add New" CssClass="btn btn-primary" OnClick="add_new_Click" />

    <div>
            <div class="row">  
         <div class="col-sm-8">

         </div>
         <div class="col-sm-4">
             <div class="search-box" >
                 <div style="float:left" >
                     <asp:TextBox ID="TextBox1"  placeholder="Name"   runat="server" ></asp:TextBox>
                 </div>
                 <div style="float:left; margin-right:auto" >
                     <asp:Button ID="Button5" CssClass="btn-dark" runat="server" Text="search" OnClick="Button5_Click" ></asp:Button>
                 </div>
             </div>
         </div>
     </div>
        </div>

    <div runat="server" id="tablerequests">
        <asp:GridView ID="inventory" runat="server" CssClass="table table-stripped table-bordered" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="passrequests_RowCommand">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID" />
            <asp:BoundField DataField="name" HeaderText="Name" />
            <asp:BoundField DataField="category" HeaderText="Category" />
            <asp:BoundField DataField="stock" HeaderText="Stock" />
  <%--          <asp:BoundField DataField="qty" HeaderText="Qty" />
            <asp:BoundField DataField="price" HeaderText="Total Price" />--%>
            <asp:ButtonField CommandName="edit_details" HeaderText="Edit" Text="Edit">
            <ItemStyle BackColor="#009933" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="delete_details" HeaderText="Delete" Text="Delete">
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
    <div runat="server" id="norecords">
        <h2 style="text-align:center; color:red">No Records Found</h2>
    </div>
    
    <div id="update_div" runat="server">
        <div id="headerdiv">
            <h1>Update Details</h1>
        </div>
        <div id="contentdiv">
            <div id="id_update">
            <asp:Label ID="Label4" runat="server" Text="ID:"></asp:Label>
            <asp:Label ID="id_lbl" runat="server" Text=""></asp:Label>
                </div>
            <div id="name_update">
            <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="nametxt_update" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            <div id="cat_drp">
            <asp:Label ID="Label2" runat="server" Text="Category" ></asp:Label>
            <asp:DropDownList ID="update_cat_drp" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            <div id="stock_update">
            <asp:Label ID="Label3" runat="server" Text="Stock"></asp:Label>
            <asp:TextBox ID="stock_txt_update" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
        </div>
        <div id="footerdiv">
            <asp:Button ID="update" runat="server" CssClass="btn btn-success"  Text="Update" OnClick="update_Click" />
            <asp:Button ID="close" runat="server"  CssClass="btn btn-danger" Text="Close" OnClick="close_Click" />
        </div>
    </div>
       <div id="delete_div" runat="server">
        <div id="header_delete_div">
            <h1>Delete Item</h1>
        </div>
        <div id="content_delete_div">
            <div id="id_delete">
            <asp:Label ID="Label5" runat="server" Text="ID:"></asp:Label>
            <asp:Label ID="delete_id_lbl" runat="server"></asp:Label>
            <h3>Are you sure you want to delete</h3>
                </div>
        </div>
        <div id="footer_delete_div">
            <asp:Button ID="Button1" runat="server" CssClass="btn btn-success"  Text="Yes" OnClick="Button1_Click"/>
            <asp:Button ID="Button2" runat="server"  CssClass="btn btn-danger" Text="No" OnClick="Button2_Click" />
        </div>
    </div>
     <div id="insert_div" runat="server">
        <div id="insert_headerdiv">
            <h1>Insert Item</h1>
        </div>
        <div id="insert_contentdiv">
            <div id="name_insert">
            <asp:Label ID="Label8" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="name_insert_txt" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            <div id="cat_insert">
            <asp:Label ID="Label9" runat="server" Text="Category" ></asp:Label>
            <asp:DropDownList ID="cat_insert_drp" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            <div id="stock_insert">
            <asp:Label ID="Label10" runat="server" Text="Stock"></asp:Label>
            <asp:TextBox ID="stock_insert_txt" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
        </div>
        <div id="insert_footerdiv">
            <asp:Button ID="Button3" runat="server" CssClass="btn btn-success"  Text="Insert" OnClick="Button3_Click"  />
            <asp:Button ID="Button4" runat="server"  CssClass="btn btn-danger" Text="Close" OnClick="Button4_Click" />
        </div>
    </div>
    </asp:Content>