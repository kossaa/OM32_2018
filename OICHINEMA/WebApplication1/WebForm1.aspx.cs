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
    public partial class WebForm1 : System.Web.UI.Page
    {
        List<string> seatList = new List<string>();//選択中の席リスト

        //データベース接続
        OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");

        private System.Drawing.Color tableChange(int ritu)
        {
            //色変更
            if (ritu >= 0 && ritu <= 40)
            {
                //緑色
                return System.Drawing.Color.Green;

            }
            else if (ritu >= 41 && ritu <= 80)
            {
                //黄色
                return System.Drawing.Color.Yellow;
            }
            else if (ritu >= 81 && ritu < 100)
            {
                //赤色
                return System.Drawing.Color.Red;
            }
            else
            {
                //黒色
                return System.Drawing.Color.Black;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Table ScreenTable = new Table();
            //DBでデータ取得
            //スケジュールID設定(仮)
            Session["ScheduleID"] = "0000002";
            //座席の予約済みを取得し昇順で表示
            OleDbDataAdapter daSeat = new OleDbDataAdapter
            ("SELECT COUNT(SEAT_ID) FROM TBL_BOOKING,TBL_BOOKINGDETAIL WHERE TBL_BOOKING.BOOKING_ID=TBL_BOOKINGDETAIL.BOOKING_ID AND SCHEDULE_ID='" + (string)Session["ScheduleID"] + "'GROUP BY SEAT_ID " + "ORDER BY SEAT_ID ASC", cn);
            //DataTableを作成し実行
            DataTable dtSeat = new DataTable();
            daSeat.Fill(dtSeat);
            //エリアごとに分ける
            for (int i = 0; i < 2; i++)
            {
                //new(インスタンス化)してテーブルに入れる
                TableCell MTC = new TableCell();
                //指定したフォームのFindControlで指定したIDを見つけてそのプロパティを変更
                i += 1;
                MTC = Master.FindControl("ScreenTable").FindControl("ClassArea1") as TableCell;
                i -= 1;
                MTC.BackColor = tableChange(int.Parse(dtSeat.Rows[i][0].ToString()) / int.Parse(dtSeat.Rows[i][0].ToString()) * 100);
            }
        }
    }
}