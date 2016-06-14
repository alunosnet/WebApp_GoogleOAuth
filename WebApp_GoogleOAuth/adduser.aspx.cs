using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp_GoogleOAuth
{
    public partial class adduser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = User.Identity.Name;
            string useremail = "",userid="";
            foreach(Claim ci in ((ClaimsPrincipal)User).Claims)
            {
                if (ci.Type.EndsWith("emailaddress"))
                    useremail = ci.Value;
                if (ci.Type.EndsWith("nameidentifier"))
                    userid = ci.Value;
            }
            string sql = "INSERT INTO users(id,username,email) VALUES (@id,@username,@useremail);";
            bd _bd = new bd();
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "@id", SqlDbType = System.Data.SqlDbType.VarChar, Value = userid },
                new SqlParameter() { ParameterName = "@username", SqlDbType = System.Data.SqlDbType.VarChar, Value = username },
                new SqlParameter() { ParameterName = "@useremail", SqlDbType = System.Data.SqlDbType.VarChar, Value = useremail }
            };
            _bd.executacomando(sql,parametros);
        }
    }
}