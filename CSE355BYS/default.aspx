 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GoOn._default" MasterPageFile="~/template.Master" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.13.0/css/all.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css" />
    
    <mailSettings>
      <smtp deliveryMethod="Network">
        <network host="smtp.gmail.com" port="587" userName="email" password="password" enableSsl="true" />
      </smtp>
    </mailSettings>

    <style>
    .container i {
        margin-left: -30px;
        cursor: pointer;
    }
        .auto-style3 {
            display: block;
            padding: 6px 12px;
            font-size: 14px;
            line-height: 1.42857143;
            color: #555;
            background-color: #fff;
            background-image: none;
            border: 1px solid #ccc;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            margin-left: 0px;
        }
        .auto-style5 {
            display: block;
            padding: 6px 12px;
            font-size: 14px;
            line-height: 1.42857143;
            color: #555;
            background-color: #fff;
            background-image: none;
            border: 1px solid #ccc;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            margin-bottom: 0;
            margin-left: 200;
        }
        .auto-style8 {
            width: 32px;
            height: 37px;
            margin-left: 0px;
        }
        .auto-style9 {
            width: 24px;
            height: 31px;
            margin-left: 0px;
        }
        .auto-style10 {
            width: 467px;
            height: 91px;
        }
        .auto-style11 {
            width: 461px;
        }
        .auto-style12 {
            width: 0;
            height: 0;
        }
        .auto-style13 {
            width: 148px;
            height: 112px;
        }
        .auto-style14 {
            width: 499px;
            height: 71px;
        }
    </style>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<img alt="" class="auto-style13" src="images/uk.jpg" /></p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:Label ID="whoisuser" ToolTip="Suanki kullan&#305;c&#305;n ad&#305;" runat="server" BorderStyle="None"></asp:Label>
    </p>
    <p class="auto-style14">
        <img alt="" class="auto-style8" src="images/user.jpg" /><asp:TextBox ID="TextBox1" placeholder="Kullan&#305;c&#305; ID giriniz" CssClass="auto-style5" ToolTip="Sisteme girmek icin kimlik ve &#351;ifrenizi giriniz" runat="server" Width="92px" Height="18px"></asp:TextBox>
        <img class="auto-style12" src="images/ss.jpg" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p class="auto-style10">
        &nbsp;<img alt="" class="auto-style9" src="images/key.jpg" />&nbsp; <asp:LinkButton ID="LinkButton1" OnClick="unknownpass" runat="server" Visible="False">&#350;ifremi Unuttum</asp:LinkButton>
          <asp:TextBox ID="TextBox2" placeholder="&#350;ifreyi Giriniz" CssClass="auto-style3" name="txtpassword" TextMode="Password" runat="server" Width="92px" Height="18px"  ></asp:TextBox>
     &nbsp; &nbsp;<asp:CheckBox ID="CheckBox1" AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged" runat="server" Text="&#350;ifreyi göster" />
        <i id="togglePassword"  class="fa fa-eye" style="width: 133px"></i>    
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         
    </p>
    <p class="auto-style11">
        <asp:Button ID="Button1" runat="server" OnClick="btnGiris_Click" Text="Giri&#351;" style="height: 26px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ReenterPass" runat="server" OnClick="changepass" Text="&#350;ifreyi De&#287;i&#351;tir" ToolTip="&#350;ifreyi de&#287;i&#351;tirmek istedi&#287;inizde bu butona bas&#305;n&#305;z" />
    </p>
    <p>
        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">&#350;ifremi Unuttum</asp:LinkButton>
    </p>
</asp:Content>

