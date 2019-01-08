using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Schedule : System.Web.UI.Page
    {
        List<string> seatList = new List<string>();//選択中の席リスト

        //データベース接続
        OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");

        private System.Drawing.Color tableChange(double ritu)
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
        //ロードイベント
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime ScheduleDay = DateTime.Today;
            DayBtn1.Text = ScheduleDay.AddDays(0).ToString("M月d日");
            DayBtn2.Text = ScheduleDay.AddDays(1).ToString("M月d日");
            DayBtn3.Text = ScheduleDay.AddDays(2).ToString("M月d日");
            DayBtn4.Text = ScheduleDay.AddDays(3).ToString("M月d日");

            DateTime SearchDay = DateTime.Today;//表示するスケジュールの日付
            SearchDay = new DateTime(2018, 12, 26, 0, 0, 0);
            //作品名、開始時間の昇順
            //dt.Rows[0][0]スケジュール番号、[0][1]開始時間、[0][2]終了時間、[0][3]スクリーン番号、[0][4]作品名、[0][5]作品画像パス
            OleDbDataAdapter daSchedule = new OleDbDataAdapter("SELECT SCHEDULE_ID,SCHEDULE_START,SCHEDULE_END,SCREEN_ID,WORK_NAME,WORK_PASS1 FROM TBL_WORK,TBL_SCHEDULE WHERE TBL_WORK.WORK_ID = TBL_SCHEDULE.WORK_ID AND SCHEDULE_START>=#" + SearchDay + "# AND SCHEDULE_START<#" + SearchDay.AddDays(1) + "# ORDER BY WORK_NAME ASC, SCHEDULE_START ASC", cn);
            DataTable dtSchedule = new DataTable();
            daSchedule.Fill(dtSchedule);
            for (int h = 0; h < dtSchedule.Rows.Count; )
            {
                TableRow Table1Rows = new TableRow();
                TableCell Table1Cell = new TableCell();

                Table TableWork = new Table();
                TableRow TableWorkRow = new TableRow();
                TableCell TableWorkCell = new TableCell();
                TableWorkCell.Text = dtSchedule.Rows[h][4].ToString();//作品名
                TableWorkRow.Controls.Add(TableWorkCell);
                TableWork.Controls.Add(TableWorkRow);
                TableWorkRow = new TableRow();
                TableWorkCell = new TableCell();
                Image img = new Image();
                img.ImageUrl = Server.HtmlEncode(@dtSchedule.Rows[h][5].ToString());//作品画像パス
                img.Width = 230;
                img.Height = 230;
                TableWorkCell.Controls.Add(img);
                TableWorkRow.Controls.Add(TableWorkCell);
                TableWork.Controls.Add(TableWorkRow);

                Table1Cell.Controls.Add(TableWork);
                Table1Rows.Controls.Add(Table1Cell);


                for (int i = 0; i < 6; i++)
                {
                    //予約数(この方法ではデータ数が0件の時その行はnullになる。可能であればSQLで解決したい)
                    string sqlBooking = "SELECT COUNT(BOOKINGDETAIL_ID) FROM TBL_BOOKING,TBL_BOOKINGDETAIL,TBL_SEAT " +
                        "WHERE TBL_BOOKING.BOOKING_ID=TBL_BOOKINGDETAIL.BOOKING_ID AND TBL_BOOKINGDETAIL.SEAT_ID=TBL_SEAT.SEAT_ID GROUP BY SCHEDULE_ID,SEAT_AREA,SCREEN_ID " +
                        "HAVING SCHEDULE_ID='" + dtSchedule.Rows[0][0].ToString() + "' AND SCREEN_ID='" + dtSchedule.Rows[0][3].ToString() + "' ORDER BY SEAT_AREA";
                    sqlBooking = "SELECT COUNT(BOOKINGDETAIL_ID) FROM TBL_BOOKING,TBL_BOOKINGDETAIL,TBL_SEAT WHERE TBL_BOOKING.BOOKING_ID=TBL_BOOKINGDETAIL.BOOKING_ID AND TBL_BOOKINGDETAIL.SEAT_ID=TBL_SEAT.SEAT_ID GROUP BY SCHEDULE_ID,SEAT_AREA,SCREEN_ID HAVING SCHEDULE_ID='0000004' AND SCREEN_ID='01' ORDER BY SEAT_AREA";
                    OleDbDataAdapter daBooking = new OleDbDataAdapter(sqlBooking, cn);
                    DataTable dtBooking = new DataTable();
                    daBooking.Fill(dtBooking);
                    //エリアごとの座席数
                    OleDbDataAdapter daSeat = new OleDbDataAdapter("SELECT SCREEN_AREA1,SCREEN_AREA2,SCREEN_AREA3,SCREEN_AREA4,SCREEN_AREA5,SCREEN_AREA6,SCREEN_AREA7,SCREEN_AREA8,SCREEN_AREA9 " +
                        "FROM TBL_SCREEN WHERE SCREEN_ID='" + dtSchedule.Rows[0][3].ToString() + "'", cn);
                    DataTable dtSeat = new DataTable();
                    daSeat.Fill(dtSeat);
                    Table1Cell = new TableCell();
                    TableWork = new Table();
                    TableWorkRow = new TableRow();
                    TableWorkCell = new TableCell();
                    TableWorkCell.Text = "スクリーン" + dtSchedule.Rows[h][3].ToString();//スクリーン番号
                    TableWorkCell.ColumnSpan = 3;
                    TableWorkRow.Controls.Add(TableWorkCell);
                    TableWork.Controls.Add(TableWorkRow);

                    for (int j = 0, k = 0; j < 3; j++)
                    {
                        TableWorkRow = new TableRow();
                        for (int l = 0; l < 3; l++, k++)
                        {
                            TableWorkCell = new TableCell();
                            //予約率=(予約数/全座席数*100)%
                            TableWorkCell.BackColor = tableChange((double)int.Parse(dtBooking.Rows[k][0].ToString()) / (double)int.Parse(dtSeat.Rows[0][k].ToString()) * 100);
                            TableWorkCell.Width = 50;
                            TableWorkCell.Height = 50;
                            TableWorkRow.Controls.Add(TableWorkCell);
                        }
                        TableWork.Controls.Add(TableWorkRow);
                    }
                    TableWorkRow = new TableRow();
                    TableWorkCell = new TableCell();
                    TableWorkCell.Text = DateTime.Parse(dtSchedule.Rows[h][1].ToString()).ToString("M/d h:mm") + "～" + DateTime.Parse(dtSchedule.Rows[h][2].ToString()).ToString("M/d h:m");
                    TableWorkCell.ColumnSpan = 3;
                    TableWorkRow.Controls.Add(TableWorkCell);
                    TableWork.Controls.Add(TableWorkRow);
                    Table1Cell.Controls.Add(TableWork);
                    Table1Rows.Controls.Add(Table1Cell);
                    h++;
                    //もし最後のスケジュールまで表示されたらそれ以上処理されないようにする
                    if (h == dtSchedule.Rows.Count)
                        break;
                    if (dtSchedule.Rows[h][4].ToString() != dtSchedule.Rows[h - 1][4].ToString())
                        break;
                }
                Table1.Controls.Add(Table1Rows);
            }
            ////Table ScreenTable = new Table();
            ////DBでデータ取得
            ////スケジュールID設定(仮)
            //Session["ScheduleID"] = "0000004";
            ////座席の予約済みを取得し昇順で表示
            //OleDbDataAdapter daSeat = new OleDbDataAdapter
            //("SELECT Count(BOOKINGDETAIL_ID), SEAT_AREA FROM TBL_BOOKING,TBL_BOOKINGDETAIL,TBL_SEAT WHERE TBL_BOOKING.BOOKING_ID = TBL_BOOKINGDETAIL.BOOKING_ID AND TBL_BOOKINGDETAIL.SEAT_ID = TBL_SEAT.SEAT_ID GROUP BY SCHEDULE_ID,SEAT_AREA HAVING (SCHEDULE_ID ='0000004') ORDER BY SEAT_AREA", cn);
            ////DataTableを作成し実行
            //DataTable dtSeat = new DataTable();
            //daSeat.Fill(dtSeat);
            ////仮登録版
            //OleDbDataAdapter daInfo = new OleDbDataAdapter
            //("SELECT TEMPORARY_SEAT FROM TBL_TEMPORARY WHERE TEMPORARY_SCHEDULE='" + (string)Session["ScheduleID"] + "'", cn);
            ////DataTableを作成し実行
            //DataTable dtInfo = new DataTable();
            //daInfo.Fill(dtInfo);
            ////本登録版
            ////dt.Rows[0][0]スケジュール番号、[0][1]開始時間、[0][2]終了時間、[0][3]スクリーン番号、[0][4]作品名、[0][5]作品画像パス
            //OleDbDataAdapter daEntry = new OleDbDataAdapter
            //("SELECT SCHEDULE_ID,SCHEDULE_START,SCHEDULE_END,SCREEN_ID,WORK_NAME,WORK_PASS1 FROM TBL_WORK,TBL_SCHEDULE WHERE TBL_WORK.WORK_ID = TBL_SCHEDULE.WORK_ID AND SCHEDULE_START>=#12/26/2018# AND SCHEDULE_START<#12/27/2018#", cn);
            ////DataTableを作成し実行
            //DataTable dtEntry = new DataTable();
            //daEntry.Fill(dtEntry);

            ////TableRowとTableCell            
            //TableRow tr;
            //TableCell tc;
            //Table tb;
            ////スケジュール作成
            ////3=映画のタイトル数
            //for (int i = 0; i < 3; i++)
            //{
            //    //1行目作成
            //    tr = new TableRow();
            //    //4＝タイトル(1)＋スクリーン名（Count)3
            //    for (int j = 0; j < dtEntry.Rows.Count; j++)
            //    {
            //        tc = new TableCell();
            //        tc.BorderStyle = BorderStyle.Solid;
            //        tc.BorderColor = System.Drawing.Color.Red;
            //        if (j == 0)
            //        {
            //            tc.Text = dtEntry.Rows[j][4].ToString();
            //            tr.Cells.Add(tc);
            //        }
            //        else
            //        {
            //            tc.Text = dtEntry.Rows[j][3].ToString();
            //            tr.Cells.Add(tc);
            //        }
            //        Table1.Rows.Add(tr);
            //    }
            //    //2行目作成
            //    tr = new TableRow();
            //    //4＝画像(1)+スクリーンのエリア番号(9分割)３
            //    for (int j = 0; j < 4; j++)
            //    {
            //        //変数aはエリアIDのカウント
            //        int a = 0;
            //        tc = new TableCell();
            //        //中にセルを作成
            //        if (j == 0)
            //        {
            //            tc.BorderColor = System.Drawing.Color.Red;
            //            tc.Text = "画像";
            //            tc.RowSpan = 2;
            //            tr.Cells.Add(tc);
            //        }
            //        else
            //        {
            //            //セルの中にテーブル２作成
            //            tb = new Table();
            //            OleDbDataAdapter daArea = new OleDbDataAdapter
            //            ("SELECT Count(SEAT_ID) FROM TBL_SEAT GROUP BY SEAT_AREA", cn);
            //            //DataTableを作成し実行
            //            DataTable dtArea = new DataTable();
            //            daArea.Fill(dtArea);

            //            //テーブル２の中にセル作成
            //            for (int k = 0; k < 3; k++)
            //            {
            //                //テーブル２の行作成
            //                TableRow tr2 = new TableRow();
            //                for (int l = 0; l < 3; l++)
            //                {
            //                    //２のセル作成                               
            //                    TableCell tc2 = new TableCell();
            //                    //予約率=(予約数/全座席数*100)%
            //                    tc2.BackColor = tableChange((double)int.Parse(dtSeat.Rows[a][0].ToString()) / int.Parse(dtArea.Rows[a][0].ToString()) * 100);
            //                    a++;
            //                    tc2.Text = "エリア" + a.ToString();
            //                    tr2.Controls.Add(tc2);                            
            //                }
            //                //テーブル追加前にテーブル２経由
            //                tb.Controls.Add(tr2);
            //            }
            //            tc.Controls.Add(tb);
            //            tr.Controls.Add(tc);
            //        }
            //        //テーブルに追加
            //        Table1.Rows.Add(tr);
            //    }
            //    //3行目作成
            //    tr = new TableRow();
            //    //for 中身
            //    for (int j = 0; j < 3; j++)
            //    {
            //        tc = new TableCell();
            //        tc.Text = "開始時間～終了時間";
            //        tr.Cells.Add(tc);
            //        Table1.Rows.Add(tr);
            //    }
            //}
        }
    }
}