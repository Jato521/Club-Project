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
     public partial class configEvent : System.Web.UI.Page
     {
          string connectionString = "Server=den1.mssql7.gear.host;" +
                         "Initial Catalog=cis5800db;" +
                         "User ID=cis5800db;" +
                         "Password=Jq25_RsP_KUD;" +
                         "Integrated Security=false";

          protected void Page_Load(object sender, EventArgs e)
          {
               SqlConnection connection;
               connection = new SqlConnection();

               try
               {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    try
                    {
                         //cookie from login.aspx.cs, determine who is logged in
                         string cookieHere = Request.Cookies["logUser"].Value;

                         //pull events
                         SqlCommand command = new SqlCommand("SELECT club.clubName, event.eventID, event.eventName, event.eventDate, event.eventDescription, event.eventLocation " +
                              "FROM event INNER JOIN club ON event.clubID=club.clubID WHERE club.username='" + cookieHere + "'", connection);
                         SqlDataReader dataReader = command.ExecuteReader();
                         while (dataReader.Read())
                         {
                              var item = new ListItem();
                              item.Value = dataReader["eventID"].ToString();
                              item.Text = dataReader["clubName"].ToString() + ", " + dataReader["eventName"].ToString() + ", " + dataReader["eventDate"].ToString() + ", " + dataReader["eventDescription"].ToString() + ", " + dataReader["eventLocation"].ToString();
                              eventDDL.Items.Add(item);
                         }
                    }
                    catch (Exception ex)
                    {
                         Response.Redirect("denied.aspx");
                    }
                    
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

          protected void deleteButton_Click(object sender, EventArgs e)
          {
               SqlConnection connection;
               connection = new SqlConnection();
               try
               {                    
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    SqlCommand command = new SqlCommand("delete_event", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@event_id", SqlDbType.Int).Value = eventDDL.SelectedValue;
                    command.ExecuteNonQuery();
                    if (eventDDL.SelectedValue != "0") { 
                         eventDDL.Visible = false;
                         editButton.Visible = false;
                         deleteButton.Visible = false;
                         eventDeleted.Visible = true;
                    }
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

          protected void editButton_Click(object sender, EventArgs e)
          {
               SqlConnection connection;
               connection = new SqlConnection();

               try
               {
                    editEventPanel.Visible = true;
                    eventDDL.Visible = false;
                    deleteButton.Visible = false;
                    editButton.Visible = false;
                    warningLabel.Visible = false;
                    connection.ConnectionString = connectionString;
                    connection.Open();
                                        
                    //pulling one event from DB and adding to textbox
                    string eventID = eventDDL.SelectedValue;
                    SqlCommand pullEvent = new SqlCommand("SELECT * FROM event WHERE " + eventID + "=eventID", connection);
                    SqlDataReader pullEventReader = pullEvent.ExecuteReader();
                    while (pullEventReader.Read())
                    {
                         nameTB.Text = pullEventReader["eventName"].ToString();                         
                         descriptionTB.Text = pullEventReader["eventDescription"].ToString();
                         locationTB.Text = pullEventReader["eventLocation"].ToString();

                         //date and string manipulation 
                         string datetime = pullEventReader["eventDate"].ToString();
                         string[] dateAndTime = datetime.Split(':', ' ', '/'); //will contain YYYY,MM,DD,HH,DD,SS
                         string month = dateAndTime[0];
                         //Response.Write(month);
                         string day = dateAndTime[1];
                         //Response.Write(day);
                         string year = dateAndTime[2];
                         //Response.Write(year);
                         string hour = dateAndTime[3];
                         //Response.Write(hour);
                         string minute = dateAndTime[4];
                         //Response.Write(minute);

                         //fill date
                         yearTB.Text = year;
                         monthTB.Text = month;
                         dayTB.Text = day;
                         hourTB.Text = hour;
                         minuteTB.Text = minute;                         
                    }                    
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

          protected void editEventButton_Click(object sender, EventArgs e)
          {
               SqlConnection connection;
               connection = new SqlConnection();

               try
               {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    SqlCommand command = new SqlCommand("modify_event", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@event_ID", SqlDbType.Int).Value = eventDDL.SelectedValue;
                    command.Parameters.Add("@event_name", SqlDbType.NVarChar).Value = nameTB.Text;
                    command.Parameters.Add("@event_date", SqlDbType.DateTime).Value = yearTB.Text + "-" + monthTB.Text + "-" + dayTB.Text + " " + hourTB.Text + ":" + minuteTB.Text + ":00";
                    command.Parameters.Add("@event_description", SqlDbType.NVarChar).Value = descriptionTB.Text;
                    command.Parameters.Add("@event_location", SqlDbType.NVarChar).Value = locationTB.Text;
                    command.ExecuteNonQuery();

                    //after successfully changing
                    eventDDL.Visible = false;
                    editButton.Visible = false;
                    deleteButton.Visible = false;
                    eventChanged.Visible = true;
                    editEventPanel.Visible = false;
               }
               catch(Exception ex)
               {
                    Response.Write(ex.Message);
               }
               finally
               {
                    connection.Close();
               }
          }

          protected void cancelEdit_Click(object sender, EventArgs e)
          {
               Response.Redirect("index.aspx");
          }
     }
}