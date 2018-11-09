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
                String userID = (string)Session["UserID"];
                OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
                //OleDbDataAdapter da = new OleDbDataAdapter("SELECT MEMBER_MAIL,MEMBER_NAME,MEMBER_KANA,MEMBER_BIRTH,MEMBER_GENDER,MEMBER_TEL,MEMBER_POST,MEMBER_ADR1,MEMBER_ADR2,MEMBER_POINT FROM TBL_MEMBER WHERE MEMBER_MAIL = '"+ a +"'", cn);
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT MEMBER_MAIL,MEMBER_NAME,MEMBER_KANA,MEMBER_BIRTH,MEMBER_GENDER,MEMBER_TEL,MEMBER_POST,MEMBER_ADR1,MEMBER_ADR2,MEMBER_POINT FROM TBL_MEMBER WHERE MEMBER_MAIL = '"+ userID +"'", cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                MemID_lbl.Text = dt.Rows[0][0].ToString();
                MemName_lbl.Text = dt.Rows[0][1].ToString();
                MemNameKana_lbl.Text = dt.Rows[0][2].ToString();
                MemBirth_lbl.Text = dt.Rows[0][3].ToString();
                MemGender_lbl.Text = dt.Rows[0][4].ToString();
                MemTel_lbl.Text = dt.Rows[0][5].ToString();
                MemPost_lbl.Text = dt.Rows[0][6].ToString();
                MemAdr_lbl.Text = dt.Rows[0][7].ToString();
                MemAdr_lbl.Text += dt.Rows[0][8].ToString();
                MemPoint_lbl.Text = dt.Rows[0][9].ToString();
            }

            

        }

        protected void Log_linkbtn_Click(object sender, EventArgs e)
        {

        }

        protected void Purchaselog_linkbtn_Click(object sender, EventArgs e)
        {

        }

        protected void Profile_linkbtn_Click(object sender, EventArgs e)
        {

        }

        protected void Password_linkbtn_Click(object sender, EventArgs e)
        {

        }

        protected void Withdrawal_btn_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session["UserID"] = null;
            Response.Redirect("Login.aspx");
        }

    }
}