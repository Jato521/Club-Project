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
     public partial class adminManagement : System.Web.UI.Page
     {
          string connectionString = //
          protected void Page_Load(object sender, EventArgs e)
          {
               SqlConnection connection;
               connection = new SqlConnection();

               //fill delete ddl
               try
               {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    SqlCommand getAdmins = new SqlCommand("SELECT clubID, clubName, username, password FROM club", connection);
                    SqlDataReader dataReader = getAdmins.ExecuteReader();
                    while (dataReader.Read())
                    {
                         ListItem item = new ListItem();
                         item.Text = dataReader["clubName"].ToString() + ", " + dataReader["username"].ToString() + ", " + dataReader["password"].ToString();
                         item.Value = dataReader["clubID"].ToString();
                         deleteDDL.Items.Add(item);
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

          protected void submitAdd_Click(object sender, EventArgs e)
          {
               SqlConnection connection;
               connection = new SqlConnection();
               try
               {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    SqlCommand add = new SqlCommand("add_club", connection);
                    add.CommandType = CommandType.StoredProcedure;
                    add.Parameters.Add("@club_name", SqlDbType.NVarChar).Value = newName.Text;
                    add.Parameters.Add("@club_location", SqlDbType.NVarChar).Value = newLocation.Text;
                    add.Parameters.Add("@club_description", SqlDbType.NVarChar).Value = newDescription.Text;
                    add.Parameters.Add("@username", SqlDbType.NVarChar).Value = newUser.Text;
                    add.Parameters.Add("@password", SqlDbType.NVarChar).Value = newPW.Text;
                    add.ExecuteNonQuery();
                    Response.Redirect("success.aspx");
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

          protected void submitDelete_Click(object sender, EventArgs e)
          {
               SqlConnection connection;
               connection = new SqlConnection();

               try
               {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    SqlCommand delete = new SqlCommand("delete_club", connection);
                    delete.CommandType = CommandType.StoredProcedure;
                    delete.Parameters.Add("@club_ID", SqlDbType.Int).Value = deleteDDL.SelectedValue;
                    delete.ExecuteNonQuery();
                    Response.Redirect("success.aspx");
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
