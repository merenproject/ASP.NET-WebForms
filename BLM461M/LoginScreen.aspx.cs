using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLM461M
{
    public partial class WebForm1 : System.Web.UI.Page
    {

            string backgExtension1;
            string backgExtension2; 
            string backgExtension3;


        //DATABASE BAĞLANMA İŞLEMİ//
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-VGHLIGB; Initial Catalog=blm461m;Integrated Security=True");

        //SAYFA YÜKLENDİĞİNDE ÇALIŞAN KOMUTLAR//
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!this.IsPostBack)
            {
                //Label4.Text = "";
                //Label5.Text = "";
                Label2.Text = "";
                Label3.Text = "";
                Label4.Text = "";
                divID.Style.Add("background-color", "Lightgray");
                ArkaPlan();
                LoginDegisDiv.Visible = false;
            }



        }
        
        protected void Button2_Click(object sender, EventArgs e)
        {

            Response.Redirect("Fdatabase2.aspx");



        }
        // LOGIN AUTHENTICATE İŞLEMİ //
        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            

            if (Dogrulama(Login1.UserName, Login1.Password))
            {
                //e.Authenticated = true;
                Login1.Visible = false;
                //Response.Write("true");
                Button3.Visible = true;
                Label3.Text = "Giriş Yapıldı";
                Button6.Visible = true;

            }
            else
            {
                e.Authenticated = false;
                //Response.Write("false");
            }

            



        }
        // ADMIN GİRİŞ BİLGİLERİ DOĞRULAMA //
        private bool Dogrulama(string UserName, string Password)
        {
            bool boolReturnValue = false;
            baglanti.Open();

            using (SqlCommand cmd9 = new SqlCommand("SELECT Kullanici_Adi, Sifre FROM Table_3 WHERE hesap_id = (SELECT MAX(hesap_id) FROM Table_3) "))
            {

                cmd9.Connection = baglanti;
                SqlDataReader read9 = cmd9.ExecuteReader();
                while (read9.Read())
                {

                    if ((UserName == read9["Kullanici_Adi"].ToString()) && (Password == read9["Sifre"].ToString()))
                    {

                        boolReturnValue = true;


                    }

                    read9.Close();
                    return boolReturnValue;

                }

            }
            baglanti.Close();
            return boolReturnValue;
        }

            protected void Button3_Click(object sender, EventArgs e)
        {

            Response.Redirect("Fdatabase1.aspx");
            
            

        }
        //ARKA PLAN RESMİNİN GÖSTERİLMESİ //
        protected void ArkaPlan()
        {

            backgExtension1 = @"C:\Users\eren_\source\repos\BLM461M\BLM461M\backgrounds2\backgroundimage.jpg";
            backgExtension2 = @"C:\Users\eren_\source\repos\BLM461M\BLM461M\backgrounds2\backgroundimage.jpeg";
            backgExtension3 = @"C:\Users\eren_\source\repos\BLM461M\BLM461M\backgrounds2\backgroundimage.png";

            if (File.Exists(backgExtension1)) { bodyID.Style["background-image"] = Page.ResolveUrl("backgrounds2/backgroundimage.jpg"); }
            if (File.Exists(backgExtension2)) { bodyID.Style["background-image"] = Page.ResolveUrl("backgrounds2/backgroundimage.jpeg"); }
            if (File.Exists(backgExtension3)) { bodyID.Style["background-image"] = Page.ResolveUrl("backgrounds2/backgroundimage.png"); }


        }

        protected void Btn6Goster_Click(object sender, EventArgs e)
        {

            LoginDegisDiv.Visible = true;


        }
        protected void BtnIptal_Click(object sender, EventArgs e)
        {

            LoginDegisDiv.Visible = false;



        }
        // KULLANICI ADI VE ŞİFRE DEĞİŞTİRME İŞLEMİ //
        protected void BtnDegistir_Click(object sender, EventArgs e)
        {

            if (TextBox2.Text != TextBox3.Text)
            {

                Label4.Text = "Yazılan şifre ile doğrulanan şifre aynı değil lütfen tekrar deneyiniz.";
                Label4.ForeColor = Color.Red;


            }
            else
            {

                baglanti.Open();

                SqlCommand gonder2 = new SqlCommand("insert into Table_3(Kullanici_Adi, Sifre) values (@Kullanici_Adi, @Sifre)", baglanti);
                gonder2.Parameters.AddWithValue("Kullanici_Adi", TextBox1.Text);
                gonder2.Parameters.AddWithValue("Sifre", TextBox2.Text);
              
                gonder2.ExecuteNonQuery();
                

                baglanti.Dispose();
                baglanti.Close();

                Label4.Visible = false;
                Label3.Visible = true;
                Label3.Text = "Giriş bilgileri değişti lütfen tekrar giriş yapınız.";
                Label3.ForeColor = Color.Blue;
                Button3.Visible = false;
                Button6.Visible = false;
                LoginDegisDiv.Visible = false;
                Login1.Visible = true;
                Login1.UserName= TextBox1.Text;

            }


        }



    }
}