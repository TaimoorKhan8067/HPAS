<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="Hostel_Managment.Views.AddEmployee" %>
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
            
        <div>
      
        <div class="form-inline mx-sm-3 mb-2">
         <h4><asp:Label ID="Label1" runat="server" Text="Name : "></asp:Label></h4>
               <div style="width:5%">  
    </div>
            <asp:TextBox ID="name" runat="server" ></asp:TextBox> 

         <div class="form-inline mx-sm-3 mb-2">
         <h4><asp:Label ID="Label2" runat="server" Text="Designation : "></asp:Label></h4>
               <div style="width:5%">  
    </div>
        <asp:Label ID="designation" runat="server" Text="***DDDD***"></asp:Label></div>
            </div>
    </div>
 
    <div class="col-lg-6 col-md-12">

    <div style="height: 200px">
  <div class="mh-200" style="width: 200px; height: 200px; background-color: rgba(0,0,255,0.1);"><img src="../EmployeeImages/emp.jpg" id="img" runat="server" alt="acsss" class="img-thumbnail"></div>
</div>
    </div>
  </div>
    
</asp:Content>
