<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginScreen.aspx.cs" Inherits="BLM461M.WebForm1" %>

<%@ Register assembly="DevExpress.Web.Bootstrap.v20.2, Version=20.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.Bootstrap" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v20.2, Version=20.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Content/Site.css" rel="stylesheet" /> 
    <style type="text/css">
        #divID {
            width: 600px;
        }
        #LoginDegisDiv {
            height: 217px;
        }
    </style>
</head>
    <form id="form1" runat="server">
<body id="bodyID" runat="server">
    &nbsp;
      <center>
        
        
        
        
        <div id="divID" runat="server" align="center" style="width auto; height: 600px; opacity: 0.95;">
            &nbsp;&nbsp;
        
        <div align="center" style="height: 59px" >
            <br />
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="X-Large" >ADMİN GİRİŞ</asp:Label>
        </div>
        <div id="LoginDiv" runat="server" align="center">
            
            <p>
                &nbsp;&nbsp;&nbsp;<asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" PasswordRequiredErrorMessage="Parola gereklidir." DisplayRememberMe ="false" DisplayConfirmation="false" Width="298px">
                    <LayoutTemplate>
                        <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                            <tr>
                                <td>
                                    <table cellpadding="0" style="width:359px;">
                                        <tr>
                                            <td align="center" colspan="2">Oturum Aç<br /> <br /> </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Kullanıcı Adı:</asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="UserName" runat="server" ></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="Kullanıcı Adı gereklidir." ForeColor="Red" ToolTip="Kullanıcı Adı gereklidir." ValidationGroup="Login1">Zorunludur</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Parola:</asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Password" runat="server"  TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Parola gereklidir." ForeColor="Red" ToolTip="Parola gereklidir." ValidationGroup="Login1">Zorunludur</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2" style="color:Red;">
                                                <br />
                                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Oturum Aç" ValidationGroup="Login1" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                </asp:Login>
&nbsp;</p>
      </div>
        <div align="center">
            <p>
                <asp:Button ID="Button3" runat="server" Text="Devam" Visible="False" OnClick="Button3_Click"/>
                &nbsp;&nbsp;
                <asp:Button ID="Button6" runat="server" Text="Hesap Bilgilerini Değiştir" Visible="False" OnClick="Btn6Goster_Click"/>
        </p>
      </div>
            <div align="center">
                <p>
                <asp:Label ID="Label3" runat="server" Text="Label" ForeColor="Green"></asp:Label>
        </p>
      </div>
      <div id="LoginDegisDiv" runat="server" align="center">







          Hesap Bilgilerini Değiştir<br />
          <br />
          Yeni Kullanıcı Adı:&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:TextBox ID="TextBox1" runat="server" ValidationGroup="ValidDegis"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Zorunludur" ForeColor="Red" ValidationGroup="ValidDegis" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
          <br />
          Yeni Şifre:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" ValidationGroup="ValidDegis"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Zorunludur" ForeColor="Red" ValidationGroup="ValidDegis" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
          <br />
          Şifreyi Doğrulayınız:&nbsp;
          <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" ValidationGroup="ValidDegis"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Zorunludur" ForeColor="Red" ValidationGroup="ValidDegis" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
          <br />
          <br />
          <asp:Button ID="Button4" runat="server" Text="Değiştir" Onclick ="BtnDegistir_Click" ValidationGroup="ValidDegis"/>
&nbsp;&nbsp;
          <asp:Button ID="Button5" runat="server" Text="İptal" OnClick ="BtnIptal_Click"/>
          <br />
          <br />
          <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>







      </div>
            
            
            
            
            <div align="center"><p>
            <asp:Label ID="Label2" runat="server" Text="Label" Font-Bold="True" Font-Names="Arial" Font-Size="Large"></asp:Label>
        </p></div>
      <div align="center">
        <br /><br /><asp:Button ID="Button2" runat="server" Text="ANASAYFA" Height="42px" Width="169px" OnClick="Button2_Click" />
          <br />
          <br />
      </div>
    </div>
            </center>
          
    
</body>
</form>
</html>
