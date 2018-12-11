using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Member_info_alter : System.Web.UI.Page
    {
        //bool memname = false,memnamekana = false,memgender = false,membirthyear = false,membirthmonth = false,membirthday = false,mempost = false,memadr = false,memtel = false,memmail = false;
        //bool memname , memnamekana , memgender , membirthyear , membirthmonth , membirthday , mempost , memadr , memtel,memmail;
        bool flg;

        OleDbConnection cn = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack != true)
            {
                datelord();
            }

            /*
            



            //membirthyear_ddl.Text = dt.Rows[0][3].ToString();
            //membirthmonth_ddl.Text = dt.Rows[0][4].ToString();
            //membirthday_ddl.Text = dt.Rows[0][5].ToString();
            mempost_tb.Text = dt.Rows[0][4].ToString();
            memadr_tb.Text = dt.Rows[0][5].ToString();
            memtel_tb.Text = dt.Rows[0][6].ToString();
            memmail_tb.Text = dt.Rows[0][7].ToString();
            */
        }

        protected void memname_tb_TextChanged(object sender, EventArgs e)
        {
            flg = true;
        }

        protected void memnamekana_tb_TextChanged(object sender, EventArgs e)
        {
            flg = true;
        }

        protected void memgender_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            flg = true;
        }

        protected void membirthyear_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            flg = true;
        }

        protected void membirthmonth_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            flg = true;
        }

        protected void membirthday_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            flg = true;
        }

        protected void mempost_tb_TextChanged(object sender, EventArgs e)
        {
            flg = true;
        }

        protected void memadr_tb_TextChanged(object sender, EventArgs e)
        {
            flg = true;
        }

        protected void memtel_tb_TextChanged(object sender, EventArgs e)
        {
            flg = true;
        }

        protected void memmail_tb_TextChanged(object sender, EventArgs e)
        {
            flg = true;
        }

        protected void Postsearch_btn_Click(object sender, EventArgs e)
        {

        }

        protected void Back_btn_Click(object sender, EventArgs e)
        {
                Response.Redirect("Member_MyPage.aspx");
        }

        protected void Cancel_btn_Click(object sender, EventArgs e)
        {
            datelord();
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            String userid = (string)Session["UserID"];
            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
            cmd.Connection = cn;
            //OleDbDataAdapter da = new OleDbDataAdapter("SELECT MEMBER_NAME,MEMBER_KANA,MEMBER_GENDER,MEMBER_BIRTH,MEMBER_POST,MEMBER_ADR,MEMBER_TEL,MEMBER_MAIL FROM TBL_MEMBER WHERE MEMBER_ID = '" + userNo + "'", cn);
            //OleDbCommand olecmd = new OleDbCommand("UPDATE MEMBER SET MEMBER_NAME = " + memname_tb.Text + ",MEMBER_KANA = " + memkana_tb.Text + ",MEMBER_GENDER = " + memgender_ddl.Text + ",MEMBER_POST = " + mempost_tb.Text + ",MEMBER_ADR = " + memadr_tb.Text + ",MEMBER_TEL = " + memtel_tb.Text + ",MEMBER_MAIL = " + memmail_tb.Text + "WHERE MEMBER_ID = '" + userNo + "'", cn);
            cmd = new OleDbCommand("UPDATE TBL_MEMBER SET MEMBER_NAME = '" + memname_tb.Text + "' WHERE MEMBER_ID = '" + userid + "'", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            Response.Redirect("Member_MyPage.aspx");
        }

        public void datelord()
        {
            //String userno = (string)Session["UserNo"];
            //cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
            //da = new OleDbDataAdapter("SELECT MEMBER_NAME,MEMBER_KANA,MEMBER_GENDER,MEMBER_BIRTH,MEMBER_POST,MEMBER_ADR,MEMBER_TEL,MEMBER_MAIL FROM TBL_MEMBER WHERE MEMBER_ID = '" + userno + "'", cn);
            //dt = new DataTable();
            //da.Fill(dt);

            memname_tb.Text = (string)Session["MemName"];
            memkana_tb.Text = (string)Session["MemKana"];
            memgender_ddl.Text = (string)Session["MemGender"];
            membirthyear_ddl.Text = (string)Session["MemBirthYear"];
            membirthmonth_ddl.Text = (string)Session["MemBirthMon"];
            membirthday_ddl.Text = (string)Session["MemBirthDay"];
            mempost_tb.Text = (string)Session["MemPost"];
            memadr_tb.Text = (string)Session["MemAdr"];
            memtel_tb.Text = (string)Session["MemTel"];
            memmail_tb.Text = (string)Session["MemMail"];
        }
    }
}