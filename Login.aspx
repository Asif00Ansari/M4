<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FleetTrack.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FleetTrack  Logistics System  Login</title>
    <link href="style/login.css" rel="stylesheet" />
</head>
<body>
     <div class="frmlogin">
        <br />
      
        <h1>Login To FleetTrack</h1>
        <form id="form2" runat="server">
            <asp:TextBox ID="txtUserName" runat="server" placeholder="UserName"  ></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName" ForeColor="Red" Display="Dynamic" ErrorMessage="Please enter username." SetFocusOnError="true" />
            <asp:TextBox ID="txtPassword" runat="server" placeholder="Password"  TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ForeColor="Red" Display="Dynamic" ErrorMessage="Please enter password." SetFocusOnError="true" />
            <asp:Button ID="btnLogin" runat="server"  Text="Login" CssClass ="btn" OnClick="btnLogin_Click" />

            <asp:Label ID="lblmessage" runat="server" ForeColor="Red" Text=""></asp:Label>
            <%--<asp:Button ID="Button1" runat="server" Text="Button" style="margin-top: 0px" />--%>
        </form>
        
    </div>
</body>
</html>

