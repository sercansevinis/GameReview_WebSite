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
    public partial class Genre : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        SqlCommand s;
        SqlDataReader reader;
        List<int> genres;
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
            string fullName = "";
            if (Request.QueryString["param"] != null)
            {
                fullName = Request.QueryString["param"];
            }
            string query = string.Format("SELECT * FROM Genres WHERE GenreName='{0}'", fullName);
            s = new SqlCommand(query, con);
            reader = s.ExecuteReader();
            genres = new List<int>();
            while (reader.Read())
            {
                lblGName.Text = reader["GenreName"].ToString();
                Session["GenreID"] = reader["GenreID"];
            }
           // Session["GenreID"] = genres;

           /* 
            * for (int i = 0; i < genres.Count; i++)
            {
                string query1 = string.Format("SELECT TOP 1 * FROM Games WHERE GenreID='{0}'", genres[i].ToString());
                s = new SqlCommand(query1, con);
                reader = s.ExecuteReader();
                while (reader.Read())
                {
                    query += "<tr><td><a href='About.aspx?param=" + reader["GameName"].ToString().Replace(" ", "_") + "'>" + reader["GameName"].ToString() + "</a></td></tr>";
                }
                reader.Close();
            }
           */

            reader.Close();

            String query2 = String.Format("select DISTINCT GameName from Games where GenreID={0}", Session["GenreID"].ToString());
            s = new SqlCommand(query2, con);
            reader = s.ExecuteReader();
            ltrlGames.Text = "<table>";

            while (reader.Read())
            {
                ltrlGames.Text += "<tr><td><a href='About.aspx?param=" + reader["GameName"].ToString().Replace(" ", "_") + "'>" + reader["GameName"].ToString() + "</a></td></tr>";
            }
            ltrlGames.Text += "</table>";
            reader.Close();

            string genreScore=string.Format("SELECT AVG(ReviewRate) AS Score,GenreID FROM Games Where GenreID={0} Group BY GenreID",Session["GenreID"]);
            s = new SqlCommand(genreScore, con);
            reader = s.ExecuteReader();

            while(reader.Read())
            {
                lblGScore.Text =(Math.Round(Convert.ToDouble(reader["Score"]),2)).ToString() + " / 100.00";
            }


            con.Close();
        }
    }
}