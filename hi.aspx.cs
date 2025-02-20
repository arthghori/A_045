
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace A_045
{
    public partial class hi : System.Web.UI.Page
    {
        //string strcon;


        string strcon = ConfigurationManager.ConnectionStrings["dbElectronics"].ConnectionString;
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                Fnconn();
                if (!Page.IsPostBack)
                {
                    Bilndddltype();
                    Blindgripdevice();
                }

            }
            else
            {
                Response.Redirect("loginpage.aspx");
            }
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string type = ddlType.SelectedValue;
                string brand = ddlBrand.SelectedValue;
                string model = txtModel.Text;
                string description = txtDescription.Text;
                string price = txtPrice.Text;
                string quantity = txtQuantity.Text;
                string color = rblColour.SelectedValue;
                string Acc = string.Empty;

                for (int i = 0; i < cblAccessories.Items.Count; i++)
                {
                    if (cblAccessories.Items[i].Selected)
                    {
                        Acc += cblAccessories.Items[i].Value + " , ";
                    }
                }

                lblDetails.Text += "<br><br> Type : " + type +
                                   "<br> Brand : " + brand +
                                   "<br> Model : " + model +
                                   "<br> Decscription : " + description +
                                   "<br> Price : " + price +
                                   "<br> Quantity : " + quantity +
                                   "<br> color : " + color +
                                   "<br> Accessories : " + Acc;


            }
            catch (Exception save)
            {
                Response.Write(save.ToString());
                throw;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                ddlType.ClearSelection();
                ddlBrand.ClearSelection();
                txtModel.Text = "";
                txtDescription.Text = "";
                txtPrice.Text = "";
                txtQuantity.Text = "";
                rblColour.ClearSelection();
                cblAccessories.ClearSelection();
            }
            catch (Exception reset)
            {

                Response.Write(reset.ToString());
                throw;
            }

        }


        public void Bilndddltype()
        {
            //  SqlConnection conn = new SqlConnection(strcon);
            // conn.Open();
            string query = "select * from tblType";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddlType.DataSource = dt;
            ddlType.DataBind();
            ddlType.DataTextField = "type";
            ddlType.DataValueField = "t_id";
            ddlType.DataBind();
            ddlType.Items.Insert(0, new ListItem("--- Select Type ---"));
            conn.Close();
        }

        //type dropdown
        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // fnBindbrand();
            Fnconn();

            SqlCommand cmd = new SqlCommand("select * from tblBrand where t_id=@t_id", conn);
            cmd.Parameters.AddWithValue("@t_id", ddlType.SelectedValue);
            ddlBrand.DataSource = cmd.ExecuteReader();
            ddlBrand.DataTextField = "BrandName";
            ddlBrand.DataBind();
            ddlBrand.Items.Insert(0, new ListItem("--- Select Brand ---"));
            conn.Close();

        }

        // brand dropdown
        //protected void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}



        protected void Blindgripdevice()
        {
            //     SqlConnection conn = new SqlConnection(strcon);
            Fnconn();

            string query = "select d_id,b_id,model,description,price,quantity,color,accessories from tblDevice";

            //    conn.Open();
            Fnconn();

            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();

            sda.Fill(ds);
            gvDevice.DataSource = ds;
            gvDevice.DataBind();
            conn.Close();


        }


        //select mate karva mate
        protected void gvDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvDevice.SelectedRow;
            for (int i = 0; i < ddlBrand.Items.Count; i++)
            {
                if (ddlBrand.Items[i].Text == row.Cells[2].Text)
                {
                    ddlBrand.SelectedIndex = i;
                }
            }
            txtModel.Text = row.Cells[3].Text;
            txtDescription.Text = row.Cells[4].Text;
            txtPrice.Text = row.Cells[5].Text;
            txtQuantity.Text = row.Cells[6].Text;
            rblColour.Text = row.Cells[7].Text;
            cblAccessories.Text = row.Cells[8].Text;


        }

        //insert button code
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string type = ddlType.SelectedValue.ToString();
            string model = txtModel.Text;
            string des = txtDescription.Text;
            string price = txtPrice.Text;
            string qua = txtQuantity.Text;
            string color = rblColour.SelectedValue.ToString();
            string Acc = string.Empty;

            for (int i = 0; cblAccessories.Items.Count > i; i++)
            {
                if (cblAccessories.Items[i].Selected)
                {
                    Acc += cblAccessories.Items[i].Value + " , ";
                }
            }
            string query = "insert into tblDevice values(@type,@model,@description,@Price,@quantity,@color,@accessories)";

            // SqlConnection conn = new SqlConnection(strcon);
            Fnconn();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@model", model);
            cmd.Parameters.AddWithValue("@description", des);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@quantity", qua);
            cmd.Parameters.AddWithValue("@color", color);
            cmd.Parameters.AddWithValue("@accessories", Acc);
            //conn.Open();
            Fnconn();
            cmd.ExecuteNonQuery();
            conn.Close();
            Blindgripdevice();
        }



        //update mate
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            GridViewRow row = gvDevice.SelectedRow;
            int d_id = Convert.ToInt16(row.Cells[1].Text);
            string b_id = ddlType.SelectedValue.ToString();
            string model = txtModel.Text;
            string des = txtDescription.Text;
            string price = txtPrice.Text;
            string qua = txtQuantity.Text;
            string color = rblColour.SelectedValue.ToString();
            string Acc = string.Empty;

            for (int i = 0; cblAccessories.Items.Count > i; i++)
            {
                if (cblAccessories.Items[i].Selected)
                {
                    Acc += cblAccessories.Items[i].Value + " , ";
                }
            }
            string query = "update tblDevice set b_id=@b_id,model=@model,description=@description,price=@price," +
                "quantity=@quantity,color=@color,accessories=@accessories where d_id=@d_id";
            SqlConnection conn = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@d_id", d_id);
            cmd.Parameters.AddWithValue("@b_id", b_id);
            cmd.Parameters.AddWithValue("@model", model);
            cmd.Parameters.AddWithValue("@description", des);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@quantity", qua);
            cmd.Parameters.AddWithValue("@color", color);
            cmd.Parameters.AddWithValue("@accessories", Acc);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Blindgripdevice();
        }


        protected void btndelete_Click(object sender, EventArgs e)
        {
            GridViewRow row = gvDevice.SelectedRow;
            int d_id = Convert.ToInt16(row.Cells[1].Text);

            string query = "delete from tblDevice where d_id=@d_id";

            SqlConnection conn = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand(@query, conn);

            cmd.Parameters.AddWithValue("@d_id", d_id);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Blindgripdevice();
        }






    }
}
