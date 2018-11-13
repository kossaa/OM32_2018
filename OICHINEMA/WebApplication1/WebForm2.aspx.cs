using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            datelord();
        }

        protected void Back_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm2.aspx");
        }

        protected void Cancel_btn_Click(object sender, EventArgs e)
        {
            datelord();
        }

        protected void Update_btn_Click(object sender, EventArgs e)
        {
            String userNo = (string)Session["UserNo"];
            OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
            //OleDbDataAdapter da = new OleDbDataAdapter("SELECT MEMBER_MAIL,MEMBER_NAME,MEMBER_KANA,MEMBER_BIRTH,MEMBER_GENDER,MEMBER_TEL,MEMBER_POST,MEMBER_ADR1,MEMBER_ADR2,MEMBER_POINT FROM TBL_MEMBER WHERE MEMBER_ID = '" + userNo + "'", cn);
            OleDbDataAdapter da = new OleDbDataAdapter("UPDATE TBL_MEMBER SET MEMBER_MAIL = " + MemID_tb.Text + ",MEMBER_NAME = " + MemName_tb +" WHERE MEMBER_ID = '" + userNo + "'", cn);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
        }

        private void datelord()
        {
            String userNo = (string)Session["UserNo"];
            OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT MEMBER_MAIL,MEMBER_NAME,MEMBER_KANA,MEMBER_BIRTH,MEMBER_GENDER,MEMBER_TEL,MEMBER_POST,MEMBER_ADR1,MEMBER_ADR2,MEMBER_POINT FROM TBL_MEMBER WHERE MEMBER_ID = '" + userNo + "'", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            MemID_tb.Text = dt.Rows[0][0].ToString();
            MemName_tb.Text = dt.Rows[0][1].ToString();
            MemNameKana_tb.Text = dt.Rows[0][2].ToString();
            MemBirth_tb.Text = dt.Rows[0][3].ToString();
            MemGender_tb.Text = dt.Rows[0][4].ToString();
            MemTel_tb.Text = dt.Rows[0][5].ToString();
            MemPost_tb.Text = dt.Rows[0][6].ToString();
            MemAdr_tb.Text = dt.Rows[0][7].ToString();
            MemAdr_tb.Text += dt.Rows[0][8].ToString();
        }
    }
}