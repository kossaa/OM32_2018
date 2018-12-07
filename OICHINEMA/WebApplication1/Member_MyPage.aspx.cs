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
    public partial class Member_MyPage1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack != true)
            {
                String userno = (string)Session["UserNo"];
                OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
                //退会日が有無を条件に退会判断（未実装）
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT MEMBER_MAIL,MEMBER_NAME,MEMBER_KANA,MEMBER_BIRTH,MEMBER_GENDER,MEMBER_TEL,MEMBER_POST,MEMBER_ADR,MEMBER_POINT FROM TBL_MEMBER WHERE MEMBER_ID = '" + userno + "'", cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                //String membirth = dt.Rows[0][3].ToString("yyyy/MM/dd");

                MemID_lbl.Text = dt.Rows[0][0].ToString();
                MemName_lbl.Text = dt.Rows[0][1].ToString();
                MemKana_lbl.Text = dt.Rows[0][2].ToString();
                MemBirth_lbl.Text = dt.Rows[0][3].ToString();
                MemGender_lbl.Text = dt.Rows[0][4].ToString();
                MemTel_lbl.Text = dt.Rows[0][5].ToString();
                MemPost_lbl.Text = dt.Rows[0][6].ToString();
                MemAdr_lbl.Text = dt.Rows[0][7].ToString();
                MemPoint_lbl.Text = dt.Rows[0][8].ToString();
            }

            

        }

        protected void Purchaselog_linkbtn_Click1(object sender, EventArgs e)
        {
            //Response.Redirect("Member_Page/BookingLog.aspx");
            Response.Redirect("BookingLog.aspx");
        }

        protected void Profile_linkbtn_Click1(object sender, EventArgs e)
        {
            //Response.Redirect("Member_Page/Member_info_alter.aspx");
            Response.Redirect("Member_info_alter.aspx");
        }

        protected void Password_linkbtn_Click1(object sendser, EventArgs e)
        {

        }

        protected void Withdrawal_btn_Click1(object sender, EventArgs e)
        {
            //とりあえずのログアウト
            FormsAuthentication.SignOut();
            Session["UserNo"] = null;
            Response.Redirect("Login.aspx");

            //退会処理は日付入れるだけ
        }

    }
}