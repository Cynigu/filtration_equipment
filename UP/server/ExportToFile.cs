using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
namespace UP.server
{
    public interface IExportDataTable 
    {
        void Save(string filepath, System.Data.DataTable dt);
    }

    public class ExportDataTableToWordService: IExportDataTable
    {
        public void Save(string filepath, System.Data.DataTable dt)
        {
            object oMissing = System.Reflection.Missing.Value;
            System.Data.DataTable DT = dt.DefaultView.ToTable();
            int rcount = DT.Rows.Count;
            int ccount = DT.Columns.Count;

            var app = new Microsoft.Office.Interop.Word.Application();
            //app.Visible = true;
            var doc = app.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            doc.PageSetup.Orientation = WdOrientation.wdOrientLandscape;
            var wparag1 = doc.Content.Paragraphs.Add(ref oMissing);
            wparag1.Range.Font.Size = 13;
            wparag1.Range.Font.Bold = 1;
            wparag1.Range.Text = "Отчет по выборке аппаратов для центрифугирования";
            wparag1.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
            wparag1.Range.InsertParagraphAfter();

            var wparag2 = doc.Content.Paragraphs.Add(ref oMissing);
            wparag2.Range.Font.Size = 12;
            wparag2.Range.Text = "Дата: " + DateTime.Now.ToString();
            wparag1.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
            wparag2.Range.InsertParagraphAfter();

            var wparag3 = doc.Paragraphs.Add(ref oMissing);
            wparag3.Range.Font.Size = 12;
            Table tb = doc.Tables.Add(wparag3.Range, rcount + 1, ccount);
            tb.Borders.Enable = 1;

            for (int k = 0; k < dt.Columns.Count; k++)
            {
                tb.Cell(1, k + 1).Range.Text = DT.Columns[k].ColumnName;
            }

            for (int i = 0; i < rcount; i++)
            {
                for (int k = 0; k < ccount; k++)
                {
                    tb.Cell(i + 2, k + 1).Range.Text = DT.Rows[i][k].ToString();
                }
            }
            wparag3.Range.InsertParagraphAfter();
            //r.Tables.Add(r, dt.Rows.Count, dt.Columns.Count, dt);
            doc.SaveAs(filepath);

            doc.Close();
            
            doc = null;
            app = null;
        }
    }
}
