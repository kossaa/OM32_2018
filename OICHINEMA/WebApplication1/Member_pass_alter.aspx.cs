using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Member_pass_alter : System.Web.UI.Page
    {

        OleDbConnection cn = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();
        DataTable dt = new DataTable();



        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == true)
            {
                Messe_lbl.Visible = false;
            }
        }

        //パスワードに大文字小文字の英数が入っているかのチェック
        Boolean passCheck = false;
        protected bool PasswordCheck(string passStr)
        {
            string password = passStr;
            //大文字か小文字と数字2種必要
            passCheck = Regex.IsMatch(password, @"[a-zA-Z]") && Regex.IsMatch(password, @"\d");
            //大文字と小文字と数字3種必要
            //passCheck = Regex.IsMatch(password, @"[A-Z]") && Regex.IsMatch(password, @"[a-z]") && Regex.IsMatch(password, @"\d");
            return passCheck;
        }

        protected void Com_btn_Click(object sender, EventArgs e)
        {
            String userid = (string)Session["UserID"];
            string cp = Pass_tb.Text;
            string np = Newpass_tb.Text;
            string cnp = CnewPass_tb.Text;

            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT MEMBER_PASS FROM TBL_MEMBER WHERE MEMBER_ID = '" + userid + "'", cn);
            da.Fill(dt);

            if (cp == dt.Rows[0][0].ToString())
            {
                PasswordCheck(Newpass_tb.Text);
                if (passCheck == true)
                {
                    dt.Clear();
                    if (np.Length >= 10)
                    {
                        if (np == cnp)
                        {
                            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
                            cmd.Connection = cn;
                            cmd = new OleDbCommand("UPDATE TBL_MEMBER SET MEMBER_PASS = '" + np + "' WHERE MEMBER_ID = '" + userid + "'", cn);
                            cn.Open();
                            cmd.ExecuteNonQuery();
                            cn.Close();
                            Response.Redirect("Member_MyPage.aspx");
                        }
                        else
                        {
                            Messe_lbl.Text = "新しいパスワードの確認入力は、新しいパスワードの入力と一致しなければなりません。";
                            Messe_lbl.Visible = true;
                        }
                    }
                    else
                    {
                        Messe_lbl.Text = "新しいパスワードは、10桁以上必要です。";
                        Messe_lbl.Visible = true;
                    }
                }
                else
                {
                    Messe_lbl.Text = "新しいパスワードは半角英数字が一文字づつ必要です。";
                    Messe_lbl.Visible = true;
                }
            }
            else
            {
                Messe_lbl.Text = "パスワードが違います。";
                Messe_lbl.Visible = true;
            } 
        }

        protected void Cancel_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Member_MyPage.aspx");
        }
    }
}