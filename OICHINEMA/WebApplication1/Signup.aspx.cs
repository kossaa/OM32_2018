﻿using System;
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
            if (IsPostBack == true)
            {
                Label20.Visible = false;
            }

            CalenderAddYear();
            CalenderAddDay();
        }

        /*=======================================
         *データベースに接続、開くまで
         ======================================*/
        public OleDbConnection cn = new OleDbConnection();

        public bool DB_Connection(){
            try{
                //コネクションの作成
                cn = new OleDbConnection();
                cn.ConnectionString=@"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;";

            }
            catch (Exception){
                Label20.Text = "DB接続×";
                Label20.Visible = true;
                return false;
            }

            return true;
        }


        /*=====================================================
         * ドロップダウンの年に当年までの年を追加
         ======================================================*/
        private void CalenderAddYear(){
            int nowyear = Today.Year;
            int year = 1920;//年カウント開始日

            for (int i = year; i <= nowyear; i++){
                DropDownList2.Items.Add(i.ToString());
            }
        }

        /*=====================================================
         * ドロップダウンの日に当月の日を追加
         ======================================================*/
        private void CalenderAddDay()
        {
            int year = int.Parse(DropDownList2.Text);
            if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0)){
              /*うるう年*/
                if (DropDownList3.Text == "2")
                {/*2月なら*/
                    for (int i = 1; i <= 29; i++){
                        DropDownList4.Items.Add(i.ToString());
                    }
                }
                else if (DropDownList3.Text == "4" || DropDownList3.Text == "6" || DropDownList3.Text == "9" || DropDownList3.Text == "11")
                {/*4,6,9,11月なら*/
                    for (int i = 1; i <= 30; i++){
                        DropDownList4.Items.Add(i.ToString());
                    }
                }
                else
                {/*1,3,5,7,8,10,12月なら*/
                    for (int i = 1; i <= 31; i++){
                        DropDownList4.Items.Add(i.ToString());
                    }
                }
            }
            else/*うるう年じゃない*/
            {
                if (DropDownList3.Text == "2")
                {/*2月なら*/
                    for (int i = 1; i <= 28; i++)
                    {
                        DropDownList4.Items.Add(i.ToString());
                    }
                }
                else if (DropDownList3.Text == "4" || DropDownList3.Text == "6" || DropDownList3.Text == "9" || DropDownList3.Text == "11")
                {/*4,6,9,11月なら*/
                    for (int i = 1; i <= 30; i++)
                    {
                        DropDownList4.Items.Add(i.ToString());
                    }
                }
                else
                {/*1,3,5,7,8,10,12月なら*/
                    for (int i = 1; i <= 31; i++)
                    {
                        DropDownList4.Items.Add(i.ToString());
                    }
                }
            }
        }



        /*====================================================
         * 会員番号の最大値を取得して新しい会員のIDを作成する
         =====================================================*/
        private string getNewMaxMemberId(){
            OleDbCommand getNIDcommand = new OleDbCommand();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter();


            DB_Connection();
            //会員番号の最大番号を取得する
            string MaxMID = "";

            //コマンド指定
            getNIDcommand = new OleDbCommand();
            getNIDcommand.CommandText = "SELECT MAX(MEMBER_ID) from TBL_MEMBER";
            getNIDcommand.Connection = cn;
            cn.Open();
            da.SelectCommand = getNIDcommand;
            da.Fill(dt);
            MaxMID = dt.Rows[0][0].ToString();
            dt.Clear();//使い終わったdtを初期化しておく
            cn.Close();

            //会員番号の最大値に+1加算
            int NewMID = int.Parse(MaxMID)+1;
            string nd = string.Format("{0:D7}", NewMID);

            return nd;
        }


        /*====================================================
        * 登録日（システム内の時間）を取得
        =====================================================*/
        DateTime Today = DateTime.Now;
        private DateTime getToday() {
            String std = Today.ToString("yyyy/MM/dd");
            Today = DateTime.Parse(std);
            return Today;
        }
    
        
        /*====================================================
         * ドロップダウンリストから生年月日を結合、Date型に変換
        =====================================================*/
        private DateTime getBirthDay()
        {
            DateTime BirthDay = DateTime.Parse(DropDownList2.Text + "/" + DropDownList3.Text + "/" + DropDownList4.Text);
            String bd = BirthDay.ToString("yyyy/MM/dd");
            BirthDay = DateTime.Parse(bd);
            return BirthDay;
        }



        /*========================================================
         * 郵便番号から住所割り出し
         ========================================================*/
        private void Adr_Post(string PostAdr)
        {
            string sKey = PostAdr;
            //文字列の前後のスペースをとる
            sKey = sKey.Trim(' ');

            // 文字列の長さを取得する
            int iLength = sKey.Length;
            if (iLength == 7)　//"-"を含まない
            {
                //接続先DBの情報をセット
                OleDbConnection PostCn = new OleDbConnection();
                PostCn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|POSTADR.accdb;";
                //実行するSQL文の指定　@IDはパラメータとして後で指定
                OleDbCommand PostCommand = new OleDbCommand("SELECT * FROM KEN_ALL WHERE フィールド3 = '" + PostAdr + "';", PostCn);
                //パラメータの指定　Accessの場合は必ずSQL文で出現したパラメータの順に指定する
                PostCommand.Parameters.AddWithValue("@PostAdr", PostAdr);
                //データベースを開く
                PostCn.Open();
                //SQL文の実行
                OleDbDataReader oledr = PostCommand.ExecuteReader();
                //データの読み込み
                if (oledr.Read())
                {
                    TextBox6.Text = oledr["フィールド7"].ToString() ;
                    TextBox7.Text = oledr["フィールド8"].ToString() + oledr["フィールド9"].ToString();
                }
                //データベースを閉じる
                PostCn.Close();
            }
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox11.Text != TextBox12.Text)
            {
            string script =
               "<script language=javascript>" +
               "window.alert('パスワードが違います')" +
               "</script>";
                Response.Write(script);

            }
            else
            {



                //            String InsertStr ="INSERT INTO TBL_MEMBER( MEMBER_ID ,MEMBER_NAME ,MEMBER_KANA ,MEMBER_POST ,MEMBER_ADR1 ,MEMBER_ADR2 ,MEMBER_BIRTH ,MEMBER_TEL ,MEMBER_GENDER ,MEMBER_DAY  ,MEMBER_POINT ,MEMBER_MAIL  ,MEMBER_PASS) " +
                //                                             "VALUES ('@MEMBER_ID','@MEMBER_NAME','@MEMBER_KANA','@MEMBER_POST','@MEMBER_ADR1','@MEMBER_ADR2',@MEMBER_BIRTH,'@MEMBER_TEL','@MEMBER_GENDER',#@MEMBER_DAY#,@MEMBER_POINT,'@MEMBER_MAIL','@MEMBER_PASS')";

                OleDbCommand command = new OleDbCommand();

                //Insertコマンドの値をcommandに指定
                //command = new OleDbCommand(InsertStr);
                //DB接続
                DB_Connection();

                /*          try
                            {

                                command.Parameters.AddWithValue("@MEMBER_ID", getNewMaxMemberId());
                                if (String.IsNullOrWhiteSpace(TextBox2.Text) != true && String.IsNullOrWhiteSpace(TextBox3.Text) != true)
                                    command.Parameters.AddWithValue("@MEMBER_NAME", TextBox2.Text + TextBox3.Text);
                                if (String.IsNullOrWhiteSpace(TextBox1.Text) != true && String.IsNullOrWhiteSpace(TextBox4.Text) != true)
                                    command.Parameters.AddWithValue("@MEMBER_KANA", TextBox1.Text + TextBox4.Text);
                                if (String.IsNullOrWhiteSpace(TextBox5.Text) != true)
                                    command.Parameters.AddWithValue("@MEMBER_POST", TextBox5.Text);
                                if (String.IsNullOrWhiteSpace(TextBox6.Text) != true && String.IsNullOrWhiteSpace(TextBox7.Text) != true)
                                    command.Parameters.AddWithValue("@MEMBER_ADR1",  TextBox6.Text + TextBox7.Text );
                                if (String.IsNullOrWhiteSpace(TextBox8.Text) != true)
                                    command.Parameters.AddWithValue("@MEMBER_ADR2", TextBox8);
                                command.Parameters.AddWithValue("@MEMBER_BIRTH", "#"+getBirthDay()+"#");
                                if (String.IsNullOrWhiteSpace(TextBox9.Text) != true)
                                command.Parameters.AddWithValue("@MEMBER_TEL",  TextBox9.Text );
                                if (String.IsNullOrWhiteSpace(DropDownList1.Text) != true)
                                command.Parameters.AddWithValue("@MEMBER_GENDER", DropDownList1.Text );
                                command.Parameters.AddWithValue("@MEMBER_DAY", getToday());
                                command.Parameters.AddWithValue("@MEMBER_POINT", 0);
                                if (String.IsNullOrWhiteSpace(TextBox10.Text) != true)
                                command.Parameters.AddWithValue("@MEMBER_MAIL",  TextBox10.Text );
                                if (String.IsNullOrWhiteSpace(TextBox11.Text) != true)
                                command.Parameters.AddWithValue("@MEMBER_PASS", TextBox11.Text);
                */
                /*↓成功*/
                String testdate = "INSERT INTO TBL_MEMBER( MEMBER_ID ,MEMBER_NAME ,MEMBER_KANA ,MEMBER_POST ,MEMBER_ADR1 ,MEMBER_ADR2 ,MEMBER_BIRTH ,MEMBER_TEL ,MEMBER_GENDER ,MEMBER_DAY  ,MEMBER_POINT ,MEMBER_MAIL  ,MEMBER_PASS) VALUES ('" + getNewMaxMemberId() + "','" + TextBox2.Text + TextBox3.Text + "','" + TextBox1.Text + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + TextBox7.Text + "','" + TextBox8.Text + "',#" + getBirthDay() + "#,'" + TextBox9.Text + "','" + DropDownList1.Text + "',#" + getToday() + "#,'" + TextBox10.Text + "','" + TextBox11.Text + "')";

                command = new OleDbCommand(testdate);

                command.Connection = cn;
                cn.Open();

                int a = command.ExecuteNonQuery();
                Label20.Text = a.ToString();
                Label20.Visible = true;
                /*          }
                            catch (OleDbException ode)
                            {
                                Label20.Text = "エラー";
                                Label20.Visible = true;
                                Console.WriteLine(ode.Message);
                            }
                */
                cn.Close();
            }
        }
        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList4.Items.Clear();
            CalenderAddDay();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Adr_Post(TextBox5.Text.ToString());
        }
    }
}