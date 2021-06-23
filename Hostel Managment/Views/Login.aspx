<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Hostel_Managment.Views.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link
      rel="stylesheet"
      href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"
      integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T"
      crossorigin="anonymous"
    />
    
    <link href="../css/login_styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <section class="Form my-2 mx-5">
            <div class="container">
              <div class="row no-gutters">
                <div class="col-lg-5">
                  <img src="../images/login_sidenav.jpg" class="img-fluid" />
                </div>

                <div class="col-lg-7 px-5 pt-5">
                  <h1 class="font-weight-bold py-3" style="text-align:center">FAST CFD HOSTELS</h1>
                  <h4>Sign into your account</h4>
                    <div class="form-row">
                      <div class="col-lg-7">
                          <asp:TextBox ID="rollno" CssClass="input" type="text" placeholder="Username" runat="server"></asp:TextBox>
                      </div>
                    </div>
                    <div class="form-row">
                      <div class="col-lg-7">
                         <asp:TextBox ID="password" CssClass="input" type="password" placeholder="Password" runat="server"></asp:TextBox>
                      </div>
                    </div>
                    <div class="form-row">
                      <div class="col-lg-7">
                          <div id ="button">
                          <asp:Button ID="login" CssClass="login" runat="server" Text="Login" OnClick="login_Click" BackColor="Black" Height="36px" Width="116px" ForeColor="White" />
                      </div>
                          </div>
                    </div>
                    <div>

                  <asp:Label ID="error_msg" runat="server" Text="Label" ForeColor="Red"></asp:Label>

                    </div>
                    <a href="#">Forgot Password</a>
                    
                  
                </div>
               </div>
               </div>
        
              </section>
        </div>
    </form>
</body>
</html>
