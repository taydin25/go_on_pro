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
//Cihazlar
namespace GoOn

{
    public partial class Cihazlar : System.Web.UI.Page
    {
     
        protected void Page_Load(object sender, EventArgs e)
        {
           // Kullanıcı
            TextBox6.Text =Request.QueryString["s"];
            
            if (!IsPostBack)
            {
               

                string cs = "Server=.;Initial Catalog=GoOn;Integrated Security=SSPI";
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Cihazlar", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {//SHOW ALL of Cihazlar
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
            string sqlstr = "select * from Cihazlar";

            SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
            da.Fill(ds);

            GridView1.DataSource = ds;
            GridView1.DataBind();
            con.Close();

        }


    
        
        
        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void Excel_Click(object sender, EventArgs e) 
        {
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachement;filename=Cihazlar.xls");
            Response.ContentType = "application/excel";
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
            Response.Write(sw.ToString());
            Response.End();
        }
        protected void Word_Click(object sender, EventArgs e)
        { //Word Aktarımı
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachement;filename=Cihazlar.doc");
            Response.ContentType = "application/word";
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
            Response.Write(sw.ToString());
            Response.End();
        }
        protected void InsertModel(object sender, EventArgs e)
        {
            if (TextBox6.Text == "Alican")
            {
                model.Items.Add(modad.Text);
                Response.Write("<script LANGUAGE='JavaScript'> alert('Model adı başarıyla admin tarafından eklendi')  </script>");
            }
            else
                Response.Write("<script LANGUAGE='JavaScript'> alert('Yanlızca admin ekleme yapabilir')  </script>");
        }
        protected void DeleteModel(object sender, EventArgs e)
        {
            if (TextBox6.Text == "Alican")
            {
                model.Items.Remove(modad.Text);
                Response.Write("<script LANGUAGE='JavaScript'> alert('Model adı başarıyla admin tarafından silindi')  </script>");
            }
            else
                Response.Write("<script LANGUAGE='JavaScript'> alert('Yanlızca admin silme yapabilir')  </script>");
        }
        protected void InsertMarka(object sender, EventArgs e)
        {
            if (TextBox6.Text == "Alican")
            {
                marka.Items.Add(marad.Text);
                Response.Write("<script LANGUAGE='JavaScript'> alert('Marka adı başarıyla admin tarafından eklendi')  </script>");
            }
            else
                Response.Write("<script LANGUAGE='JavaScript'> alert('Yanlızca admin ekleme yapabilir')  </script>");
        }
        protected void DeleteMarka(object sender, EventArgs e)
        {
            if (TextBox6.Text == "Alican")
            {
                marka.Items.Remove(marad.Text);
                Response.Write("<script LANGUAGE='JavaScript'> alert('Marka adı başarıyla admin tarafından silindi')  </script>");
            }
            else
                Response.Write("<script LANGUAGE='JavaScript'> alert('Yanlızca admin silme yapabilir')  </script>");
        }
        protected void InsertDepo(object sender, EventArgs e)
        {
            if (TextBox6.Text == "Alican") 
            {
                dropdownlist1.Items.Add(Add.Text);
                Response.Write("<script LANGUAGE='JavaScript'> alert('Depo adı başarıyla admin tarafından eklendi')  </script>");
            }
            else
               Response.Write("<script LANGUAGE='JavaScript'> alert('Yanlızca admin ekleme yapabilir')  </script>");
        }
        protected void DeleteDepo(object sender, EventArgs e)
        {
            if (TextBox6.Text == "Alican")
            {
                dropdownlist1.Items.Remove(Add.Text);
                Response.Write("<script LANGUAGE='JavaScript'> alert('Depo adı başarıyla admin tarafından silindi')  </script>");
            }
            else
                Response.Write("<script LANGUAGE='JavaScript'> alert('Yanlızca admin silme yapabilir')  </script>");
        }
        protected void Insert_Click(object sender, EventArgs e)
        {//INSERT


       
            int success = 0;
            string Reg = "insert into Regs([Çalışanın Adı],[İşlemin Adı],[Seri Numarası],Marka,Model,DepoZimmet,[İşlemin Tarihi]) values('";
            Reg = Reg + TextBox6.Text + "'";
            Reg = Reg + ",'EKLEME',";
            Reg = Reg + TextBox1.Text + ",'";
            Reg = Reg + marka.Text + "','";
            Reg = Reg + model.Text + "','";
            Reg = Reg + dropdownlist1.Text + "','";
            Reg = Reg + DateTime.Now + "')";
      
            string sqlstr = "insert into Cihazlar(SeriNumarasi,Marka,Model,DepoZimmet,IslemTarih,Kullanici) values(";
            sqlstr = sqlstr + TextBox1.Text + ",'";
            sqlstr = sqlstr + marka.Text + "','";
            sqlstr = sqlstr + model.Text + "','";
            sqlstr = sqlstr + dropdownlist1.Text + "','";
            sqlstr = sqlstr + DateTime.Now + "','";
            sqlstr = sqlstr + TextBox6.Text + "')";

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
            SqlCommand execreg = new SqlCommand(Reg, con);

            try
            {
                exec.ExecuteNonQuery();
                execreg.ExecuteNonQuery();
                success = 1;
            }
            catch (Exception)
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('Seri numarası boş bırakılamaz')  </script>");
                // throw;
            }
            con.Close();

            if (success == 1)
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('Başarıyla eklendi')  </script>");
            }
            else
            {
                //Response.Write("<script LANGUAGE='JavaScript'> alert('Hata,eklenmede sorun çıktı')  </script>");
            }


        }
        protected void Update_Click(object sender, EventArgs e)
        {//UPDATE 
            int success = 0;
            string sqlstr = "Update Cihazlar set DepoZimmet = '";
                   sqlstr = sqlstr + dropdownlist1.Text+"'";
                   sqlstr = sqlstr+"where SeriNumarasi=";
                   sqlstr = sqlstr + TextBox1.Text;
            string connectionString = ConfigurationManager.ConnectionStrings["conStr"].ToString();
            SqlConnection con = new SqlConnection(connectionString);
            
            string Reg = "insert into Regs([Çalışanın Adı],[İşlemin Adı],[Seri Numarası],Marka,Model,DepoZimmet,[İşlemin Tarihi]) values('";
            Reg = Reg + TextBox6.Text + "'";
            Reg = Reg + ",'GUNCELLENDİ',";
            Reg = Reg + TextBox1.Text + ",'";
            Reg = Reg + marka.Text + "','";
            Reg = Reg + model.Text + "','";
            Reg = Reg + dropdownlist1.Text + "','";
            Reg = Reg + DateTime.Now + "')";

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
            SqlCommand execreg = new SqlCommand(Reg, con);
            try
            {
                exec.ExecuteNonQuery();
                execreg.ExecuteNonQuery();
                success = 1;
                Response.Write("<script LANGUAGE='JavaScript'> alert('Başarıyla güncellendi')  </script>");
            }
            catch (Exception)
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('Bazı şeyler eksik girildi güncelleme yapılamadı')  </script>");
                //throw;
            }
            con.Close();

