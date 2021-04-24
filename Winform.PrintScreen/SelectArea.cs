﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winform.PrintScreen.Properties;

namespace Winform.PrintScreen
{
    public partial class SelectArea : Form
    {
        SettingsInstance SettingsInstance = null;
        string latestImagePath = "";
        //Image latestImage = null;
        List<string> ImagePaths = null;
        Image CursorImage = null;
        bool isCustomCursorApplied = false;
        int degreeRotation = 0;
        bool recordingStarted = false;
        readonly int borderWidth = 10;

        //Moving window by click-drag on a control https://stackoverflow.com/a/13477624/5260872
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        //How to resize a form without a border? https://stackoverflow.com/a/32261547/5260872
        public SelectArea()
        {
            InitializeComponent();
            this.Opacity = .10;
            //this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SettingsInstance = Utility.GetSettings();
            Task.Factory.StartNew(() => Utility.DeleteTempFiles());
            borderWidth = this.SettingsInstance.BorderWidth;
        }

        protected override void OnPaint(PaintEventArgs e) // you can safely omit this method if you want
        {
            var borderColorHex = SettingsInstance.BorderColor;
            var borderColor = Utility.GetColor(borderColorHex);
            var brush = new SolidBrush(borderColor);

            e.Graphics.FillRectangle(brush, Top);
            e.Graphics.FillRectangle(brush, Left);
            e.Graphics.FillRectangle(brush, Right);
            e.Graphics.FillRectangle(brush, Bottom);
        }

        private const int
            HTLEFT = 10,
            HTRIGHT = 11,
            HTTOP = 12,
            HTTOPLEFT = 13,
            HTTOPRIGHT = 14,
            HTBOTTOM = 15,
            HTBOTTOMLEFT = 16,
            HTBOTTOMRIGHT = 17;

        

        new Rectangle Top { get { return new Rectangle(0, 0, this.ClientSize.Width, borderWidth); } }
        new Rectangle Left { get { return new Rectangle(0, 0, borderWidth, this.ClientSize.Height); } }
        new Rectangle Bottom { get { return new Rectangle(0, this.ClientSize.Height - borderWidth, this.ClientSize.Width, borderWidth); } }
        new Rectangle Right { get { return new Rectangle(this.ClientSize.Width - borderWidth, 0, borderWidth, this.ClientSize.Height); } }
        Rectangle TopLeft { get { return new Rectangle(0, 0, borderWidth, borderWidth); } }

        private void panelDrag_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            e.Action = DragAction.Cancel;
            //this.panelDrag.Cursor = Cursors.Arrow;
            this.panelDrag.AllowDrop = false;
        }

        private bool disableMovement = false;

