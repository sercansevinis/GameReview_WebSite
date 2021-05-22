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
    public partial class Publisher : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        SqlCommand s;
        SqlDataReader reader;
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();

            string fullName = "";
            if (Request.QueryString["param"] != null)
            {
                fullName = Request.QueryString["param"].Replace("_", " ");
            }
            string query = string.Format("SELECT * FROM Publishers WHERE PublisherName='{0}'", fullName);
            s = new SqlCommand(query, con);
            reader = s.ExecuteReader();
            while (reader.Read())
            {
                lblPName.Text = reader["PublisherName"].ToString();
                lblPLoc.Text = reader["PLocation"].ToString();
               // lblPScore.Text= reader["PScore"].ToString();
                lblPUrl.Text= reader["PLink"].ToString();
                Session["PublisherID"] = reader["PublisherID"];
                string img = string.Format("<img src = 'images/publishers/{0}.jpg' Height='200px' Width='200px' />", reader["PublisherID"]);
                ltrlImg.Text= img;
            }
            reader.Close();
            
            String query2 = String.Format("select DISTINCT GameName from Games where PublisherID={0}", Session["PublisherID"].ToString());
            s = new SqlCommand(query2, con);
            reader = s.ExecuteReader();
            ltrlGames.Text = "<table>";

            while (reader.Read())
            {
                ltrlGames.Text+= "<tr><td><a href='About.aspx?param=" + reader["GameName"].ToString().Replace(" ", "_") + "'>" + reader["GameName"].ToString() + "</a></td></tr>";
            }
            ltrlGames.Text += "</table>";
            reader.Close();

            string publisherScr = string.Format("SELECT AVG(ReviewRate) AS Score,PublisherID FROM Games Where PublisherID={0} Group BY PublisherID", Session["PublisherID"]);
            s = new SqlCommand(publisherScr, con);
            reader = s.ExecuteReader();

            while (reader.Read())
            {
                lblPScore.Text = (Math.Round(Convert.ToDouble(reader["Score"]), 2)).ToString() + " / 100.00";
            }

            /*
            lblPName.Text = Session["PublisherName"].ToString();
            lblPLoc.Text = Session["PLocation"].ToString();
            lblPScore.Text = Session["PScore"].ToString();
            lblPUrl.Text = Session["PLink"].ToString();
            ltrlImg.Text= "<img src = 'rdr2.jpg' Height='244px' Width='205px' /> ";
            */

            con.Close();
        }
    }
}