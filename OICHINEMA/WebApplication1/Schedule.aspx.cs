using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Schedule : System.Web.UI.Page
    {
        const int SeatMax = 5;
        string[] seatAll = new string[SeatMax];
        string seatChoice = "";
        //データベース接続
        OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
        //クリックしているイメージボタンを取得する関数
        protected void ImageBtn_Click(object sender, ImageClickEventArgs e)
        {
            //クリックされたボタンを取得
            seatFull((ImageButton)sender);
        }
        //シートクリック時の処理する関数
        public void seatFull(ImageButton SelectedButton)
        {
            //Nullじゃないとき＝2席目から
            if (Session["seatInfomation"] != null)
            {
                seatAll = (string[])Session["seatInfomation"];
            }
            //クリックされたら色を変える
            if ((SelectedButton).CssClass == "FreeSeat")
            {
                //一つずつ格納
                for (int i = 0; i < SeatMax; i++)
                {
                    if (seatAll[i] == null)
                    {
                        seatAll[i] = (SelectedButton).ID;
                        //CSSでグレーを挿入
                        (SelectedButton).CssClass = "ChoiceSeat";
                        //今までの選択中のカウント                        
                        break;
                    }
                    else
                    {
                        //席が６席以上選択されたら                        
                        //javascriptでonloadを表示させる
                        ClientScriptManager cs = Page.ClientScript;
                        Type csType = this.GetType();
                        cs.RegisterStartupScript(csType, "onload", "<script type=\"text/javascript\">alert('5席まで同時選択可能です。');</script>");
                    }
                }
            }
            else
            {
                //選択中を解除
                //CSSで色を元に戻す
                (SelectedButton).CssClass = "FreeSeat";

                for (int i = 0; i < SeatMax; i++)
                {
                    if (seatAll[i] == (SelectedButton).ID)
                    {
                        seatAll[i] = null;
                    }
                }
            }
            Session["seatInfomation"] = seatAll;
            //ソートする
            StringComparer cmp = StringComparer.OrdinalIgnoreCase;
            Array.Sort(seatAll, cmp);

            //今までの選択された席をStringの中に入れる
            for (int i = 0; i < SeatMax; i++)
            {
                if (seatAll[i] != null)
                {
                    if (i != 0 && seatChoice != "")
                    {
                        seatChoice = seatChoice + "、";
                    }
                    seatChoice = seatChoice + seatAll[i];
                }
            }
            seatChoice = seatChoice + "が選択中です";

            //ラベルに表示
            Label1.Text = seatChoice;
        }
        //ロード時
        protected void Page_Load(object sender, EventArgs e)
        {
            //処理を楽にする
            if (IsPostBack)
            {
                return;
            }
            //仮スケジュールID設定            
            //座席の予約済みを取得し昇順で表示
            Session["scheduleId"] = "0000002";
            OleDbDataAdapter daSeatId = new OleDbDataAdapter
            ("SELECT SEAT_ID FROM TBL_BOOKING,TBL_BOOKINGDETAIL WHERE TBL_BOOKING.BOOKING_ID=TBL_BOOKINGDETAIL.BOOKING_ID AND SCHEDULE_ID='" + (string)Session["scheduleId"] + "'ORDER BY SEAT_ID ASC", cn);
            //DataTableを作成し実行
            DataTable dtseat = new DataTable();
            daSeatId.Fill(dtseat);
            //ロードに予約されていたら色を変えてクリックできなくする
            for (int i = 0; i < dtseat.Rows.Count; i++)
            {
                //イメージボタンを作成し、CSSを変更し入れ替え
                ImageButton ibtn = new ImageButton();
                //指定したフォームのFindControlで指定したIDを見つけてそのプロパティを変更
                ibtn = Master.FindControl("MainContent").FindControl(dtseat.Rows[i][0].ToString()) as ImageButton;
                ibtn.CssClass = "SoldSeat";
                ibtn.Enabled = false;
            }
        }
        //次へクリック
        protected void BtnNext_Click(object sender, EventArgs e)
        {
            seatAll = (string[])Session["seatInfomation"];
            //選択された席分をデータベースに仮登録
            for (int i = 0; i < seatAll.Length; i++)
            {
                //Nullならばもう一度回す(continue;)
                if (seatAll[i] == null)
                {
                    continue;
                }
                //テーブル指定
                OleDbDataAdapter daBookingId = new OleDbDataAdapter("INSERT INTO TBL_TEMPORARY(TEMPORARY_SCHEDULE,TEMPORARY_SEAT,TEMPORARY_TIME)VALUES('" + (string)Session["scheduleId"] + "','" + seatAll[i] + "',#" + DateTime.Now + "# )", cn);
                //DataTableを作成し実行
                DataTable dtBooking = new DataTable();
                daBookingId.Fill(dtBooking);
                //dtBooking.Reset();
                //dtBooking.Clear();
                //もし同時に座席が選ばれたら仮登録を見てあれば座席をロック、キャンセルされたらデリート文、
                OleDbDataAdapter daSeatId = new OleDbDataAdapter
                ("SELECT COUNT(*) WHERE TEMPORARY_SCHEDULE='" + (string)Session["scheduleId"] + "' AND TEMPORARY_SEAT='" + seatAll[i] + "'", cn);    
                
                //-----------
                //次ここから
                //-------------
                //0ならばロックとかする

                //DataTableを作成し実行
                DataTable dtseat = new DataTable();
                daSeatId.Fill(dtseat);
            }
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            //スケジュール画面に戻る

        }
    }
}