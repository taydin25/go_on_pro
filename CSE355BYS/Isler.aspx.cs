using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
//Categories
namespace GoOn

{
    public partial class Isler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Show_Click(object sender, EventArgs e)
        {//SHOW ALL of Isler
            string connectionString = ConfigurationManager.ConnectionStrings["conStr"].ToString();

            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                con.Open();
            }
            catch (Exception)
            {
                con.Close();
                return;
                throw;
            }


            DataSet ds = new DataSet();
            string sqlstr = "select * from Isler";

            SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
            da.Fill(ds);

            GridView1.DataSource = ds;
            GridView1.DataBind();
            con.Close();

        }

     
        protected void Insert_Click(object sender, EventArgs e)
        {//INSERT
            int success = 0;
            string sqlstr = "insert into Isler(CalisanID,IsinAdı,CihazID) values(";
            sqlstr = sqlstr + TextBox1.Text + ",'";
            sqlstr = sqlstr + TextBox2.Text + "',";
            sqlstr = sqlstr + TextBox3.Text + ")";
            string connectionString = ConfigurationManager.ConnectionStrings["conStr"].ToString();

            SqlConnection con = new SqlConnection(connectionString);


            try
            {
                con.Open();
            }
            catch (Exception)
            {
                con.Close();
                return;
                throw;
            }

            SqlCommand exec = new SqlCommand(sqlstr, con);


            try
            {
                exec.ExecuteNonQuery();
                success = 1;
            }
            catch (Exception)
            {
                throw;
            }
            con.Close();

            if (success == 1)
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('Successfully Inserted')  </script>");
            }
            else
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('Error program can not insert it')  </script>");
            }


        }

        protected void Delete_Click(object sender, EventArgs e)
        {//DELETE
            int success = 0;
            string sqlstr = "delete from Isler where IsinAdı='";
            sqlstr = sqlstr + TextBox1.Text+ "'";
            string connectionString = ConfigurationManager.ConnectionStrings["conStr"].ToString();

            SqlConnection con = new SqlConnection(connectionString);


            try
            {
                con.Open();
            }
            catch (Exception)
            {
                con.Close();
                return;
                throw;
            }

            SqlCommand exec = new SqlCommand(sqlstr, con);


            try
            {
                exec.ExecuteNonQuery();
                success = 1;
            }
            catch (Exception)
            {
                throw;
            }
            con.Close();

            if (success == 1)
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('Successfully Deleted')  </script>");
            }
            else
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('Error program can not delete it')  </script>");
            }


        }
    }
}