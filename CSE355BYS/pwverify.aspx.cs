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
    public partial class changep : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void backto(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
        protected void OK(object sender, EventArgs e)
        {
            if (userId.Text == "" || password.Text == "")
            {
                Label1.Text = "Kullanıcının siz olduğunu onaylamak icin lütfen kullanıcı adını ve size ait olan şifrenizi girin";
            }
            else
            {


                SqlConnection baglanti = new SqlConnection("Integrated Security=True;Data Source=;Initial Catalog=GoOn");
                SqlCommand sorgu = new SqlCommand("SELECT * FROM Admin WHERE AdminId=@user AND AdminPassword=@pass", baglanti);

                sorgu.Parameters.Add("@user", SqlDbType.VarChar).Value = userId.Text;
                sorgu.Parameters.Add("@pass", SqlDbType.VarChar).Value = password.Text;

                baglanti.Open();

                SqlDataReader oku = sorgu.ExecuteReader();
                // Eğer bir kayıt varsa
                if (oku.Read())
                {
                    // Okunan verileri Session(Oturum) değişkenlerinde saklayalım
                    Session["AdminID"] = oku["AdminID"].ToString();
                    Session["AdminName"] = oku["AdminName"].ToString();
                    Response.Redirect("chpass.aspx?s=" + Session["AdminID"]);
                    
                }
                else // Kayıt yoksa
                {

                    Response.Write("<script LANGUAGE='JavaScript'> alert('Böyle bir kullanıcı kaydı bulunmuyor.Lütfen kullanıcı adınızı ve şifrenizi kontrol ediniz')  </script>");
                }
                oku.Close(); 
                baglanti.Close(); 
            }
        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}