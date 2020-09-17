<%@ Page Title="" Language="C#" MasterPageFile="~/MPage.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="StatsBet.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <table>
    <tr>
        <td><asp:Label ID="Label_pnome" runat="server" Text="Primeiro Nome"></asp:Label></td>
        <td><asp:TextBox ID="TextBox_pnome" runat="server" Enabled="false"></asp:TextBox></td>
    </tr>
   
    <tr>
        <td><asp:Label ID="Label_unome" runat="server" Text="Ultimo Nome"></asp:Label></td>
        <td><asp:TextBox ID="TextBox_unome" runat="server" Enabled="false"></asp:TextBox></td>
    </tr>
    
    <tr>
       <td><asp:Label ID="Label_genero" runat="server" Text="Genero"></asp:Label></td> 
       <td><asp:TextBox ID="TextBox_genero" runat="server"></asp:TextBox></td>
    </tr>
   
    <tr>
        <td><asp:Label ID="Label_nif" runat="server" Text="NIF"></asp:Label></td>
        <td><asp:TextBox ID="TextBox_nif" runat="server" Enabled="false"></asp:TextBox></td>
    </tr>
    
    <tr>
        <td><asp:Label ID="Label_dt_nasc" runat="server" Text="Data de Nascimento"></asp:Label></td>
        <td><asp:TextBox ID="TextBox_dtnasc" runat="server" Enabled="false"></asp:TextBox></td>
    </tr>
   
    <tr>
        <td><asp:Label ID="Label_email" runat="server" Text="Email"></asp:Label></td>
        <td><asp:TextBox ID="TextBox_email" runat="server" Enabled="false"></asp:TextBox></td>
    </tr>
    
    <tr>
        <td><asp:Label ID="Label_morada" runat="server" Text="Morada"></asp:Label></td>
        <td><asp:TextBox ID="TextBox_morada" runat="server"></asp:TextBox></td>
    </tr>
    
    <tr>
        <td><asp:Label ID="Label_localidade" runat="server" Text="Localidade"></asp:Label></td>
        <td><asp:TextBox ID="TextBox_localidade" runat="server"></asp:TextBox></td>
    </tr>
    
    <tr>
        <td><asp:Label ID="Label_distrito" runat="server" Text="Distrito"></asp:Label></td>
        <td><asp:TextBox ID="TextBox_distrito" runat="server"></asp:TextBox></td>
    </tr>
    
    <tr>
        <td><asp:Label ID="Label_cc" runat="server" Text="Nº Cartão de Cidadão"></asp:Label></td>
        <td><asp:TextBox ID="TextBox_cc" runat="server" Enabled="false"></asp:TextBox></td>
    </tr>
    
    <tr>
        <td><asp:Label ID="Label_telemovel" runat="server" Text="Telemóvel"></asp:Label></td>
        <td><asp:TextBox ID="TextBox_telemovel" runat="server"></asp:TextBox></td>
    </tr>
    

    </table>
    
</asp:Content>
