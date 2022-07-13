<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="changep.aspx.cs" Inherits="GoOn.changep" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td>
                        <asp:Label ID="Label1" Text = "Lütfen kullanıcı adını ve değiştirmek istediğiniz şifreyi girin" runat="server" ></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Kullanıcı Adı:&nbsp; <asp:TextBox ID="userId" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Şifre:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="password" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp; </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Şifrenizi değiştirmek için lütfen butona basın:
                        <asp:Button ID="chnge" OnClick="OK" runat="server" Text="OK" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
        <table class="auto-style1">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
