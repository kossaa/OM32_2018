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
            if ((string)Session["PageID"] != "Reservation_Ticket_Selection" && !IsPostBack)//正規の手順でこのフォームを表示しなかった場合
            {
                //各Sessionのクリア
                Session.Remove("ScheduleID");
                Session.Remove("ScheduleEnd");
                Session.Remove("BookingMail");
                Session.Remove("SeatInformation");
                Session.Remove("SelectedTicket");
                Session.Remove("WorkName");
                Session.Remove("ScheduleStart");
                Session.Remove("TicketSelectedIndexList");
                Session.Remove("MemberName");
                Session.Remove("MemberPoint");
                Session.Remove("PointGet");
                Session.Remove("PointUse");
                Session.Remove("BookingBuy");
                Response.Redirect("Reservation_Ticket_Selection.aspx");
                //Response.Redirect("TOP.aspx");//TOP画面に飛ぶ
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
            if ((string)Session["MemberID"] != "")
                tableCell.Text = (string)Session["MemberName"];
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
            tableCell.RowSpan = selectedticketList.Count + 2;
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

            for (int i = 0; i < selectedticketList.Count; i++)
            {
                tableRow = new TableRow();
                tableCell = new TableCell();
                tableCell.Text = selectedticketList[i].seatNumber;//予約席名
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
            tableCell.Text = "合計" + selectedticketList.Count.ToString() + "席";
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
            Session["PageID"] = "Reservation_Confirm_Input_Information_back";
            Response.Redirect("Reservation_Ticket_Selection.aspx");
        }

        protected void AcceptBtn_Click(object sender, EventArgs e)
        {
            seatList = (List<string>)Session["SeatInformation"];//Sessionに格納されてる選択された座席情報を使えるようにseatListに展開する
            selectedticketList = (List<SelectedTicket>)Session["SelectedTicket"];//引き継いだ選択されたチケット情報を格納する
            //仮予約テーブルの該当する席を削除する
            OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
            OleDbDataAdapter daTemporary = new OleDbDataAdapter("DELETE FROM TBL_TEMPORARY WHERE TEMPORARY_SCHEDULE='" + (string)Session["ScheduleID"] + "'" + SQLWhereMaker.SQLMakeAND(seatList, "TEMPORARY_SEAT"), cn);
            DataTable dtTemporary = new DataTable();
            daTemporary.Fill(dtTemporary);
            //ログイン中の時に会員テーブルのポイントの更新
            if ((string)Session["MemberID"] != "")
            {
                int SUMPoint = 0;
                for (int i = 0; i < selectedticketList.Count; i++)
                {
                    if (selectedticketList[i].ticketName == ((int)Session["PointUse"]).ToString() + "ポイントで一回無料")
                        SUMPoint -= (int)Session["PointUse"];
                    else
                        SUMPoint += (int)Session["PointGet"];
                }
                OleDbDataAdapter daMember = new OleDbDataAdapter("UPDATE TBL_MEMBER SET MEMBER_POINT = MEMBER_POINT +" + SUMPoint + "  WHERE MEMBER_ID='" + (string)Session["MemberID"] + "'", cn);
                DataTable dtMember = new DataTable();
                daMember.Fill(dtMember);
            }
            //一番大きい予約番号を取得
            //dtNumbering.Rows[0][0]予約番号、[0][1]購入番号、[0][2]予約詳細番号、[0][3]売上番号
            OleDbDataAdapter daNumbering = new OleDbDataAdapter("SELECT NUMBERING_BOOKING,NUMBERING_BOOKINGBUY,NUMBERING_BOOKINGDETAIL,NUMBERING_SALES FROM TBL_NUMBERING", cn);
            DataTable dtNumbering = new DataTable();
            daNumbering.Fill(dtNumbering);
            int NumberingBooking = int.Parse(dtNumbering.Rows[0][0].ToString()) + 1;//一番大きい予約番号+1を格納
            int NumberingBuy = int.Parse(dtNumbering.Rows[0][1].ToString());
            if (NumberingBuy == 99999)
                NumberingBuy = 1;
            else
                NumberingBuy += 1;
            Session["BookingBuy"] = NumberingBuy.ToString("00000");
            int NumberingDetail = int.Parse(dtNumbering.Rows[0][2].ToString());//予約詳細番号を格納
            int NumberingSales = int.Parse(dtNumbering.Rows[0][3].ToString());//売上番号を格納
            //予約テーブルに予約情報を格納
            string strSQL = "";
            if ((string)Session["MemberID"] != "")
                strSQL = "INSERT INTO TBL_BOOKING (BOOKING_ID,BOOKING_BUYID,BOOKING_MAIL,SCHEDULE_ID,MEMBER_ID,BOOKING_DAY) VALUES ('" + NumberingBooking.ToString("00000000") + "','" + Session["BookingBuy"].ToString() + "','" + Session["BookingMail"].ToString() + "','" + Session["ScheduleID"] + "','" + Session["MemberID"].ToString() + "','" + DateTime.Now.ToString() + "')";
            else
                strSQL = "INSERT INTO TBL_BOOKING (BOOKING_ID,BOOKING_BUYID,BOOKING_MAIL,SCHEDULE_ID,BOOKING_DAY) VALUES ('" + NumberingBooking.ToString("00000000") + "','" + Session["BookingBuy"].ToString() + "','" + Session["BookingMail"].ToString() + "','" + Session["ScheduleID"] + "','" + DateTime.Now.ToString() + "')";
            OleDbDataAdapter daBooking = new OleDbDataAdapter(strSQL, cn);
            DataTable dtBooking = new DataTable();
            daBooking.Fill(dtBooking);
            //予約詳細テーブルと売上テーブルに座席一つ分ずつデータを追加する
            for (int i = 0; i < selectedticketList.Count; i++)
            {
                //予約詳細テーブル
                NumberingDetail++;//予約詳細番号を最大値+1する
                int point = selectedticketList[i].ticketName == ((int)Session["PointUse"]).ToString() + "ポイントで一回無料" ? -6 : 1;
                OleDbDataAdapter daBookingDetail = new OleDbDataAdapter("INSERT INTO TBL_BOOKINGDETAIL (BOOKINGDETAIL_ID,BOOKING_ID,SEAT_ID,EVENT_ID,RATE_ID,BOOKINGDETAIL_POINT) VALUES ('" + NumberingDetail.ToString("00000000") + "','" + NumberingBooking.ToString("00000000") + "','" + selectedticketList[i].seatNumber + "','" + selectedticketList[i].eventNumber + "','" + selectedticketList[i].defaultnumber + "','" + point + "')", cn);
                DataTable dtBookingDetail = new DataTable();
                daBookingDetail.Fill(dtBookingDetail);
                //売上テーブル
                NumberingSales++;//売上番号を最大値+1する
                OleDbDataAdapter daSales = new OleDbDataAdapter("INSERT INTO TBL_SALES (SALES_ID,RATE_ID,EVENT_ID,SCHEDULE_ID) VALUES ('" + NumberingSales.ToString("00000000") + "','" + selectedticketList[i].defaultnumber + "','" + selectedticketList[i].eventNumber + "','" + Session["ScheduleID"] + "')", cn);
                DataTable dtSales = new DataTable();
                daSales.Fill(dtSales);
            }
            //採番テーブルの予約番号、購入番号、予約詳細番号、売上番号の最大値を更新する
            OleDbDataAdapter daNumberingUp = new OleDbDataAdapter("UPDATE TBL_NUMBERING SET NUMBERING_BOOKING = '" + NumberingBooking.ToString("00000000") + "',NUMBERING_BOOKINGBUY='" + Session["BookingBuy"].ToString() + "',NUMBERING_BOOKINGDETAIL='" + NumberingDetail.ToString("00000000") + "',NUMBERING_SALES='" + NumberingSales.ToString("00000000") + "'", cn);
            DataTable dtNumberingUp = new DataTable();
            daNumberingUp.Fill(dtNumberingUp);
            Response.Redirect("Reservation_Receipt_Confirmation.aspx");
        }
    }
}