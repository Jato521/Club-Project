<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CIS5800_Project.index1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Homepage</title>
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

               <div class="background-hero">
                    <h1>Baruch College<br />Club Page</h1>
                    <hr />
                    <a class="btn btn-dark btn-lg" href="signup.aspx" role="button">Join our mailing list</a>
                    <a class="btn btn-secondary btn-lg" href="clubs.aspx" role="button">See our clubs</a>
                    <a class="btn btn-primary btn-lg" href="events.aspx" role="button">Attend an event</a>
               </div>
               <footer>
                    Copyright 2019 &copy 
               </footer>
          </div>     
     </form>
     
</body>
</html>
