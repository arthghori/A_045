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
    public partial class drop : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            funconn();
            if (!Page.IsPostBack)
            {
                depaddl();
            }
        }

        public void funconn()
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

        public void depaddl()
        {

            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();
            string query = "select * from depa_1";
            SqlDataAdapter adpt = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            ddldepa.DataSource = dt;
            ddldepa.DataBind();
            ddldepa.DataTextField = "depa_name";
            ddldepa.DataValueField = "depa_id";
            ddldepa.DataBind();
            conn.Close();




        }

        protected void ddldepa_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from depa_1 where depa_id=@depa_id", conn);
            cmd.Parameters.AddWithValue("@depa_id", ddldepa.SelectedItem.Value);
             
            ddlcou.DataSource = cmd.ExecuteReader();
            ddlcou.DataTextField = "course_name";
            ddlcou.DataValueField = "cousre_id";
            ddlcou.DataBind();
        }
    }
}