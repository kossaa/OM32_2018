using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Reservation_Ticket_Selection : System.Web.UI.Page
    {
        int seatcount = 0;
        string[] seatname = new string[1];
        const int Cell2Width = 300;
        string UserID = "";//ログイン時はユーザーのログインIDが格納される
        Button BackBtn = new Button();
        Button NextBtn = new Button();
        TextBox MailAddressTextbox = new TextBox();
        string[] eventname = new string[1];//イベント名を格納
        int[] eventrate = new int[1];//イベント料金を格納
        string[] eventprice = new string[1];//変更する料金番号を格納
        string[] eventaddname = new string[1];
        int[] eventaddrate = new int[1];
        string[] displayticketname = new string[1];//表示されるチケット名を格納
        int[] displayticketrate = new int[1];//表示されるチケット料金を格納

        private DropDownList[] TicketDDL;

        protected void Page_Load(object sender, EventArgs e)
        {
            //結合準備中
            Session["ScheduleID"] = "0000005";
            Session["ScheduleEnd"] = DateTime.Parse("2018/10/25 14:25:00");


            DateTime time = (DateTime)Session["ScheduleEnd"];
            OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
            //イベントテーブル
            //その上映時に開催しているイベントの一覧を取得する
            //dtEvent.Rows[0][0]イベント番号、[0][1]イベント名、[0][2]イベント料金、[0][3]スケジュール番号、[0][4]料金番号
            OleDbDataAdapter daEvent = new OleDbDataAdapter("SELECT EVENT_ID,EVENT_NAME,EVENT_RATE,SCHEDULE_ID,RATE_ID FROM TBL_EVENT WHERE EVENT_STARTDAY<=#" + (DateTime)Session["ScheduleEnd"] + "# AND EVENT_ENDDAY>=#" + (DateTime)Session["ScheduleEnd"] + "# ORDER BY RATE_ID", cn);
            DataTable dtEvent = new DataTable();
            daEvent.Fill(dtEvent);
            int scheduleflag = 0;//スケジュール番号がnullでないイベントがあった時にフラグを立てる
            for (int i = 0; i < dtEvent.Rows.Count; i++)//スケジュール番号チェック
            {
                //スケジュール番号が登録されている場合
                if (dtEvent.Rows[i][3].ToString() != "")
                {
                    scheduleflag = 1;
                    eventname[0] = dtEvent.Rows[i][1].ToString();
                    eventrate[0] = int.Parse(dtEvent.Rows[i][2].ToString());
                    break;
                }
            }
            //イベント配列に該当する条件のイベントを格納する
            if (scheduleflag == 0)//スケジュール番号が登録されていなければ
            {
                for (int i = 0, j = 0,k=0; i < dtEvent.Rows.Count; i++)//イベントテーブルに該当するイベントが登録されていたら
                {
                    if (dtEvent.Rows[i][4].ToString() == "ADD")//追加されるチケットを格納
                    {
                        Array.Resize(ref eventaddname, k + 1);
                        Array.Resize(ref eventaddrate, k + 1);
                        eventaddname[k] = dtEvent.Rows[i][1].ToString();
                        eventaddrate[k] = int.Parse(dtEvent.Rows[i][2].ToString());
                        k++;
                    }
                    else//変更されるチケットを格納
                    {
                        //配列のサイズをチケットの種類数に合わせて変化させ、イベント内容を格納する
                        Array.Resize(ref eventname, j + 1);
                        Array.Resize(ref eventrate, j + 1);
                        Array.Resize(ref eventprice, j + 1);
                        eventname[j] = dtEvent.Rows[i][1].ToString();
                        eventrate[j] = int.Parse(dtEvent.Rows[i][2].ToString());
                        eventprice[j] = dtEvent.Rows[i][4].ToString();
                        j++;
                    }
                }
                //料金テーブル
                //上映終了時間が開始時間と終了時間の間に含まれる料金の一覧を取得する
                //dtRate.Rows[0][0]料金番号、[0][1]料金名、[0][2]料金
                OleDbDataAdapter daRate = new OleDbDataAdapter("SELECT RATE_ID,RATE_NAME,RATE_PRICE FROM TBL_RATE WHERE RATE_START<=#" + ((DateTime)Session["ScheduleEnd"]).TimeOfDay + "# AND RATE_END>=#" + ((DateTime)Session["ScheduleEnd"]).TimeOfDay + "# ORDER BY RATE_ID", cn);
                DataTable dtRate = new DataTable();
                daRate.Fill(dtRate);
                int ticketcount = 0;
                for (int i = 0; i < dtRate.Rows.Count; i++,ticketcount++)
                {
                    Array.Resize(ref displayticketname, i + 1);
                    Array.Resize(ref displayticketrate, i + 1);
                    for (int j = 0; j < eventprice.Length; j++)
                    {

                    }
                }
                TicketDDL[ticketcount].Items.Add("6ポイントで一回無料");
            }
            //ClientScriptManager cs = Page.ClientScript;
            //Type csType = this.GetType();
            //cs.RegisterStartupScript(csType, "onload", "<script type=\"text/javascript\">alert('"+表示したい値+"');</script>");


              



            //設定時間のうちイベントテーブルをチェックした結果変更されなかった料金番号を表示する


            //取得した料金テーブルの料金番号と料金名を格納する配列をそれぞれ用意し、格納する。
            //取得したイベントテーブルの料金番号を取得して料金番号配列の料金番号と照らし合わせてその位置にある料金名を置き換える


            //画面結合時に前の画面からデータを継承する
            //ログイン中の場合会員情報を取得する
            seatcount = 3;//継承した予約席数を格納する
            Array.Resize(ref seatname, seatcount);//配列の数を継承した予約数に合わせる
            seatname[0] = "c4";
            seatname[1] = "c5";
            seatname[2] = "c6";




            TableRow tableRow;
            TableCell tableCell;

            tableRow = new TableRow();
            tableCell = new TableCell();
            tableCell.Text = "席番号";
            tableRow.Cells.Add(tableCell);
            tableCell = new TableCell();
            tableCell.Text = "チケットの種類";
            tableRow.Cells.Add(tableCell);
            Table1.Rows.Add(tableRow);

            this.TicketDDL = new DropDownList[seatname.Length];
            for (int i = 0; i < seatname.Length; i++)
            {
                tableRow = new TableRow();
                tableCell = new TableCell();
                tableCell.Text = seatname[i];
                tableRow.Cells.Add(tableCell);
                tableCell = new TableCell();
                TicketDDL[i] = new DropDownList();
                TicketDDL[i].Items.Add("チケットの種類を選択してください");
                if (scheduleflag == 0)//スケジュール番号が登録されていないからチケットの種類が一つに絞られない場合
                {
                    for (int j = 0; j<displayticketname.Length; j++)//表示チケット名配列の数だけ繰り返す
                        TicketDDL[i].Items.Add(displayticketname[j]);
                }
                else//スケジュール番号が登録されているからチケットが一種類しかない場合
                    TicketDDL[i].Items.Add(eventname[0]);
                tableCell.Controls.Add(TicketDDL[i]);
                tableRow.Cells.Add(tableCell);
                Table1.Rows.Add(tableRow);
            }

            if (UserID == "")
            {
                tableRow = new TableRow();
                tableCell = new TableCell();
                Button LoginLinkBtn = new Button();
                LoginLinkBtn.Text = "ログイン";
                LoginLinkBtn.Click += new System.EventHandler(this.LoginLinkBtn_Click);
                tableCell.Controls.Add(LoginLinkBtn);
                tableRow.Cells.Add(tableCell);
                tableCell = new TableCell();
                Button MemberFormLinkBtn = new Button();
                MemberFormLinkBtn.Text = "新規登録";
                MemberFormLinkBtn.Click += new System.EventHandler(this.MemberFormLinkBtn_Click);
                tableCell.Controls.Add(MemberFormLinkBtn);
                tableRow.Cells.Add(tableCell);
                Table1.Rows.Add(tableRow);
            }
            tableRow = new TableRow();
            tableCell = new TableCell();
            tableCell.Text = "メールアドレス：";
            tableRow.Cells.Add(tableCell);
            tableCell = new TableCell();
            MailAddressTextbox.MaxLength = 50;
            MailAddressTextbox.Width = 296;//セルのサイズが300の場合そこに入る最大サイズが296
            tableCell.Controls.Add(MailAddressTextbox);
            tableCell.Width = Cell2Width;
            tableRow.Cells.Add(tableCell);
            Table1.Rows.Add(tableRow);

            tableRow = new TableRow();
            tableCell = new TableCell();
            BackBtn.Text = "戻る";
            BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            tableCell.Controls.Add(BackBtn);
            tableRow.Cells.Add(tableCell);
            tableCell = new TableCell();
            NextBtn.Text = "次へ進む";
            NextBtn.Click += new System.EventHandler(this.NextBtn_Click);
            tableCell.Controls.Add(NextBtn);
            tableRow.Cells.Add(tableCell);
            Table1.Rows.Add(tableRow);
        }

        protected void LoginLinkBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Member_Login.aspx");
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reservation_Seat_Selection.aspx");
        }

        protected void NextBtn_Click(object sender, EventArgs e)
        {
            int noSelectflag = 0;
            for (int i = 0; i < seatname.Length; i++)
            {
                if (TicketDDL[i].SelectedIndex == 0)
                {
                    noSelectflag = 1;
                    break;//for文のチェックを抜ける
                }
            }
            if (noSelectflag == 1)
            {
                TableRow tableRow;
                TableCell tableCell;
                tableRow = new TableRow();
                tableCell = new TableCell();
                tableCell.Text = "チケットの種類を選択してください";
                tableCell.ColumnSpan = 2;
                tableRow.Cells.Add(tableCell);
                Table1.Rows.AddAt(seatcount + 3, tableRow);
                return;
            }
            if (MailAddressTextbox.Text == "")
            {
                TableRow tableRow;
                TableCell tableCell;
                tableRow = new TableRow();
                tableCell = new TableCell();
                tableCell.Text = "メールアドレスを入力してください";
                tableCell.ColumnSpan = 2;
                tableRow.Cells.Add(tableCell);
                Table1.Rows.AddAt(seatcount+3,tableRow);
                return;
            }
            if (!isHankaku(MailAddressTextbox.Text))
            {
                TableRow tableRow;
                TableCell tableCell;
                tableRow = new TableRow();
                tableCell = new TableCell();
                tableCell.Text = "半角英数字記号のみ使用できます";
                tableCell.ColumnSpan = 2;
                tableRow.Cells.Add(tableCell);
                Table1.Rows.AddAt(seatcount + 3, tableRow);
                return;
            }
            if (CheckMailAddressFormat(MailAddressTextbox.Text) == false)
            {
                TableRow tableRow;
                TableCell tableCell;
                tableRow = new TableRow();
                tableCell = new TableCell();
                tableCell.Text = "正しいメールアドレスではありません";
                tableCell.ColumnSpan = 2;
                tableRow.Cells.Add(tableCell);
                Table1.Rows.AddAt(seatcount + 3, tableRow);
                return;
            }
            Session["BookingMail"] = MailAddressTextbox.Text;
            Response.Redirect("Reservation_Confirm_Input_Information.aspx");
        }

        bool CheckMailAddressFormat(string address) 
        {
            try
            {
                System.Net.Mail.MailAddress mailAddress = new System.Net.Mail.MailAddress(address);
            }
            catch (FormatException)
            {
                //メールアドレスとしての文法エラー
                return false;
            }
            //文法エラーなし
            return true;
        }

        protected void MemberFormLinkBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberForm.aspx");
        }

        static Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");//文字コードを指定する

        //半角文字が含まれているかどうかを判定
        public static bool isHankaku(string str)
        {
            int num = sjisEnc.GetByteCount(str);
            return num == str.Length;
        }
    }
}