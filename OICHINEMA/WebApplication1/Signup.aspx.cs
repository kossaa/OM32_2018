using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                messageLabel.Visible = false;
            }
            else
            {
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
                messageLabel.Text = "DB接続×";
                messageLabel.Visible = true;
                return false;
            }
            return true;
        }
        /*=====================================================
         * ドロップダウンの年に当年までの年を追加
         ======================================================*/
        private void CalenderAddYear(){
            int nowyear = Today.Year;
            int year = 1900;//年カウント開始日

            for (int i = year; i <= nowyear; i++){
                YearDDL.Items.Add(i.ToString());
            }
        }

        /*=====================================================
         * ドロップダウンの日に当月の日を追加
         ======================================================*/
        private void CalenderAddDay()
        {
            int year = int.Parse(YearDDL.Text);
            if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0)){
              /*うるう年*/
                if (MonthDDL.Text == "2")
                {/*2月なら*/
                    for (int i = 1; i <= 29; i++){
                        DayDDL.Items.Add(i.ToString());
                    }
                }
                else if (MonthDDL.Text == "4" || MonthDDL.Text == "6" || MonthDDL.Text == "9" || MonthDDL.Text == "11")
                {/*4,6,9,11月なら*/
                    for (int i = 1; i <= 30; i++){
                        DayDDL.Items.Add(i.ToString());
                    }
                }
                else
                {/*1,3,5,7,8,10,12月なら*/
                    for (int i = 1; i <= 31; i++){
                        DayDDL.Items.Add(i.ToString());
                    }
                }
            }
            else/*うるう年じゃない*/
            {
                if (MonthDDL.Text == "2")
                {/*2月なら*/
                    for (int i = 1; i <= 28; i++)
                    {
                        DayDDL.Items.Add(i.ToString());
                    }
                }
                else if (MonthDDL.Text == "4" || MonthDDL.Text == "6" || MonthDDL.Text == "9" || MonthDDL.Text == "11")
                {/*4,6,9,11月なら*/
                    for (int i = 1; i <= 30; i++)
                    {
                        DayDDL.Items.Add(i.ToString());
                    }
                }
                else
                {/*1,3,5,7,8,10,12月なら*/
                    for (int i = 1; i <= 31; i++)
                    {
                        DayDDL.Items.Add(i.ToString());
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
            String MaxMID ;

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
            DateTime BirthDay = DateTime.Parse(YearDDL.Text + "/" + MonthDDL.Text + "/" + DayDDL.Text);
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
                    FADR1Txb.Text = oledr["フィールド7"].ToString() ;
                    LADR1Txb.Text = oledr["フィールド8"].ToString() ;
                }
                //データベースを閉じる
                PostCn.Close();
            }
        }

        /*====================================================
        * SQLに影響の出る文字の検索
        =====================================================*/
        int TxbCheck = -1;
        protected void SQLInjectionCheck(string txbStr)
        {
            char[] CheckChar = {'=',  ';', '\'',  '"',    '\\',    '*',    '#',    '$'};
            string checkStr = txbStr;
            TxbCheck = checkStr.IndexOfAny(CheckChar);
        }

        /*====================================================
        * パスワードに大文字小文字の英数が入っているかのチェック
        =====================================================*/
        Boolean passCheck = false;
        protected bool PasswordCheck(string passStr)
        {
            string password = passStr;
            passCheck = Regex.IsMatch(password, @"[a-zA-Z]") &&
            Regex.IsMatch(password, @"\d");
            return passCheck;
        }
        

        protected void EnterBtn_Click(object sender, EventArgs e)
        {

            TextBox[] TextBoxArray = new TextBox[10];
            TextBoxArray[0] = FNameTxb;
            TextBoxArray[1] = FKanaTbx;
            TextBoxArray[2] = PostTxb;
            TextBoxArray[3] = FADR1Txb;
            TextBoxArray[4] = LADR1Txb;
            TextBoxArray[5] = ADR2Txb;
            TextBoxArray[6] = TELTxb;
            TextBoxArray[7] = MailTxb;
            TextBoxArray[8] = PassTxb;
            TextBoxArray[9] = PassTxb2;
            
            OleDbCommand command = new OleDbCommand();

            //DB接続
            DB_Connection();

            if (String.IsNullOrWhiteSpace(FNameTxb.Text) != true && String.IsNullOrWhiteSpace(FKanaTbx.Text) != true && String.IsNullOrWhiteSpace(PostTxb.Text) != true && String.IsNullOrWhiteSpace(FADR1Txb.Text) != true && String.IsNullOrWhiteSpace(LADR1Txb.Text) != true && String.IsNullOrWhiteSpace(TELTxb.Text) != true && String.IsNullOrWhiteSpace(MailTxb.Text) != true && String.IsNullOrWhiteSpace(PassTxb.Text) != true)
            {
            //各テキストボックスに特定の文字が含まれてたらInsert処理しない
                for(int i = 0;i < TextBoxArray.Length; i++){
                    SQLInjectionCheck(TextBoxArray[i].Text);
                    if (TxbCheck > -1)
                    {
                        messageLabel.Text = "無効な文字が含まれています。";
                        messageLabel.Visible = true;
                        return;
                    }
                }
            //パスワードに大文字、小文字の英数が入っているか
                if (PasswordCheck(PassTxb.Text) == false)
                {
                    messageLabel.Text = "パスワードには大文字、小文字の英数字で登録してください。";
                    messageLabel.Visible = true;
                    return;
                }
            //パスワードと確認用のパスワードが一致するか
                if (PassTxb.Text != PassTxb2.Text)
                {
                    messageLabel.Text = "パスワードが一致しません。";
                    messageLabel.Visible = true;
                    return;
                }
                /*↓成功*/
                String testdate = "INSERT INTO TBL_MEMBER( MEMBER_ID ,MEMBER_NAME ,MEMBER_KANA ,MEMBER_POST ,MEMBER_ADR1 ,MEMBER_ADR2 ,MEMBER_BIRTH ,MEMBER_TEL ,MEMBER_GENDER ,MEMBER_DAY  ,MEMBER_POINT ,MEMBER_MAIL  ,MEMBER_PASS) VALUES ('" + getNewMaxMemberId() + "','" + FNameTxb.Text + "','" + FKanaTbx.Text + "','" + PostTxb.Text + "','" + FADR1Txb.Text + LADR1Txb.Text + "','" + ADR2Txb.Text + "',#" + getBirthDay() + "#,'" + TELTxb.Text + "','" + SexDDL.Text + "',#" + getToday() + "#,0,'" + MailTxb.Text + "','" + PassTxb.Text + "')";
                command = new OleDbCommand(testdate);
                command.Connection = cn;
                cn.Open();
                int a = command.ExecuteNonQuery();
                if (a != 0)
                {

                }
                cn.Close();
            }
            else
            {
                messageLabel.Text = "未入力の箇所があります。";
                messageLabel.Visible = true;
            }
        }

       
        
        protected void MonthDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            DayDDL.Items.Clear();
            CalenderAddDay();
        }

        protected void SerchBtn_Click(object sender, EventArgs e)
        {
            Adr_Post(PostTxb.Text.ToString());
        }
    }
}