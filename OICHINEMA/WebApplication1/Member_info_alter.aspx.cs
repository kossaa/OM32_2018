using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Member_info_alter : System.Web.UI.Page
    {
        int year = 1900,month = 1;

        OleDbConnection cn = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack != true)
            {
                Messe_lbl.Visible = false;

                //必要な変数を宣言する
                DateTime dtNow = DateTime.Now;

                //年 (Year) を取得する
                int maxyear = dtNow.Year;

                //今年までの年を作る
                for (year = 1900; year <= maxyear; year++)
                {
                    membirthyear_ddl.Items.Add(year.ToString());
                }

                datelord();

                //年と月を変数に入れる
                year = int.Parse(membirthyear_ddl.SelectedValue);
                month = int.Parse(membirthmonth_ddl.SelectedValue);

                //日数を取得する
                int iDaysInMonth = DateTime.DaysInMonth(year, month);
                for (int iday = 1; iday <= iDaysInMonth; iday++)
                {
                    membirthday_ddl.Items.Add(iday.ToString());
                }

                membirthday_ddl.SelectedValue = (string)Session["MemBirthDay"];

            }
        }

        protected void membirthyear_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //年と月を変数に入れる
            year = int.Parse(membirthyear_ddl.SelectedValue);
            month = int.Parse(membirthmonth_ddl.SelectedValue);

            //リストクリア
            membirthday_ddl.Items.Clear();

            //日数を取得する
            int iDaysInMonth = DateTime.DaysInMonth(year, month);
            for (int iday = 1; iday <= iDaysInMonth; iday++)
            {
                membirthday_ddl.Items.Add(iday.ToString());
            }
        }

        protected void membirthmonth_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            year = int.Parse(membirthyear_ddl.SelectedValue);
            month = int.Parse(membirthmonth_ddl.SelectedValue);

            //リストクリア
            membirthday_ddl.Items.Clear();

            int iDaysInMonth = DateTime.DaysInMonth(year, month);
            for (int iday = 1; iday <= iDaysInMonth; iday++)
            {
                membirthday_ddl.Items.Add(iday.ToString());
            }
        }

        protected void Postsearch_btn_Click(object sender, EventArgs e)
        {
            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|POSTADR.accdb;");
            da = new OleDbDataAdapter("SELECT フィールド7,フィールド8 FROM KEN_ALL WHERE フィールド3 = '" + mempost_tb.Text + "'", cn);
            dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                memadr_tb.Text = dt.Rows[0][0].ToString() + dt.Rows[0][1].ToString();
            }
            else if (dt.Rows.Count == 0)
            {

            }
            
        }

        protected void Back_btn_Click(object sender, EventArgs e)
        {
                Response.Redirect("Member_MyPage.aspx");
        }

        protected void Cancel_btn_Click(object sender, EventArgs e)
        {
            datelord();
        }

        protected void Con_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(memname_tb.Text) == false && string.IsNullOrWhiteSpace(memkana_tb.Text) == false && string.IsNullOrWhiteSpace(mempost_tb.Text) == false && string.IsNullOrWhiteSpace(memadr_tb.Text) == false && string.IsNullOrWhiteSpace(memmail_tb.Text) == false)
            {
                String userid = (string)Session["UserID"];
                cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
                cmd.Connection = cn;
                cmd = new OleDbCommand("UPDATE TBL_MEMBER SET MEMBER_NAME = '" + memname_tb.Text + "',MEMBER_KANA = '" + memkana_tb.Text + "',MEMBER_GENDER = '" + memgender_ddl.Text + "',MEMBER_BIRTH = '" + membirthyear_ddl.Text + "/" + membirthmonth_ddl.Text + "/" + membirthday_ddl.Text + "',MEMBER_POST = '" + mempost_tb.Text + "',MEMBER_ADR = '" + memadr_tb.Text + "',MEMBER_MAIL = '" + memmail_tb.Text + "' WHERE MEMBER_ID = '" + userid + "'", cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                Response.Redirect("Member_MyPage.aspx");
            }
            else
            {
                Messe_lbl.Text = "入力されていない欄があります。";
                Messe_lbl.Visible = true;
            }
        }

        public void datelord()
        {
            memname_tb.Text = (string)Session["MemName"];
            memkana_tb.Text = (string)Session["MemKana"];
            memgender_ddl.Text = (string)Session["MemGender"];
            membirthyear_ddl.SelectedValue = (string)Session["MemBirthYear"];
            membirthmonth_ddl.SelectedValue = (string)Session["MemBirthMon"];
            membirthday_ddl.SelectedValue = (string)Session["MemBirthDay"];
            mempost_tb.Text = (string)Session["MemPost"];
            memadr_tb.Text = (string)Session["MemAdr"];
            memtel_tb.Text = (string)Session["MemTel"];
            memmail_tb.Text = (string)Session["MemMail"];
        }
    }
}