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
    public partial class test : System.Web.UI.Page
    {
        const int Cell2Width = 300;
        List<string> seatList = new List<string>();//座席選択画面から引き継いだ座席情報を格納
        List<SelectedTicket> selectedticketList = new List<SelectedTicket>();//チケット選択画面から引き継いだ選択されたチケット情報を格納

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["PageID"] != "Reservation_Ticket_Selection")//正規の手順でこのフォームを表示しなかった場合
            {
                //各Sessionのクリア
                Session.Remove("ScheduleID");
                Session.Remove("ScheduleEnd");
                Session.Remove("BookingMail");
                Session.Remove("SeatInformation");
                Session.Remove("SelectedTicket");
                Session.Remove("WorkName");
                Session.Remove("ScheduleStart");
                Response.Redirect("https://www.yahoo.co.jp/");
                //Response.Redirect("Schedule.aspx");//TOP画面に飛ぶ
                return;
            }
            Session["PageID"] = "Reservation_Confirm_Input_Information";
            seatList = (List<string>)Session["SeatInformation"];//Sessionに格納されてる選択された座席情報を使えるようにseatListに展開する
            selectedticketList = (List<SelectedTicket>)Session["SelectedTicket"];//引き継いだ選択されたチケット情報を格納する

            TableRow tableRow;
            TableCell tableCell;

            tableRow = new TableRow();
            tableCell = new TableCell();
            tableCell.Text = "上映タイトル：";
            tableRow.Cells.Add(tableCell);
            tableCell = new TableCell();
            tableCell.Text = (string)Session["WorkName"];
            tableCell.Width = Cell2Width;
            tableRow.Cells.Add(tableCell);
            Table1.Rows.Add(tableRow);

            tableRow = new TableRow();
            tableCell = new TableCell();
            tableCell.Text = "氏名：";
            tableRow.Cells.Add(tableCell);
            tableCell = new TableCell();
            if ((string)Session["MemberID"] != "")//ログインされていたら会員番号から会員名を取り出して表示する
            {
                OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
                OleDbDataAdapter daRate = new OleDbDataAdapter("SELECT MEMBER_NAME FROM TBL_RATE WHERE MEMBER_ID='" + (string)Session["MemberID"] + "'", cn);
                DataTable dtRate = new DataTable();
                daRate.Fill(dtRate);
                tableCell.Text = dtRate.Rows[0][0].ToString();
            }
            else
                tableCell.Text = "ログインされていません";
            tableCell.Width = Cell2Width;
            tableRow.Cells.Add(tableCell);
            Table1.Rows.Add(tableRow);

            tableRow = new TableRow();
            tableCell = new TableCell();
            tableCell.Text = "上映予定日時：";
            tableRow.Cells.Add(tableCell);
            tableCell = new TableCell();
            tableCell.Text = ((DateTime)Session["ScheduleStart"]).ToString("yyyy年M月d日 H時m分") + "～" + ((DateTime)Session["ScheduleEnd"]).ToString("yyyy年M月d日 H時m分");
            tableCell.ColumnSpan = 2;
            tableCell.Width = Cell2Width;
            tableRow.Cells.Add(tableCell);
            Table1.Rows.Add(tableRow);

            tableRow = new TableRow();
            tableCell = new TableCell();
            tableCell.Text = "メールアドレス：";
            tableRow.Cells.Add(tableCell);
            tableCell = new TableCell();
            tableCell.Text = Session["BookingMail"].ToString();
            tableCell.Width = Cell2Width;
            tableRow.Cells.Add(tableCell);
            Table1.Rows.Add(tableRow);

            tableRow = new TableRow();
            tableCell = new TableCell();
            tableCell.Text = "予約席及び料金：";
            tableCell.RowSpan = seatList.Count + 2;
            tableRow.Cells.Add(tableCell);
            tableCell = new TableCell();
            tableCell.Text = "予約席";
            tableCell.Width = Cell2Width;
            tableRow.Cells.Add(tableCell);
            tableCell = new TableCell();
            tableCell.Text = "チケットの種類";
            tableRow.Cells.Add(tableCell);
            tableCell = new TableCell();
            tableCell.Text = "料金";
            tableRow.Cells.Add(tableCell);
            Table1.Rows.Add(tableRow);
            int totalcost = 0;//チケットの合計金額を格納する

            for (int i = 0; i < seatList.Count; i++)
            {
                tableRow = new TableRow();
                tableCell = new TableCell();
                tableCell.Text = seatList[i];//予約席名
                tableCell.Width = Cell2Width;
                tableRow.Cells.Add(tableCell);
                tableCell = new TableCell();
                tableCell.Text = selectedticketList[i].ticketName;//各予約席のチケットの種類
                tableRow.Cells.Add(tableCell);
                tableCell = new TableCell();
                tableCell.Text = selectedticketList[i].ticketRate.ToString();//チケットの種類に基づく料金
                tableRow.Cells.Add(tableCell);
                Table1.Rows.Add(tableRow);
                totalcost += selectedticketList[i].ticketRate;//チケットの料金を足す
            }

            tableRow = new TableRow();
            tableCell = new TableCell();
            tableCell.Text = "合計" + seatList.Count.ToString() + "席";
            tableCell.Width = Cell2Width;
            tableRow.Cells.Add(tableCell);
            tableCell = new TableCell();
            tableCell.Text = "合計金額";
            tableRow.Cells.Add(tableCell);
            tableCell = new TableCell();
            tableCell.Text = totalcost.ToString();
            tableRow.Cells.Add(tableCell);
            Table1.Rows.Add(tableRow);

            tableRow = new TableRow();
            tableCell = new TableCell();
            tableCell.Text = "以上の内容でよろしいでしょうか";
            tableCell.ColumnSpan = 2;
            tableRow.Cells.Add(tableCell);
            Table1.Rows.Add(tableRow);

            tableRow = new TableRow();
            tableCell = new TableCell();
            Button BackBtn = new Button();
            BackBtn.Text = "戻る";
            BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            tableCell.Controls.Add(BackBtn);
            tableRow.Cells.Add(tableCell);
            tableCell = new TableCell();
            Button AcceptBtn = new Button();
            AcceptBtn.Text = "確定";
            AcceptBtn.Click += new System.EventHandler(this.AcceptBtn_Click);
            tableCell.Controls.Add(AcceptBtn);
            tableRow.Cells.Add(tableCell);
            Table1.Rows.Add(tableRow);
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reservation_Ticket_Selection.aspx");
        }

        protected void AcceptBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reservation_Receipt_Confirmation.aspx");
        }
    }
}