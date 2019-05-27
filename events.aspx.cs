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
     public partial class events : System.Web.UI.Page
     {
          string connectionString = "Server=den1.mssql7.gear.host;" +
                        "Initial Catalog=cis5800db;" +
                        "User ID=cis5800db;" +
                        "Password=Jq25_RsP_KUD;" +
                        "Integrated Security=false";

          protected void Page_Load(object sender, EventArgs e)
          {
               //welcome message for guest or admins
               if (Request.IsAuthenticated)
               {                    
                    
               }
               else
               {
                    
               }

               SqlConnection connection;
               connection = new SqlConnection();

               //load the clubs in the filter option
               try
               {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    SqlCommand getClub = new SqlCommand("SELECT clubName, clubID FROM club ORDER BY clubName ASC", connection);
                    SqlDataReader dataReader = getClub.ExecuteReader();

                    //add value 0 item
                    ListItem item0 = new ListItem();
                    item0.Text = "<<Select Club>>";
                    item0.Value = "0";
                    filterDDL.Items.Add(item0);

                    while (dataReader.Read())
                    {
                         ListItem item = new ListItem();
                         item.Text = dataReader["clubName"].ToString();
                         item.Value = dataReader["clubID"].ToString();
                         filterDDL.Items.Add(item);
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

               //load all events 
               try
               {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT club.clubName, event.eventName, event.eventDate, event.eventDescription, event.eventLocation " +
                         "FROM event INNER JOIN club ON event.clubID=club.clubID "+
                         "ORDER BY event.eventDate ASC", connection);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                         TableRow row = new TableRow();
                         TableCell cell1 = new TableCell();
                         cell1.Text = dataReader["clubName"].ToString();
                         row.Cells.Add(cell1);

                         TableCell cell2 = new TableCell();
                         cell2.Text = dataReader["eventName"].ToString();
                         row.Cells.Add(cell2);

                         TableCell cell3 = new TableCell();
                         cell3.Text = dataReader["eventDate"].ToString();
                         row.Cells.Add(cell3);

                         TableCell cell4 = new TableCell();
                         cell4.Text = dataReader["eventDescription"].ToString();
                         row.Cells.Add(cell4);

                         TableCell cell5 = new TableCell();
                         cell5.Text = dataReader["eventLocation"].ToString();
                         row.Cells.Add(cell5);

                         /*admin functions: edit and delete
                         if (Request.IsAuthenticated)
                         {
                              //config button
                              TableCell cell6 = new TableCell();                              
                              Button configButton = new Button();
                              cell6.Controls.Add(configButton);
                              configButton.Text = "Change/Delete";
                              configButton.Click += new EventHandler(configButton_Click);
                              row.Cells.Add(cell6);

                              /*delete button
                              TableCell cell7 = new TableCell();
                              Button deleteButton = new Button();
                              cell7.Controls.Add(deleteButton);
                              deleteButton.Text = "Delete";                              
                              deleteButton.Click += new EventHandler(deleteButton_Click);
                              //deleteButton.OnClientClick = "confirmDelete()"; //link to JS 
                              row.Cells.Add(cell7);
                              
                         }                    
                         */

                         clubEventTable.Rows.Add(row);
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

          protected void filterDDL_SelectedIndexChanged(object sender, EventArgs e)
          {

          }

          protected void filterButton_Click(object sender, EventArgs e)
          {
               SqlConnection connection;
               connection = new SqlConnection();
               try
               {
                    //remove all rows except header
                    while (clubEventTable.Rows.Count > 1)
                    {
                         clubEventTable.Rows.RemoveAt(1);
                    }

                    connection.ConnectionString = connectionString;
                    connection.Open();
                    SqlCommand filter = new SqlCommand("SELECT club.clubName, event.eventName, event.eventDate, event.eventDescription, event.eventLocation " +
                         "FROM event INNER JOIN club " +
                         "ON event.clubID=club.clubID " +
                         "WHERE club.clubID='" + filterDDL.SelectedValue + "'", connection);
                    SqlDataReader dataReader = filter.ExecuteReader();                    

                    while (dataReader.Read())
                    {
                         TableRow row = new TableRow();
                         TableCell cell1 = new TableCell();
                         cell1.Text = dataReader["clubName"].ToString();
                         row.Cells.Add(cell1);

                         TableCell cell2 = new TableCell();
                         cell2.Text = dataReader["eventName"].ToString();
                         row.Cells.Add(cell2);

                         TableCell cell3 = new TableCell();
                         cell3.Text = dataReader["eventDate"].ToString();
                         row.Cells.Add(cell3);

                         TableCell cell4 = new TableCell();
                         cell4.Text = dataReader["eventDescription"].ToString();
                         row.Cells.Add(cell4);

                         TableCell cell5 = new TableCell();
                         cell5.Text = dataReader["eventLocation"].ToString();
                         row.Cells.Add(cell5);

                         clubEventTable.Rows.Add(row);
                    }
                    filterDDL.Visible = false;
                    filterButton.Visible = false;
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

          /*
          protected void configButton_Click(object sender, EventArgs e)
          {
               Response.Redirect("configEvent.aspx");
          }

          protected void deleteButton_Click(object sender, EventArgs e)
          {

               Response.Redirect("configureEvent.aspx");
               
               string confirmValue = Request.Form["confirmValue"];
               if (confirmValue=="true")
               {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Event Deleted')", true);                                                  
               }
               else
               {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Event Not Deleted')", true);
               }
          }
          */
     }
}
