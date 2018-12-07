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
            Messe_lbl.Visible = false;

            Session["PageID"] = "Member_MyPage.aspx";
        }

        protected void Login_btn_Click(object sender, EventArgs e)
        {
            String userid = MemMail_tb.Text;
            String pass = Pass_tb.Text;

            //仮データ（入力省略用）
            userid = "Tasaka+yahoo@oic.jp";
            pass = "qwert12345";

            //データベース接続
            OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT MEMBER_ID FROM TBL_MEMBER WHERE MEMBER_MAIL = '" + userid + "' AND MEMBER_PASS = '" + pass + "'", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)    //該当するものがあれば
            {
                //前のページ名取得
                String pageid = (string)Session["PageID"];
                Session["UserNo"] = dt.Rows[0][0];
                FormsAuthentication.RedirectFromLoginPage(userid, false);
                Response.Redirect(pageid);

                //Response.Redirect("Member_MyPage.aspx");
            }
            else
            {
                Messe_lbl.Text = "ユーザーID、パスワードを確認してください。";
                Messe_lbl.Visible = true;
            }
        }

        protected void Signup_btn_Click(object sender, EventArgs e)
        {

        }
    }
}