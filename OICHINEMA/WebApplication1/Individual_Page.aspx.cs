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
    public partial class Individual_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
            OleDbDataAdapter da;
            da = new OleDbDataAdapter("SELECT WORK_PASS1,WORK_PASS2,WORK_PASS3,WORK_PASS4,WORK_COMMENT,WORK_ACTOR FROM TBL_WORK WHERE WORK_ID = '" + Session["IntroID"] + "'", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            MovieSignbordImage.ImageUrl = dt.Rows[0][0].ToString();
            MovieCaptureImage1.ImageUrl = dt.Rows[0][1].ToString();
            MovieCaptureImage2.ImageUrl = dt.Rows[0][2].ToString();
            MovieCaptureImage3.ImageUrl = dt.Rows[0][3].ToString();

            String[] actors = dt.Rows[0][5].ToString().Split(',');
            TableCell tblCell;
            TableRow tblRow = new TableRow();

            for (int i = 0; i < actors.Length; i++)
            {
                Table Tbl = new Table();
                Tbl.ID = "CastTbl" + i.ToString();
                tblCell = new TableCell();
                tblCell.Controls.Add(Tbl);
                tblRow.Cells.Add(tblCell);
                CastTable.Rows.Add(tblRow);
                tblRow = new TableRow();

                Label lbl = new Label();
                lbl.ID = "CastLabel" + i.ToString();
                lbl.Text = actors[i];

                tblCell.Controls.Add(lbl);
                tblRow.Cells.Add(tblCell);
                Table tbl = (Table)Master.FindControl("MainContent").FindControl("CastTbl" + i.ToString());
                if (tbl != null)
                {
                    tbl.Rows.Add(tblRow);
                }
            }
            CastTable.Rows.Add(tblRow);

            int flag=0;
            int cnt=0;
            int sumCnt = 0;
            String str = dt.Rows[0][4].ToString();
            String[] Summary = new String[str.Length/40+1];

            while (flag == 0)
            {
                if (str.Length - cnt >= 40)
                {
                    Summary[sumCnt] = str.Substring(cnt, 40);
                    sumCnt++;
                    cnt += 40;
                }
                else
                {
                    Summary[sumCnt] = str.Substring(cnt, str.Length-cnt);
                    flag = 1;
                    sumCnt++;
                }
            }

            for (int i = 0; i < sumCnt; i++)
            {
                Table Tbl = new Table();
                Tbl.ID = "SummaryTbl" + i.ToString();
                tblCell = new TableCell();
                tblCell.Controls.Add(Tbl);
                tblRow.Cells.Add(tblCell);
                SummaryTable.Rows.Add(tblRow);
                tblRow = new TableRow();

                Label lbl = new Label();
                lbl.ID = "SummaryLabel" + i.ToString();
                lbl.Text = Summary[i];

                tblCell.Controls.Add(lbl);
                tblRow.Cells.Add(tblCell);
                Table tbl = (Table)Master.FindControl("MainContent").FindControl("SummaryTbl" + i.ToString());
                if (tbl != null)
                {
                    tbl.Rows.Add(tblRow);
                }
            }

            SummaryTable.Rows.Add(tblRow);
        }
    }
}