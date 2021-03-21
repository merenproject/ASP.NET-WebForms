using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web.UI.HtmlControls;

namespace BLM461M
{
    public partial class Fdatabase2 : System.Web.UI.Page
    {
        bool confirm1;
        string alternatif;
        string tedarik1;
        string tedarik2;
        int tedarik1Int;
        int tedarik2Int;
        string backgExtension1;
        string backgExtension2;
        string backgExtension3;
        bool admin;

        // DATABASE BAĞLANMA İŞLEMİ //
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-VGHLIGB; Initial Catalog=blm461m;Integrated Security=True");
        
        // SAYFA YÜKLENDİĞİNDE YAPILAN İŞLEMLER //
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.GridShow();
                Label8.Text = "";
                Label16.Text = Label15.Text = Label14.Text = Label11.Text = Label10.Text = Label9.Text = Label8.Text;
                Label17.Text = "";
                Label20.Visible = false;
                ilacbilgikismi.Visible = false;
                ArkaPlan();
                //Response.Write(admin);
            }
            
        }


        // GENEL GRIDVIEW //
        public void GridShow()
        {


            using (SqlCommand cmd = new SqlCommand("SELECT ilacadi, stokdurumu, tedarikzamani, alternatifilaclar FROM Table_1"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = baglanti;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }

        }
        // ÖZEL GRIDVIEW //
        public void GridShow2()
        {


            using (SqlCommand cmd2 = new SqlCommand("SELECT ilacadi, stokdurumu, tedarikzamani, alternatifilaclar FROM Table_1 where ilacadi = '" + TextBox1.Text + "' or ilacadi= '" + alternatif + "' "))
            {
                using (SqlDataAdapter sda2 = new SqlDataAdapter())
                {
                    cmd2.Connection = baglanti;
                    sda2.SelectCommand = cmd2;
                    using (DataTable dt2 = new DataTable())
                    {
                        sda2.Fill(dt2);
                        GridView2.DataSource = dt2;
                        GridView2.DataBind();


                    }
                }
            }

        }

     
        
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // SORGULA BUTONUNA BASILDIĞINDA YAPILAN İŞLEMLER //
        protected void Sorgula_Click(object sender, EventArgs e)
        {
            Label2.Text = "SONUÇLAR";
            

            baglanti.Open();

            using (SqlCommand cmd1 = new SqlCommand("SELECT ilacadi, alternatifilaclar, ilacbilgileri FROM Table_1 WHERE ilacadi= '" + TextBox1.Text + "' "))
            {
                
                cmd1.Connection = baglanti;
                SqlDataReader read1 = cmd1.ExecuteReader();
                while (read1.Read())
                {
                    if (TextBox1.Text != read1["ilacadi"].ToString() ) { confirm1 = false; }
                    else
                    {
                        alternatif = read1["alternatifilaclar"].ToString();
                        confirm1 = true;
                        TextBox7.Text = read1["ilacbilgileri"].ToString();
                    }
                    
                }
                read1.Close();

            }
            // EĞER İLAÇ BİLGİSİ BULUNDUYSA BİLGİ VE YORUM KISIMLARI GÖSTERİLİYOR // 
            if (confirm1)
            {
                Label4.Text = "" + TextBox1.Text + " İlacı";
                ilacbilgikismi.Visible = true;
                Label18.Text = TextBox1.Text + " İlacı Yorumları";
                Label19.Text = TextBox1.Text + " İlacı İçin Yorum Yaz";
                Yorum_Goster();
                this.GridShow2();

                // İLAÇ RESMİNİN GÖSTERİLMESİ İŞLEMİ //
                string imageExtension1 = @"C:\Users\eren_\source\repos\BLM461M\BLM461M\images2\" + TextBox1.Text + ".jpg";
                string imageExtension2 = @"C:\Users\eren_\source\repos\BLM461M\BLM461M\images2\" + TextBox1.Text + ".png";
                string imageExtension3 = @"C:\Users\eren_\source\repos\BLM461M\BLM461M\images2\" + TextBox1.Text + ".jpeg";

                if (File.Exists(imageExtension1)) { ilacresim.ImageUrl = "images2/" + TextBox1.Text + ".jpg"; }
                if (File.Exists(imageExtension2)) { ilacresim.ImageUrl = "images2/" + TextBox1.Text + ".png"; }
                if (File.Exists(imageExtension3)) { ilacresim.ImageUrl = "images2/" + TextBox1.Text + ".jpeg"; }
                
                // SONUÇ EKRANI İÇİN YAPILAN İŞLEMLER //
                using (SqlCommand cmd2 = new SqlCommand("SELECT ilacadi, stokdurumu, alternatifilaclar, tedarikzamani FROM Table_1 where ilacadi = '" + TextBox1.Text + "' or ilacadi= '" + alternatif + "' "))
                {
                    cmd2.Connection = baglanti;
                    

                    SqlDataReader read2 = cmd2.ExecuteReader();

                    while (read2.Read())
                    {
                        if (read2["ilacadi"].ToString() == TextBox1.Text)
                        {

                            Label8.Text = "Aradığınız ilaç " + read2["ilacadi"].ToString() + "";
                            Label9.Text = read2["stokdurumu"].ToString();
                            tedarik1 = read2["tedarikzamani"].ToString();

                        }
                        if (read2["ilacadi"].ToString() == alternatif)
                        {

                            Label10.Text = "Aradığınız ilacın alternatifi " + read2["ilacadi"].ToString() + "";
                            Label11.Text = read2["stokdurumu"].ToString();
                            tedarik2 = read2["tedarikzamani"].ToString();
                        }
                       
                    }

                    
                    read2.Close();
                    baglanti.Close();
                }

                tedarik1Int = Convert.ToInt32(tedarik1);
                tedarik2Int = Convert.ToInt32(tedarik2);
                if (Label9.Text == "YOK")
                {
                    Label8.ForeColor = Color.Red;
                    Label9.ForeColor = Color.Red;
                    Label14.ForeColor = Color.Red;
                    Label14.Text = "ve bu ilaç " + tedarik1 + " gün sonra temin edilecektir.";
                }
                else if (Label9.Text == "VAR")
                {
                    Label8.ForeColor = Color.Green;
                    Label9.ForeColor = Color.Green;
                    Label14.Text = "";
                }
                if (Label11.Text == "YOK")
                {
                    Label10.ForeColor = Color.Red;
                    Label11.ForeColor = Color.Red;
                    Label15.ForeColor = Color.Red;
                    Label15.Text = "ve bu ilaç " + tedarik2 + " gün sonra temin edilecektir.";
                }
                else if (Label11.Text == "VAR")
                {
                    Label10.ForeColor = Color.Green;
                    Label11.ForeColor = Color.Green;
                    Label15.Text = "";
                }

                Label16.ForeColor = Color.Blue;
                if (Label9.Text == "VAR" && Label11.Text == "VAR") { Label16.Text = "" + Label8.Text + " ilacı eczanede mevcuttur."; }
                else if (Label9.Text == "YOK" && Label11.Text == "VAR") { Label16.Text = "" + Label8.Text + " ilacı " + tedarik1 + " gün sonra temin edilecektir. " + Label10.Text + " ilacı eczanede mevcuttur."; }
                else if (Label11.Text == "YOK" && Label9.Text == "VAR") { Label16.Text = "" + Label8.Text + " ilacı eczanede mevcuttur."; }
                else if (Label11.Text == "YOK" && Label9.Text == "YOK")
                {



                    if (tedarik1Int <= tedarik2Int) { Label16.Text = "" + Label8.Text + " ilacı ve " + Label10.Text.ToLower() + " ilacı eczanede mevcut değildir. Bu durumda en erken olarak " + Label8.Text.ToLower() + " ilacını " + tedarik1 + " gün sonra temin edebilirsiniz"; }
                    else if (tedarik1Int > tedarik2Int) { Label16.Text = "" + Label8.Text + " ilacı ve " + Label10.Text.ToLower() + " ilacı eczanede mevcut değildir. Bu durumda en erken olarak " + Label10.Text.ToLower() + " ilacını " + tedarik2 + " gün sonra temin edebilirsiniz"; }


                }

            }
            // İLAÇ ADI YANLIŞ İSE İŞLEMLER //
            else
            {

                Label16.Text = "İlaç adını yanlış girdiniz lütfen tekrar deneyiniz.";
                Label8.Text = "";
                Label15.Text = Label14.Text = Label11.Text = Label10.Text = Label9.Text = Label8.Text;


                baglanti.Close();

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginScreen.aspx");


        }


        // YORUM SIFIRLA VE GÖNDER BUTONUNA BASILDIĞINDA YAPILAN İŞLEMLER //
        protected void reset_Click(object sender, EventArgs e)
        {
            comment.Text = "";
        }
      

        
        protected void submitcontrol_Click(object sender, EventArgs e)
        {

            baglanti.Open();

           
            SqlCommand gonder = new SqlCommand("insert into Table_2(kullanici_ilac, kullanici_ad, kullanici_yorum) values (@kullanici_ilac,@kullanici_ad,@kullanici_yorum)", baglanti);
            gonder.Parameters.AddWithValue("kullanici_ilac", TextBox1.Text);
            gonder.Parameters.AddWithValue("kullanici_ad", name.Text);
            gonder.Parameters.AddWithValue("kullanici_yorum", comment.Text);

                 
            gonder.ExecuteNonQuery();
            
           

            Label17.ForeColor = Color.Green;
            Label17.Text = "Yorum Gönderildi";
            
            Yorum_Goster();

        }

        // İLAÇLA İLGİLİ VE ONAYLANMIŞ YORUMLARI GÖSTEREN İŞLEMLER //
        protected void Yorum_Goster()
        {
          
            using (SqlCommand cmd5 = new SqlCommand("SELECT kullanici_id, kullanici_ilac, kullanici_ad, kullanici_yorum FROM Table_2 WHERE kullanici_ilac = '" + TextBox1.Text + "' AND admin_onay = 'ONAY' "))
            {
                cmd5.Connection = baglanti;
                SqlDataReader read5 = cmd5.ExecuteReader();
                while (read5.Read())
                {
                                           
                        HtmlGenericControl myDiv = new HtmlGenericControl("div");
                        myDiv.ID = read5["kullanici_id"].ToString();
                        //myDiv.InnerHtml = "< figure class=avatar><img src = images/demo/avatar.png /></figure>";
                        myDiv.InnerHtml = "<ul><li><article><header><figure class = avatar><img src = 'images/demo/avatar.png' /></figure> " +
                            "<div id = divName runat = server><address>" + read5["kullanici_ad"].ToString() + "</address></div></header>" +
                            "<div id = divComment class = comcont runat = server><p>" + read5["kullanici_yorum"].ToString() + "</p></div></article></li></ul>";

                        PlaceHolder1.Controls.Add(myDiv);
                   
                }
                read5.Close();
            }
           
        }
        // ARKA PLAN RESMİNİN GÖSTERİLMESİ //
        protected void ArkaPlan()
        {

            backgExtension1 = @"C:\Users\eren_\source\repos\BLM461M\BLM461M\backgrounds2\backgroundimage.jpg";
            backgExtension2 = @"C:\Users\eren_\source\repos\BLM461M\BLM461M\backgrounds2\backgroundimage.jpeg";
            backgExtension3 = @"C:\Users\eren_\source\repos\BLM461M\BLM461M\backgrounds2\backgroundimage.png";

            if (File.Exists(backgExtension1)) { divID3.Style["background-image"] = Page.ResolveUrl("backgrounds2/backgroundimage.jpg"); }
            if (File.Exists(backgExtension2)) { divID3.Style["background-image"] = Page.ResolveUrl("backgrounds2/backgroundimage.jpeg"); }
            if (File.Exists(backgExtension3)) { divID3.Style["background-image"] = Page.ResolveUrl("backgrounds2/backgroundimage.png"); }


        }





    }
}