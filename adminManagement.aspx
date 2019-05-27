<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminManagement.aspx.cs" Inherits="CIS5800_Project.adminManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Admin Management</title>
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
                         
               <div class="management-content">
                    <asp:Panel runat="server" ID="addPanel">
                         <h1 class="section-heading">Add Club:</h1>
                         
                         <div class="form-group">
                              <label for="newName">Club Name</label>
                              <asp:TextBox runat="server" ID="newName" CssClass="form-control"></asp:TextBox>
                         </div> 
                         <div class="form-group">
                              <label for="newLocation">Club Location</label>
                              <asp:TextBox runat="server" ID="newLocation" CssClass="form-control"></asp:TextBox>
                         </div>
                         <div class="form-group">
                              <label for="newDescription">Club Description</label>
                              <asp:TextBox runat="server" ID="newDescription" CssClass="form-control"></asp:TextBox>
                         </div>
                         <div class="form-group">
                              <label for="newUser">Admin Username</label>
                              <asp:TextBox runat="server" ID="newUser" CssClass="form-control"></asp:TextBox>
                         </div>
                         <div class="form-group">
                              <label for="newPW">Admin Password</label>
                              <asp:TextBox runat="server" ID="newPW" CssClass="form-control"></asp:TextBox>
                         </div>
                         <asp:Button runat="server" ID="submitAdd" OnClick="submitAdd_Click" Text="Add Club" CssClass="btn btn-primary btn-lg btn-block"/>
                    </asp:Panel>
               </div>

               <div class="management-content">
                    <asp:Panel runat="server" ID="deletePanel">
                         <h1 class="section-heading">Delete Club:</h1>
                         <asp:DropDownList runat="server" ID="deleteDDL">
                              <asp:ListItem Value="0" Text="<<Select Club And Admin To Delete>>"></asp:ListItem>
                         </asp:DropDownList>
                         <p class="warning">Warning: Club and admin will be deleted without additional prompting.</p>
                         <asp:Button runat="server" ID="submitDelete" OnClick="submitDelete_Click" Text="Delete Club" CssClass="btn btn-primary btn-lg btn-block"/><br />
                         <br />
                    </asp:Panel>
               </div>          
               <footer>
                    Copyright 2019 &copy 
               </footer>
          </div>
     </form>
</body>
</html>
