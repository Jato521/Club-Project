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
     public partial class signup : System.Web.UI.Page
     {
          string connectionString = 

          protected void Page_Load(object sender, EventArgs e)
          {
               printSuccess.Visible = false;
          }

          protected void submitEmail_Click(object sender, EventArgs e)
          {
               SqlConnection connection;
               connection = new SqlConnection();
               try
               {                    
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    SqlCommand command = new SqlCommand("insert_email", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@email", SqlDbType.NVarChar).Value=emailTextbox.Text;
                    command.ExecuteNonQuery();

                    //when email is added successfully
                    emailTextbox.Visible = false;
                    submitEmail.Visible = false;
                    printSuccess.Visible = true;
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
     }
}
