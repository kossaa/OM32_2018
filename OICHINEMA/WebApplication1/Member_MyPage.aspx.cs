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
                String userNo = (string)Session["UserNo"];
                //String userNo = "0000001";
                OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT MEMBER_MAIL,MEMBER_NAME,MEMBER_KANA,MEMBER_BIRTH,MEMBER_GENDER,MEMBER_TEL,MEMBER_POST,MEMBER_ADR,MEMBER_POINT FROM TBL_MEMBER WHERE MEMBER_ID = '" + userNo + "'", cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                MemID_lbl.Text = dt.Rows[0][0].ToString();
                MemName_lbl.Text = dt.Rows[0][1].ToString();
                MemKana_lbl.Text = dt.Rows[0][2].ToString();
                MemBirth_lbl.Text = dt.Rows[0][3].ToString();
                MemGender_lbl.Text = dt.Rows[0][4].ToString();
                MemTel_lbl.Text = dt.Rows[0][5].ToString();
                MemPost_lbl.Text = dt.Rows[0][6].ToString();
                MemAdr_lbl.Text = dt.Rows[0][7].ToString();
                //MemAdr_lbl.Text += dt.Rows[0][7].ToString();
                MemPoint_lbl.Text = dt.Rows[0][8].ToString();

                Session["memname"] = MemName_lbl.Text;
                Session["memkana"] = MemKana_lbl.Text;
                Session["membirth"] = MemBirth_lbl.Text;
                Session["memgender"] = MemGender_lbl.Text;
                Session["memtel"] = MemTel_lbl.Text;
                Session["menmail"] = MemID_lbl.Text;
                Session["mempost"] = MemPost_lbl.Text;
                Session["memadr"] = MemAdr_lbl.Text;
            }

            

        }

        protected void Purchaselog_linkbtn_Click1(object sender, EventArgs e)
        {
            Response.Redirect("BookingLog.aspx");
        }

        protected void Profile_linkbtn_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Member_info_alter.aspx");
        }

        protected void Password_linkbtn_Click1(object sendser, EventArgs e)
        {

        }

        protected void Withdrawal_btn_Click1(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session["UserNo"] = null;
            Response.Redirect("Login.aspx");
        }

    }
}