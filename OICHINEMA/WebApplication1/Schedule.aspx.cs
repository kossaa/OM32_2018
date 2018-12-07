﻿using System;
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
            LabelChoice.Text = seatChoice;
        }
        //ロード時
        protected void Page_Load(object sender, EventArgs e)
        {
            //ページロードを2回目から処理しない
            /*if (IsPostBack)
            {
                return ;
            }
            */
            //仮スケジュールID設定                        
            Session["scheduleId"] = "0000002";

            //座席の予約済みを取得し昇順で表示
            OleDbDataAdapter daSeat = new OleDbDataAdapter
            ("SELECT SEAT_ID FROM TBL_BOOKING,TBL_BOOKINGDETAIL WHERE TBL_BOOKING.BOOKING_ID=TBL_BOOKINGDETAIL.BOOKING_ID AND SCHEDULE_ID='" + (string)Session["scheduleId"] + "'ORDER BY SEAT_ID ASC", cn);
            //DataTableを作成し実行
            DataTable dtSeat = new DataTable();
            daSeat.Fill(dtSeat);
            //ロードに予約されていたら色を変えてクリックできなくする
            for (int i = 0; i < dtSeat.Rows.Count; i++)
            {
                //イメージボタンを作成し、CSSを変更し入れ替え
                ImageButton ibtn = new ImageButton();
                //指定したフォームのFindControlで指定したIDを見つけてそのプロパティを変更
                ibtn = Master.FindControl("MainContent").FindControl(dtSeat.Rows[i][0].ToString()) as ImageButton;
                ibtn.CssClass = "SoldSeat";
                ibtn.Enabled = false;
            }

            
        }
        //次へクリック
        protected void BtnNext_Click(object sender, EventArgs e)
        {
            

            seatAll = (string[])Session["seatInfomation"];

            //配列をListに変換
            List<string> stringList = new List<string>();
            stringList.AddRange(seatAll);
            // 空要素(null)を一括削除
            stringList.RemoveAll(item => item == null);

            //選択された席分をデータベースに仮登録
            for (int i = 0; i < seatAll.Length; i++)
            {
                //Nullならばもう一度回す(continue;)
                if (seatAll[i] == null)
                {
                    continue;
                }
                //仮登録するデータを仮登録テーブルに追加する
                OleDbDataAdapter daBookingInsert = new OleDbDataAdapter
                ("INSERT INTO TBL_TEMPORARY(TEMPORARY_SCHEDULE,TEMPORARY_SEAT,TEMPORARY_TIME)VALUES('" + (string)Session["scheduleId"] + "','" + seatAll[i] + "',#" + DateTime.Now + "# )", cn);
                //DataTableを作成し実行
                DataTable dtBookingIn = new DataTable();
                daBookingInsert.Fill(dtBookingIn);

                //--------ここから追加コード-------
                
                //座席の予約済みを取得し昇順で表示
                OleDbDataAdapter daSeat = new OleDbDataAdapter
                ("SELECT SEAT_ID FROM TBL_BOOKING,TBL_BOOKINGDETAIL WHERE TBL_BOOKING.BOOKING_ID=TBL_BOOKINGDETAIL.BOOKING_ID AND SCHEDULE_ID='" + (string)Session["scheduleId"] + ssd("SEAT_ID") + "'ORDER BY SEAT_ID ASC", cn);
                //DataTableを作成し実行
                DataTable dtSeat = new DataTable();
                daSeat.Fill(dtSeat);

                //仮登録されたデータ
                OleDbDataAdapter daInfo = new OleDbDataAdapter
                ("SELECT TEMPORARY_SEAT FROM TBL_TEMPORARY WHERE SCHEDULE_ID='" + (string)Session["scheduleId"] +"'"+ ssd("TEMPORARY_SEAT"), cn);
                //DataTableを作成し実行
                DataTable dtInfo = new DataTable();
                daInfo.Fill(dtInfo);

                if (dtSeat.Rows.Count != 0)
                {
                    //javascriptでonloadを表示させる
                    ClientScriptManager cs = Page.ClientScript;
                    Type csType = this.GetType();
                    cs.RegisterStartupScript(csType, "onload", "<script type=\"text/javascript\">alert('5席まで同時選択可能です。');</script>");
                }
                //もし同時に座席が選ばれたら==仮登録を見てあれば座席をロック
                if(dtInfo.Rows.Count!=0)
                {
                    //javascriptでonloadを表示させる
                    ClientScriptManager cs = Page.ClientScript;
                    Type csType = this.GetType();
                    cs.RegisterStartupScript(csType, "onload", "<script type=\"text/javascript\">alert('5席まで同時選択可能です。');</script>");
                }

                //次の画面に行く
            }
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            //スケジュール画面に戻る
            
        }

        private string ssd(string bbb)
        {
            string aaa = "";
                for (int j = 0; seatAll[j] == null; j++)
                {
                    if (j == 0)
                    {
                        aaa = aaa + " AND ";
                    }
                    else
                    {
                        aaa = aaa + " OR  ";
                    }
                    aaa = aaa + bbb + "='" + seatAll[j] + "'";
                }
                return aaa;
        }
    }
}