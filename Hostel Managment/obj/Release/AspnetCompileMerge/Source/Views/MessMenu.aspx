<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="MessMenu.aspx.cs" Inherits="Hostel_Managment.Views.MessMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
         <link href="../css/gatepass.css" rel="stylesheet" />
    <link href="../css/Bootstrap/bootstrap.min.css" rel="stylesheet" />
    <script src="../js/Bootstrap/bootstrap.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <div class="card-header py-3">
                            <h6 class="text-primary m-0 font-weight-bold">Mess Menu</h6>
  
              </div>
    <asp:Label runat="server" Text="Month"  CssClass="leftalign text-center" ></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server" Height="36px" Width="116px" CssClass="rightalign text-center" AutoPostBack = "true" style="margin-top:10px; margin-bottom:10px; margin-right:10px;" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem Text="Week 1 " Value="1"></asp:ListItem>
            <asp:ListItem Text="Week 2" Value="2"></asp:ListItem>
            <asp:ListItem Text="Week 3" Value="3"></asp:ListItem>
            <asp:ListItem Text="Week 4" Value="4"></asp:ListItem>
    </asp:DropDownList>
    <asp:Label runat="server" Text="Week" CssClass="rightalign text-center" style="margin-top:18px; margin-right:3px"></asp:Label>
    
    <asp:DropDownList ID="DropDownList2" runat="server" Height="36px" Width="116px" CssClass="leftalign text-center" AutoPostBack = "true" style="margin-top:10px; margin-bottom:10px; margin-right:10px; " OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
        <asp:ListItem Text="January" Value="1"></asp:ListItem>
            <asp:ListItem Text="February" Value="2"></asp:ListItem>
            <asp:ListItem Text="March" Value="3"></asp:ListItem>
            <asp:ListItem Text="April" Value="4"></asp:ListItem>
        <asp:ListItem Text="May" Value="5"></asp:ListItem>
            <asp:ListItem Text="June" Value="6"></asp:ListItem>
            <asp:ListItem Text="July" Value="7"></asp:ListItem>
            <asp:ListItem Text="August" Value="8"></asp:ListItem>
        <asp:ListItem Text="September" Value="9"></asp:ListItem>
        <asp:ListItem Text="October" Value="10"></asp:ListItem>
            <asp:ListItem Text="November" Value="11"></asp:ListItem>
            <asp:ListItem Text="December" Value="12"></asp:ListItem>
    </asp:DropDownList>
     
                        <div class="card-body flex-grow-0">
                            <div class="table-responsive" >
                                 <asp:GridView ID="GridView1" CssClass="table" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdated="GridView1_RowUpdated" OnRowUpdating="GridView1_RowUpdating">
                      <Columns>
                          <asp:TemplateField HeaderText="Day" >
                              <ItemTemplate>  
                        <asp:Label ID="day" runat="server" Text='<%#Eval("day") %>'></asp:Label>  
                    </ItemTemplate>  
                          <ItemStyle Font-Bold="True" />
                          </asp:TemplateField>
                         
                          <asp:TemplateField HeaderText="Breakfast">
                               <ItemTemplate>  
                        <asp:Label ID="menubreakfast" runat="server" Text='<%#Eval("menubreakfast") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_menubreakfast" runat="server" Text='<%#Eval("menubreakfast") %>'></asp:TextBox>  
                    </EditItemTemplate> 
                          </asp:TemplateField>
                         
                          
                          <asp:TemplateField HeaderText="Points">
                               <ItemTemplate>  
                        <asp:Label ID="pointbreakfast" runat="server" Text='<%#Eval("pointbreakfast") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_pointbreakfast" runat="server" Text='<%#Eval("pointbreakfast") %>'></asp:TextBox>  
                    </EditItemTemplate> 
                          </asp:TemplateField>
                         
                          
                          <asp:TemplateField HeaderText="Lunch">
                               <ItemTemplate>  
                        <asp:Label ID="menulunch" runat="server" Text='<%#Eval("menulunch") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_menulunch" runat="server" Text='<%#Eval("menulunch") %>'></asp:TextBox>  
                    </EditItemTemplate> 
                          </asp:TemplateField>
                         

                          
                          <asp:TemplateField HeaderText="Points">
                               <ItemTemplate>  
                        <asp:Label ID="pointlunch" runat="server" Text='<%#Eval("pointlunch") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_pointlunch" runat="server" Text='<%#Eval("pointlunch") %>'></asp:TextBox>  
                    </EditItemTemplate> 
                          </asp:TemplateField>
                         
                          
                          <asp:TemplateField HeaderText="Dinner">
                               <ItemTemplate>  
                        <asp:Label ID="menudinner" runat="server" Text='<%#Eval("menudinner") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_menudinner" runat="server" Text='<%#Eval("menudinner") %>'></asp:TextBox>  
                    </EditItemTemplate> 
                          </asp:TemplateField>
                         

                             
                          <asp:TemplateField HeaderText="Points">
                               <ItemTemplate>  
                        <asp:Label ID="pointdinner" runat="server" Text='<%#Eval("pointdinner") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_pointdinner" runat="server" Text='<%#Eval("pointdinner") %>'></asp:TextBox>  
                    </EditItemTemplate> 
                          </asp:TemplateField>
                         



                           <asp:TemplateField>  
                    <ItemTemplate>  
                        <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" />  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update"/>  
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>  
                    </EditItemTemplate>  
                </asp:TemplateField>  
                      </Columns>
 
                  </asp:GridView>
                            </div>
                        </div>
                  
</asp:Content>
