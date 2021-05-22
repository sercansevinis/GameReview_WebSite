using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace WebApplication2
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        SqlCommand s;
        SqlDataReader reader;
        protected void Page_Load(object sender, EventArgs e)
        {

            
           
        }

        protected void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            if(rbUser.Checked)
            {
                con.Open();
                string query=string.Format("SELECT * FROM users");
                s = new SqlCommand(query,con);
                reader = s.ExecuteReader();

                while(reader.Read())
                {
                    string name = reader["userName"].ToString();
                    string pass = reader["userPass"].ToString();
                    if(name.Equals(txtName.Text) && pass.Equals(txtPass.Text))
                    {
                        Session["isAdmin"] = 0;
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        continue;
                    //MessageBox.Show("Wrong username or password");

                    }
                    
                }
                MessageBox.Show("Wrong username or password");

            }
            else if(rbAdmin.Checked)
            {
                con.Open();
                string query = string.Format("SELECT * FROM admins");
                s = new SqlCommand(query, con);
                reader = s.ExecuteReader();

                while (reader.Read())
                {
                    string name = reader["adminName"].ToString();
                    string pass = reader["adminPass"].ToString();
                    if (name.Equals(txtName.Text) && pass.Equals(txtPass.Text))
                    {
                        Session["isAdmin"] = 1;
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        MessageBox.Show("Wrong username or password");
                    }

                }
            }
            con.Close();
        }

        protected void imgLogIn_Click(object sender, ImageClickEventArgs e)
        {
           
        }

        protected void imgRegister_Click(object sender, ImageClickEventArgs e)
        {
           
        }
    }
}