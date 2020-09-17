var ct_aposta = 1;
var res = 0;//resultado maximo possivel de ganhos
var i = 1;
var exactOdd=[];//array para as odds de cada div
var t = [];
var resAposta=0;//somatorio do resultado dos inputs 
var somatorioOdd = 0;//somatorio das oddexatas
var verificaaposta = [];
var z = 0;
var vtextArray = [];//guarda o valor dos inputs do vtext
var arrayLength = [];
var arrayId = [];//array para os ids dos inputs da aposta simples
var array = [];//array para o valor dos ids dos inputs da aposta simples
var k = -1;//var para controlo do array
var l = -1;//var para controlo do array exactOdd

var arrayInput = [];
var colectApostaSimples = 0;

var ct_oddSimples = 0;

var lbl_odd = document.createElement("div");
lbl_odd.width = "100px";
lbl_odd.height = "100px";

var lbl_multipla = document.createElement("label");
lbl_multipla.width = "100px";
lbl_multipla.height = "100px";
lbl_multipla.innerText = "";

var lblAposta = document.createElement("label");
lblAposta.width = "100px";
lblAposta.height = "100px";

var w = 1;



/*FUNCAO DE BOTOES DE APOSTA-------------------------------------------------------------------*/
function criarBut(v,e,d,idjg) {

   
    var linha = document.createElement("tr");

    var coluna_vazia = document.createElement("td");

    linha.appendChild(coluna_vazia);

    
   
    for (var j = 0; j < 3; j = j + 1)
    {
            var coluna = document.createElement("td");
            var btn = document.createElement("input");
            btn.type = "button";
            btn.name = "button" + i;
            btn.id = "id" + i;

       
        
        if (j == 0) {
            btn.value = v;
        }
        else if (j == 1) {
            btn.value = e;
        }
        else if (j == 2) {
            btn.value = d;
        }

        btn.setAttribute("onclick", "janela_aposta(" + btn.value +", " + idjg + ", " + j + " );");

        i++;
        coluna.appendChild(btn);
        linha.appendChild(coluna);

    }
    
    document.getElementById("body_jogos").appendChild(linha);

}//fim da criacao de botoes



/*FUNCAO CRIACAO DE DIVS DE APOSTA-----------------------------------------------------------*/
function janela_aposta(odd, idjog, j)
{ 

    var div = document.createElement("div");
    var text = document.createElement("input");
    var lbl = document.createElement("label");
    var lblodd = document.createElement("label");
    var btnElimina = document.createElement("input");
    


    div.id =  w;
    div.style.width = "200px";
    div.style.height = "100px";
    div.style.border = "solid 1px";

    //botao de eliminar aposta
   
    btnElimina.type = "button";
    btnElimina.name = "X";
    btnElimina.id = w;

    //funcionalidade do botaoElimina
    btnElimina.setAttribute("onclick","eliminaDiv(this,"+odd+")");

    lbl.id = "lblid" + w;
    lbl.name = "lbl" + w;

    lblodd.id = "lbloddid" + w;
    lblodd.name = "lblodd" + w;

    if (j == 0) {
        lbl.innerText = idjog + "Vitória Casa";
        lblodd.innerText = odd;
    }
    else if (j == 1) {
        lbl.innerText = idjog + "Empate";
        lblodd.innerText = odd;
    }
    else if (j == 2) {
        lbl.innerText = idjog + "Vitória Fora";
        lblodd.innerText = odd;
    }


      

    text.type = "text";
    text.name = "text" + w;
    text.id = w;
    text.setAttribute("onchange", "mostraoddSimples(this.value," + text.id + "," + odd + ")");
    text.setAttribute("onkeydown","JavaScript: return isNumericKeyStroke();");

    ct_aposta = parseFloat(ct_aposta) * parseFloat(odd);
    lbl_odd.innerText = ct_aposta.toString();
 
    verificaaposta[w] = idjog;
     w++;

    
    if (verificaaposta.includes(idjog))
    {
            document.getElementsByClassName("txt").disabled = true;
    }
    

    div.appendChild(lbl);
    div.appendChild(lblodd);
    div.appendChild(text);
    div.appendChild(btnElimina);
    document.getElementById("Multipla").appendChild(div);
    document.getElementById("Multipla").appendChild(lbl_odd);
}



/*FUNCAO DE ODD MULTIPLA--------------------------------------------------------------------------------------------------*/
function mostraodd(vtxt)
{
    z++;
    
    console.log(vtxt.value);
    console.log(parseFloat(vtxt.value));
    console.log(parseFloat(ct_aposta));



    vtextArray[z] = vtxt.value;


    if (vtxt.value == "")
    {
        console.log("blabla" + vtxt.value);
        res = 0;
        res = res + somatorioOdd;
        lbl_multipla.innerText = res; 
        resAposta = 0;
        lblAposta.innerHTML = "Total Apostado: " + resAposta + "<br>";

    }
   
    else
    {   
        //lbl do valor total---------------------------------------------------------------------------------
        res = parseFloat(vtextArray[z]) * parseFloat(ct_aposta);
        res = parseFloat(res) + parseFloat(somatorioOdd);
        lbl_multipla.innerHTML = res;

        //lbl do total apostado------------------------------------------------------------------------------
        resAposta = parseFloat(resAposta) + parseFloat(vtxt.value);
        lblAposta.innerHTML = "Total Apostado: "+resAposta+"<br>";
        document.getElementById("Multipla").appendChild(lblAposta);

    }


    //Criação da label de ganhos possiveis-------------------------------------------------------------------
    
    document.getElementById("Multipla").appendChild(lbl_multipla);
}



