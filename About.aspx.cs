
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2 {
    public partial class About : Page {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        SqlCommand s;
        SqlDataReader reader, reader2;
        ArrayList genres;
        string publisher;
        protected void Page_Load(object sender, EventArgs e) {
            // if(Session["U"].ToString().Equals("Admin"))

            con.Open();
            int temp =Convert.ToInt32(Session["isAdmin"]);
            if (temp == 1)
            {
                imgDelete.Visible = true;
                imgUpdate.Visible = true;
            } 
            else {
                imgDelete.Visible = false;
                imgUpdate.Visible = false;
            }


            txtUpgrade.Visible = false;
            btnUpdate.Visible = false;
            btnUpdate.Text = "Update";

            string fullName="";
            if (Request.QueryString["param"] != null)
            {
                 fullName = Request.QueryString["param"].Replace("_", " ");
            }
            string query = string.Format("SELECT * FROM Games WHERE GameName='{0}'", fullName);
            s = new SqlCommand(query,con);
            reader = s.ExecuteReader();

            genres = new ArrayList();
            while (reader.Read())
            {
                ltrlName.Text = reader["GameName"].ToString();
                ltrlDeveloper.Text = reader["Developers"].ToString();
                ltrlDate.Text = reader["ReleaseDate"].ToString();
                ltrlRate.Text = reader["ReviewRate"].ToString();
                ltrlPlatform.Text = reader["Platforms"].ToString();
                publisher = reader["PublisherID"].ToString();
                Session["id"] = reader["GameID"];
                string image = string.Format("<img src = 'images/games/{0}.jpg' Height = '250px' Width = '200px' /> ", reader["GameID"]);
                ltrlImg.Text = image;

                genres.Add(reader["GenreID"]);


            }

            reader.Close();
           
            string queryGenre;
            if (genres.Count==1)
            {
               queryGenre = string.Format("Select GenreName from Genres Where GenreID={0}",genres[0]);
            }
            else if(genres.Count==2)
            {
                queryGenre = string.Format("Select GenreName from Genres Where GenreID={0} or GenreID={1}", genres[0], genres[1]);
            }
            else
            {
                queryGenre = string.Format("Select GenreName from Genres Where GenreID={0} or GenreID={1} or GenreID={2}", genres[0], genres[1],genres[2]);
            }

            s = new SqlCommand(queryGenre, con);
            reader=s.ExecuteReader();

            while(reader.Read())
            {
                ltrlGenres.Text += "<a href = 'Genre.aspx?param=" + reader["GenreName"].ToString() + "' > " + reader["GenreName"].ToString() + "</a>" + " ";

            }
            reader.Close();

            string queryPublisher= string.Format("Select PublisherName from Publishers Where PublisherID={0}", publisher);
            s = new SqlCommand(queryPublisher, con);
            reader = s.ExecuteReader();

            while(reader.Read())
            {
                ltrlPublisher.Text = "<a href = 'Publisher.aspx?param=" + reader["PublisherName"].ToString().Replace(" ", "_") + "' > " + reader["PublisherName"].ToString() + "</a>";
            }

            ltrlContent.Text = "<table>";

            String querya = String.Format("SELECT ReviewText FROM Reviews WHERE GameID = (SELECT TOP 1 GameID FROM Games WHERE GameName ='{0}')", fullName);
            s = new SqlCommand(querya, con);
            reader.Close();
            reader2 = s.ExecuteReader();

            while (reader2.Read())
            {
                ltrlContent.Text += "<tr><td><b>Review: </b>" + reader2["ReviewText"].ToString() + "</td></tr>";
            }

            ltrlContent.Text += "</table>";

            con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e) {
            string fullName = "";
            if (Request.QueryString["param"] != null)
            {
                fullName = Request.QueryString["param"].Replace("_", " ");
            }
            String query = "insert into Reviews(GameID, ReviewText) values((Select GameID from Games Where GameName='" + fullName + "'), @r)";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@r", txtComment.Text);

            try {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lblError.Text = "added";
            } catch(Exception ex) {
                lblError.Text = ex.Message;
            }
            string url = String.Format("About?param={0}",fullName.Replace(" ", "_"));
            Response.Redirect(url);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = string.Format("Update Games SET ReviewRate={0} WHERE GameID={1}", txtUpgrade.Text, Session["id"]);
            SqlCommand s = new SqlCommand(query,con);
            s.ExecuteNonQuery();

            string fullName = "";
            if (Request.QueryString["param"] != null)
            {
                fullName = Request.QueryString["param"].Replace("_", " ");
            }
            string url = String.Format("About?param={0}", fullName.Replace(" ", "_"));
            Response.Redirect(url);
            con.Close();
        }

        protected void imgUpdate_Click(object sender, ImageClickEventArgs e)
        {
            txtUpgrade.Visible = true;
            btnUpdate.Visible = true;
        }

        protected void imgDelete_Click(object sender, ImageClickEventArgs e)
        {
            con.Open();
            string query = string.Format("Delete FROM Games WHERE GameID={0}", Session["id"]);
            SqlCommand s = new SqlCommand(query, con);
            s.ExecuteNonQuery();

            Response.Redirect("Default.aspx");
            con.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            txtComment.Text = "";
        }
    }
}
