using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

namespace StatsBet
{
    public partial class Futebol : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!Page.IsPostBack)
            {
                String sql = "select liga_id,liga_nome from Liga;";
                string p = "";
                using (Data cn = new Data())
                {
                    cn.executeSql(sql);

                    SqlDataReader rd = cn.query(sql);

                    if (rd.HasRows)
                    {
                        while(rd.Read())
                        {
                            p += " <tr><td> " + rd["liga_nome"] + " </td> <td> ";



                        }//end if read

                        Label2.Text = p;

                    }//end if

                }//end data


                string datajogo = DateTime.Now.ToShortDateString();
                string carregaDados = "select jogos_id,jogo_odd_v,jogo_odd_e,jogo_odd_d, (select equipa_nome from jogos left join Equipa on Equipa.equipa_id = Jogos.jogos_casa where jogos_data_hora = '" + datajogo + "' AND jogos_id = J.jogos_id) as Equipa_casa, (select equipa_nome from jogos left join Equipa on Equipa.equipa_id = Jogos.jogos_fora where jogos_data_hora = '" + datajogo + "' AND jogos_id = J.jogos_id) as Equipa_fora from Jogos AS J where jogos_data_hora = '" + datajogo +"'";
                string t = "";
                
                using (Data cnn = new Data())
                {
                    cnn.executeSql(carregaDados);

                    SqlDataReader dr = cnn.query(carregaDados);

                    
                    while (dr.Read())
                    {
                      
                        
                        t += "<tr><td>"+dr["jogos_id"]+"</td><td> " + dr["Equipa_casa"] + " </td> <td>vs</td> <td> " + dr["Equipa_fora"] + " </td></tr>";

                        t += " <script>criarBut(" + dr["jogo_odd_v"].ToString() + ", " + dr["jogo_odd_e"].ToString() + " , "+ dr["jogo_odd_d"].ToString() + ","+dr["jogos_id"].ToString()+");</script>";

                         

                    }

                    

                }

                Label1.Text = t;

               
            }//end if postback
        }



       

        protected void Portugal_Click(object sender, EventArgs e)
        {
            
        }

       

        protected void Portugal_click(object sender, EventArgs e)
        {

        }

        protected void Inglaterra_Click(object sender, EventArgs e)
        {


        }

        protected void btnBet_Click(object sender, EventArgs e)
        {
           
        }

        protected void btn2Bet_Click(object sender, EventArgs e)
        {

        }

        protected void btn3Bet_Click(object sender, EventArgs e)
        {

        }

        protected void Button_aposta_Click(object sender, EventArgs e)
        {
            string ganhoPossivel = jsResultado.Value;
            //Response.Write(jsResultado.Value);

            string apostaPossivel = "insert into Apostas(aposta_ganhos) values (" + float.Parse(ganhoPossivel) + ");";

            using (Data cnn = new Data())
            {
                cnn.executeSql(ganhoPossivel);

                SqlDataReader dr = cnn.query(ganhoPossivel);

            }
        }
      
    }//end public class






}//end project