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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label20.Visible = false;
        }

        /*=======================================
         *データベースに接続、開くまで
         ======================================*/
        public OleDbCommand command;
        public OleDbDataAdapter dbAdapter;
        public OleDbConnection cn;
        public bool DB_Connection_Open(){
            try
            {
                //コネクションの作成
                cn = new OleDbConnection();
                command = new OleDbCommand();

                cn.ConnectionString=@"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;";
                //コネクションを開く
                cn.Open();
            }
            catch (Exception)
            {
                Label20.Text = "DB接続×";
                Label20.Visible = true;
                return false;
            }

            return true;
        }





        /*====================================================
         * 会員番号の最大値を取得して新しい会員のIDを作成する
         =====================================================*/
        private string getNewMaxMemberId()
        {
            DB_Connection_Open();
            //会員番号の最大番号を取得する
            int MaxMID = 0;

            //コマンド指定
            command.CommandText = "SELECT MAX(MEMBER_ID) from TBL_MEMBER";
            command.Connection = cn;

            MaxMID = command.ExecuteNonQuery();


            //会員番号の最大値に+1加算
            String NewMID = (MaxMID + 1).ToString();
            string nd = string.Format("{0:D7}", NewMID);

            return nd;
        }


        protected void Button2_Click(object sender, EventArgs e)
        {

            String InsertStr ="insert into TBL_MEMBER(MEMBER_ID,MEMBER_NAME,MEMBER_KANA,MEMBER_POST,MEMBER_ADR1,MEMBER_ADR2,MEMBER_BIRTH,MEMBER_TEL,MEMBER_GENDER,MEMBER_DAY,MEMBER_MAIL,MEMBER_PASS) " +
                                             "values (@MEMBER_ID,@MEMBER_NAME,@MEMBER_KANA,@MEMBER_POST,@MEMBER_ADR1,@MEMBER_ADR2,@MEMBER_BIRTH,@MEMBER_TEL,@MEMBER_GENDER,@MEMBER_DAY,@MEMBER_MAIL,@MEMBER_PASS)";
            
            
            //DB接続とOpen
            DB_Connection_Open();

            /*テーブル指定(dt)*/



            //Insertコマンドの値指定
            command = new OleDbCommand(InsertStr);

            command.Parameters.AddWithValue("@MEMBER_ID",getNewMaxMemberId());
            command.Parameters.AddWithValue("@MEMBER_NAME",TextBox2.Text+TextBox3.Text);
            command.Parameters.AddWithValue("@MEMBER_KANA",TextBox1.Text+TextBox4.Text);
            command.Parameters.AddWithValue("@MEMBER_POST",TextBox5.Text);
            command.Parameters.AddWithValue("@MEMBER_ADR1",TextBox6.Text+TextBox7.Text);
            command.Parameters.AddWithValue("@MEMBER_ADR2",TextBox8);
            //command.Parameters.AddWithValue("@MEMBER_BIRTH",);
            command.Parameters.AddWithValue("@MEMBER_TEL",TextBox9.Text);
            command.Parameters.AddWithValue("@MEMBER_GENDER",DropDownList1.Text);
            //command.Parameters.AddWithValue("@MEMBER_DAY",);
            command.Parameters.AddWithValue("@MEMBER_MAIL",TextBox10.Text);
            command.Parameters.AddWithValue("@MEMBER_PASS",TextBox11.Text);
        }
                

    }
}