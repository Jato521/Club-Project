<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clubs.aspx.cs" Inherits="CIS5800_Project.clubs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
     <title>Clubs</title>
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
          
               <h1 class="section-heading">Club List</h1>

               <!--Club list-->
               <asp:Table ID="clubListTable" runat="server">
                    <asp:TableHeaderRow>
                         <asp:TableHeaderCell>Club Name</asp:TableHeaderCell>
                         <asp:TableHeaderCell>Club Location</asp:TableHeaderCell>
                         <asp:TableHeaderCell>Club Description</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
               </asp:Table>
          

               <div class="carousel slide" data-ride="carousel">
                    <div class="carousel-inner">
                         <div class="carousel-item active">
                              <img src="images/club-carousel1.jpg" class="d-block w-100" alt="archery"/>
                         </div>
                         <div class="carousel-item">
                              <img src="images/club-carousel2.jpg" class="d-block w-100" alt="finance"/>
                         </div>
                         <div class="carousel-item">
                              <img src="images/club-carousel3.jpg" class="d-block w-100" alt="computer"/>
                         </div>
                    </div>
               </div>
               <footer>
                    Copyright 2019 &copy 
               </footer>
          </div>
     </form>

     <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
     <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
     <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
</body>
</html>

