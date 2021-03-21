<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fdatabase2.aspx.cs" Inherits="BLM461M.Fdatabase2" %>

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
      <!--li><a href="#" title="Sign Up"><i class="fa fa-lg fa-edit"></i></a></li-->
    </ul>
    <!-- ################################################################################################ -->
  </div>
</div>
<!-- ################################################################################################ -->
<!-- ################################################################################################ -->
<!-- ################################################################################################ -->
<form runat="server">
<div class="wrapper row1">
  <header id="header" class="hoc clear">
    <section> 
      <!-- ################################################################################################ -->
      <div><i class="fa fa-phone"></i> 123-45-67</div>
      <div>
        <h1 id="logo"><a href="Fdatabase1.aspx">Eczane Bilgi Sistemi<br /><br /></a></h1>
      </div>
      
        
      <div>                             
         
          <asp:TextBox id="Arama1" runat="server" placeholder="İlaç Arayın&hellip;" Width="150px"></asp:TextBox>
           
      </div>
      <div>         
                      <asp:Button class="btn btn-primary" runat="server" id="btnArama1" text="Ara" Width="56px"></asp:Button>
     </div>
         
        
      <!-- ################################################################################################ -->
    </section>
    <nav id="mainav"> 
      <!-- ################################################################################################ -->
      <ul class="clear">
        <li><a href="Fdatabase2.aspx">Anasayfa</a></li>
        <li class="active"><a class="drop" href="#">Sayfalar</a>
          <ul>
            
            <li class="active"><a href="Fdatabase2.aspx">Kullanıcı Bölümü</a></li>
            <li><a href="LoginScreen.aspx">Admin Bölümü</a></li>
            
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
	
    
    <div id="divID3" runat="server" class="bgded">
  <div id="pageintro" class="hoc clear"> 
    <article>
      <h3 class="heading">Arama Bölümü</h3>
	  
	  
	  
	  <div align="center">
  <header>
    <section> 
      <!-- ################################################################################################ -->
      
      <div >
    
    
    
    <!--------------------------------------------------------------------------------------------------------------------->
    
      <fieldset>
        
        
        
        
           

            

            <asp:Label ID="Label1" runat="server" Text="İLAÇ SORGULAMA" Font-Bold="True" Font-Names="Arial" Font-Size="Large"></asp:Label><p></p>
           
   
            <asp:TextBox ID="TextBox1" runat="server" placeholder="İlac adını giriniz..." Height="21px" Width="160px"></asp:TextBox><p></p>
            
            
           <!-- <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Geri" OnClick="Button1_Click"/> -->
          
            <asp:Button class="btn btn-primary" ID="Sorgula" runat="server" Text="Sorgula" OnClick="Sorgula_Click" ValidationGroup="Group1" Height="33px" Width="107px" />
            <br />
            
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="İlaç adı girmediniz" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
            
            
            <br /><br />
        
       
           
        <asp:GridView ID="GridView2" runat="server" style=" background-color:aliceblue;" >
        </asp:GridView><br /><br />
       
            
            
            <div style="background-color:white;">
                
            <asp:Label ID="Label2" runat="server" Font-Bold="True"></asp:Label><p></p>

            
            
            <asp:Label ID="Label8" runat="server" Text="Label" Font-Bold="True"></asp:Label>
<asp:Label ID="Label9" runat="server" Text="Label" Font-Bold="True"></asp:Label>
<asp:Label ID="Label14" runat="server" Text="Label" Font-Bold="True"></asp:Label>
          
            
            <asp:Label ID="Label10" runat="server" Text="Label" Font-Bold="True" Font-Underline="False"></asp:Label>
<asp:Label ID="Label11" runat="server" Text="Label" Font-Bold="True"></asp:Label>
            <asp:Label ID="Label15" runat="server" Text="Label" Font-Bold="True"></asp:Label>
           
            
            <asp:Label ID="Label16" runat="server" Text="Label" Font-Bold="True"></asp:Label>
            
            
       </div><br /><br />
       
        <asp:GridView ID="GridView1" runat="server" style=" background-color:aliceblue;" >
        </asp:GridView>
        
        
           
           </fieldset>  </div>
         </section>
    </header></div>

</article>
    <!-- ################################################################################################ -->
  </div>
</div>
    
    
    <div id="ilacbilgikismi" runat="server">
    <div class="wrapper row3">
  <main class="hoc container clear"> 
    <!-- main body -->
    <!-- ################################################################################################ -->
    <div class="sectiontitle">
       <h6 class="heading">İLAÇ BİLGİLERİ</h6>
      <p>&nbsp;</p>
    </div>
    <div class="group">
      <div class="one_half first"><asp:image runat="server" class="inspace-15 borderedbox" id="ilacresim" Height="360px" Width="474px" /></div>
      <div class="one_half">
        <ul class="nospace group inspace-15">
          
            <article>
              <h6 class="heading" align="center">
                  <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                </h6>
              <p id="ilacBilgiler" runat="server" class="nospace">
                  <asp:TextBox ID="TextBox7" runat="server" TextMode="MultiLine" Rows="5" cols="25" Height="328px" Width="527px" ForeColor="Black" ReadOnly="True"></asp:TextBox>
                </p>
            </article>   
        </ul>
      </div>
    </div>
    <!-- ################################################################################################ -->
    <!-- / main body -->
    <div class="clear"></div>
  </main>
</div>
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
            <asp:Label ID="Label20" runat="server" Text="Label"></asp:Label>
            <br />
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
        
        <!----------------------------------------------------------------------------------------------------------------------->
        
        <h2 align="center">
            <asp:Label ID="Label19" runat="server" Text="Label"></asp:Label><br /><br />
        </h2>
        
          <div class="one_third first">
            <label for="name">Ad <span>*</span></label>
            <asp:TextBox runat="server" type="text" name="name" id="name" value="" size="22" ></asp:TextBox>
          </div>
          <div class="one_third">
            <label for="email">E-Posta <span></span></label>
            <asp:TextBox runat="server" type="email" name="email" id="email" value="" size="22" ></asp:TextBox>
          </div>
          <div class="one_third">
            <label for="url">Website</label>
            <asp:TextBox runat="server" type="url" name="url" id="url" value="" size="22"></asp:TextBox>
          </div>
          <div class="block clear">
            <label for="comment">Yorumunuz</label>
            <asp:TextBox runat="server" name="comment" TextMode="MultiLine" Rows="5" id="comment" cols="25"  Height="110px" Width="957px"></asp:TextBox>
          </div>
          <div>
            <asp:Button runat="server" ID="submitcontrol" Text="Gönder" onClick="submitcontrol_Click" />
            &nbsp;
            <asp:Button runat="server" ID="reset" Text="Sıfırla" onClick="reset_Click" />
          &nbsp;<asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
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

    <a id="backtotop" href="#top"><i class="fa fa-chevron-up"></i></a>

<script src="layout/scripts/jquery.min.js"></script>
<script src="layout/scripts/jquery.backtotop.js"></script>
<script src="layout/scripts/jquery.mobilemenu.js"></script>
</body>
</html>
