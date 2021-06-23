<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Student.Master" AutoEventWireup="true" CodeBehind="complaintform.aspx.cs" Inherits="Hostel_Managment.Views.complaintform" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <div class="container">
	<div class="row">
		<center><h2> Complaints Or Suggestions</h2></center>
        <div class="col-md-4"></div>
        <div class="col-md-4">
            <div class="panel panel-default">
                    <div class="panel-body">
                        <form>
                            <table class="table">
                             
                                <tr>
                                    <td>
                                          <asp:TextBox ID="TextBox2" runat="server" type="text" Cssclass="form-control"  placeholder="Subject"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox runat="server" Cssclass="form-control" TextMode="MultiLine" placeholder="Message text . . ."></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                             <asp:Button ID="Button2" runat="server"  Cssclass="btn btn-primary btn-sm" Text="Send" style="width: 100%;" OnClick="Button2_Click"/>

                                    </td>
                                </tr>
                            </table>

                        </form>
                    </div>
                </div>

            </div>

        </div>
	</div>

</asp:Content>
