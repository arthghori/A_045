using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A_045
{
    public partial class loginpage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbElectronics"].ConnectionString;
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            Fnconn();

        }


        protected void Fnconn()
        {

            strcon = ConfigurationManager.ConnectionStrings["dbElectronics"].ConnectionString;
            conn = new SqlConnection(strcon);

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                Response.Write("yessss....");


            }
            else
            {
                Response.Write("fail....");

            }

        }



        protected void btnlogin_Click(object sender, EventArgs e)
        {
            string username = txtemail.Text;
            string password = txtpass.Text;
            Session["username"] = txtemail.Text;
            SqlConnection conn = new SqlConnection(strcon);

            conn.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from tblCustomer where Email=@Email and Password=@Password", conn);
            cmd.Parameters.AddWithValue("Email", username);
            cmd.Parameters.AddWithValue("password", password);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            if (i == 0)
            {
                Response.Write("Login not valid");
            }
            else
            {
                Response.Redirect("search.aspx");
            }
            conn.Close();
        }
    }
}

