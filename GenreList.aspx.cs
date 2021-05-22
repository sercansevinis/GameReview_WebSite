using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class GenreList : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        SqlCommand s;
        SqlDataReader reader;
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
            ltrlGenre.Text = "<table>";

            String query = String.Format("SELECT GenreName FROM Genres ORDER BY GenreName DESC");
            s = new SqlCommand(query, con);

            reader = s.ExecuteReader();

            while (reader.Read())
            {
                ltrlGenre.Text += "<tr><td><a href='Genre.aspx?param=" + reader["GenreName"].ToString().Replace(" ", "_") + "'>" + reader["GenreName"].ToString() + "</a></td></tr>";
            }

            ltrlGenre.Text += "</table>";

            con.Close();
        }
    }
}