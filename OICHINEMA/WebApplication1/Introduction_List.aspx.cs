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
    public partial class Introduction_List : System.Web.UI.Page
    {
        void MoveScreen(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            Session["introID"] = btn.ID.Substring(6);
            Response.Redirect("Individual_Page.aspx");
        }


        protected void Page_Load(object sender, EventArgs e)
        {


            int cnt;
            OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
            OleDbDataAdapter da;
            da = new OleDbDataAdapter("SELECT COUNT(*) FROM TBL_WORK WHERE WORK_END>Date()", cn);
            DataTable dtc = new DataTable();
            da.Fill(dtc);
            cnt = int.Parse(dtc.Rows[0][0].ToString());

            da = new OleDbDataAdapter("SELECT WORK_NAME,WORK_PASS1,WORK_ID FROM TBL_WORK WHERE WORK_END>Date()", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            TableCell tblCell;
            TableRow tblRow = new TableRow();
            ImageButton imgbtn;
            MainTable.Width = 500;

            for (int i = 0; i < cnt; i++)
            {
                Table Tbl = new Table();
                Tbl.ID = "Tbl" + i.ToString();
                tblCell = new TableCell();
                tblCell.Controls.Add(Tbl);
                tblRow.Cells.Add(tblCell);

                if ((i + 1) % 3 == 0)
                {
                    MainTable.Rows.Add(tblRow);
                    tblRow = new TableRow();
                }

                if (i == cnt - 1 && (i + 1) % 3 != 0)
                {
                    MainTable.Rows.Add(tblRow);
                }
            }

            for (int i = 0; i < cnt; i++)
            {
                tblCell = new TableCell();
                tblRow = new TableRow();
                imgbtn = new ImageButton();
                imgbtn.ID = "imgbtn" + dt.Rows[i][2].ToString();
                imgbtn.Width = 300;
                imgbtn.Height = 300;
                imgbtn.ImageUrl = dt.Rows[i][1].ToString();
                imgbtn.Click += MoveScreen;
                
                tblCell.Controls.Add(imgbtn);
                tblRow.Cells.Add(tblCell);
                Table tbl = (Table)Master.FindControl("MainContent").FindControl("tbl" + i.ToString());
                if (tbl != null)
                {
                    tbl.Rows.Add(tblRow);
                }

                tblCell = new TableCell();
                tblRow = new TableRow();
                Label lbl = new Label();
                lbl.Text = dt.Rows[i][0].ToString();
                tblCell.Controls.Add(lbl);
                tblRow.Cells.Add(tblCell);

                if (tbl != null)
                {
                    tbl.Rows.Add(tblRow);
                }
            }
        }
    }
}