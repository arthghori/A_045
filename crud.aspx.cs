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

        }
    }
}