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
        public void WriteDocument(string content, string imagePath, string filePath)
        {
            FileStream ms = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            Image image = Image.FromFile(imagePath);


            if (!File.Exists(filePath))
            {
                using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    XWPFDocument doc = new XWPFDocument();
                    var p0 = doc.CreateParagraph();
                    p0.Alignment = ParagraphAlignment.CENTER;
                    XWPFRun r0 = p0.CreateRun();

                    double scaling = 1.0;
                    if (image.Width > 72 * 6) scaling = (72 * 6) * 1.0 / image.Width * 1.0;

                    r0.AddPicture(ms, (int)PictureType.JPEG, Path.GetFileName(filePath), Units.ToEMU(scaling * image.Width), Units.ToEMU(image.Height * scaling));

                    var list = GetParagraphs(content);

                    bool addSteps = false;

                    addSteps = list.Count > 0;

                    foreach (var str in list)
                    {
                        var p1 = doc.CreateParagraph();
                        p1.Alignment = ParagraphAlignment.LEFT;
                        p1.IndentationFirstLine = 500;
                        XWPFRun r1 = p1.CreateRun();
                        r1.FontFamily = "·ÂËÎ";
                        r1.FontSize = 12;
                        r1.IsBold = false;
                        int number = 0;

                        if (addSteps)
                        {
                            number += 1;
                            XWPFNumbering numbering = doc.CreateNumbering();
                            string abstractNumId = numbering.AddAbstractNum();
                            string numId = numbering.AddNum(abstractNumId);
                            p1.SetNumID(numId,"1");
                        }

                        r1.SetText(str);
                    }


                    doc.Write(fs);
                }
            }
            else
            {
                XWPFDocument doc = null;
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    doc = new XWPFDocument(fs);
                    var p0 = doc.CreateParagraph();
                    p0.Alignment = ParagraphAlignment.CENTER;
                    XWPFRun r0 = p0.CreateRun();

                    double scaling = 1.0;
                    if (image.Width > 72 * 6) scaling = (72 * 6) * 1.0 / image.Width * 1.0;

                    r0.AddPicture(ms, (int)PictureType.JPEG, Path.GetFileName(filePath), Units.ToEMU(scaling * image.Width), Units.ToEMU(image.Height * scaling));

                    var list = GetParagraphs(content);

                    bool addSteps = false;

                    addSteps = list.Count > 0;

                    int number = 0;

                    foreach (var str in list)
                    {
                        var p1 = doc.CreateParagraph();
                        p1.Alignment = ParagraphAlignment.LEFT;
                        p1.IndentationFirstLine = 500;
                        XWPFRun r1 = p1.CreateRun();
                        r1.FontFamily = "·ÂËÎ";
                        r1.FontSize = 12;
                        r1.IsBold = false;

                        if (addSteps)
                        {
                            number += 1;
                            XWPFNumbering numbering = doc.CreateNumbering();
                            string abstractNumId = numbering.AddAbstractNum();
                            string numId = numbering.AddNum(abstractNumId);
                            p1.SetNumID(numId, number.ToString());
                        }

                        r1.SetText(str);
                    }
                    //var p0 = doc.CreateParagraph();
                    //p0.Alignment = ParagraphAlignment.CENTER;
                    //XWPFRun r0 = p0.CreateRun();

                    //double scaling = 1.0;
                    //if (image.Width > 72 * 6) scaling = (72 * 6) * 1.0 / image.Width * 1.0;

                    //r0.AddPicture(ms, (int)PictureType.JPEG, Path.GetFileName(filePath), Units.ToEMU(scaling * image.Width), Units.ToEMU(image.Height * scaling));

                    //var p1 = doc.CreateParagraph();
                    //p1.Alignment = ParagraphAlignment.LEFT;
                    //p1.IndentationFirstLine = 500;
                    //XWPFRun r1 = p1.CreateRun();
                    //r1.FontFamily = "·ÂËÎ";
                    //r1.FontSize = 12;
                    //r1.IsBold = false;
                    //r1.SetText(content);
                }

                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    doc.Write(fs);
                }
            }
        }

        private List<string> GetParagraphs(string content)
        {
            if (content.ToLower().Contains("step one"))
            {
                string[] arrays = content.Split("step");
                var list = new List<string>(arrays);
                return list;
            }
            else
            {
                var list = new List<string>();
                list.Add(content);
                return list;
            }
            
        }
    }
}
