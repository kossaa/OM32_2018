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
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT MEMBER_MAIL,MEMBER_NAME,MEMBER_KANA,MEMBER_GENDER,MEMBER_BIRTH,MEMBER_POST,MEMBER_ADR,MEMBER_TEL,MEMBER_POINT FROM TBL_MEMBER WHERE MEMBER_ID = '" + userid + "'", cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                MemID_lbl.Text = dt.Rows[0][0].ToString();
                MemName_lbl.Text = dt.Rows[0][1].ToString();
                MemKana_lbl.Text = dt.Rows[0][2].ToString();

                MemGender_lbl.Text = dt.Rows[0][3].ToString();

                DateTime membirth = DateTime.Parse(dt.Rows[0][4].ToString());
                MemBirth_lbl.Text = membirth.ToString("yyyy/MM/dd");

                string mempost = dt.Rows[0][5].ToString();
                MemPost_lbl.Text = mempost.Insert(3, "-");

                MemAdr_lbl.Text = dt.Rows[0][6].ToString();
                MemTel_lbl.Text = dt.Rows[0][7].ToString();
                MemPoint_lbl.Text = dt.Rows[0][8].ToString();

                Session["MemMail"] = dt.Rows[0][0].ToString();
                Session["MemName"] = dt.Rows[0][1].ToString();
                Session["MemKana"] = dt.Rows[0][2].ToString();
                Session["MemGender"] = dt.Rows[0][3].ToString();

                Session["MemBirthYear"] = membirth.ToString("yyyy");
                Session["MemBirthMon"] = membirth.ToString("MM");
                Session["MemBirthDay"] = membirth.ToString("dd");

                Session["MemPost"] = dt.Rows[0][5].ToString();
                Session["MemAdr"] = dt.Rows[0][6].ToString();
                Session["MemTel"] = dt.Rows[0][7].ToString();
            }

            

        }

        protected void Purchaselog_linkbtn_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Member_BookingLog.aspx");
        }

        protected void Profile_linkbtn_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Member_info_alter.aspx");
        }

        protected void Passalter_linkbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Member_pass_alter2.aspx");
        }

        protected void Withdrawal_btn_Click1(object sender, EventArgs e)
        {
            //とりあえずのログアウト
            FormsAuthentication.SignOut();
            Session["UserID"] = null;
            Session["MemName"] = null;
            Session["MemKana"] = null;
            Session["MemGender"] = null;
            Session["MemBirthYear"] = null;
            Session["MemBirthMon"] = null;
            Session["MemBirthDay"] = null;
            Session["MemPost"] = null;
            Session["MemAdr"] = null;
            Session["MemTel"] = null;
            Session["MemBirthDay"] = null;
            Response.Redirect("Login.aspx");

            //DateTime dtToday = DateTime.Today;
            ////退会処理は退会日時を入れるだけ
            //String userid = (string)Session["UserID"];
            //OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
            //OleDbCommand cmd = new OleDbCommand("UPDATE TBL_MEMBER SET MEMBER_OUT = '" + dtToday.ToString() + "' WHERE MEMBER_ID = '" + userid + "'", cn);
            //cn.Open();
            //cmd.ExecuteNonQuery();
            //cn.Close();

            //FormsAuthentication.SignOut();
            //Session["UserID"] = null;
            ////テスト用
            //Response.Redirect("Login.aspx");

            //本来
            //Response.Redirect("Top.aspx");
        }
    }
}