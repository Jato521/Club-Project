using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace CIS5800_Project
{
     public partial class addevent : System.Web.UI.Page
     {
          string connectionString = //;
          protected void Page_Load(object sender, EventArgs e)
          {
               successDiv.Visible = false;
               
               SqlConnection connection;
               connection = new SqlConnection();               
               connection.ConnectionString = connectionString;
               connection.Open();

               try
               {
                    //cookie from login.aspx.cs, determine who is logged in
                    string cookieHere = Request.Cookies["logUser"].Value;

                    //load club ddl
                    SqlCommand getClubList = new SqlCommand("SELECT clubName, clubID FROM club WHERE username='" + cookieHere + "'", connection);
                    SqlDataReader dataReader = getClubList.ExecuteReader();
                    while (dataReader.Read())
                    {
                         ListItem item = new ListItem();
                         item.Text = dataReader["clubName"].ToString();
                         item.Value = dataReader["clubID"].ToString();
                         clubDDL.Items.Add(item);
                    }
               }
               catch(Exception ex)
               {
                    Response.Redirect("denied.aspx");
               }            
               //add value 0 item
               /*ListItem item0 = new ListItem();
               item0.Text = "<<Select Club>>";
               item0.Value = "0";
               clubDDL.Items.Add(item0);*/              
          }

          protected void addButton_Click(object sender, EventArgs e)
          {
               SqlConnection connection;
               connection = new SqlConnection();
               try
               {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    SqlCommand command = new SqlCommand("add_event", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    //update: change this from a DDL to a fixed value depending on who is logged in
                    command.Parameters.Add("@club_id", SqlDbType.Int).Value = clubDDL.SelectedValue;
                    command.Parameters.Add("@event_name", SqlDbType.NVarChar).Value = nameTB.Text;
                    command.Parameters.Add("@event_date", SqlDbType.DateTime).Value = yearTB.Text + "-" + monthTB.Text + "-" + dayTB.Text + " " + hourTB.Text + ":" + minuteTB.Text + ":00";
                    command.Parameters.Add("@event_description", SqlDbType.NVarChar).Value = descriptionTB.Text;
                    command.Parameters.Add("@event_location", SqlDbType.NVarChar).Value = locationTB.Text;
                    command.ExecuteNonQuery();

                    //print success
                    formDiv.Visible = false;
                    successDiv.Visible = true;
               }
               catch (Exception ex)
               {
                    Response.Write(ex.Message);
               }
               finally
               {
                    connection.Close();
               }
          }
     }
}
