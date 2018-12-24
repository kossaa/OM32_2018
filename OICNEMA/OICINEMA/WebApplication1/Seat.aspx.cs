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
        const int SeatMax = 5;  //席の最大選択数
        string seatChoice = ""; //ラベル表示
        List<string> seatList = new List<string>();//選択中の席リスト

        //データベース接続
        OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");

        //SQL(同時に席が選ばれた時の判別)でSEAT_IDかTEMPORARY_SEATでの使用を簡略化した関数
        private string Judgment(string character)
        {
            string conditions = "";
            for (int j = 0; j < seatList.Count; j++)
            {
                if (j != 0)
                {
                    conditions = conditions + " OR  ";
                }
                else
                {
                    conditions = conditions + " AND ";
                }
                conditions = conditions + character + "='" + seatList[j] + "'";
            }
            return conditions;
        }

        private void changeImgBtn(string dtChara)
        {
            //イメージボタンを作成し、CSSを変更し入れ替え
            ImageButton ibtn = new ImageButton();
            //指定したフォームのFindControlで指定したIDを見つけてそのプロパティを変更
            ibtn = Master.FindControl("MainContent").FindControl(dtChara) as ImageButton;
            ibtn.CssClass = "SoldSeat";
            ibtn.Enabled = false;
        }

        //クリックしているイメージボタンを取得する関数
        protected void ImageBtn_Click(object sender, ImageClickEventArgs e)
        {
            //クリックされたボタンを取得
            ImageButton SelectedButton = (ImageButton)sender;
            //Nullじゃないとき＝2席目から
            if (Session["SeatInfomation"] != null)
            {
                seatList = (List<string>)Session["SeatInfomation"];
            }
            //クリックされたら色を変える
            if ((SelectedButton).CssClass == "FreeSeat")
            {
                //席が６席以上選択されたら  
                if (seatList.Count == SeatMax)
                {
                    //javascriptでonloadを表示させる
                    ClientScriptManager cs = Page.ClientScript;
                    Type csType = this.GetType();
                    cs.RegisterStartupScript(csType, "onload", "<script type=\"text/javascript\">alert('5席まで同時選択可能です。');</script>");
                    return;
                }
                else
                {
                    //今までの座席の選択中をカウントする配列に入れる
                    seatList.Add((SelectedButton).ID);
                    //CSSでグレーを挿入
                    (SelectedButton).CssClass = "ChoiceSeat";
                    //席が選択されてため次へボタンを出現させる
                    BtnNext.Enabled = true;
                }
            }
            else
            {
                //選択中を解除
                seatList.Remove((SelectedButton).ID);
                //CSSで色を元に戻す
                (SelectedButton).CssClass = "FreeSeat";
                //席が０席なら次へボタンを隠す
                if (seatList.Count == 0)
                {
                    BtnNext.Enabled = false;
                }
                else
                {
                    BtnNext.Enabled = true;
                }
            }
            //クリックされているSession["SeatInfomation"]
            Session["SeatInfomation"] = seatList;
            //昇順でソートする
            seatList.Sort();
            //今までの選択された席をStringの中に入れる
            for (int i = 0; i < seatList.Count; i++)
            {
                if (i != 0 && seatChoice != "")
                {
                    seatChoice = seatChoice + "、";
                }
                seatChoice = seatChoice + seatList[i];
            }
            seatChoice = seatChoice + "が選択中です";
            //ラベルに表示
            LabelChoice.Text = seatChoice;
        }
        //ロード時
        protected void Page_Load(object sender, EventArgs e)
        {
            //マスターからセションクリアする関数を実行する
            //前のスケジュール画面以外から飛んできた場合
            /*
            if((string)Session["PageID"] != "Schedule" && !IsPostBack)
            {
                //トップへ飛ぶ
                Response.Redirect("Top.aspx");
                return;
            }
            */           

            if (!IsPostBack)
            {
                Session.Remove("SeatInfomation");
            }
            //スケジュールID設定(仮)
            Session["ScheduleID"] = "0000002";
            //座席の予約済みを取得し昇順で表示
            OleDbDataAdapter daSeat = new OleDbDataAdapter
            ("SELECT SEAT_ID FROM TBL_BOOKING,TBL_BOOKINGDETAIL WHERE TBL_BOOKING.BOOKING_ID=TBL_BOOKINGDETAIL.BOOKING_ID AND SCHEDULE_ID='" + (string)Session["ScheduleID"] + "'ORDER BY SEAT_ID ASC", cn);
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
            //仮登録版
            string sqlString = "SELECT TEMPORARY_SEAT FROM TBL_TEMPORARY WHERE TEMPORARY_SCHEDULE='" + (string)Session["ScheduleID"] + "'" + Judgment("TEMPORARY_SEAT");
            OleDbDataAdapter daInfo = new OleDbDataAdapter
            (sqlString, cn);
            //DataTableを作成し実行
            DataTable dtInfo = new DataTable();
            daInfo.Fill(dtInfo);
            for (int i = 0; i < dtInfo.Rows.Count; i++)
            {
                changeImgBtn(dtInfo.Rows[i][0].ToString());
            }
            //ロード時に次へボタンを隠す
            BtnNext.Enabled = false;
        }

        //次へクリック
        protected void BtnNext_Click(object sender, EventArgs e)
        {
            //クリックされているseatListにSession["SeatInfomation"]を入れる
            seatList = (List<string>)Session["SeatInfomation"];
            //空要素(null)を一括削除
            seatList.RemoveAll(item => item == null);
            //座席の予約済みを取得し昇順で表示
            string sqlSeat = "SELECT SEAT_ID FROM TBL_BOOKING,TBL_BOOKINGDETAIL WHERE TBL_BOOKING.BOOKING_ID=TBL_BOOKINGDETAIL.BOOKING_ID AND SCHEDULE_ID='" + (string)Session["ScheduleID"] + "'" + Judgment("SEAT_ID") + "ORDER BY SEAT_ID ASC";
            OleDbDataAdapter daSeat = new OleDbDataAdapter(sqlSeat, cn);
            //DataTableを作成し実行
            DataTable dtSeat = new DataTable();
            daSeat.Fill(dtSeat);
            //仮登録されたデータ
            string sqlString = "SELECT TEMPORARY_SEAT FROM TBL_TEMPORARY WHERE TEMPORARY_SCHEDULE='" + (string)Session["ScheduleID"] + "'" + Judgment("TEMPORARY_SEAT");
            OleDbDataAdapter daInfo = new OleDbDataAdapter(sqlString, cn);
            //DataTableを作成し実行
            DataTable dtInfo = new DataTable();
            daInfo.Fill(dtInfo);
            //0ではない場合、エラーメッセージを出す
            if (dtSeat.Rows.Count != 0)
            {
                for (int i = 0; i < dtSeat.Rows.Count; i++)
                {
                    changeImgBtn(dtSeat.Rows[i][0].ToString());
                    //javascriptでonloadを表示させる
                    ClientScriptManager cs = Page.ClientScript;
                    Type csType = this.GetType();
                    cs.RegisterStartupScript(csType, "onload", "<script type=\"text/javascript\">alert('その席は他の人が予約済みです');</script>");
                }
                return;
            }

            //選択された席分をデータベースに仮登録
            for (int i = 0; i < seatList.Count; i++)
            {
                //仮登録するデータを仮登録テーブルに追加する
                OleDbDataAdapter daBookingInfo = new OleDbDataAdapter
                ("INSERT INTO TBL_TEMPORARY(TEMPORARY_SCHEDULE,TEMPORARY_SEAT,TEMPORARY_TIME)VALUES('" + (string)Session["ScheduleID"] + "','" + seatList[i] + "',#" + DateTime.Now + "# )", cn);
                //DataTableを作成し実行
                DataTable dtBookingIn = new DataTable();
                daBookingInfo.Fill(dtBookingIn);
            }
            //Session2個必要。座席画面用と予約画面用を作成
            Session["ThisSeat"] = "0000002";
            Session.Remove("ThisSeat");

            //次の（チケット選択）画面に行く
            //Response.Redirect("Reservation_Ticket_Selection");
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            //スケジュール画面に戻る
            Response.Redirect("Schedule.aspx");
        }
       


    }
}