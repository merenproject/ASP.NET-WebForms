using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using DevExpress.ClipboardSource.SpreadsheetML;
using System.IO;
using System.Drawing;
using System.Web.UI.HtmlControls;
using System.Activities.Expressions;

namespace BLM461M
{
    public partial class Fdatabase1 : System.Web.UI.Page
    {
        bool confirm2;
        string extension;
        string imageExtension1;
        string imageExtension2;
        string imageExtension3;
        string backgExtension1;
        string backgExtension2;
        string backgExtension3;
        
        // DATABASE BAĞLANMA İŞLEMİ //
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-VGHLIGB; Initial Catalog=blm461m;Integrated Security=True");


        // SAYFA YÜKLENDİĞİNDE YAPILAN İŞLEMLER //
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.GridShow();
                Label1.Text = "";
                Label2.Text = "";
                Label3.Text = "";
                Label6.Text = "";
                Label7.Text = "";
                Label20.Text = "";
                ilacbilgikismi.Visible = false;
                ArkaPlan();
                
            }
            Yorum_Goster();
        }
        // EKLE BUTONUNA BASILINCA YAPILAN İŞLEMLER //
        protected void Ekle_Click(object sender, EventArgs e)
        {


            baglanti.Open();

            

            SqlCommand gonder = new SqlCommand("insert into Table_1(ilacadi,stokdurumu,tedarikzamani,alternatifilaclar) values (@ilacadi,@stokdurumu,@tedarikzamani,@alternatifilaclar)", baglanti);
            gonder.Parameters.AddWithValue("ilacadi", TextBox1.Text);
            gonder.Parameters.AddWithValue("stokdurumu", DropDownList1.Text);
            if (DropDownList1.Text == "VAR")
            {
                gonder.Parameters.AddWithValue("tedarikzamani", 0);
            }
            else
            {
                gonder.Parameters.AddWithValue("tedarikzamani", TextBox3.Text);
            }
            gonder.Parameters.AddWithValue("alternatifilaclar", TextBox4.Text);
            gonder.ExecuteNonQuery();
            Aktar();
            baglanti.Dispose();
            baglanti.Close();
            Label1.Text = "Ekleme İşlemi Başarılı";
        }



        // EKLENEN BİLGİLERİN GRIDVIEWE AKTARILMASI //
        protected void Aktar()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandText = "SELECT id, ilacadi, stokdurumu, tedarikzamani, alternatifilaclar FROM Table_1";

            SqlDataReader read = cmd.ExecuteReader();


            GridView1.DataSource = read;
            GridView1.DataBind();


            read.Close();
            //baglanti.Close();

        }
        // GRIDVIEWDEN SATIR SİLME İŞLEMİ //
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);


            using (SqlCommand cmd = new SqlCommand("DELETE FROM Table_1 WHERE id = @id"))
            {
                cmd.Parameters.AddWithValue("id", id);
                cmd.Connection = baglanti;
                baglanti.Open();
                cmd.ExecuteNonQuery();
                baglanti.Close();
            }

            this.GridShow();
        }
        // GENEL GRIDVIEW //
        public void GridShow()
        {


            using (SqlCommand cmd = new SqlCommand("SELECT id, ilacadi, stokdurumu, tedarikzamani, alternatifilaclar FROM Table_1"))
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


            using (SqlCommand cmd2 = new SqlCommand("SELECT id, ilacadi, stokdurumu, tedarikzamani, alternatifilaclar FROM Table_1 where ilacadi ='" + TextBox5.Text + "' "))
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
        // GRIDVIEW EDIT İŞLEMİ İÇİN INDEXLERİ TUTMA İŞLEMİ //
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.GridShow();
        }

        // GRIDVIEW SATIR GÜNCELLEME İŞLEMİ //
        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {



            GridViewRow row = GridView1.Rows[e.RowIndex];
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string ilacadi = (row.Cells[2].Controls[0] as TextBox).Text;
            string stokdurumu = (row.Cells[3].Controls[0] as TextBox).Text;
            string tedarikzamani = (row.Cells[4].Controls[0] as TextBox).Text;
            string alternatifilaclar = (row.Cells[5].Controls[0] as TextBox).Text;



            using (SqlCommand cmd = new SqlCommand("UPDATE Table_1 SET ilacadi = @ilacadi, stokdurumu = @stokdurumu, tedarikzamani = @tedarikzamani, alternatifilaclar = @alternatifilaclar WHERE id = @id"))
            {
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("ilacadi", ilacadi);
                cmd.Parameters.AddWithValue("stokdurumu", stokdurumu);
                cmd.Parameters.AddWithValue("tedarikzamani", tedarikzamani);
                cmd.Parameters.AddWithValue("alternatifilaclar", alternatifilaclar);

                cmd.Connection = baglanti;
                baglanti.Open();
                cmd.ExecuteNonQuery();
                baglanti.Close();
            }

            GridView1.EditIndex = -1;
            this.GridShow();

        }

        // GRIDVIEW EDİTLEMEKTEN VAZGEÇERSEK İNDEXİN BIRAKILMASI //
        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            GridView1.EditIndex = -1;
            this.GridShow();
        }

        // ROW İŞLEMLERİ KONTROLÜ VE İSİM TEXTBOX BOYUT AYARLAMALARI //
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowState == DataControlRowState.Edit || e.Row.RowState == (DataControlRowState)5)
            {
                LinkButton lbUpdate = (LinkButton)e.Row.Controls[0].Controls[0];
                lbUpdate.Text = "Güncelle";

            }


            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Silme işlemini onaylayınız');";
                // (e.Row.Cells[0].Controls[0] as LinkButton).Attributes["onclick"] = "return confirm('Edit işlemi');";


            }
            if (e.Row.RowState == DataControlRowState.Edit)
            {
                TextBox ilacadi = (TextBox)e.Row.Cells[2].Controls[0];     //give the cell index of which column TextBox you want to set
                TextBox stokdurumu = (TextBox)e.Row.Cells[3].Controls[0];
                TextBox tedarikzamani = (TextBox)e.Row.Cells[4].Controls[0];
                TextBox alternatifilaclar = (TextBox)e.Row.Cells[5].Controls[0];
                ilacadi.Width = 90;
                stokdurumu.Width = 40;
                tedarikzamani.Width = 30;
                alternatifilaclar.Width = 90;
            }
        }
        
         ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginScreen.aspx");


        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // İLAÇ ARAMA İŞLEMİ //
        protected void Ara_Click(object sender, EventArgs e)
        {
            Label3.Text = "SONUÇLAR";
            Label7.Text = "";
            baglanti.Open();

            using (SqlCommand cmd3 = new SqlCommand("SELECT ilacadi, ilacbilgileri FROM Table_1 WHERE ilacadi= '" + TextBox5.Text + "' "))
            {

                cmd3.Connection = baglanti;
                SqlDataReader read3 = cmd3.ExecuteReader();
                while (read3.Read())
                {
                    if (TextBox5.Text == read3["ilacadi"].ToString())
                    {
                        confirm2 = true;
                        TextBox7.Text = read3["ilacbilgileri"].ToString();
                        TextBox8.Text = TextBox7.Text;
                    }
                    else { confirm2 = false; }

                }
                read3.Close();
                // EĞER İLAÇ BİLGİSİ BULUNDUYSA BİLGİ VE YORUM KISIMLARI GÖSTERİLİYOR // 
                if (confirm2)
                {
                    Label2.Text = "";
                    this.GridShow2();
                    Label4.Text = "" + TextBox5.Text + " İlacı";
                    ilacbilgikismi.Visible = true;
                    Label18.Text = TextBox5.Text + " İlacı Yorumları";
                   // Yorum_Goster();
                    
                    // İLAÇ RESMİNİN GÖSTERİLMESİ İŞLEMİ (BU 3 TÜRDEN HANGİ UZANTIDA VARSA RESMİ GÖSTERİYOR)//

                    imageExtension1 = @"C:\Users\eren_\source\repos\BLM461M\BLM461M\images2\" + TextBox5.Text + ".jpg";
                    imageExtension2 = @"C:\Users\eren_\source\repos\BLM461M\BLM461M\images2\" + TextBox5.Text + ".png";
                    imageExtension3 = @"C:\Users\eren_\source\repos\BLM461M\BLM461M\images2\" + TextBox5.Text + ".jpeg";

                    if (File.Exists(imageExtension1)) { ilacresim.ImageUrl = "images2/" + TextBox5.Text + ".jpg"; }
                    if (File.Exists(imageExtension2)) { ilacresim.ImageUrl = "images2/" + TextBox5.Text + ".png"; }
                    if (File.Exists(imageExtension3)) { ilacresim.ImageUrl = "images2/" + TextBox5.Text + ".jpeg"; }


                   
               }
                // İLAÇ ADININ HATALI OLMASI DURUMUNDA //
                else { Label2.Text = "İlaç adını hatalı girdiniz."; }
            }



        }
        
        ////////////////////////////***********************************************************///////////////////////////
       
        protected void OnRowDataBound2(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowState == DataControlRowState.Edit || e.Row.RowState == (DataControlRowState)5)
            {
                LinkButton lbUpdate = (LinkButton)e.Row.Controls[0].Controls[0];
                lbUpdate.Text = "Güncelle";

            }



            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView2.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Silme işlemini onaylayınız');";

            }
            if (e.Row.RowState == DataControlRowState.Edit)
            {

                TextBox ilacadi = (TextBox)e.Row.Cells[2].Controls[0];     
                TextBox stokdurumu = (TextBox)e.Row.Cells[3].Controls[0];
                TextBox tedarikzamani = (TextBox)e.Row.Cells[4].Controls[0];
                TextBox alternatifilaclar = (TextBox)e.Row.Cells[5].Controls[0];
                ilacadi.Width = 90;
                stokdurumu.Width = 40;
                tedarikzamani.Width = 30;
                alternatifilaclar.Width = 90;
            }

        }

        protected void OnRowCancelingEdit2(object sender, EventArgs e)
        {
            GridView2.EditIndex = -1;
            this.GridShow2();
            this.GridShow();
        }

        protected void OnRowUpdating2(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView2.Rows[e.RowIndex];
            int id = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Values[0]);
            string ilacadi = (row.Cells[2].Controls[0] as TextBox).Text;
            string stokdurumu = (row.Cells[3].Controls[0] as TextBox).Text;
            string tedarikzamani = (row.Cells[4].Controls[0] as TextBox).Text;
            string alternatifilaclar = (row.Cells[5].Controls[0] as TextBox).Text;



            using (SqlCommand cmd = new SqlCommand("UPDATE Table_1 SET ilacadi = @ilacadi, stokdurumu = @stokdurumu, tedarikzamani = @tedarikzamani, alternatifilaclar = @alternatifilaclar WHERE id = @id"))
            {
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("ilacadi", ilacadi);
                cmd.Parameters.AddWithValue("stokdurumu", stokdurumu);
                cmd.Parameters.AddWithValue("tedarikzamani", tedarikzamani);
                cmd.Parameters.AddWithValue("alternatifilaclar", alternatifilaclar);

                cmd.Connection = baglanti;
                baglanti.Open();
                cmd.ExecuteNonQuery();
                baglanti.Close();
            }

            GridView2.EditIndex = -1;
            this.GridShow2();
            this.GridShow();
        }

        protected void OnRowEditing2(object sender, GridViewEditEventArgs e)
        {
            GridView2.EditIndex = e.NewEditIndex;
            this.GridShow2();
            this.GridShow();
        }

        protected void OnRowDeleting2(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Values[0]);


            using (SqlCommand cmd = new SqlCommand("DELETE FROM Table_1 WHERE id = @id"))
            {
                cmd.Parameters.AddWithValue("id", id);
                cmd.Connection = baglanti;
                baglanti.Open();
                cmd.ExecuteNonQuery();
                baglanti.Close();
            }

            this.GridShow2();
            this.GridShow();
        }
        
        /////////////////////////////////*************************************************///////////////////////////////
        


            //İLAÇ BİLGİLERİ DEĞİŞTİRME BÖLÜMÜ //
        protected void Degistir_Click(object sender, EventArgs e)
        {
            string ilacadi = TextBox5.Text;
            string ilacbilgileri = TextBox7.Text;



            using (SqlCommand cmd4 = new SqlCommand("UPDATE Table_1 SET ilacbilgileri = @ilacbilgileri  WHERE ilacadi = @ilacadi "))
            {
                cmd4.Parameters.AddWithValue("ilacadi", ilacadi);
                cmd4.Parameters.AddWithValue("ilacbilgileri", ilacbilgileri);

                cmd4.Connection = baglanti;
                baglanti.Open();
                cmd4.ExecuteNonQuery();
                baglanti.Close();


            }
            Label6.ForeColor = Color.Green;
            Label6.Text = "İlaç Bilgileri Güncellendi.";

        }

        protected void Iptal_Click(object sender, EventArgs e)
        {

            TextBox7.Text = TextBox8.Text;
            Label6.ForeColor = Color.Red;
            Label6.Text = "İşlem İptal Edildi.";
        }
        // İLAÇ RESMİ DEĞİŞTİRME BÖLÜMÜ //
        protected void UploadFile(object sender, EventArgs e)
        {
            string folderPath = Server.MapPath("images2/");

            //Check whether Directory (Folder) exists.
            if (!Directory.Exists(folderPath))
            {
                
                Directory.CreateDirectory(folderPath);
            }

            
            // EĞER YÜKLENECEK RESİM İLE AYNI İSİMDE BAŞKA BİR RESİM DOSYASI VARSA O DOSYA SİLİNİYOR //
            if (FileUpload1.HasFile)
            {



                imageExtension1 = @"C:\Users\eren_\source\repos\BLM461M\BLM461M\images2\" + TextBox5.Text + ".jpg";
                imageExtension2 = @"C:\Users\eren_\source\repos\BLM461M\BLM461M\images2\" + TextBox5.Text + ".png";
                imageExtension3 = @"C:\Users\eren_\source\repos\BLM461M\BLM461M\images2\" + TextBox5.Text + ".jpeg";


                if (File.Exists(imageExtension1)) { FileInfo filedeleter = new FileInfo(imageExtension1); filedeleter.Delete(); }
                if (File.Exists(imageExtension2)) { FileInfo filedeleter = new FileInfo(imageExtension2); filedeleter.Delete(); }
                if (File.Exists(imageExtension3)) { FileInfo filedeleter = new FileInfo(imageExtension3); filedeleter.Delete(); }

                // İLAÇLA İLGİLİ RESİM DOSYASINI İLAÇLA AYNI İSİMDE KAYDEDİYOR //
                extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                if (extension != ".jpg" && extension != ".jpeg" && extension != ".png") { Label7.ForeColor = Color.Red; Label7.Text = "Resim türü .jpg, .jpeg veya .png olmalıdır."; }
                FileUpload1.SaveAs(folderPath + TextBox5.Text + extension);
                Label7.ForeColor = Color.Green;
                Label7.Text = "Resim şu isimle yüklendi: " + TextBox5.Text + extension;
                ilacresim.ImageUrl = "images2/" + TextBox5.Text + extension;
                
            }
            else
            {
                Label7.ForeColor = Color.Red;
                Label7.Text = "Önce Resim Seçiniz.";
            }


            



        }
        // YORUM ONAYLAMA VEYA SİLME BÖLÜMÜ //
        protected void Yorum_Goster()
        {



            using (SqlCommand cmd6 = new SqlCommand("SELECT kullanici_id, kullanici_ad, kullanici_yorum FROM Table_2 WHERE kullanici_ilac= '" + TextBox5.Text + "' AND admin_onay IS NULL "))
            {

                baglanti.Open();
                cmd6.Connection = baglanti;
                SqlDataReader read6 = cmd6.ExecuteReader();
                while (read6.Read())
                {

                    // HER YORUM İÇİN DİV BÖLÜMÜNÜ VE SİLME - ONAYLAMA BUTONLARINI OLUŞTURUYOR //
                    HtmlGenericControl myDiv = new HtmlGenericControl("div");
                    myDiv.ID = "div"+ read6["kullanici_id"].ToString();
                    //myDiv.InnerHtml = "< figure class=avatar><img src = images/demo/avatar.png /></figure>";
                    Button btnSil = new Button();
                    btnSil.ID = read6["kullanici_id"].ToString();
                    btnSil.Click += new EventHandler (BtnSil_Click);
                    btnSil.CausesValidation = false;
                    btnSil.Text = "Sil";
                    btnSil.CssClass = "btn btn-primary";
                    btnSil.BackColor = Color.LightSalmon;
                    btnSil.ForeColor = Color.White;
                    btnSil.Font.Bold = true;

                    Button btnOnay = new Button();
                    btnOnay.ID = "a"+read6["kullanici_id"].ToString();
                    btnOnay.Click += new EventHandler(BtnOnay_Click);
                    btnOnay.CausesValidation = false;
                    btnOnay.Text = "Onay";
                    btnOnay.CssClass = "btn btn-primary";
                    btnOnay.BackColor = Color.LightGreen;
                    btnOnay.ForeColor = Color.White;
                    btnOnay.Font.Bold = true;

                    myDiv.InnerHtml = "<li><ul><article><header><figure class = avatar><img src = 'images/demo/avatar.png' /></figure> " +
                        "<div id = divName runat = server><address>" + read6["kullanici_ad"].ToString() + "</address></div></header>" +
                        "<div id = divComment class = comcont runat = server><p>" + read6["kullanici_yorum"].ToString() + "</p></div></article>" +
                        "</ul></li>";

                    myDiv.Controls.Add(btnSil);
                    myDiv.Controls.Add(btnOnay);
                    //Response.Write(DateTime.Now.ToString());
                    PlaceHolder1.Controls.Add(myDiv);
                    PlaceHolder1.Controls.Add(new HtmlGenericControl("br"));

                    // YORUM SİLME BUTONU //
                    void BtnSil_Click(object sender, EventArgs e)
                    {

                        int kullanici_id = Convert.ToInt32(btnSil.ID);


                        using (SqlCommand cmd7 = new SqlCommand("DELETE FROM Table_2 WHERE kullanici_id = @kullanici_id"))
                        {
                            cmd7.Parameters.AddWithValue("kullanici_id", kullanici_id);
                            cmd7.Connection = baglanti;
                            baglanti.Open();
                            cmd7.ExecuteNonQuery();
                            baglanti.Close();
                            
                        }


                    }
                    // YORUM ONAY BUTONU //
                    void BtnOnay_Click(object sender, EventArgs e)
                    {
                        string example = btnOnay.ID;
                        string trimmed = example.Trim('a', 'z');

                        int kullanici_id = Convert.ToInt32(trimmed);
                        string admin_onay = "ONAY";

                        using (SqlCommand cmd8 = new SqlCommand("UPDATE Table_2 SET admin_onay = @admin_onay WHERE kullanici_id = @kullanici_id"))
                        {
                            cmd8.Parameters.AddWithValue("kullanici_id", kullanici_id);
                            cmd8.Parameters.AddWithValue("admin_onay", admin_onay);
                            cmd8.Connection = baglanti;
                            baglanti.Open();
                            cmd8.ExecuteNonQuery();
                            baglanti.Close();
                        }
                        btnOnay.Visible = false;

                    }
                }
                read6.Close();
                baglanti.Close();
            }



        }

         // ARKA PLAN RESMİ DEĞİŞTİRME KISMI //
        protected void UploadFile2(object sender, EventArgs e)
        {
            string folderPath = Server.MapPath("backgrounds2/");

            
            if (!Directory.Exists(folderPath))
            {
                
                Directory.CreateDirectory(folderPath);
            }

            
            if (FileUpload2.HasFile)
            {

                backgExtension1 = @"C:\Users\eren_\source\repos\BLM461M\BLM461M\backgrounds2\backgroundimage.jpg";
                backgExtension2 = @"C:\Users\eren_\source\repos\BLM461M\BLM461M\backgrounds2\backgroundimage.jpeg";
                backgExtension3 = @"C:\Users\eren_\source\repos\BLM461M\BLM461M\backgrounds2\backgroundimage.png";


                if (File.Exists(backgExtension1)) { FileInfo filedeleter = new FileInfo(backgExtension1); filedeleter.Delete(); }
                if (File.Exists(backgExtension2)) { FileInfo filedeleter = new FileInfo(backgExtension2); filedeleter.Delete(); }
                if (File.Exists(backgExtension3)) { FileInfo filedeleter = new FileInfo(backgExtension3); filedeleter.Delete(); }

                // RESİMLERİ "backgroundimage" ADIYLA KAYDEDİYOR //
                extension = Path.GetExtension(FileUpload2.PostedFile.FileName);
                if (extension != ".jpg" && extension != ".jpeg" && extension != ".png") { Label20.ForeColor = Color.Red; Label20.Text = "Resim türü .jpg, .jpeg veya .png olmalıdır."; }
                FileUpload2.SaveAs(folderPath + "backgroundimage" + extension);
                Label20.ForeColor = Color.Green;
                Label20.Text = "Resim şu isimle yüklendi: " + "backgroundimage" + extension;
                divID2.Style["background-image"] = Page.ResolveUrl("backgrounds2/backgroundimage"+ extension);         
               
            }
            else
            {
                Label20.ForeColor = Color.Red;
                Label20.Text = "Önce Resim Seçiniz.";
            }


            



        }


        // ARKA PLAN RESMİNİN GÖSTERİLMESİ İŞLEMİ //
        protected void ArkaPlan()
        {

            backgExtension1 = @"C:\Users\eren_\source\repos\BLM461M\BLM461M\backgrounds2\backgroundimage.jpg";
            backgExtension2 = @"C:\Users\eren_\source\repos\BLM461M\BLM461M\backgrounds2\backgroundimage.jpeg";
            backgExtension3 = @"C:\Users\eren_\source\repos\BLM461M\BLM461M\backgrounds2\backgroundimage.png";

            if (File.Exists(backgExtension1)) { divID2.Style["background-image"] = Page.ResolveUrl("backgrounds2/backgroundimage.jpg"); }
            if (File.Exists(backgExtension2)) { divID2.Style["background-image"] = Page.ResolveUrl("backgrounds2/backgroundimage.jpeg"); }
            if (File.Exists(backgExtension3)) { divID2.Style["background-image"] = Page.ResolveUrl("backgrounds2/backgroundimage.png"); }


        }








    }
}
    