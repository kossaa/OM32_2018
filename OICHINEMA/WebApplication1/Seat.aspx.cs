using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Collections;

namespace WebApplication1
{
    public partial class test : System.Web.UI.Page
    {
        //private ImageButton[] tmpBtn;
        private Image[] image;   
        const int SeatMax = 5;
        string[] seatAll = new string[SeatMax];
        string seatChoice = ""; 
        char[] seatHead={'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};

        private void seatCreate()
        {
            //データベース接続
            OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
            OleDbDataAdapter daScreenId;
            //スクリーン番号取得、セションを使用
            daScreenId = new OleDbDataAdapter(" SELECT SEAT_ID FROM TBL_SEAT WHERE SCREEN_ID = '" + (string)Session["screenId"] + "'", cn);

            DataTable dtscreen = new DataTable();
            daScreenId.Fill(dtscreen);
            //座席が予約済みを取得、セションを使用
            OleDbDataAdapter daSeatId = new OleDbDataAdapter(" SELECT SEAT_ID FROM TBL_BOOKING WHERE SCREEN_ID = '" + (string)Session["scheduleId"] + "'", cn);

            DataTable dtseat = new DataTable();
            daScreenId.Fill(dtseat);

            //Labelに取得したデータを格納　rows[行][列]で指定
            //Label2.Text = dtseat.Rows[0][0].ToString();
            //Label3.Text = dtseat.Rows[1][0].ToString();

            //tableのRowとCellを宣言
            TableRow tableRow;
            TableCell tableCell;
            //Seat生成
            //this.imgBtn = new ImageButton[141];
            this.image = new Image[40];
            int imageSeatBtn = 0;
            int imageRoad = 0;

            Hashtable imgBtnTable = new Hashtable();

            //データベースから席数をとる
            int sheetcount = 141;
            //int row = 14;
            //int col = 10;
            //列を生成
            for (int i = 0; i < sheetcount / 14; i++)
            {
                //Rowの（行）作成
                tableRow = new TableRow();

                imageSeatBtn = 0;

                //セルを生成
                for (int j = 0; j < sheetcount / 10; j++)
                {
                    //左から４列目のときに画像追加
                    if (j == 3 || j == 10)
                    {
                        //プロパティ設定
                        tableCell = new TableCell();
                        tableCell.Height = 20;
                        this.image[imageRoad] = new Image();
                        this.image[imageRoad].ID = "ImageRoad" + imageRoad.ToString();
                        this.image[imageRoad].ImageUrl = "~/img/tuuro.png";
                        this.image[imageRoad].Height = 30;
                        this.image[imageRoad].Width = 30;
                        //通路の画像を追加
                        this.image[imageRoad].CssClass = "FreeSeat";
                        //プロパティを設定したImageをテーブルのセルに追加
                        tableCell.Controls.Add(this.image[imageRoad]);
                        //中身を設定したセルをテーブルに追加
                        tableRow.Cells.Add(tableCell);
                        //通路画像の番号を+1
                        imageRoad++;
                    }
                    else
                    {
                        //席１つ１つの数
                        imageSeatBtn++;
                        //テーブル内に入れるセル(1マス)を生成
                        tableCell = new TableCell();
                        tableCell.Height = 20;
                        ImageButton tmpBtn = new ImageButton();
                        //プロパティ設定
                        string zero = (imageSeatBtn).ToString();
                        if(zero.Length == 1)
                        {
                            zero = "0" + zero;
                        }
                        tmpBtn.ID = seatHead[i] + zero;
                        tmpBtn.ImageUrl = "~/img/isu.png";
                        tmpBtn.Height = 30;
                        tmpBtn.Width = 30;
                        tmpBtn.CssClass = "FreeSeat";
                        //ハッシュテーブルに保存
                        imgBtnTable.Add( seatHead[i] + zero, tmpBtn);

                        
                        //イベント追加
                        tmpBtn.Click += new System.Web.UI.ImageClickEventHandler(this.ImageBtnSeat_Click);
                        //プロパティを設定したImgBtnをテーブルのセルに追加
                        tableCell.Controls.Add(tmpBtn);
                        //中身を設定したセルをテーブルに追加
                        tableRow.Cells.Add(tableCell);
                    }
                }
                //テーブルに追加
                Table1.Rows.Add(tableRow);
            }
            //プロパティ設定
            string seatNum = 1.ToString();
            if (seatNum.Length == 1)
            {
                seatNum = "0" + seatNum;
            }
            ImageButton imgButton = imgBtnTable[seatHead[0] + seatNum] as ImageButton;
            //ここで改行される          
        }
            //空席の有無               

        /*
        for(int i=0;i<dtseat.Rows.Count;i++)
        {
            this.imgBtn[imageSeatBtn].CssClass = "SoldSeat";
                
        }
        */            
        
        protected void Page_Load(object sender, EventArgs e)
        {                                 
            seatCreate();
        }

        //席をクリック
        protected void ImageBtnSeat_Click(object sender, ImageClickEventArgs e)
        {
            //セッション
            if (Session["value"] != null)
            {
                seatAll = (string[])Session["value"];
            }                    
            //クリックされたら色を変える
            if (((ImageButton)sender).CssClass == "FreeSeat")
            {
                //今までの選択中のカウント
                int counter = 0;                
                //一つずつ格納
                for (int i = 0; i < SeatMax; i++)
                {
                    if (seatAll[i] == null)
                    {
                        seatAll[i] = ((ImageButton)sender).ID;
                        //CSSでグレーを挿入
                        ((ImageButton)sender).CssClass = "ChoiceSeat";
                        break;
                    }
                    else
                    {
                        counter++;
                        //席が６席以上選択されたら
                        if (counter == SeatMax)
                        {
                            //javascriptでonloadを表示させる
                            ClientScriptManager cs = Page.ClientScript;
                            Type csType = this.GetType();
                            cs.RegisterStartupScript(csType, "onload", "<script type=\"text/javascript\">alert('5席まで同時選択可能です。');</script>");
                        }
                    }
                }
            }
            else
            {
                //選択中を解除
                //CSSで色を元に戻す
                ((ImageButton)sender).CssClass = "FreeSeat";

                for(int i = 0; i < SeatMax; i++)
                {
                    if(seatAll[i] == ((ImageButton)sender).ID)
                    {
                        seatAll[i] = null;                        
                    }
                }
            }
            Session["value"] = seatAll;
            
            //今までの選択された席をStringの中に入れる
            for (int i = 0; i < SeatMax; i++)
            {
                if(i!=0)
                {
                    seatChoice = seatChoice + "、";
                }
                seatChoice = seatChoice + seatAll[i];
            }
            seatChoice = seatChoice + "が選択中です";

            //ラベルに表示
            Label1.Text = seatChoice;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //次（確定）画面に飛ぶ
            //リンクを飛ばす
            //Response.Redirect("https://www.yahoo.co.jp/");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //前（スケジュール）画面に戻る
        }
     
    }
}