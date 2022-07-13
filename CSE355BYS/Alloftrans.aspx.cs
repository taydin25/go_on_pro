using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Data.OleDb;
using System.Data;

namespace GoOn
{
    public partial class Alloftrans : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            string sqlstr = "select * from Regs";

            SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
            da.Fill(ds);

            GridView1.DataSource = ds;
            GridView1.DataBind();
            con.Close();
        }
        protected void backto(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void Excel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ClearHeaders();
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachement;filename=Kayıtlar.xls");
            Response.ContentType = "application/excel";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1254");
            Response.Charset = "windows-1254";
            StringWriter sw = new StringWriter();
            HtmlTextWriter ht = new HtmlTextWriter(sw);
            GridView1.HeaderRow.Style.Add("background-color", "#FFFFFF");
            foreach (TableCell tableCell in GridView1.HeaderRow.Cells)
            {
                tableCell.Style["background-color"] = "#A55129";
            }
            foreach (GridViewRow gridViewRow in GridView1.Rows)
            {
                gridViewRow.BackColor = System.Drawing.Color.White;
                foreach (TableCell gridViewRowTableCell in gridViewRow.Cells)
                {
                    gridViewRowTableCell.Style["background-color"] = "#FFF7E7";
                }
            }

            
            GridView1.RenderControl(ht);
            Response.Output.Write(" <meta http-equiv='Content-Type' content='text/html; charset=windows-1254' />" + sw.ToString());
            Response.Flush();
            Response.End();
        }
        protected void Word_Click(object sender, EventArgs e)
        { //Word Aktarımı
            Response.Clear();
            Response.ClearHeaders();
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachement;filename=Kayıtlar.doc");
            Response.ContentType = "application/word";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1254");
            Response.Charset = "windows-1254";
            StringWriter sw = new StringWriter();
            HtmlTextWriter ht = new HtmlTextWriter(sw);
            GridView1.HeaderRow.Style.Add("background-color", "#FFFFFF");
            foreach (TableCell tableCell in GridView1.HeaderRow.Cells)
            {
                tableCell.Style["background-color"] = "#A55129";
            }
            foreach (GridViewRow gridViewRow in GridView1.Rows)
            {
                gridViewRow.BackColor = System.Drawing.Color.White;
                foreach (TableCell gridViewRowTableCell in gridViewRow.Cells)
                {
                    gridViewRowTableCell.Style["background-color"] = "#FFF7E7";
                }
            }

            GridView1.RenderControl(ht);
            Response.Output.Write(" <meta http-equiv='Content-Type' content='text/html; charset=windows-1254' />" + sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
}