/*FUNCAO DE ODD SIMPLES----------------------------------------------------------------------------*/
function mostraoddSimples(vres,id,odd)
{
    

    console.log("vres= " + vres);
    console.log("id= " + id);
    console.log("odd= " + odd);

    k++;
    l++;
    
    //acrescenta id ao array de ids
    array[l] = vres;
   

    if (arrayId.includes(id))
    { 

       

        if (vres == "") {
            
            somatorioOdd = parseFloat(somatorioOdd) - exactOdd[l - 1];
            res = parseFloat(res) - exactOdd[l - 1];
            res = parseFloat(res) + 0;
            lbl_multipla.innerHTML = res;

        }

        else
        {
            somatorioOdd = somatorioOdd - exactOdd[l - 1];

            res = parseFloat(res) - exactOdd[id - 1];
            l--;//volta o contador atras
            //calculo da odd exata da div
            exactOdd[id - 1] = parseFloat(odd) * parseFloat(vres);
            //resultado + odd exata do id do input
            res = parseFloat(res) + parseFloat(exactOdd[id-1]);

            lbl_multipla.innerText = res;

            // somatorio do array da odd-------------------------------------
            somatorioOdd = somatorioOdd + exactOdd[l];

        }
       
    }//end if
     
    else
    {      
             arrayId[l] = id;
             exactOdd[id - 1] = parseFloat(odd) * parseFloat(vres);

            res = parseFloat(res) + parseFloat(exactOdd[id-1]);
            console.log("resultado" + res);
            lbl_multipla.innerHTML = res;

            // somatorio do array da odd---------------------------------
            somatorioOdd = somatorioOdd + exactOdd[l];
 
    }

   
    //calculo de todos os valores das inputs para o dinheiro apostado-----------------------
   

    for (var ct_g = 0; ct_g < arrayId.length; ct_g++) {
        //colectApostaSimples = parseFloat(colectApostaSimples) + parseFloat(array[id - 1]);
        colectApostaSimples = parseFloat(colectApostaSimples) + parseFloat(array[ct_g]);
    }
   

    //valor total apostado
    lblAposta.innerHTML = "Total Apostado: " + (parseFloat(resAposta) + parseFloat(colectApostaSimples)) + "<br>";

    colectApostaSimples = 0;
        
}//fim funcao


/*FUNCAO ELIMINAR AS DIVS----------------------------------------------------------------------------------------------------------------------*/

function eliminaDiv(button,odd)
{   

    
    var parent = button.parentNode;
    var grand_father = parent.parentNode;
    grand_father.removeChild(parent);
      
    //resultado menos a odd do ultimo input
    ct_aposta = parseFloat(ct_aposta) / parseFloat(odd);
    
    console.log("resultado" + res);
    lbl_odd.innerText = ct_aposta.toString();
    
    //se o valor da ct_aposta for 1 elimina o valor da label
    if (ct_aposta == 1)
    {
        lbl_odd.innerText = '';
    }
    
    //resultado menos a odd do ultimo input
    res = parseFloat(res)/ parseFloat(odd);
    console.log("resultadoElimina" + res);
    console.log("resultadoOddexata" + odd);
    lbl_multipla.innerText = res;
    
    resAposta = parseFloat(resAposta) + parseFloat(array[l]);
    lblAposta.innerHTML = "Total Apostado: " + resAposta + "<br>";

}

//FUNCAO PARA NEGAR LETRAS NOS INPUTS------------------------------------------------------------------------------------
function isNumericKeyStroke()
{
    
        
    var returnValue = false;
    var keyCode = (window.event.which) ? window.event.which : window.event.keyCode;
    
    if (((keyCode >= 48) && (keyCode <= 57)) || // All numerics
        (keyCode == 8) ||     // Backspace
        (keyCode == 13))     // Carriage Return
        returnValue = true;
    
    if (window.event.returnValue)
        window.event.returnValue = returnValue;
    
    return returnValue;
    
}
//----------------------------------------------------------------------------------------------------------------------


/*---------------------------------------------------------------BOTAO DE APOSTA-----------------------------------------------  */



function apostaClick()
{
    var bddAposta;
    bddAposta = document.getElementById('jsResultado');
    bddAposta.value = '123';
    //alert("res");
    //document.getElementById('jsOdd').value = ;

}

