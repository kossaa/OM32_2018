using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Schedule
{
    public partial class ScheduleForm : System.Web.UI.Page
    {
        List<string> seatList = new List<string>();//選択中の席リスト

        //データベース接続
        OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
        /*
        private System.Drawing.Color tableChange(string )
        {
            //new(インスタンス化)してテーブルに入れる
            Table tb = new Table();
            //指定したフォームのFindControlで指定したIDを見つけてそのプロパティを変更
            tb = Master.FindControl("MainContent").FindControl("ScreenTable") as Table;
            return System.Drawing.Color.Green;
        }
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            Table ScreenTable = new Table();
            //DBでデータ取得
            //スケジュールID設定(仮)
            Session["ScheduleID"] = "0000002";
            //座席の予約済みを取得し昇順で表示
            OleDbDataAdapter daSeat = new OleDbDataAdapter
            ("SELECT COUNT(SEAT_ID) FROM TBL_BOOKING,TBL_BOOKINGDETAIL WHERE TBL_BOOKING.BOOKING_ID=TBL_BOOKINGDETAIL.BOOKING_ID AND SCHEDULE_ID='" + (string)Session["ScheduleID"] + "'GROUP BY SEAT_ID " + "'ORDER BY SEAT_ID ASC", cn);
            //DataTableを作成し実行
            DataTable dtSeat = new DataTable();
            daSeat.Fill(dtSeat);
            DataTable dtTotal=new DataTable();
            //エリアごとに分ける
            for (int i = 0; i < 9; i++)
            {
                int a = int.Parse(dtSeat.Rows[i][0].ToString())/int.Parse(dtTotal.Rows[i][0].ToString())*100;
                //色変更
                if (a >= 0 && a <= 40)
                {
                    //緑色
                    //tableChange("green");                    
                }
                else if (a >= 41 && a <= 80)
                {
                    //黄色
                }
                else if (a >= 81 && a < 100)
                {
                    //赤色
                }
                else
                {
                    //黒色
                }
                

            }
            
            
        }

    }
}