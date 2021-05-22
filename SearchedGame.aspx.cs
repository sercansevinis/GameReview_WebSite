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
    public partial class SearchedGame : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        SqlCommand s;
        SqlDataReader reader;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            ltrlType.Text += Session["Type"].ToString();

            ltrlFounds.Text = "<table>";
            string query="";
            con.Open();
            if (Session["Type"].ToString().Equals("Games"))
            {
                List<int> GPList = (List<int>)Session["GameID"];

                for (int i = 0; i < GPList.Count; i++)
                {
                    string query1 = string.Format("SELECT TOP 1 * FROM Games WHERE GameID='{0}'", GPList[i].ToString());
                    s = new SqlCommand(query1, con);
                    reader = s.ExecuteReader();
                    while(reader.Read())
                    {
                        query += "<tr><td><a href='About.aspx?param=" + reader["GameName"].ToString().Replace(" ", "_") + "'>" + reader["GameName"].ToString() + "</a></td></tr>";
                    }
                    reader.Close();
                }
            }
            else if(Session["Type"].ToString().Equals("Genres"))
            {
                List<string> GPList = (List<string>)Session["GenreName"];
                for (int i = 0; i < GPList.Count; i++)
                {
                    query += "<tr><td><a href='Genre.aspx?param=" + GPList[i].ToString().Replace(" ", "_") + "'>" + GPList[i].ToString() + "</a></td></tr>";
                }
            }
            else
            {
                List<string> GPList = (List<string>)Session["PublisherName"];
                for (int i = 0; i < GPList.Count; i++)
                {
                    query += "<tr><td><a href='Publisher.aspx?param=" + GPList[i].ToString().Replace(" ", "_") + "'>" + GPList[i].ToString() + "</a></td></tr>";
                }
            }
            
            ltrlFounds.Text += query;

            ltrlFounds.Text += "</table>";
        }
    }
}