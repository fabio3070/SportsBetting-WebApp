using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace StatsBet
{
    public partial class MPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                esconder();
            
        }

        protected void esconder()
        {
            if (Session["user_id"] == null)
            {

                Login_teste.Visible = true;
                Regist_teste.Visible = true;
            }
            else
            {
                Login_teste.Visible = false;
                Regist_teste.Visible = false;

                Label1.Text = Session["user_pn"].ToString() + " " + Session["user_un"].ToString();
                Label1.Visible = true;
            }
        }

        protected void Button_Log_Click(object sender, EventArgs e)
        {
            string sql = "select uti_id, uti_user, uti_pw, uti_primeiro_nome, uti_ultimo_nome, uti_nif, uti_data_de_nascimento, uti_email, uti_morada, uti_localidade, uti_distrito, uti_cc, uti_telemovel from Utilizadores where uti_user = '" + TextBox_User.Text + "' and uti_pw = '" + TextBox_Pw.Text + "'";

            using (Data cn = new Data())
            {
                cn.executeSql(sql);

                SqlDataReader dr = cn.query(sql);
                if (dr.HasRows)
                {

                    dr.Read();
                    Session["user_id"] = dr["uti_id"];
                    Session["user_pn"] = dr["uti_primeiro_nome"];
                    Session["user_un"] = dr["uti_ultimo_nome"];
                    Session["user_nif"] = dr["uti_nif"];
                    Session["user_ddn"] = dr["uti_data_de_nascimento"];
                    Session["user_email"] = dr["uti_email"];
                    Session["user_morada"] = dr["uti_morada"];
                    Session["user_localidade"] = dr["uti_localidade"];
                    Session["user_cc"] = dr["uti_cc"];
                    Session["user_telemovel"] = dr["uti_telemovel"];
                    Session["user_distrito"] = dr["uti_distrito"];
                    Login_teste.Visible = false;
                    Regist_teste.Visible = false;

                    Label1.Text = Session["user_pn"].ToString() + " " + Session["user_un"].ToString();
                    Label1.Visible = true;
                }
                else
                {
                    TextBox_User.Text = "";
                    TextBox_Pw.Text = "";
                    
                }
            }
        }

        protected void Button_Reg_Click(object sender, EventArgs e)
        {

            Response.Redirect("RegistoUtilizador.aspx");
            
        }

       

      
    }
}