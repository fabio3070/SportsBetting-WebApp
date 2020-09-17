



<%@ Page Title="" Language="C#" MasterPageFile="~/MPage.Master" AutoEventWireup="true" CodeBehind="Futebol.aspx.cs" Inherits="StatsBet.Futebol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            
        
       
    <link rel="stylesheet" type="text/css" href="estilo1.css">
	<script type="text/javascript" src="javascript.js"></script>
    


    <head>
	<title>Futebol</title>
</head>
<body>
      <div class="slideshow-container">

  <!-- Full-width images with number and caption text -->
  <div class="mySlides fade">
    <div class="numbertext">1 / 3</div>
    <img src="img/bm.jpg" style="width:100%">
    <div class="text">Caption Text</div>
  </div>

  <div class="mySlides fade">
    <div class="numbertext">2 / 3</div>
    <img src="img/bp.jpg" style="width:100%">
    <div class="text">Caption Two</div>
  </div>

  <div class="mySlides fade">
    <div class="numbertext">3 / 3</div>
    <img src="img/bs.jpg" style="width:100%">
    <div class="text">Caption Three</div>
  </div>

  <!--  Setas -->
  <a class="prev" onclick="plusSlides(-1)">&#10094;</a>
  <a class="next" onclick="plusSlides(1)">&#10095;</a>
</div>
<br>

<!-- Pontos -->
<div style="text-align:center">
  <span class="dot" onclick="currentSlide(1)"></span>
  <span class="dot" onclick="currentSlide(2)"></span>
  <span class="dot" onclick="currentSlide(3)"></span>
</div>

   <div class="pai">

	  <div class="Ligas">
		    <div class="Ligaicon"><img src="icones/jgdr.png"> Ligas</div>
		
	
    <table>
        <asp:Label ID="Label2" runat="server" Text="Ligas"></asp:Label>

    </table>

     </div><!--Fim class ligas-->

       </div>

    
      

    <div class="container_aposta">
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
               <table id="jogos">
                   <tbody id="body_jogos">
                       <asp:Label ID="Label1" runat="server" Text="Tabela"></asp:Label>
                   </tbody>

               </table>

            <div id="Multipla">

                <asp:TextBox Class="txt" ID="TextBox_Multipla" runat="server" Visible="true" onchange="mostraodd(this)" onkeydown="JavaScript: return isNumericKeyStroke();" ></asp:TextBox>
                <asp:Button ID="Button_aposta" runat="server" Text="Apostar" Visible="true" OnClientClick="apostaClick()" OnClick="Button_aposta_Click"  />
                <asp:HiddenField ID="jsResultado" runat="server" />
            </div>

    </div>
   
    <asp:HiddenField ID="jsTipo" runat="server"/>
    <asp:HiddenField ID="jsOdd" runat="server" />

</body>
        
    
       


    

</asp:Content>
