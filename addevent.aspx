<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addevent.aspx.cs" Inherits="CIS5800_Project.addevent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Add Event</title>
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

		     <h1 class="section-heading">Add Event</h1>
               <div id="formDiv" runat="server">
                    <div class="form-group">
                         <label for="clubDDL">Name of Hosting Club</label>
                         <asp:DropDownList ID="clubDDL" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                         <label for="nameTB">Event Name</label>
                         <asp:TextBox ID="nameTB" runat="server" CssClass="form-control"/>
                    </div>
                    <div class="form-group">
                         <label>Event Date</label>
                         <div class="row">
                              <div class="col">
                                   <asp:TextBox ID="yearTB" runat="server" MaxLength="4" Placeholder="YYYY" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col">
                                   <asp:TextBox ID="monthTB" runat="server" MaxLength="2" Placeholder="MM" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col">
                                   <asp:TextBox ID="dayTB" runat="server" MaxLength="2" Placeholder="DD" CssClass="form-control"></asp:TextBox>
                              </div>
                         </div>
                    </div>
                    <div class="form-group">
                         <label>Event Time</label>
                         <div class="row">
                              <div class="col">
                                   <asp:TextBox ID="hourTB" runat="server" MaxLength="2" Placeholder="HH" CssClass="form-control"></asp:TextBox>
                              </div>
                              <div class="col">
                                   <asp:TextBox ID="minuteTB" runat="server" MaxLength="2" Placeholder="MM" CssClass="form-control"></asp:TextBox>
                              </div>
                         </div>
                    </div>
                    <div class="form-group">
                         <label for="descriptionTB">Event Description</label>
                         <asp:TextBox ID="descriptionTB" runat="server" TextMode="MultiLine" Columns="50" Rows="5" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                         <label for="locationTB">Event Location</label>
                         <asp:TextBox ID="locationTB" runat="server" CssClass="form-control" />
                    </div>
                    <asp:Button ID="addButton" runat="server" OnClick="addButton_Click" Text="Add Event" CssClass="btn btn-primary btn-lg btn-block"/>
               </div>

               <div id="successDiv" runat="server">
                   <asp:Label ID="successLabel" runat="server">Event Added!</asp:Label><br />
                   <a href="index.aspx">Click To Return To Home Page</a>
               </div>
          
               <footer>
                    Copyright 2019 &copy 
               </footer>
          </div>
     </form>
</body>
</html>
