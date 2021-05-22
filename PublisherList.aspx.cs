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
    public partial class PublisherList : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        SqlCommand s;
        SqlDataReader reader;
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
            ltrlPublisher.Text = "<table>";

            String query = "SELECT Score, PublisherID, p.PublisherName from Publishers p, ( (SELECT AVG(ReviewRate) as Score, PublisherID as s FROM Games GROUP BY PublisherID)) as a WHERE p.PublisherID=s ORDER BY Score DESC";

            s = new SqlCommand(query, con);

            reader = s.ExecuteReader();

            while (reader.Read())
            {
                ltrlPublisher.Text += "<tr><td><a href='Publisher.aspx?param=" + reader["PublisherName"].ToString().Replace(" ", "_") + "'>" + reader["PublisherName"].ToString() + "</a><p><b>Score: </b>" + (Math.Round(Convert.ToDouble(reader["Score"]),2)).ToString() + "</p></td></tr>";
            }

            ltrlPublisher.Text += "</table>";

            con.Close();
        }
    }
}