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
    public partial class Reservation_Ticket_Selection : System.Web.UI.Page
    {
        OleDbCommand cmd;
        DataSet ds;
        int seatcount = 0;
        string[] seatname = new string[1];
        const int Cell2Width = 300;
        string UserID = "";//ログイン時はユーザーのログインIDが格納される
        Button BackBtn = new Button();
        Button NextBtn = new Button();
        TextBox MailAddressTextbox = new TextBox();

        private DropDownList[] TicketDDL;

        protected void Page_Load(object sender, EventArgs e)
        {
            //結合準備中
            Session["ScheduleID"] = "0000005";
            Session["ScheduleEnd"] = DateTime.Parse("2018/10/25 14:25:00");

            
            DateTime time = (DateTime)Session["ScheduleEnd"];
            OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
            ////cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|\\stusrv\システム開発演習\OM-32\データベース\BookingDB.accdb;");
            OleDbDataAdapter daEvent = new OleDbDataAdapter("SELECT EVENT_ID,EVENT_NAME,EVENT_RATE,SCHEDULE_ID,EVENT_STARTDAY,EVENT_ENDDAY,RATE_ID FROM TBL_EVENT WHERE SCHEDULE_ID='" + (string)Session["ScheduleID"] + "' OR EVENT_STARTDAY<=#" + (DateTime)Session["ScheduleEnd"] + "# AND EVENT_ENDDAY>=#" + (DateTime)Session["ScheduleEnd"] + "#", cn);
            DataTable dtEvent = new DataTable();
            daEvent.Fill(dtEvent);
            OleDbDataAdapter daRate = new OleDbDataAdapter("SELECT * FROM TBL_RATE WHERE RATE_START<=#" + ((DateTime)Session["ScheduleEnd"]).TimeOfDay + "# AND RATE_END>=#" + ((DateTime)Session["ScheduleEnd"]).TimeOfDay + "#", cn);
            DataTable dtRate = new DataTable();
            daEvent.Fill(dtRate);
            //ClientScriptManager cs = Page.ClientScript;
            //Type csType = this.GetType();
            //cs.RegisterStartupScript(csType, "onload", "<script type=\"text/javascript\">alert('"+表示したい値+"');</script>");
            if (dtRate.Rows.Count != 0)//イベントテーブルに該当するイベントが登録されていたら
            {
                ClientScriptManager cs = Page.ClientScript;
                Type csType = this.GetType();
                cs.RegisterStartupScript(csType, "onload", "<script type=\"text/javascript\">alert('" + dtRate.Rows.Count + "');</script>");
            }



            //イベントテーブル
            //選択されたスケジュール番号が登録されているかどうかをチェックし、なければ現在の日付がイベントの開始日と終了日の間に入っているかをチェック。
            //料金番号がallの場合表示される全ての料金をイベント料金に置き換える
            //料金番号がaddの場合イベント料金の置き換えは発生させずにチケット一覧に追加する

            //料金テーブル
            //設定時間のうちイベントテーブルをチェックした結果変更されなかった料金番号を表示する
            

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
                TicketDDL[i].Items.Add("1");
                TicketDDL[i].Items.Add("2");
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
            //IMEMODEをDisableに設定する
            //MailAddressTextbox.CssClass = "disabled";
            //MailAddressTextbox.Style.Add("ime-mode", "disabled");
            //入力可能文字を数字のみにする
            //MailAddressTextbox.TextChanged += new System.EventHandler(this.MailAddressTextbox_TextChanged);
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
            //MailAddressTextboxに全角が含まれている場合はtableCell.Text = "半角英数字と記号のみ使用できます";
            //Reservation_Enter_Reservation_Information.aspxを再表示する
            int noSelectflag=0;
            for(int i=0;i<seatname.Length;i++)
            {
                if(TicketDDL[i].SelectedIndex==0)
                {
                    noSelectflag=1;
                    break;//for文のチェックを抜ける
                }
            }
            if(noSelectflag==1)
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
            Session["BookingMail"] = MailAddressTextbox.Text;
            Response.Redirect("Reservation_Confirm_Input_Information.aspx");
        }

        protected void MemberFormLinkBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberForm.aspx");
        }
    }
}