using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Web.UI;

namespace TranSmart.Static
{
    public class Grd2Pdf
    {
        public static void GrdPrepare(RadGrid grd, string Title)
        {
            string headerMiddleCell = "<h2>TransSmart Managment System</h2>" + Title ;
            string headerLeftCell = "<img src=\"Content/Images/logo.jpg\" alt=\"TransSmart\" style=\"width:99px; height: 66px;\" />";
            string footerMiddleCell = "<?page-number?>";


            //grdProjList.ExportSettings.Pdf.BorderType = GridPdfSettings.GridPdfBorderType.AllBorders;
            grd.ExportSettings.Pdf.PageHeader.MiddleCell.Text = headerMiddleCell;
            grd.ExportSettings.Pdf.PageHeader.MiddleCell.TextAlign = GridPdfPageHeaderFooterCell.CellTextAlign.Center;
            grd.ExportSettings.Pdf.PageHeader.LeftCell.Text = headerLeftCell;
            grd.ExportSettings.Pdf.PageHeader.LeftCell.TextAlign = GridPdfPageHeaderFooterCell.CellTextAlign.Center;
            grd.ExportSettings.Pdf.PageFooter.MiddleCell.Text = footerMiddleCell;
            grd.ExportSettings.Pdf.PageFooter.MiddleCell.TextAlign = GridPdfPageHeaderFooterCell.CellTextAlign.Center;
            grd.ExportSettings.Pdf.PageFooter.LeftCell.Text = DateTime.Now.ToString();
            grd.ExportSettings.Pdf.PageFooter.LeftCell.TextAlign = GridPdfPageHeaderFooterCell.CellTextAlign.Center;

        }
        public static void FormatGridItem(GridItem item)
        {
            item.Style["color"] = "#000000";

            if (item is GridDataItem)
            {
                item.Style["vertical-align"] = "middle";
                item.Style["text-align"] = "center";
            }

            switch (item.ItemType) //Mimic RadGrid appearance for the exported PDF file
            {
                case GridItemType.Item: item.Style["background-color"] = "#e0e0e0"; item.BorderWidth = 0; break;
                case GridItemType.AlternatingItem: item.Style["background-color"] = "#ffffff"; break;
                case GridItemType.Header: item.Style["background-color"] = "#adadad"; break;
                case GridItemType.CommandItem: item.Style["background-color"] = "#000000"; break;
            }

            if (item is GridCommandItem)
            {
                item.PrepareItemStyle();  //needed to span the image over the CommandItem cells
            }
        }
    }
}