﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Member_info_alter : System.Web.UI.Page
    {
        //bool memname = false,memnamekana = false,memgender = false,membirthyear = false,membirthmonth = false,membirthday = false,mempost = false,memadr = false,memtel = false,memmail = false;
        bool memname , memnamekana , memgender , membirthyear , membirthmonth , membirthday , mempost , memadr , memtel,memmail;

        protected void Page_Load(object sender, EventArgs e)
        {
            //String userNo = (string)Session["UserNo"];
            String userNo = "0000001";
            OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT MEMBER_NAME,MEMBER_KANA,MEMBER_GENDER,MEMBER_BIRTH,MEMBER_POST,MEMBER_ADR,MEMBER_TEL,MEMBER_MAIL FROM TBL_MEMBER WHERE MEMBER_ID = '" + UserNo + "'", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            memname_tb.Text = dt.Rows[0][0].ToString();
            memnamekana_tb.Text = dt.Rows[0][1].ToString();
            memgender_ddl.Text = dt.Rows[0][2].ToString();



            //membirthyear_ddl.Text = dt.Rows[0][3].ToString();
            //membirthmonth_ddl.Text = dt.Rows[0][4].ToString();
            //membirthday_ddl.Text = dt.Rows[0][5].ToString();
            mempost_tb.Text = dt.Rows[0][4].ToString();
            memadr_tb.Text = dt.Rows[0][5].ToString();
            memtel_tb.Text = dt.Rows[0][6].ToString();
            memmail_tb.Text = dt.Rows[0][7].ToString();
        }

        protected void memname_tb_TextChanged(object sender, EventArgs e)
        {
            memname = true;
        }

        protected void memnamekana_tb_TextChanged(object sender, EventArgs e)
        {
            memnamekana = true;
        }

        protected void memgender_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            memgender = true;
        }

        protected void membirthyear_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            membirthyear = true;
        }

        protected void membirthmonth_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            membirthmonth = true;
        }

        protected void membirthday_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            membirthday = true;
        }

        protected void mempost_tb_TextChanged(object sender, EventArgs e)
        {
            mempost = true;
        }

        protected void memadr_tb_TextChanged(object sender, EventArgs e)
        {
            memadr = true;
        }

        protected void memtel_tb_TextChanged(object sender, EventArgs e)
        {
            memtel = true;
        }

        protected void memmail_tb_TextChanged(object sender, EventArgs e)
        {
            memmail = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {

        }

        private void datelord()
        {
            
        }
    }
}