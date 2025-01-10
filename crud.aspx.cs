using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A_045
{
    public partial class crud : System.Web.UI.Page
    {
        SqlConnection conn;
        string strcon;
        protected void fnconnctions()
        {

            strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

            conn = new SqlConnection(strcon);

            if (conn.State != ConnectionState.Open)
            {

                conn.Open();
                Response.Write("success!");

            }
            else
            {

                Response.Write("fail!");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            fnconnctions();
            if (!Page.IsPostBack)
            {
               
            }
        }

        //login mate 
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtLogin.Text;
            string pass = txtPass.Text;
            SqlConnection con = new SqlConnection(strcon);

            con.Open();
            string query = "select count(*) from login where email=@email and password=@password";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("email", email);
            cmd.Parameters.AddWithValue ("password", pass);
            int i = Convert.ToInt16(cmd.ExecuteScalar());

            if (i == 0)
            {
                Response.Write("not valid login!");

            }
            else
            {
                Session["a"]=txtLogin.Text;
                Response.Redirect("re form.aspx");
            }
        }
    }
}