            if (success == 1)
            {
               // Response.Write("<script LANGUAGE='JavaScript'> alert('Başarıyla güncellendi')  </script>");
            }
            else
            {
               // Response.Write("<script LANGUAGE='JavaScript'> alert('Error program can not delete it')  </script>");
            }
        }
      
   
            protected void Delete_Click(object sender, EventArgs e) 
        {//DELETE
            int success = 0;

            string Reg = "insert into Regs([Çalışanın Adı],[İşlemin Adı],[Seri Numarası],Marka,Model,DepoZimmet,[İşlemin Tarihi]) values('";
            Reg = Reg + TextBox6.Text + "'";
            Reg = Reg + ",'SİLME',";
            Reg = Reg + TextBox1.Text + ",'";
            Reg = Reg + marka.Text + "','";
            Reg = Reg + model.Text + "','";
            Reg = Reg + dropdownlist1.Text + "','";
            Reg = Reg + DateTime.Now + "')";

            string sqlstr = "delete from Cihazlar where SeriNumarasi=";
            sqlstr = sqlstr + TextBox1.Text;
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
            SqlCommand execReg = new SqlCommand(Reg, con);

            try
            {
                exec.ExecuteNonQuery();
                execReg.ExecuteNonQuery();
                success = 1;
            }
            catch (Exception)
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('Seri numarası boş bırakılamaz')  </script>");
              //  throw;
            }
            con.Close();

            if (success == 1)
            {
                Response.Write("<script LANGUAGE='JavaScript'> alert('Başarıyla silindi')  </script>");
            }
            else
            {
              //  Response.Write("<script LANGUAGE='JavaScript'> alert('Error program can not delete it')  </script>");
            }


        }

        
    }
}