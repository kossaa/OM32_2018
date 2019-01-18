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
        String signBord;
        protected void Page_Load(object sender, EventArgs e)
        {
                OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=|DataDirectory|BookingDB.accdb;");
                OleDbDataAdapter da;
                da = new OleDbDataAdapter("SELECT WORK_PASS1,WORK_PASS2,WORK_PASS3,WORK_PASS4,WORK_COMMENT,WORK_ACTOR,WORK_TIME FROM TBL_WORK WHERE WORK_ID = '" + Session["IntroID"] + "'", cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                signBord = dt.Rows[0][0].ToString();
                if (IsPostBack == false)
                {
                    MovieSignbordImage.ImageUrl = dt.Rows[0][0].ToString();
                    MovieCaptureImage1.ImageUrl = dt.Rows[0][1].ToString();
                    MovieCaptureImage2.ImageUrl = dt.Rows[0][2].ToString();
                    MovieCaptureImage3.ImageUrl = dt.Rows[0][3].ToString();
                }

                String[] actors = dt.Rows[0][5].ToString().Split(',');
                TableCell tblCell;
                TableRow tblRow=new TableRow();

                for (int i = 0; i < actors.Length; i++)
                {
                    tblRow = new TableRow();
                    tblCell = new TableCell();
                    if (i == 6){
                        Label slbl = (Label)Master.FindControl("MainContent").FindControl("CastLabel" + (i-1).ToString());
                        slbl.Text = "...etc";
                        break;
                    }
                    Label lbl = new Label();
                    lbl.ID = "CastLabel" + i.ToString();
                    lbl.Text = actors[i];

                    tblCell.Controls.Add(lbl);
                    tblRow.Cells.Add(tblCell);
                    CastTable.Rows.Add(tblRow);
                }
            MainSummaryLabel.Text = dt.Rows[0][4].ToString();
            TimeLabel.Text = "上映時間："+dt.Rows[0][6].ToString()+"分";
        }

        String work;
        protected void MovieCaptureImage1_Click(object sender, ImageClickEventArgs e)
        {

            
            work = MovieSignbordImage.ImageUrl;
            MovieSignbordImage.ImageUrl = MovieCaptureImage1.ImageUrl;
            MovieCaptureImage1.ImageUrl = work;
             
        }

        protected void MovieCaptureImage2_Click(object sender, ImageClickEventArgs e)
        {
            String work2;
            work = MovieSignbordImage.ImageUrl;
            if (work == signBord)
            {
                work2 = MovieCaptureImage1.ImageUrl;
                MovieCaptureImage1.ImageUrl = MovieSignbordImage.ImageUrl;
                MovieSignbordImage.ImageUrl = MovieCaptureImage2.ImageUrl;
                MovieCaptureImage2.ImageUrl = work2;
            }
            else
            {
                MovieSignbordImage.ImageUrl = MovieCaptureImage2.ImageUrl;
                MovieCaptureImage2.ImageUrl = work;
            }
        }

        protected void MovieCaptureImage3_Click(object sender, ImageClickEventArgs e)
        {
            String work2;
            work = MovieSignbordImage.ImageUrl;
            if (work == signBord)
            {
                work2 = MovieCaptureImage1.ImageUrl;
                MovieCaptureImage1.ImageUrl = MovieSignbordImage.ImageUrl;
                MovieSignbordImage.ImageUrl = MovieCaptureImage3.ImageUrl;
                MovieCaptureImage3.ImageUrl = work2;
            }
            else
            {
                MovieSignbordImage.ImageUrl = MovieCaptureImage3.ImageUrl;
                MovieCaptureImage3.ImageUrl = work;
            }
        }
    }
}