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
        //private Image[] img;
        int seatcount=0;
        string[] seatname=new string[1];
        const int Cell2Width = 300;

        protected void Page_Load(object sender, EventArgs e)
        {
            //画面結合時に前の画面からデータを継承する
            //継承内容
            //座席番号 スケジュール番号 チケットデータ一式 会員番号 メールアドレス
            seatcount = 3;//継承した予約席数を格納する
            Array.Resize(ref seatname, seatcount);//配列の数を継承した予約数に合わせる
            seatname[0] = "c4";
            seatname[1] = "c5";
            seatname[2] = "c6";




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


                //this.img = new Image[10];
                //for (int i=0;i<img.Length;i++)
                //{
                //    tableRow = new TableRow();
                //    for (int j = 0; j < img.Length; j++) { 
                //        tableCell = new TableCell();

                //    this.img[i] = new Image();
                //    //プロパティ設定
                //    this.img[i].ID = "SeatImage" + i.ToString();
                //    this.img[i].ImageUrl = "isu.png";
                //    this.img[i].Height = 30;
                //    this.img[i].Width = 30;
                //    //コントロールをフォームに追加
                //    tableCell.Controls.Add(this.img[i]);


                //    tableRow.Cells.Add(tableCell);}
                //    Table1.Rows.Add(tableRow);
                //}
            

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
            tableCell.RowSpan = seatname.Length + 2;
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

            for (int i = 0; i < seatname.Length; i++)
            {
                tableRow = new TableRow();
                tableCell = new TableCell();
                tableCell.Text = seatname[i];//予約席名
                tableCell.Width = Cell2Width;
                tableRow.Cells.Add(tableCell);
                tableCell = new TableCell();
                tableCell.Text = "";//各予約席のチケットの種類
                tableRow.Cells.Add(tableCell);
                tableCell = new TableCell();
                tableCell.Text = "";//チケットの種類に基づく料金
                tableRow.Cells.Add(tableCell);
                Table1.Rows.Add(tableRow);
                totalcost += 0;//チケットの料金を足す
            }

            tableRow = new TableRow();
            tableCell = new TableCell();
            tableCell.Text = "合計" + seatname.Length.ToString() + "席";
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