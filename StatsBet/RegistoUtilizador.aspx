<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistoUtilizador.aspx.cs" Inherits="StatsBet.RegistoUtilizador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 5px">
    <form id="form1" runat="server">
        <table>
            <tr>
        <td><asp:Label ID="Label_user" runat="server" Text="Username"></asp:Label></td>
        <td><asp:TextBox ID="TextBox_user" runat="server" ></asp:TextBox></td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"  ControlToValidate="TextBox_user" ValidationGroup="registo" ErrorMessage="Caixa de Texto do Utilizador vazia!" Display="none" ></asp:RequiredFieldValidator>
  
            </tr>
            <tr>
        <td><asp:Label ID="Label_pw" runat="server" Text="Password"></asp:Label></td>
        <td><asp:TextBox ID="TextBox_pw" runat="server" TextMode="Password"></asp:TextBox></td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"  ControlToValidate="TextBox_pw" ValidationGroup="registo" ErrorMessage="Caixa de Texto da Password vazia!" Display="none" ></asp:RequiredFieldValidator>
  
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Confirmar Password"></asp:Label></td>
                <td>
                    <asp:TextBox ID="TextBox_conf" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
 <td><asp:Label ID="Label_pn" runat="server" Text="Primeiro Nome"></asp:Label></td>
       <td><asp:TextBox ID="TextBox_pn" runat="server"></asp:TextBox></td> 
         <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"  ControlToValidate="TextBox_pn" ValidationGroup="registo" ErrorMessage="Caixa de Texto do Primeiro Nome vazia!" Display="none" ></asp:RequiredFieldValidator>
  
                </tr>
  
           <tr>
   <td><asp:Label ID="Label_un" runat="server" Text="Ultimo Nome"></asp:Label></td> 
       <td><asp:TextBox ID="TextBox_un" runat="server"></asp:TextBox></td> 
       <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"  ControlToValidate="TextBox_un" ValidationGroup="registo" ErrorMessage="Caixa de Texto do Ultimo Nome vazia!" Display="none" ></asp:RequiredFieldValidator>
  
           </tr>
    <tr>
    <td><asp:Label ID="Label_dt" runat="server" Text="Data de Nascimento"></asp:Label></td>
        <td><asp:TextBox ID="TextBox_dt" runat="server" TextMode="Date"></asp:TextBox></td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"  ControlToValidate="TextBox_dt" ValidationGroup="registo" ErrorMessage="Caixa de Texto da Data de Nascimento vazia!" Display="none" ></asp:RequiredFieldValidator>
      
    </tr>
            <tr>
               <td><asp:Label ID="Label1" runat="server" Text="Email"></asp:Label></td> 
               <td><asp:TextBox ID="TextBox_email" runat="server" TextMode="Email"></asp:TextBox></td> 
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"  ControlToValidate="TextBox_email" ValidationGroup="registo" ErrorMessage="Caixa de Texto do E-mail vazia!" Display="none" ></asp:RequiredFieldValidator>
  
            </tr>
    
        <tr>
            <td><asp:Label ID="Label_nif" runat="server" Text="NIF"></asp:Label></td>
        <td><asp:TextBox ID="TextBox_nif" runat="server" MaxLength="9" pattern="\d+"></asp:TextBox></td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"  ControlToValidate="TextBox_nif" ValidationGroup="registo" ErrorMessage="Caixa de Texto do NIF vazia!" Display="none" ></asp:RequiredFieldValidator>
  
        </tr>
           
       
     <tr>
         <td><asp:Label ID="Label_CC" runat="server" Text="Nº Cartão de Cidadão"></asp:Label></td>
          <td><asp:TextBox ID="TextBox_cc" runat="server" pattern="\d+"></asp:TextBox></td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"  ControlToValidate="TextBox_cc" ValidationGroup="registo" ErrorMessage="Caixa de Texto do Nº de Crtão de Cidadão vazia!" Display="none" ></asp:RequiredFieldValidator>
  
     </tr>
           
        <tr>
            <td><asp:Label ID="Label_Morada" runat="server" Text="Morada"></asp:Label></td>
          <td><asp:TextBox ID="TextBox_Morada" runat="server"></asp:TextBox>
             </td> 
             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"  ControlToValidate="TextBox_Morada" ValidationGroup="registo" ErrorMessage="Caixa de Texto da Morada vazia!" Display="none" ></asp:RequiredFieldValidator>
        </tr>   
         
         <tr>
             <td><asp:Label ID="Label_Localidade" runat="server" Text="Localidade"></asp:Label></td>
             <td> <asp:TextBox ID="TextBox_localidade" runat="server"></asp:TextBox></td>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  ControlToValidate="TextBox_localidade" ValidationGroup="registo" ErrorMessage="Caixa de Texto do Localidade vazia!" Display="none" ></asp:RequiredFieldValidator>

         </tr>
           
        <tr>
          <td><asp:Label ID="Label_Distrito" runat="server" Text="Distrito"></asp:Label></td>
          <td><asp:TextBox ID="TextBox_distrito" runat="server" ></asp:TextBox></td>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  ControlToValidate="TextBox_distrito" ValidationGroup="registo" ErrorMessage="Caixa de Texto do Distrito vazia!"   Display="none" ></asp:RequiredFieldValidator>
            
        </tr>
         
       
          <tr>
              <td><asp:Label ID="Label_Telemovel" runat="server" Text="Telemovel"></asp:Label></td>
          <td><asp:TextBox ID="TextBox_telemovel" runat="server" MaxLength="9" TextMode="Phone" pattern="\[0-9]"   ></asp:TextBox></td>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ControlToValidate="TextBox_telemovel" ValidationGroup="registo" ErrorMessage="Caixa de Texto do Telémovel!" Display="None"  ></asp:RequiredFieldValidator>
          </tr>
           
                

             <tr>
                 <td><asp:Label ID="Label_Genero" runat="server" Text="Genero"></asp:Label></td>
                 <td><asp:RadioButtonList ID="RadioButtonList1" runat="server">
                    <asp:ListItem Value="1" Text="Masculino"></asp:ListItem>
                 <asp:ListItem Value="2" Text="Feminino"></asp:ListItem>
                 <asp:ListItem Value="3" Text="Outro"></asp:ListItem>
                </asp:RadioButtonList></td>
             </tr>  
                
                                                                         
          <p>
               <asp:Button ID="Button1" runat="server" Text="Registar" ValidationGroup="registo" CausesValidation="true"  OnClick="Button1_Click"  />
              <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" DisplayMode="BulletList" ValidationGroup="registo" ShowSummary="false"  runat="server" />
        </table>
    </form>
</body>
</html>
