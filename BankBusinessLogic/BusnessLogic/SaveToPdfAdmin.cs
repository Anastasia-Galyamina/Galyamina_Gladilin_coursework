using BankBusinessLogic.HelperModelsAdmin;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System.Collections.Generic;

namespace BankBusinessLogic.BusnessLogic
{
    public static class SaveToPdfAdmin
    {
       [System.Obsolete]
        public static void CreateDoc(PdfInfo info)
        {
            Document document = new Document();
            DefineStyles(document);
            Section section = document.AddSection();
            Paragraph paragraph = section.AddParagraph(info.Title);
            paragraph.Format.SpaceAfter = "1cm";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Style = "NormalTitle";
            var table = document.LastSection.AddTable();
            List<string> columns = new List<string> { "2cm", "6cm", "3cm", "6cm" };
            foreach (var elem in columns)
            {
                table.AddColumn(elem);
            }
            CreateRow(new PdfRowParameters
            {
                Table = table,
                Texts = new List<string> { "Номер заявки", "Почта", "Валюта", "Сумма" },
                Style = "NormalTitle",
                ParagraphAlignment = ParagraphAlignment.Center
            });
            if (info.Requests != null)
            {
                foreach (var fb in info.Requests)
                {
                    CreateRow(new PdfRowParameters
                    {
                        Table = table,
                        Texts = new List<string> {
                        fb.RequestId.ToString(),
                        fb.Email,
                        fb.Currency,
                        fb.Count.ToString()
                        },
                        Style = "Normal",
                        ParagraphAlignment = ParagraphAlignment.Left
                    });
                }
            }
            Paragraph paragraph2 = section.AddParagraph("Кредиты");
            paragraph2.Format.SpaceAfter = "1cm";
            paragraph2.Format.Alignment = ParagraphAlignment.Center;
            paragraph2.Style = "NormalTitle";
            var table2 = document.LastSection.AddTable();
            List<string> columns2 = new List<string> { "2cm", "2cm", "4cm", "4cm", "3cm", "2cm", "2cm" };
            foreach (var elem in columns2)
            {
                table2.AddColumn(elem);
            }
            CreateRow(new PdfRowParameters
            {
                Table = table2,
                Texts = new List<string> { "Название сделки", "Клиент", "Кредит", "Срок", "Валюта", "Цена" },
                Style = "NormalTitle",
                ParagraphAlignment = ParagraphAlignment.Center
            });
            if (info.Credits != null)
            {
                foreach (var fb in info.Credits)
                {
                    CreateRow(new PdfRowParameters
                    {
                        Table = table2,
                        Texts = new List<string> {
                        fb.DealName,
                        fb.ClientFio,
                        fb.CreditName,
                        fb.Term,                        
                        fb.Currency,
                        fb.Price.ToString()
                        },
                        Style = "Normal",
                        ParagraphAlignment = ParagraphAlignment.Left
                    });
                }
            }
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always)
            {
                Document = document
            };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(info.FileName);
        }
        private static void DefineStyles(Document document)
        {
            Style style = document.Styles["Normal"];
            style.Font.Name = "Times New Roman";
            style.Font.Size = 14;
            style = document.Styles.AddStyle("NormalTitle", "Normal");
            style.Font.Bold = true;
        }
        private static void CreateRow(PdfRowParameters rowParameters)
        {
            Row row = rowParameters.Table.AddRow();
            for (int i = 0; i < rowParameters.Texts.Count; ++i)
            {
                FillCell(new PdfCellParameters
                {
                    Cell = row.Cells[i],
                    Text = rowParameters.Texts[i],
                    Style = rowParameters.Style,
                    BorderWidth = 0.5,
                    ParagraphAlignment = rowParameters.ParagraphAlignment
                });
            }
        }
        private static void FillCell(PdfCellParameters cellParameters)
        {
            cellParameters.Cell.AddParagraph(cellParameters.Text);

            if (!string.IsNullOrEmpty(cellParameters.Style)) { cellParameters.Cell.Style = cellParameters.Style; }

            cellParameters.Cell.Borders.Left.Width = cellParameters.BorderWidth;
            cellParameters.Cell.Borders.Right.Width = cellParameters.BorderWidth;
            cellParameters.Cell.Borders.Top.Width = cellParameters.BorderWidth;
            cellParameters.Cell.Borders.Bottom.Width = cellParameters.BorderWidth;
            cellParameters.Cell.Format.Alignment = cellParameters.ParagraphAlignment;
            cellParameters.Cell.VerticalAlignment = VerticalAlignment.Center;
        }
    }
}
