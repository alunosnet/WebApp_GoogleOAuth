using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp_GoogleOAuth
{
    public partial class loginuser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bt.Click += terminarSessao;

            string username = User.Identity.Name;
            string useremail = "", userid = "";
            foreach (Claim ci in ((ClaimsPrincipal)User).Claims)
            {
                if (ci.Type.EndsWith("emailaddress"))
                    useremail = ci.Value;
                if (ci.Type.EndsWith("nameidentifier"))
                    userid = ci.Value;
            }
            bd _bd = new bd();
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@id", SqlDbType = System.Data.SqlDbType.VarChar, Value = userid },
                new SqlParameter() { ParameterName = "@username", SqlDbType = System.Data.SqlDbType.VarChar, Value = username },
                new SqlParameter() { ParameterName = "@useremail", SqlDbType = System.Data.SqlDbType.VarChar, Value = useremail }
            };
            DataTable dados = _bd.devolveconsulta("SELECT * FROM users WHERE id=@id AND username=@username AND email=@useremail", parametros);
            if (dados == null || dados.Rows.Count == 0)
                Response.Write("Login falhou");
            else
                Response.Write("Login com sucesso");
        }
        private void terminarSessao(Object sender, EventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut("MyApp");
            Response.Redirect("login.aspx");
        }
    }
}