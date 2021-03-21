<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fdatabase1.aspx.cs" Inherits="BLM461M.Fdatabase1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>İlaç Sorgulama</title>
<meta charset="utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no"/>
<link href="layout/styles/layout.css" rel="stylesheet" type="text/css" media="all"/>


</head>
<body id="top")>
    <!-- ################################################################################################ -->
<!-- ################################################################################################ -->
<!-- ################################################################################################ -->
<div class="wrapper row0">
  <div id="topbar" class="hoc clear"> 
    <!-- ################################################################################################ -->
    <ul class="nospace">
      
      <li><a href="Fdatabase2.aspx" title="Anasayfa"><i class="fa fa-lg fa-home"></i></a></li>
      <li><a href="LoginScreen.aspx" title="Login"><i class="fa fa-lg fa-sign-in"></i></a></li>
      <li><a href="Fdatabase2.aspx" title="Çıkış"><i class="fa fa-lg fa-edit"></i></a></li>
    </ul>
    <!-- ################################################################################################ -->
  </div>
</div>
<!-- ################################################################################################ -->
<!-- ################################################################################################ -->
<!-- ################################################################################################ -->
<div class="wrapper row1">
  <header id="header" class="hoc clear">
    <section> 
      <!-- ################################################################################################ -->
      <div></div>
      <div>
        <h1 id="logo"><a href="Fdatabase1.aspx">Eczane Bilgi Sistemi<br /><br />Yönetim</a></h1>
      </div>
      <div>
        
      </div>
      <!-- ################################################################################################ -->
    </section>
    <nav id="mainav"> 
      <!-- ################################################################################################ -->
      <ul class="clear">
         <li><a href="Fdatabase2.aspx">Anasayfa</a></li>
        <li class="active"><a class="drop" href="#">Sayfalar</a>
          <ul>
            
            <li><a href="Fdatabase2.aspx">Kullanıcı Bölümü</a></li>
            <li class="active"><a href="Fdatabase1.aspx">Admin Bölümü</a></li>
            
          </ul>
        </li>
      </ul>
      <!-- ################################################################################################ -->
    </nav>
  </header>
</div>
<!-- ################################################################################################ -->
<!-- ################################################################################################ -->
<div class="wrapper row2">
  <header id="header" class="hoc clear">
     
      <!-- ################################################################################################ -->
      
      
      
      <!-- ################################################################################################ -->
    
    </header>
</div>
	
     <!-- ###################################################################style="background-image:url('backgrounds2/04.png');############################# -->
   
    <form runat="server">
    
    
    <div id="divID2" runat="server" class="bgded">
  
           <asp:FileUpload ID="FileUpload2" runat="server"  class="borderedbox" BackColor="White" /><br />
           <asp:Button class="btn btn-primary" ID="btnArkaplan" Text="Resmi Yükle" runat="server" OnClick="UploadFile2" Font-Bold="False"/>
           <asp:Label ID="Label20" runat="server" Text="Label" BackColor="White"></asp:Label>
        
        
        
        
        <div id="pageintro" class="hoc clear"> 
    <article>
      <h3 class="heading">Admin Bölümü</h3>
	  
	  
	  
	  <div align="center">
  <header>
    <section> 
      <!-- ################################################################################################ -->
      
      <div >
    
    
    
    
        
        <fieldset>
        
        
        
        
        
        
        
            
            <strong class="yeniStil1"><span class="auto-style1">
            
            İLAÇ EKLEME</span></strong><p></p>
            
            
            İlaç Adı: <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><p></p>
         Stok Durumu:
            <asp:DropDownList ID="DropDownList1" runat="server" Width="100px">
                <asp:ListItem>Seçiniz</asp:ListItem>
                <asp:ListItem>VAR</asp:ListItem>
                <asp:ListItem>YOK</asp:ListItem>
            </asp:DropDownList><p></p>
             Tedarik Zamanı:
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><p></p>
 Alternatif ilaçlar:
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox><p></p>
        
        
        
            
            
             <!--   <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Çıkış" OnClick="Button1_Click" Height="30px" Width="66px"/> -->
<asp:Button class="btn btn-primary" ID="Ekle" runat="server" Text="Ekle" OnClick="Ekle_Click" OnClientClick="return confirm('Ekleme işlemini onaylayınız');" Height="34px" Width="77px" /> <br /><br />
            
       <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="True" ForeColor="Green"></asp:Label>
            
        
            
            <strong class="yeniStil2">
            <br />
            İLAÇ ARAMA</strong><p></p>
            
            
            <asp:TextBox ID="TextBox5" runat="server" placeholder="İlac adını giriniz..." Width="153px"></asp:TextBox><p></p>