        SpeechRecognizer speechRecognizer = null;
        private void SelectArea_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Control && e.KeyCode == Keys.A)       // Ctrl-S Save
            //{
            //    this.panelDrag.BackgroundImage = null;
            //    var image = this.SaveImage(this.Location.X, this.Location.Y, this.Width, this.Height, this.Size);
            //    this.panelDrag.BackgroundImage = image;
            //    this.panelDrag.DoDragDrop(this.panelDrag, DragDropEffects.None);
            //    // Do what you want here
            //    e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
            //}
            //else if (e.Control && e.KeyCode == Keys.S)
            //{
            //    latestImage = this.panelDrag.BackgroundImage.Clone() as Image;
            //}
            ////else if (e.Control && e.KeyCode == Keys.Oem2)
            //else 
            if (e.Control && e.KeyCode == (Keys)Char.ToUpper(this.SettingsInstance.StartRecordingKey))
            {
                this.panelDrag.BackgroundImage = null;
                isCustomCursorApplied = true;
                CursorImage = Utility.GetCursor();
                var image1 = this.SaveImage(this.Location.X, this.Location.Y, this.Width, this.Height, this.Size);
                this.panelDrag.BackgroundImage = image1;
                this.panelDrag.DoDragDrop(this.panelDrag, DragDropEffects.None);

                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                //var bitmap = Properties.Resources.custom_cursor;
                var bitmap = new Bitmap(Utility.GetCursor());
                this.panelDrag.Cursor = new Cursor(bitmap.GetHicon());

                //this.panelDrag.Cursor.Size = new Size( this.SettingsInstance.CursorImageSize, this.SettingsInstance.CursorImageSize);

                disableMovement = true;
                SendMessage(this.Handle, 61456, 0, 0);

                if (recordingStarted)
                {
                    var recordedText = speechRecognizer.GetRecordedText();
                    var image = Image.FromFile(latestImagePath);
                    string docPath = Utility.BasePath + $"Documents/{DateTime.Now.ToString("yyyyMMddhhmmss")}.docx";
                    DocumentWriter writer = new DocumentWriter();
                    writer.WriteDocument(recordedText, latestImagePath, docPath);
                    Utility.LaunchWordDocument(docPath);
                    recordingStarted = false;
                }
                else
                {
                    if(speechRecognizer==null)
                        speechRecognizer = new SpeechRecognizer();

                    recordingStarted = true;
                }
            }
            else if (e.Control && e.KeyCode == (Keys)Char.ToUpper(this.SettingsInstance.RotateKey))
            {
                int currentDegree = 0;
                CursorImage = GetCurrentCursorImage(out currentDegree);
                this.panelDrag.Cursor = new Cursor((CursorImage as Bitmap).GetHicon());
                
                
                isCustomCursorApplied = true;
            }
            //else if (e.Control && e.KeyCode == Keys.P)
            //{
            //    degreeRotation = 0;
            //    //var bitmap = Properties.Resources.custom_cursor;
            //    var bitmap = new Bitmap(Utility.GetCursor());
            //    this.panelDrag.Cursor = new Cursor(bitmap.GetHicon());
            //    isCustomCursorApplied = false;
            //}
            else if(e.Control && e.KeyCode == Keys.O)
            {
                var settingsPrompt = new Settings();
                settingsPrompt.ShowDialog(this);
            }
        }

        int clickNo = 0;

        private Image GetCurrentCursorImage(out int degree)
        {
            var image = Utility.GetCursor(); //(Image)bitmap;
            if (degreeRotation == 0)
            {
                image.RotateFlip(RotateFlipType.Rotate90FlipY);
                degreeRotation += 90;
            }
            else if (degreeRotation == 90)
            {
                image.RotateFlip(RotateFlipType.Rotate180FlipX);
                degreeRotation += 90;
            }
            else if (degreeRotation == 180)
            {
                image.RotateFlip(RotateFlipType.Rotate270FlipY);
                degreeRotation += 90;
            }
            else if (degreeRotation == 270)
            {
                image.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                degreeRotation = 0;
            }

            degree = degreeRotation;
            return image;
        }

        Rectangle TopRight { get { return new Rectangle(this.ClientSize.Width - borderWidth, 0, borderWidth, borderWidth); } }
        Rectangle BottomLeft { get { return new Rectangle(0, this.ClientSize.Height - borderWidth, borderWidth, borderWidth); } }
        Rectangle BottomRight { get { return new Rectangle(this.ClientSize.Width - borderWidth, this.ClientSize.Height - borderWidth, borderWidth, borderWidth); } }


        protected override void WndProc(ref Message message)
        {
            const int WM_SYSCOMMAND = 0x0112;

            base.WndProc(ref message);

            const int SC_MOVE = 61456;
            if (message.Msg == 0x84) // WM_NCHITTEST
            {
                var cursor = this.PointToClient(Cursor.Position);

                if (TopLeft.Contains(cursor)) message.Result = (IntPtr)HTTOPLEFT;
                else if (TopRight.Contains(cursor)) message.Result = (IntPtr)HTTOPRIGHT;
                else if (BottomLeft.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMLEFT;
                else if (BottomRight.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMRIGHT;

                else if (Top.Contains(cursor)) message.Result = (IntPtr)HTTOP;
                else if (Left.Contains(cursor)) message.Result = (IntPtr)HTLEFT;
                else if (Right.Contains(cursor)) message.Result = (IntPtr)HTRIGHT;
                else if (Bottom.Contains(cursor)) message.Result = (IntPtr)HTBOTTOM;
            }
            else

            if ((message.Msg == WM_SYSCOMMAND) && (message.WParam.ToInt32() == SC_MOVE))
            {
                return;
            }

        }
        private void panelDrag_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!disableMovement)
                {
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
                }

                if (isCustomCursorApplied)
                {
                    Image newImage = null;
                    clickNo += 1;

                    var numberColorHex = this.SettingsInstance.NumberColor;
                    SolidBrush semiTransBrush2 = new SolidBrush(Utility.GetColor(numberColorHex));
                    Font crFont = new Font("arial", this.SettingsInstance.NumberFontSize, FontStyle.Bold);
                    Image img = null;

                    using (newImage = string.IsNullOrEmpty(latestImagePath) ? this.panelDrag.BackgroundImage : Image.FromFile(latestImagePath))
                    {
                        using (Graphics g = Graphics.FromImage(newImage))
                        {
                            var bitmap = CursorImage;

                            Rectangle destRect = new Rectangle(e.X, e.Y, bitmap.Width, bitmap.Height);
                            Rectangle sourceRect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

                            StringFormat StrFormat = new StringFormat();
                            StrFormat.Alignment = StringAlignment.Center;

                            g.DrawImage(bitmap, destRect, sourceRect, GraphicsUnit.Pixel);

                            g.DrawString(clickNo.ToString(), crFont, semiTransBrush2, new PointF(e.X + 35, e.Y + 20), StrFormat);

                            g.Dispose();

                            latestImagePath = Utility.BasePath + $"Temp\\{Guid.NewGuid()}tempImage.jpeg";

                            newImage.Save(latestImagePath, System.Drawing.Imaging.ImageFormat.Jpeg);

                            if (ImagePaths == null)
                            {
                                ImagePaths = new List<string>();
                            }

                            if (ImagePaths.Where(t => t.ToLower() == latestImagePath.ToLower()).Count() < 1 )
                            {
                                ImagePaths.Add(latestImagePath);
                            }

                            img = Image.FromFile(latestImagePath);
                            //latestImagePath = null;

                        }
                    }

                    this.panelDrag.BackgroundImage = img;

                    this.Opacity = 1;

                    this.FormBorderStyle = FormBorderStyle.None;

                    if (ImagePaths != null && ImagePaths.Count > 0)
                    {
                        Utility.DeleteTempImages(ImagePaths);
                    }
                }
            }
        }

        private void btnCaptureThis_Click(object sender, EventArgs e)
        {
            this.Hide();
            //Save save = new Save(this.Location.X, this.Location.Y, this.Width, this.Height, this.Size);
            //save.Show();
        }

        private Image SaveImage(Int32 x, Int32 y, Int32 w, Int32 h, Size s)
        {
            Rectangle rect = new Rectangle(x, y, w, h);
            Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, s, CopyPixelOperation.SourceCopy);
            string screenShot = Utility.BasePath + "Temp\\screen.jpeg";
            bmp.Save(screenShot, System.Drawing.Imaging.ImageFormat.Jpeg);
            return bmp;
        }


        
    }
}
