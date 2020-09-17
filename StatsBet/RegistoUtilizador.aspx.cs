using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace StatsBet
{
    public partial class RegistoUtilizador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string verifica = "select uti_user,uti_nif,uti_cc,uti_email from utilizadores where uti_user = '" + TextBox_user.Text + "' or uti_nif = '" + TextBox_nif.Text + "' or uti_email = '" + TextBox_email.Text + "' or uti_cc = '" + TextBox_cc.Text + "'";
            using (Data cnn = new Data())
            {
                cnn.executeSql(verifica);

                SqlDataReader drr = cnn.query(verifica);
                if(drr.HasRows)
                {
                    Response.Write("Username, NIF, Email ou Nº Cartao de cidadao ja existentes");

                }
                else
                {
                    DateTime dt1 = DateTime.Now;
                    TimeSpan resultado = dt1.Subtract(Convert.ToDateTime(TextBox_dt.Text));
                    Decimal resultado2 = Convert.ToDecimal(resultado.TotalDays);

                    

                    if (resultado2 < 6570)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
                             "alertMessage",
                             "alert('Apenas maiores de idade podem registar-se');", true);
                    }
                    else
                    {

                        using (Data cnn2 = new Data())
                        {
                            if (TextBox_pw.Text == TextBox_conf.Text)
                            {
                                string sql = "insert into Utilizadores(uti_user,uti_pw, uti_primeiro_nome, uti_ultimo_nome,uti_data_de_nascimento, uti_nif, uti_email, seg_id, uti_morada, uti_localidade, uti_distrito, uti_cc, uti_telemovel, uti_genero)"
                            + "values ('" + TextBox_user.Text + "','" + TextBox_pw.Text + "','" + TextBox_pn.Text + "','" + TextBox_un.Text + "','" + TextBox_dt.Text + "','" + TextBox_nif.Text + "', '" + TextBox_email.Text + "', '2','" + TextBox_Morada.Text + "','" + TextBox_localidade.Text + "','" + TextBox_distrito.Text + "','" + TextBox_cc.Text + "','" + TextBox_telemovel.Text + "','" + RadioButtonList1.Text + "')";

                                cnn2.executeSql(sql);
                            }
                            else
                            {
                                Response.Write("As palavras passes não são compativeis\n");
                            }
                        }
                    }



                   
                }

               

            }
            
        }

   

        

      
    }
}