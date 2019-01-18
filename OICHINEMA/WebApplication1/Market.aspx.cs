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
    public partial class Market : System.Web.UI.Page
    {
        const int wh = 1048;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == true)
            {
                return;
            }

            DataPage1("01");
        }

        public void DataPage1(string a)
        {
            OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
            OleDbDataAdapter da;

            string query_sql = "SELECT GOODS_NAME,GOODS_PRICE,GOODS_PASS FROM TBL_GOODS WHERE CLASS_ID='" + a + "'";
            //string query_sql = "SELECT GOODS_NAME,GOODS_KANA,GOODS_DAY,CLASS_ID,GOODS_PRICE,GOODS_PASS FROM TBL_GOODS"; 

            //扱いたいデータをSQLで取ってきてDataAdapterに格納
            da = new OleDbDataAdapter(query_sql, cn);

            //Adapterに格納したデータを項目単位で利用するためにデータテーブルに格納　GridViewとかに入れるならAdapterから直で行けるはず
            DataTable dt = new DataTable();
            da.Fill(dt);

            TableRow tableRow;
            TableCell tableCell;
            Image img;


            int D;
            int i;



            D = dt.Rows.Count;
            for (i = 0; i < D; )
            {
                tableRow = new TableRow();
                int k = 0;
                for (k = 0; k < 3 && dt.Rows.Count != i; k++, i++)
                {
                    tableCell = new TableCell();
                    img = new Image();
                    img.ID = "FoodImage";
                    img.ImageUrl = Server.HtmlEncode(@dt.Rows[i][2].ToString());
                    img.Width = 300;
                    img.Height = 300;
                    tableCell.Width = wh / 3;
                    tableCell.Controls.Add(img);
                    tableCell.ColumnSpan = 2;//ひとつ右のセルと結合する
                    tableRow.Controls.Add(tableCell);
                }
                if (k % 3 != 0)
                {
                    i -= k % 3;
                }
                else
                {
                    i -= 3;
                }


                Table1.Rows.Add(tableRow);
                //


                tableRow = new TableRow();
                for (k = 0; k < 3 && dt.Rows.Count != i; k++, i++)
                {

                    tableCell = new TableCell();
                    tableCell.Text = dt.Rows[i][0].ToString();
                    tableCell.Width = wh / 3;
                    tableRow.Cells.Add(tableCell);

                    tableCell = new TableCell();
                    tableCell.Text = ((int)decimal.Parse(dt.Rows[i][1].ToString())).ToString() + "円";
                    tableCell.Width = wh / 3;
                    tableRow.Cells.Add(tableCell);
                }


                Table1.Rows.Add(tableRow);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataPage1("01");

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            DataPage1("02");
        }
    }
}