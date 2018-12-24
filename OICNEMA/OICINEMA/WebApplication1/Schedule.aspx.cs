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
    public partial class WebForm1 : System.Web.UI.Page
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
            //Table ScreenTable = new Table();
            //DBでデータ取得
            //スケジュールID設定(仮)
            Session["ScheduleID"] = "0000004";
            //座席の予約済みを取得し昇順で表示
            OleDbDataAdapter daSeat = new OleDbDataAdapter
            ("SELECT Count(BOOKINGDETAIL_ID), SEAT_AREA FROM TBL_BOOKING,TBL_BOOKINGDETAIL,TBL_SEAT WHERE TBL_BOOKING.BOOKING_ID = TBL_BOOKINGDETAIL.BOOKING_ID AND TBL_BOOKINGDETAIL.SEAT_ID = TBL_SEAT.SEAT_ID GROUP BY SCHEDULE_ID,SEAT_AREA HAVING (SCHEDULE_ID ='0000004') ORDER BY SEAT_AREA", cn);
            //DataTableを作成し実行
            DataTable dtSeat = new DataTable();
            daSeat.Fill(dtSeat);
            //仮登録版
            OleDbDataAdapter daInfo = new OleDbDataAdapter
            ("SELECT TEMPORARY_SEAT FROM TBL_TEMPORARY WHERE TEMPORARY_SCHEDULE='" + (string)Session["ScheduleID"] + "'", cn);
            //DataTableを作成し実行
            DataTable dtInfo = new DataTable();
            daInfo.Fill(dtInfo);
            //本登録版
            //dt.Rows[0][0]スケジュール番号、[0][1]開始時間、[0][2]終了時間、[0][3]スクリーン番号、[0][4]作品名、[0][5]作品画像パス
            OleDbDataAdapter daEntry = new OleDbDataAdapter
            ("SELECT SCHEDULE_ID,SCHEDULE_START,SCHEDULE_END,SCREEN_ID,WORK_NAME,WORK_PASS1 FROM TBL_WORK,TBL_SCHEDULE WHERE TBL_WORK.WORK_ID = TBL_SCHEDULE.WORK_ID AND SCHEDULE_START>=#12/26/2018# AND SCHEDULE_START<#12/27/2018#", cn);
            //DataTableを作成し実行
            DataTable dtEntry = new DataTable();
            daEntry.Fill(dtEntry);
            //TableRowとTableCell            
            TableRow tr;
            TableCell tc;
            Table tb;
            //スケジュール作成
            //3=映画のタイトル数
            for (int i = 0; i < 3; i++)
            {
                //1行目作成
                tr = new TableRow();
                //4＝タイトル(1)＋スクリーン名（Count)3
                for (int j = 0; j < dtEntry.Rows.Count; j++)
                {
                    tc = new TableCell();
                    tc.BorderStyle = BorderStyle.Solid;
                    tc.BorderColor = System.Drawing.Color.Red;
                    if (j == 0)
                    {
                        tc.Text = dtEntry.Rows[j][4].ToString();
                        tr.Cells.Add(tc);
                    }
                    else
                    {
                        tc.Text = dtEntry.Rows[j][3].ToString();
                        tr.Cells.Add(tc);
                    }
                    Table1.Rows.Add(tr);
                }
                //2行目作成
                tr = new TableRow();
                //4＝画像(1)+スクリーンのエリア番号(9分割)３
                for (int j = 0; j < 4; j++)
                {
                    //変数aはエリアIDのカウント
                    int a = 0;
                    tc = new TableCell();
                    //中にセルを作成
                    if (j == 0)
                    {
                        tc.BorderColor = System.Drawing.Color.Red;
                        tc.Text = "画像";
                        tc.RowSpan = 2;
                        tr.Cells.Add(tc);
                    }
                    else
                    {
                        //セルの中にテーブル２作成
                        tb = new Table();
                        OleDbDataAdapter daArea = new OleDbDataAdapter
                        ("SELECT Count(SEAT_ID) FROM TBL_SEAT GROUP BY SEAT_AREA", cn);
                        //DataTableを作成し実行
                        DataTable dtArea = new DataTable();
                        daArea.Fill(dtArea);

                        //テーブル２の中にセル作成
                        for (int k = 0; k < 3; k++)
                        {
                            //テーブル２の行作成
                            TableRow tr2 = new TableRow();
                            for (int l = 0; l < 3; l++)
                            {
                                //２のセル作成                               
                                TableCell tc2 = new TableCell();
                                tc2.BackColor = tableChange((double)int.Parse(dtSeat.Rows[a][0].ToString()) / int.Parse(dtArea.Rows[a][0].ToString()) * 100);
                                a++;
                                tc2.Text = "エリア" + a.ToString();
                                tr2.Controls.Add(tc2);                            
                            }
                            //テーブル追加前にテーブル２経由
                            tb.Controls.Add(tr2);
                        }
                        tc.Controls.Add(tb);
                        tr.Controls.Add(tc);
                    }
                    //テーブルに追加
                    Table1.Rows.Add(tr);
                }
                //3行目作成
                tr = new TableRow();
                //for 中身
                for (int j = 0; j < 3; j++)
                {
                    tc = new TableCell();
                    tc.Text = "開始時間～終了時間";
                    tr.Cells.Add(tc);
                    Table1.Rows.Add(tr);
                }
            }
        }
        
    }
}