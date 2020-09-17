using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace StatsBet
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            

                TextBox_pnome.Text =      Session["user_pn"].ToString();
                TextBox_unome.Text =      Session["user_un"].ToString();
                TextBox_nif.Text =        Session["user_nif"].ToString();
                TextBox_dtnasc.Text =     Session["user_ddn"].ToString();
                TextBox_email.Text =      Session["user_email"].ToString();
                TextBox_morada.Text =     Session["user_morada"].ToString();
                TextBox_localidade.Text = Session["user_localidade"].ToString();
                TextBox_distrito.Text =   Session["user_distrito"].ToString();
                TextBox_cc.Text =         Session["user_cc"].ToString();
                TextBox_telemovel.Text =  Session["user_telemovel"].ToString();

        }
    }
}