using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;

namespace CIS5800_Project
{     
     public partial class login : System.Web.UI.Page
     {
          

          protected void Page_Load(object sender, EventArgs e)
          {
               if (!Page.IsPostBack)
               {
                    try
                    {
                         MembershipUser newUser = Membership.CreateUser("sladmin", "slpw", "", null, null, true, out MembershipCreateStatus status);
                    }
                    catch (Exception ex)
                    {
                         Response.Write(ex);
                    }
               }
          }

          protected void loginButton_Click(object sender, EventArgs e)
          {
               string connectionString = "Server=den1.mssql7.gear.host;" +
                    "Initial Catalog=cis5800db;" +
                    "User ID=cis5800db;" +
                    "Password=Jq25_RsP_KUD;" +
                    "Integrated Security=false";
               SqlConnection connection;
               connection = new SqlConnection();
               connection.ConnectionString = connectionString;

               try
               {
                    string username = userTB.Text;
                    string pass = pwTB.Text;      
                    connection.Open();

                    //student life
                    if (username=="sladmin" && pass == "slpw")
                    {
                         //allow acccess to pages based on what is in the clubAdmin table
                         FormsAuthentication.SetAuthCookie(userTB.Text, rememberMe.Checked);

                         //regular admins, redirect to events
                         Response.Redirect("adminManagement.aspx");
                    }
                    else {
                         
                         string query = "SELECT username, password FROM club WHERE username='" + username + "' AND password='" + pass + "'";
                         SqlCommand command = new SqlCommand(query, connection);
                         SqlDataReader reader = command.ExecuteReader();

                         //if username and password is correct
                         if (reader.Read())
                         {
                              //set up cookie for determining which club is logged in (who can add/edit/delete which events)
                              HttpCookie cookieVariable = new HttpCookie("logUser", username);
                              Response.Cookies.Add(cookieVariable);
                              
                              //allow acccess to pages based on what is in the clubAdmin table
                              FormsAuthentication.SetAuthCookie(userTB.Text, rememberMe.Checked);
                              
                              //regular admins, redirect to events
                              Response.Redirect("events.aspx");
                         }

                         //if incorrect
                         else
                         {
                              failedLogin.Text = "Login Failed. Wrong Username or Password.";
                         }
                    }
               }
               catch (Exception exception)
               {
                    Response.Write(exception.Message);
               }
               finally
               {
                    connection.Close();
               }
          }
     }
}