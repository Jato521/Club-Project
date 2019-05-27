<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="CIS5800_Project.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Login</title>
     <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous"/>
     <link rel="stylesheet" href="master.css" />
</head>

<body>
     <form id="form1" runat="server">
          <div class="container-fluid">
               <nav class="navbar navbar-expand-lg navbar-light bg-light justify-content-center fixed-top">
                    <ul class="navbar-nav">
                         <li class="nav-item active">
                              <a class="nav-link" href="index.aspx">Home</a>
                         </li>
                         <li class="nav-item">
                              <a class="nav-link" href="clubs.aspx">Clubs</a>
                         </li>
                         <li class="nav-item">
                              <a class="nav-link" href="events.aspx">Events</a>
                         </li>
                         <li class="nav-item">
                              <a class="nav-link" href="signup.aspx">Join</a>
                         </li>
                         <li class="nav-item">
                              <asp:LoginView runat="server" ID="loginNav">
                                   <AnonymousTemplate>
                                        <a class="nav-link" href="login.aspx">Login</a>
                                   </AnonymousTemplate>
                                   <LoggedInTemplate>
                                        <asp:LoginStatus ID="loginStatus" runat="server" LogoutAction="Redirect" LogoutPageUrl="logout.aspx" CssClass="nav-link" />
                                   </LoggedInTemplate>
                              </asp:LoginView>
                         </li>
                    </ul>
               </nav>

               <h1 class="section-heading">Login</h1>          
			<div id="loginDiv">             
                    <b>Username</b><br /> <asp:TextBox ID="userTB" runat="server"></asp:TextBox><br /><br />
                    <b>Password</b><br /> <asp:TextBox ID="pwTB" runat="server" TextMode="Password"></asp:TextBox><br /><br />
                    <b>Remember Me:</b> <asp:CheckBox ID="rememberMe" runat="server" /><br /><br />
                    <asp:Button ID="loginButton" runat="server" OnClick="loginButton_Click" Text="Log In" />
                    <br />
                    <asp:Label ID="failedLogin" runat="server"></asp:Label>
			</div>	

               <footer>
                    Copyright 2019 &copy 
               </footer>
          </div>
     </form>
</body>
</html>
