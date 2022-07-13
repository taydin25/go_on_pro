using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;



namespace GoOn
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (IsPostBack)
            {
                string Password = TextBox2.Text;
                TextBox2.Attributes.Add("value", Password);
            }
        }

        protected void unknownpass(object sender, EventArgs e)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("email", "password"),
                EnableSsl = true,
            };

           // smtpClient.Send("email", "recipient", "subject", "body");

            var mailMessage = new MailMessage
            {
                From = new MailAddress("email@gmail.com"),
                Subject = "subject",
                Body = "<h1>Hello</h1>",
                IsBodyHtml = true,
            };
            mailMessage.To.Add("tunahan.aydin2707@gmail.com");

            smtpClient.Send(mailMessage);
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == false)
            {
                TextBox2.TextMode = TextBoxMode.Password;
            }

            if (CheckBox1.Checked == true)
            {
                TextBox2.TextMode = TextBoxMode.SingleLine;
            }
        }
        protected void changepass(object sender, EventArgs e)
        {
            Response.Redirect("pwverify.aspx" );
        }
        protected void show(object sender, EventArgs e)
        {
            //showhide.ImageUrl = "";
            TextBox2.TextMode=0;
        }
        protected void hide(object sender, EventArgs e)
        {
            //showhide.ImageUrl = "";
            TextBox2.TextMode =TextBoxMode.Password;
        }
        protected void btnGiris_Click(object sender, EventArgs e)
        {

            if (TextBox1.Text == "" || TextBox2.Text == "")
            {
                whoisuser.Text = "Kullanıcı adı ve şifrenizi giriniz";
                whoisuser.ForeColor = System.Drawing.Color.Red;
            }
            else
            {


                SqlConnection baglanti = new SqlConnection("Integrated Security=True;Data Source=;Initial Catalog=GoOn");
                SqlCommand sorgu = new SqlCommand("SELECT * FROM Admin WHERE AdminId=@user AND AdminPassword=@pass", baglanti);

                sorgu.Parameters.Add("@user", SqlDbType.VarChar).Value = TextBox1.Text;
                sorgu.Parameters.Add("@pass", SqlDbType.VarChar).Value = TextBox2.Text;

                baglanti.Open();

                SqlDataReader oku = sorgu.ExecuteReader();
                // Eğer bir kayıt varsa
                if (oku.Read())
                {
                    // Okunan verileri Session(Oturum) değişkenlerinde saklayalım
                    Session["AdminID"] = oku["AdminID"].ToString();
                    Session["AdminName"] = oku["AdminName"].ToString();

                    //Session["AdiSoyadi"] = oku["ADI"].ToString() + " " + oku["SOYADI"].ToString();
                    whoisuser.Text = oku["AdminName"].ToString();

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

                    string Reg = "insert into Regs([Çalışanın Adı],[İşlemin Adı],[İşlemin Tarihi]) values('";
                    Reg = Reg + whoisuser.Text + "'";
                    Reg = Reg + ",'Giriş yaptı','";
                    Reg = Reg + DateTime.Now + "')";

                    SqlCommand execReg = new SqlCommand(Reg, con);
                    try
                    {
                        execReg.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        // throw;
                    }
                    Response.Redirect("Cihazlar.aspx?s=" + whoisuser.Text);
                }
                else 
                {
                    whoisuser.ForeColor = System.Drawing.Color.Red;
                    whoisuser.Text = "Böyle bir kullanıcı bulunamadı yada şifre yanlış!!!";

                }
                oku.Close(); // Reader nesnesini kapat
                baglanti.Close(); // Bağlantı nesnesini kapat
            }



        
    
    }

    protected void Button1_Click(object sender, EventArgs e)
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
           
            string sqlstr = "select * from Admin where AdminID=" + TextBox1.Text;

            SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
           
            da.Fill(ds);
           
          
            
            string AdminID = ds.Tables[0].Rows[0]["AdminID"].ToString();
            string AdminPassword = ds.Tables[0].Rows[0]["AdminPassword"].ToString();
            string AdminName = ds.Tables[0].Rows[0]["AdminName"].ToString();
            string enteredpasswd = TextBox2.Text;
            
            Console.WriteLine(AdminPassword);
            con.Close();

            Session["AdminID"] = AdminID;
            Session["AdminName"] = AdminName;
            whoisuser.Text =AdminName;
            
            string Reg = "insert into Regs([Çalışanın Adı],[İşlemin Adı],[İşlemin Tarihi]) values('";
            Reg = Reg + whoisuser.Text  + "'";
            Reg = Reg + ",'Giriş yaptı','";
            Reg = Reg + DateTime.Now + "')";

            SqlCommand execReg = new SqlCommand(Reg, con);
            try
            {
                execReg.ExecuteNonQuery();
            }
            catch (Exception)
            {
                // throw;
            }
            if (String.Equals(AdminPassword, enteredpasswd)) 
            {
                Response.Redirect("Cihazlar.aspx");
            }

        }
        public string wuser
        {
            get {
                return whoisuser.Text;
            }   
            
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {

        }
    }
    }
