<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="configEvent.aspx.cs" Inherits="CIS5800_Project.configEvent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Modify/Delete Events</title>
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
          
               <h1 class="section-heading">Modify/Delete Events</h1>
               <div id="edit-delete-div">
                    <asp:DropDownList runat="server" ID="eventDDL">
                         <asp:ListItem Text="<<Select Event>>" Value="0"></asp:ListItem>
                    </asp:DropDownList>
			     <label id="warningLabel" runat="server">Warning: Event will be deleted without additional prompting.</label><br />
                    <asp:Button runat="server" ID="editButton" Text="Edit" OnClick="editButton_Click" CssClass="btn btn-primary btn-lg" />
                    <asp:Button runat="server" ID="deleteButton" Text="Delete" OnClick="deleteButton_Click" CssClass="btn btn-primary btn-lg"  />
               </div>

               <div>
                    <asp:Label runat="server" ID="eventDeleted" Visible="false">
                         Event Successfully Deleted!<br />
                    </asp:Label>
                    <asp:Label runat="server" ID="eventChanged" Visible="false">
                         Event Successfully Changed!<br />
                    </asp:Label>
               </div>

               <!--section to edit events-->
               <div id="editEventDiv">
                    <asp:Panel ID="editEventPanel" runat="server" Visible="false">
                         <div id="editFormDiv" runat="server">
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
                              <asp:Button ID="editEventButton" runat="server" Text="Finish Edit" OnClick="editEventButton_Click" CssClass="btn btn-primary btn-lg"/>
                              <asp:Button ID="cancelEdit" runat="server" Text="Cancel and Return Home" OnClick ="cancelEdit_Click" CssClass="btn btn-primary btn-lg"/>
                         </div>
                    </asp:Panel>
                    
               </div>
               
               <asp:Label ID="testLbl" runat="server"></asp:Label>
               <footer>
                    Copyright 2019 &copy 
               </footer>
          </div>
     </form>
</body>
</html>
