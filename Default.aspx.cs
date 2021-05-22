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
    public partial class _Default : Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        SqlCommand s;
        SqlDataReader reader;
        int counter, counterPublish;
        protected void Page_Load(object sender, EventArgs e)
        {
            rbGame.EnableViewState = true;
            rbPublisher.EnableViewState = true;

            ChangeText();

        }

        protected void GetGame(String name)
        {
            con.Open();
            s = new SqlCommand("Select * from Games", con);
            reader = s.ExecuteReader();

            while (reader.Read())
            {
                if (reader["GameName"].ToString() == name)
                {
                    Session["GameId"] = reader["GameId"];
                    Session["GameName"] = name;
                    Session["Platforms"] = reader["Platforms"];

                    Response.Redirect("About.aspx?param="+name.Replace(" ", "_")+"");
                    break;
                }
            }
            con.Close();
        }

        protected void GetPublisher(String name)
        {
            try
            {
                con.Open();
                s = new SqlCommand("SELECT * FROM Publishers", con);
                reader = s.ExecuteReader();

                while(reader.Read())
                {
                    if(reader["PublisherName"].ToString()== name)
                    {
                        Session["PublisherName"] = reader["PublisherName"];
                        Session["PLocation"] = reader["PLocation"];
                        Session["PScore"] = reader["PScore"];
                        Session["PublisherID"] = reader["PublisherID"];
                        Session["PLink"] = reader["PLink"];

                        Response.Redirect("Publisher.aspx?param="+Session["PublisherName"]);
                        break;

                    }
                }
                con.Close();
            }
            catch
            {
                con.Close();
            }
        }

       

        protected void btn1_Click(object sender, EventArgs e)
        {
            String name = lblGame1.Text;
            if(rbGame.Checked)
            {
                GetGame(name);
            }
            else
            {
                GetPublisher(name);
            }
           
        }
      
        protected void btn3_Click(object sender, EventArgs e)
        {
            String name = lblGame3.Text;
            if (rbGame.Checked)
            {
                GetGame(name);
            }
            else
            {
                GetPublisher(name);
            }
        }
        protected void rbGame_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void rbPublisher_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btn2_Click1(object sender, EventArgs e)
        {
            String name = lblGame2.Text;
            if(rbGame.Checked)
            {
                GetGame(name);
            }
            else
            {
                GetPublisher(name);
            }
        }

        protected void btn4_Click1(object sender, EventArgs e)
        {
            String name = lblGame4.Text;
            if(rbGame.Checked)
            {
                GetGame(name);
            }
            else
            {
                GetPublisher(name);
            }
        }

        protected void btn5_Click1(object sender, EventArgs e)
        {

            String name = lblGame5.Text;
            if (rbGame.Checked)
            {
                GetGame(name);
            }
            else
            {
                GetPublisher(name);
            }
        }

        private void ChangeText()
        {
            if (rbPublisher.Checked)
            {
                con.Open();
                s = new SqlCommand("Select * from Publishers ORDER BY PScore DESC", con);
                try
                {
                    reader = s.ExecuteReader();
                    counterPublish = 1;
                    while (reader.Read())
                    {
                        string id = reader["PublisherName"].ToString();
                        if (counterPublish == 1)
                        {
                            lblGame1.Text = id;

                        }
                        else if (counterPublish == 2)
                        {
                            lblGame2.Text = id;
                        }
                        else if (counterPublish == 3)
                        {
                            lblGame3.Text = id;
                        }
                        else if (counterPublish == 4)
                        {
                            lblGame4.Text = id;
                        }
                        else if (counterPublish == 5)
                        {
                            lblGame5.Text = id;
                        }
                        else
                        {
                            break;
                        }
                        counterPublish++;

                    }
                    con.Close();
                }
                catch (Exception)
                {
                    con.Close();
                }
            }
            else
            {
                try
                {
                    con.Open();

                    s = new SqlCommand("Select TOP 5 GameName from Games ORDER BY ReviewRate DESC", con);
                    reader = s.ExecuteReader();

                    counter = 1;
                    while (reader.Read())
                    {
                        string id = reader["GameName"].ToString();
                        if (counter == 1)
                        {
                            lblGame1.Text = id;

                        }
                        else if (counter == 2)
                        {
                            lblGame2.Text = id;
                        }
                        else if (counter == 3)
                        {
                            lblGame3.Text = id;
                        }
                        else if (counter == 4)
                        {
                            lblGame4.Text = id;
                        }
                        else if (counter == 5)
                        {
                            lblGame5.Text = id;
                        }
                        else
                        {
                            break;
                        }
                        counter++;

                    }
                    con.Close();

                }

                catch
                {
                    con.Close();
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if(ddlOptions.SelectedIndex==0)
            {
                try
                {
                    con.Open();
                    string command = String.Format("SELECT DISTINCT GameID FROM Games WHERE GameName LIKE '%{0}%'", txtSearch.Text);
                    s = new SqlCommand(command,con);
                    reader = s.ExecuteReader();
                    List<int> games = new List<int>();

                    while (reader.Read())
                    {
                        games.Add(Convert.ToInt32(reader["GameID"]));
                    }
                    Session["GameID"] = games;
                    Session["Type"] = "Games";
                    Response.Redirect("SearchedGame.aspx");
            }
                catch (Exception)
                {

                    con.Close();
                }
            }
            else if(ddlOptions.SelectedIndex==1)
            {
                try
                {
                    con.Open();
                    string command = String.Format("SELECT * FROM Genres WHERE GenreName LIKE '%{0}%'", txtSearch.Text);
                    s = new SqlCommand(command, con);
                    reader = s.ExecuteReader();
                    List<string> genres = new List<string>();

                    while (reader.Read())
                    {
                        genres.Add(reader["GenreName"].ToString());
                    }
                    Session["GenreName"] = genres;
                    Session["Type"] = "Genres";
                    Response.Redirect("SearchedGame.aspx");
                }
                catch (Exception)
                {
                    con.Close();
                }
            }

            else if(ddlOptions.SelectedIndex == 2)
            {
                try
                {

                    con.Open();
                    string command = String.Format("SELECT * FROM Publishers WHERE PublisherName LIKE '%{0}%'", txtSearch.Text);
                    s = new SqlCommand(command, con);
                    reader = s.ExecuteReader();
                    List<string> publishers = new List<string>();

                    while (reader.Read())
                    {
                        publishers.Add(reader["PublisherName"].ToString());
                    }
                    Session["PublisherName"] = publishers;
                    Session["Type"] = "Publishers";
                    Response.Redirect("SearchedGame.aspx");
                }
                catch (Exception)
                {

                    con.Close();
                }
            }
        
        }

        protected void btnTopFive_Click(object sender, EventArgs e)
        {
            ChangeText();
        }

    }
}