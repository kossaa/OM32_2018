using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
        }

        protected void Login_btn_Click(object sender, EventArgs e)
        {
            String userid = MemMail_tb.Text;
            String pass = Pass_tb.Text;

            OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT MEMBER_ID FROM TBL_MEMBER WHERE MEMBER_MAIL = '" + userid + "' AND MEMBER_PASS = '" + pass + "'", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)    //該当するものがあれば
            {
                Session["UserID"] = userid;
                FormsAuthentication.RedirectFromLoginPage(userid, false);
                Response.Redirect("Member_MyPage.aspx");
            }
            else
            {
                Label1.Text = "ユーザー名、パスワードを確認してください。";
                Label1.Visible = true;
            }
        }

        protected void Signup_btn_Click(object sender, EventArgs e)
        {

        }
    }
}