﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;


namespace A_045
{
    public partial class re_form : System.Web.UI.Page
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

                Response.Write(Session["a"]);
                fnBindstate(); 
                fnBindstate();

                this.Bindgrid();
                this.Blinddb();
                this.Blinddb1();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string password = txtPassword.Text;
            string cpassword = txtCpassword.Text;
            string date = txtBod.Text;
            string gender = rblGender.SelectedValue;
            string media = string.Empty;
            string address = txtAddress.Text;
            string state = ddlstate.SelectedValue;
            string city = ddlCity1.SelectedValue;

            for(int i = 0; i < cblSocial.Items.Count; i++)
            {
                if (cblSocial.Items[i].Selected)
                {
                    media += cblSocial.Items[i].Value + " , ";
                }


            }

            lblDetalis.Text += " Name : " + name
                               + " Email : " + email
                               + " Phone : " + phone
                               + " Password : " + password
                               + " Confirm Password : " + cpassword
                               + " B.O.D : " + date
                               + " Gender : " + gender
                               + " Social Media : " + media
                               + " Address : " + address
                               + " State : " + state
                               + " City : " + city;
                               

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtPassword.Text = "";
            txtCpassword.Text = "";
            txtBod.Text = ""; 
            rblGender.ClearSelection();
              txtAddress.Text = "";
            ddlstate.ClearSelection();
            ddlCity1.ClearSelection();
         }

        protected void fnBindstate()
        {
            ddlstate.Items.Insert(0, new ListItem("---Select State---"));
            ddlstate.Items.Add("gujarat");
            ddlstate.Items.Add("maharashtra");
            ddlstate.Items.Add("delhi");
            ddlstate.Items.Add("tamilnadu");
            ddlstate.Items.Add("karnataka");
        }

        protected void fnBindcity()
        {
            ddlCity1.Items.Clear();

            ddlCity1.Items.Insert(0, new ListItem("---Select city---"));


            if (ddlstate.SelectedValue == "gujarat")
            {
                ddlCity1.Items.Add("Surat");
                ddlCity1.Items.Add("Navsari");
                ddlCity1.Items.Add("Ahmedabad");
                ddlCity1.Items.Add("Vadodara");
                ddlCity1.Items.Add("Rajkot");
            }
            else if (ddlstate.SelectedValue == "maharashtra")
            {
                ddlCity1.Items.Add("Mumbai");
                ddlCity1.Items.Add("Pune");
                ddlCity1.Items.Add("Nagpur");
                ddlCity1.Items.Add("Nashik");
                ddlCity1.Items.Add("Aurangabad");
            }
            else if (ddlstate.SelectedValue == "delhi")
            {
                ddlCity1.Items.Add("New Delhi");
                ddlCity1.Items.Add("Delhi Cantonment");
                ddlCity1.Items.Add("Dwarka");
                ddlCity1.Items.Add("Rohini");
            }
            else if (ddlstate.SelectedValue == "tamilnadu")
            {
                ddlCity1.Items.Add("Chennai");
                ddlCity1.Items.Add("Coimbatore");
                ddlCity1.Items.Add("Madurai");
                ddlCity1.Items.Add("Trichy");
                ddlCity1.Items.Add("Salem");
            }
            else if (ddlstate.SelectedValue == "karnataka")
            {
                ddlCity1.Items.Add("Bangalore");
                ddlCity1.Items.Add("Mysore");
                ddlCity1.Items.Add("Hubli");
                ddlCity1.Items.Add("Mangalore");
                ddlCity1.Items.Add("Belgaum");
            }
        }

        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            fnBindcity();
        }


      
        // ddl depa and cou for drop down
        public void Blinddb()
        {
            SqlConnection conn = new SqlConnection (strcon);
            conn.Open ();
            string query = "select * from cou_1";
            SqlDataAdapter adpt = new SqlDataAdapter(query,conn);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            ddlDep.DataSource = dt;
            ddlDep.DataBind();
            ddlDep.DataTextField = "course_name";
            ddlDep.DataTextField = "depa_id";
            ddlDep.DataBind();
            conn.Close(); 

        }


        protected void ddlDepa_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from cou_1 where depa_id=@depa_id", conn);

            cmd.Parameters.AddWithValue("depa_id",ddlDep.SelectedValue);

           
         ddlCour.DataSource = cmd.ExecuteReader();
         ddlCour.DataTextField = "course_name";
         ddlCour.DataValueField = "cousre_id";
         ddlCour.DataBind();

        }

        protected void ddlCou_SelectedIndexChanged(object sender, EventArgs e)
        {
        }


        //grid view mate che main grid view to display depaname and coursename 
        //public void Bindgrid()
        //{
        //    SqlConnection conn = new SqlConnection(strcon);
        //    string query = "select c.course_name,d.depa_name from cou_1 c, depa_1 d where c.depa_id= d.depa_id";

        //    conn.Open();
        //    SqlDataAdapter sda = new SqlDataAdapter(query, conn);
        //    DataSet ds = new DataSet();
        //    sda.Fill(ds);

        //    gvdepa.DataSource = ds;
        //    gvdepa.DataBind();
        //    conn.Close();


        //}

        public void Bindgrid()
        {
            SqlConnection conn = new SqlConnection(strcon);
            string query = "select * from cou_1";
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            gvdepa.DataSource = ds;
            gvdepa.DataBind();
            conn.Close();

        }

        //insert mate je dropdown che te mate 

        public void Blinddb1()
        {
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();
            string query = "select * from depa_1";
            SqlDataAdapter adpt = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            ddlDname.DataSource = dt;
            ddlDname.DataBind();
            ddlDname.DataTextField = "depa_name";
            ddlDname.DataValueField = "depa_id";
            ddlDname.DataBind();
            conn.Close();

        }
        // insert mate 
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string c_name = txtCname.Text;
            string c_depa = ddlDname.SelectedValue.ToString() ;
           
            string query = "insert into cou_1 values(@course_name,@depa_name)";
             
            fnconnctions();
            SqlCommand cmd = new SqlCommand(query,conn);
            cmd.Parameters.AddWithValue("@course_name",c_name);
            cmd.Parameters.AddWithValue("@depa_name", c_depa);
            fnconnctions();
            cmd.ExecuteNonQuery();
            conn.Close();
            Bindgrid();
            
        }

      
        protected void ddlDname_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        //update mate 
        protected void gvdepa_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvdepa.SelectedRow;
            
             txtCname.Text = row.Cells[1].Text;
             ddlDname.Text = row.Cells[2].Text;
                      

        }

        protected void txtCname_TextChanged(object sender, EventArgs e)
        {

        }

        //delete mate button 
       
        protected void btnDelete_Click1(object sender, EventArgs e)
        {
            GridViewRow row = gvdepa.SelectedRow;
            int cousre_id = Convert.ToInt32(row.Cells[1].Text);
            string query = "Delete from cou_1 where cousre_id=@cousre_id";
            SqlConnection conn = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@cousre_id", cousre_id);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Bindgrid();
        }
        //row delete karva mate
        protected void gvdepa_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = gvdepa.Rows[e.RowIndex];
            int cousre_id = Convert.ToInt32(row.Cells[1].Text);
            string query = "Delete from depa_1 where cousre_id=@cousre_id";
            SqlConnection conn = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@cousre_id", cousre_id);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Bindgrid();
        }

        protected void gvdepa_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void btnre_Click(object sender, EventArgs e)
        {
            txtCname.Text = " ";
            ddlDname.ClearSelection();
        }

        protected void ddlCity1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}