<asp:Button class= "btn btn-primary" ID="Ara" runat="server" Text="Ara" Onclick="Ara_Click" ValidationGroup="Group2" Height="28px" Width="66px" /><br />

            <asp:Label ID="Label2" runat="server" Text="Label" ForeColor="Red"></asp:Label>
            
            
            
            

            <br />
            
            
            
            

            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox5" ErrorMessage="İlaç adı girmediniz" ForeColor="Red" ValidationGroup="Group2"></asp:RequiredFieldValidator>
            
            
            
            <div style="background-color:white;">
            <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Label"></asp:Label><p></p>
            <asp:GridView ID="GridView2" runat="server" style=" background-color:aliceblue;" DataKeyNames="id" OnRowDataBound="OnRowDataBound2" OnRowEditing="OnRowEditing2" OnRowCancelingEdit="OnRowCancelingEdit2" 
            OnRowUpdating="OnRowUpdating2" OnRowDeleting="OnRowDeleting2" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True">
                
            </asp:GridView>
            </div><br /><br />
           
        <asp:GridView ID="GridView1" runat="server" style=" background-color:aliceblue; " DataKeyNames="id" OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" 
            OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" 
             AutoGenerateEditButton="True" AutoGenerateDeleteButton="True">
        
        </asp:GridView>
    
            
           </fieldset> </div>
         </section>
    </header></div>
          
         </article>
    <!-- ################################################################################################ -->
  </div>
</div>
    
    <div id="ilacbilgikismi" runat="server">
    <!-- ################################################################################################ -->
    <div class="wrapper row3">
  <main class="hoc container clear"> 
    <!-- main body -->
    <!-- ################################################################################################ -->
    <div class="sectiontitle">
      <h6 class="heading">İLAÇ BİLGİLERİ DÜZENLEME</h6>
      <p>&nbsp;</p>
    </div>
    <div class="group">
      <div class="one_half first">
           <asp:FileUpload ID="FileUpload1" runat="server"  class="borderedbox" /><br />
           <asp:Button class="btn btn-primary" ID="btnUpload" Text="Resmi Yükle" runat="server" OnClick="UploadFile" />
           <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
           <br />
          <asp:image runat="server" class="inspace-15 borderedbox" id="ilacresim" Height="360px" Width="474px" />

      </div>
      <div class="one_half" align="center">
        <ul class="nospace group inspace-15">
          
            <article>
              <h6 class="heading">
                  <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                </h6>
              <p id="ilacBilgiler" runat="server" class="nospace">
                  <asp:TextBox ID="TextBox7" runat="server" TextMode="MultiLine" Rows="5" cols="25" Height="415px" Width="527px" ForeColor="Black"></asp:TextBox>
                   <br />
                  <asp:Button class="btn btn-primary" ID="Degistir" runat="server" Text="DEĞİŞTİR" onClick="Degistir_Click" Height="41px" Width="120px"/><br /><br />
                  <asp:Button class="borderedbox" ID="Iptal" runat="server" Text="İptal" onclick="Iptal_Click" Height="30px" Width="90px"/>
                  <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
              
              
              
              </p>
            </article>   
        </ul>
      </div>
    </div>
    <!-- ################################################################################################ -->
    <!-- / main body -->
    <div class="clear" >
        <br />
        <br />
        <br />
        
        </div>
  </main>
</div>
    <!-- ################################################################################################ -->
     <div class="clear">
         <asp:TextBox ID="TextBox8" runat="server" Visible="False"></asp:TextBox>
    </div>

    <!-- Yorum Denetleme Kısmı ------------------------------------------------------------------------------------->

    <!-- ------------------------------------------------------------------------------------------------------------------>
    
    <!-- ------------------------------------------------------------------------------------------------------------------>
    <div class="wrapper row3">
  <main class="hoc container clear"> 
    <!-- main body -->
    <!-- ################################################################################################ -->
    <div class="content"> 
    
    
    <div id="comments">
        <h2 align="center">
            <asp:Label ID="Label18" runat="server" Text="Label"></asp:Label><br /><br />
        </h2>
        <%--
        <ul>
          <li>
            <article>
              <header>
                <figure class="avatar"><img src="images/demo/avatar.png" alt="" /></figure>
                <div id="divName" runat="server"><address>
                    &nbsp;</address></div>
                <time datetime="2045-04-06T08:15+00:00">Friday, 6<sup>th</sup> April 2045 @08:15:00</time>
              </header>
              <div id="divComment" class="comcont" runat="server">
                <p>
                    &nbsp;</p>
              </div>
            </article>
          </li>
        </ul>
       --%>
        <!----------------------------------------------------------------------------------------------------------------------->
        <div>
        
                
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder><br /><br />


       </div>

 </div>
      <!-- ################################################################################################ -->
    </div>
    <!-- ################################################################################################ -->
   
      <!-- / main body -->
    <div class="clear"></div>
  </main>
</div>

<!-- ################################################################################################ -->
</div></form>
<!-- ################################################################################################ -->
    
    <div class="wrapper row2">
  <header id="header" class="hoc clear">
  <div align="center">
   15290030
     </div>
  </header>
</div>


<div class="wrapper coloured">
  <article class="hoc cta clear"> 
    <!-- ################################################################################################ -->
    <h6 class="three_quarter first"></h6>
    <!--footer class="one_quarter"><a class="btn" href="#"> &raquo;</a></!--footer-->
    <!-- ################################################################################################ -->
  </article>
</div>


    <!-- ################################################################################################ -->

    <a id="backtotop" href="#top"><i class="fa fa-chevron-up"></i></a>

<script src="layout/scripts/jquery.min.js"></script>
<script src="layout/scripts/jquery.backtotop.js"></script>
<script src="layout/scripts/jquery.mobilemenu.js"></script>
</body>
</html>
