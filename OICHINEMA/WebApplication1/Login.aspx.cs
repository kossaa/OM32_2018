﻿using System;
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

            //仮データ（入力省略用）
            MemMail_tb.Text = "Tasaka+yahoo@oic.jp";
            Pass_tb.Text = "qwert12345";

            //（退会済み）
            //MemMail_tb.Text = "aaa@aaa.a";
            //Pass_tb.Text = "1111111111";
        }

        protected void Login_btn_Click(object sender, EventArgs e)
        {
            String userid = MemMail_tb.Text;
            String pass = Pass_tb.Text;

            //データベース接続
            OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
            //退会日の有無で退会判断
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT MEMBER_ID FROM TBL_MEMBER WHERE MEMBER_MAIL = '" + userid + "' AND MEMBER_PASS = '" + pass + "' AND MEMBER_OUT IS NULL", cn);
            //OleDbDataAdapter da = new OleDbDataAdapter("SELECT MEMBER_ID FROM TBL_MEMBER WHERE MEMBER_MAIL = '" + userid + "' AND MEMBER_PASS = '" + pass + "' AND MEMBER_OUT IS NULL OR 7 > (SELECT DATEDIFF(DAY,MEMBER_OUT,GETDATE) FROM TBL_MEMBER WHERE MEMBER_MAIL = '" + userid + "' AND MEMBER_PASS = '" + pass + "')", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)    //該当するものがあれば
            {
                //前のページ名取得
                String pageid = (string)Session["PageID"];
                Session["UserID"] = dt.Rows[0][0];
                FormsAuthentication.RedirectFromLoginPage(userid, false);
                Response.Redirect(pageid);
            }
            else
            {
                Messe_lbl.Text = "ユーザーID、パスワードを確認してください。";
                Messe_lbl.Visible = true;
            }
        }

        protected void Signup_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Signup.aspx");
        }
    }
}