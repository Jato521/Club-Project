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
     public partial class clubs : System.Web.UI.Page
     {
          string connectionString = //
          protected void Page_Load(object sender, EventArgs e)
          {
               SqlConnection connection;
               connection = new SqlConnection();
               try
               {                                  
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT clubName, clubLocation, clubDescription FROM club ORDER BY clubName ASC", connection);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while(dataReader.Read())
                    {
                         TableRow row = new TableRow();
                         TableCell cell1 = new TableCell();
                         cell1.Text = dataReader["clubName"].ToString();
                         row.Cells.Add(cell1);

                         TableCell cell2 = new TableCell();
                         cell2.Text = dataReader["clubLocation"].ToString();
                         row.Cells.Add(cell2);

                         TableCell cell3 = new TableCell();
                         cell3.Text = dataReader["clubDescription"].ToString();
                         row.Cells.Add(cell3); 
                                                 
                         clubListTable.Rows.Add(row);
                    }
               }
               catch(Exception ex)
               {
                    Response.Write(ex.Message);
               }
               finally
               {
                    //close connection
                    connection.Close();
               }
          }
     }
}
