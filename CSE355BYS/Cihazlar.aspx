<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cihazlar.aspx.cs" Inherits="GoOn.Cihazlar" MasterPageFile="~/template.Master" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    
    <p>
        &nbsp;</p>
    <p>
        Seri numaras&#305;&nbsp;
        <asp:TextBox ID="TextBox1" ToolTip="Cihaz&#305;n seri numaras&#305;n&#305; giriniz" runat="server" Wrap="True" CausesValidation="False" BorderStyle="NotSet"></asp:TextBox>
    </p>
    <p>
        Marka&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
        <asp:DropDownList  ID="marka" ToolTip="Cihaz&#305;n marka ad&#305;n&#305; giriniz" runat="server">
            <asp:ListItem>Erzurum</asp:ListItem>
            <asp:ListItem>&#304;stanbul</asp:ListItem>
            <asp:ListItem>bura</asp:ListItem>
            <asp:ListItem>ora</asp:ListItem>
            <asp:ListItem>&#351;uras&#305;</asp:ListItem>
        </asp:DropDownList>
    &nbsp;&nbsp; Marka Ad&#305;:<asp:TextBox ID="marad" runat="server" ToolTip="Marka ad&#305; ekleme i&#351;lemini buradan yap&#305;n&#305;z."></asp:TextBox>
    </p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="marek" OnClick="InsertMarka" runat="server" Text="Marka Ekle" />
&nbsp;
        <asp:Button ID="marsl" OnClick="DeleteMarka" runat="server" Text="Marka Sil" />
    </p>

   <p>
        Model&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
       <asp:DropDownList  ID="model" ToolTip="Cihaz&#305;n modelini seçiniz" runat="server">
            <asp:ListItem>Erzurum</asp:ListItem>
            <asp:ListItem>&#304;stanbul</asp:ListItem>
            <asp:ListItem>bura</asp:ListItem>
            <asp:ListItem>ora</asp:ListItem>
            <asp:ListItem>&#351;uras&#305;</asp:ListItem>
       </asp:DropDownList>
    &nbsp;&nbsp; Model Ad&#305;:<asp:TextBox ID="modad" runat="server" ToolTip="Model ad&#305; ekleme i&#351;lemini buradan yap&#305;n&#305;z."></asp:TextBox>
    </p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="modek" OnClick="InsertModel" runat="server" Text="Model Ekle" />
&nbsp;
        <asp:Button ID="modsl" OnClick="DeleteModel" runat="server" Text="Model Sil" />
    </p>
     <p>
         Depo&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList  ID="dropdownlist1" ToolTip="Cihaz&#305;n kime zimmetli oldu&#287;unu seçiniz" runat="server">
            <asp:ListItem>Erzurum</asp:ListItem>
            <asp:ListItem>&#304;stanbul</asp:ListItem>
            <asp:ListItem>bura</asp:ListItem>
            <asp:ListItem>ora</asp:ListItem>
            <asp:ListItem>&#351;uras&#305;</asp:ListItem>
          
         </asp:DropDownList>
    &nbsp;
         &nbsp;Depo Ad&#305;:<asp:TextBox ID="Add" runat="server" ToolTip="Depoya ekleme i&#351;lemini buradan yap&#305;n&#305;z." Width="119px"></asp:TextBox>
        <asp:Button ID="upd" runat="server" OnClick="Update_Click" Text="Depoya At" ToolTip="Depo bilgilerini güncellemek için lütfen butona bas&#305;n" />
    </p>
    <p>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="EkleDepo" runat="server" OnClick="InsertDepo" Text="Depo Ekle" Width="78px" />
         &nbsp;&nbsp;<asp:Button ID="Delete" runat="server" OnClick="DeleteDepo" Text="Depo Sil" Width="79px" />
         &nbsp;&nbsp;
    </p>
     <p>
         Kullan&#305;c&#305;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
         <asp:TextBox ID="TextBox6" ToolTip="Cihaz&#305; kimin kulland&#305;&#287;&#305;n&#305; giriniz" runat="server" ReadOnly="True"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Insert_Button" runat="server" OnClick="Insert_Click" Text="Ekle" style="height: 26px" ToolTip="Bilgileri eklemek için lütfen butona bas&#305;n" /> 
        <asp:Button ID="Button2" runat="server" OnClick="Delete_Click" Text="Sil" style="height: 26px" ToolTip="Bilgileri silmek için lütfen butona bas&#305;n" /> 
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click"  Text="Cihaz Bilgilerini Göster" style="height: 26px; margin-left: 240px" />
    </p>
    <p>
       
         <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
          
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />

         </asp:GridView>
       <p>
         <asp:Button ID="ExcelButton" runat="server" OnClick="Excel_Click" Text="Excelde Göster " style="height: 26px" />
         <asp:Button ID="WordButton" runat="server" OnClick="Word_Click" Text="Worde Göster " style="height: 26px" />
       </p>
       
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>

