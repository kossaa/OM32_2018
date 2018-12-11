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
                String userid = (string)Session["UserID"];
                OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT MEMBER_MAIL,MEMBER_NAME,MEMBER_KANA,MEMBER_BIRTH,MEMBER_GENDER,MEMBER_TEL,MEMBER_POST,MEMBER_ADR,MEMBER_POINT FROM TBL_MEMBER WHERE MEMBER_ID = '" + userid + "'", cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                String membirth_str = dt.Rows[0][3].ToString();
                DateTime membirth = DateTime.Parse(membirth_str);
                //membirth.ToString("yyyy/MM/dd");

                MemID_lbl.Text = dt.Rows[0][0].ToString();
                MemName_lbl.Text = dt.Rows[0][1].ToString();
                MemKana_lbl.Text = dt.Rows[0][2].ToString();
                MemBirth_lbl.Text = membirth.ToString("yyyy/MM/dd");
                MemGender_lbl.Text = dt.Rows[0][4].ToString();
                MemTel_lbl.Text = dt.Rows[0][5].ToString();
                MemPost_lbl.Text = dt.Rows[0][6].ToString();
                MemAdr_lbl.Text = dt.Rows[0][7].ToString();
                MemPoint_lbl.Text = dt.Rows[0][8].ToString();

                Session["MemMail"] = MemID_lbl.Text;
                Session["MemName"] = MemName_lbl.Text;
                Session["MemKana"] = MemKana_lbl.Text;

                Session["MemBirthYear"] = membirth.ToString("yyyy");
                Session["MemBirthMon"] = membirth.ToString("mm");
                Session["MemBirthDay"] = membirth.ToString("dd");

                Session["MemGender"] = MemGender_lbl.Text;
                Session["MemTel"] = MemTel_lbl.Text;
                Session["MemPost"] = MemPost_lbl.Text;
                Session["MemPost"] = MemPost_lbl.Text;
                Session["MemAdr"] = MemAdr_lbl.Text;
            }

            

        }

        protected void Purchaselog_linkbtn_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Member_BookingLog.aspx");
        }

        protected void Profile_linkbtn_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Member_info_alter2.aspx");
        }

        protected void Password_linkbtn_Click1(object sendser, EventArgs e)
        {
            //まだない
        }

        protected void Withdrawal_btn_Click1(object sender, EventArgs e)
        {
            //とりあえずのログアウト
            //FormsAuthentication.SignOut();
            //Session["UserNo"] = null;
            //Response.Redirect("Login.aspx");

            DateTime dtToday = DateTime.Today;
            //退会処理は退会日時を入れるだけ
            String userid = (string)Session["UserID"];
            OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
            OleDbCommand cmd = new OleDbCommand("UPDATE TBL_MEMBER SET MEMBER_OUT = '" + dtToday.ToString() + "' WHERE MEMBER_ID = '" + userid + "'", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

            FormsAuthentication.SignOut();
            Session["UserID"] = null;
            //テスト用
            Response.Redirect("Login.aspx");

            //Response.Redirect("Top.aspx");
        }

    }
}