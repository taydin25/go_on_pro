using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
    public partial class chpass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            userId.Text = Request.QueryString["s"];
        }
        protected void backto(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
        protected void OK(object sender, EventArgs e)
        {
           
            SqlConnection baglanti = new SqlConnection("Integrated Security=True;Data Source=;Initial Catalog=GoOn");

            // Sorgu nesnemizi tanımlıyoruz.

            SqlCommand sorgu = new SqlCommand();

            // Sorgumuzu baglanti nesnesine bağlıyoruz.

            sorgu.Connection = baglanti;

            baglanti.Open();

            // Güncelleme işlemini bu sorgudaki gibi gerçekleştiriyoruz.

            sorgu.CommandText = "UPDATE Admin SET AdminPassword ='" + password.Text + "' WHERE AdminID=" + Convert.ToInt32(userId.Text);

            sorgu.ExecuteNonQuery();

            Response.Write("<script LANGUAGE='JavaScript'> alert('Şifreniz başarıyla değiştirildi')  </script>");

            baglanti.Close();
        }
    }
}