using System;
using System.Collections.Generic;
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
            Session["ScheduleID"] = "0000004";//結合準備
            
            
            
            
            if (Session["ScheduleID"] == null)
            {
                Response.Redirect("Schedule.aspx");//スケジュール画面に飛ぶ
                return;
            }
            if (Session["SeatInformation"] == null || Session["SelectedTicket"] == null)
            {
                Response.Redirect("Reservation_Ticket_Selection.aspx");//チケット選択画面に飛ぶ
                return;
            }
            //画面結合時に前の画面からデータを継承する
            //継承内容
            //座席番号 スケジュール番号 チケットデータ一式 会員番号 メールアドレス
            seatList = (List<string>)Session["SeatInformation"];//Sessionに格納されてる選択された座席情報を使えるようにseatListに展開する
            selectedticketList = (List<SelectedTicket>)Session["SelectedTicket"];//引き継いだ選択されたチケット情報を格納する
            
            TableRow tableRow;
            TableCell tableCell;

            tableRow = new TableRow();
            tableCell = new TableCell();
            tableCell.Text = "上映タイトル：";
            tableRow.Cells.Add(tableCell);
            tableCell = new TableCell();
            tableCell.Text = "セル2";
            tableCell.Width = Cell2Width;
            tableRow.Cells.Add(tableCell);
            Table1.Rows.Add(tableRow);
            
            tableRow = new TableRow();
            tableCell = new TableCell();
            tableCell.Text = "氏名：";
            tableRow.Cells.Add(tableCell);
            tableCell = new TableCell();
            tableCell.Text = "セルB";
            tableCell.Width = Cell2Width;
            tableRow.Cells.Add(tableCell);
            Table1.Rows.Add(tableRow);

            tableRow = new TableRow();
            tableCell = new TableCell();
            tableCell.Text = "上映予定日時：";
            tableRow.Cells.Add(tableCell);
            tableCell = new TableCell();
            tableCell.Text = "8888年88月88日 88時88分～8888年88月88日 88時88分";
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
            tableCell=new TableCell();
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