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
    public partial class GameList : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        SqlCommand s;
        SqlDataReader reader;

        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
            ltrlGame.Text = "<table>";

            String query = String.Format("SELECT GameName,ReviewRate FROM Games ORDER BY ReviewRate DESC");
            s = new SqlCommand(query, con);

            reader = s.ExecuteReader();

            while (reader.Read())
            {
                ltrlGame.Text += "<tr><td><a href='About.aspx?param=" + reader["GameName"].ToString().Replace(" ", "_") + "'>" + reader["GameName"].ToString() + "</a><p><b>Score: </b>" + reader["ReviewRate"] + "</p></td></tr>";
            }

            ltrlGame.Text += "</table>";

            con.Close();
        }
    }
}