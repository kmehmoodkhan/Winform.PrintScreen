using NPOI.Util;
using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace Winform.PrintScreen
{
    public class DocumentWriter
    {
        public void WriteDocument(string content,string imagePath, string filePath)
        {
            FileStream ms = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            Image image = Image.FromFile(imagePath);


            //string title = "Recording Session";
            using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                XWPFDocument doc = new XWPFDocument();
                var p0 = doc.CreateParagraph();
                p0.Alignment = ParagraphAlignment.CENTER;
                XWPFRun r0 = p0.CreateRun();

                double scaling = 1.0;
                if (image.Width > 72 * 6) scaling = (72 * 6)*1.0 / image.Width*1.0;

                r0.AddPicture(ms, (int)PictureType.JPEG, Path.GetFileName(filePath), Units.ToEMU(scaling*image.Width), Units.ToEMU(image.Height*scaling));

                //var docPr = ((NPOI.OpenXmlFormats.Dml.WordProcessing.CT_Drawing)r0.GetCTR().Items[0]).inline[0].docPr;
                //docPr.id = 1000;

                //r0.FontFamily = "microsoft yahei";
                //r0.FontSize = 18;
                //r0.IsBold = true;
                //r0.SetText(title);

                var p1 = doc.CreateParagraph();
                p1.Alignment = ParagraphAlignment.LEFT;
                p1.IndentationFirstLine = 500;
                XWPFRun r1 = p1.CreateRun();
                r1.FontFamily = "·ÂËÎ";
                r1.FontSize = 12;
                r1.IsBold = false;
                r1.SetText(content);


                doc.Write(fs);
            }
        }

    }
}
