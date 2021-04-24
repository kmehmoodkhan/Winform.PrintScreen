
namespace Winform.PrintScreen
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCursorSize = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxNumberColor = new System.Windows.Forms.TextBox();
            this.buttonNumberColor = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxNumberOfFontSize = new System.Windows.Forms.TextBox();
            this.textBoxBorderColor = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonBorderColor = new System.Windows.Forms.Button();
            this.textBoxToggleSession = new System.Windows.Forms.TextBox();
            this.textBoxStartRecording = new System.Windows.Forms.TextBox();
            this.textBoxNewLabel = new System.Windows.Forms.TextBox();
            this.textBoxUndo = new System.Windows.Forms.TextBox();
            this.textBoxRotate = new System.Windows.Forms.TextBox();
            this.textBoxBorderWidth = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxNumberColorPallete = new System.Windows.Forms.Label();
            this.textBoxBorderColorPallete = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cursor Image Size";
            // 
            // textBoxCursorSize
            // 
            this.textBoxCursorSize.Location = new System.Drawing.Point(224, 36);
            this.textBoxCursorSize.MaxLength = 3;
            this.textBoxCursorSize.Name = "textBoxCursorSize";
            this.textBoxCursorSize.Size = new System.Drawing.Size(301, 27);
            this.textBoxCursorSize.TabIndex = 3;
            this.textBoxCursorSize.TextChanged += new System.EventHandler(this.textBoxCursorSize_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Toggle Sessions (Ctrl+)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Start Recording (Ctrl+)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "New Label (Ctrl+)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Undo (Ctrl+)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 295);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Rotate (Ctrl+)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 347);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Number Color (Hex)";
            // 
            // textBoxNumberColor
            // 
            this.textBoxNumberColor.Location = new System.Drawing.Point(224, 347);
            this.textBoxNumberColor.Name = "textBoxNumberColor";
            this.textBoxNumberColor.ReadOnly = true;
            this.textBoxNumberColor.Size = new System.Drawing.Size(227, 27);
            this.textBoxNumberColor.TabIndex = 15;
            // 
            // buttonNumberColor
            // 
            this.buttonNumberColor.BackColor = System.Drawing.Color.Transparent;
            this.buttonNumberColor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonNumberColor.BackgroundImage")));
            this.buttonNumberColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonNumberColor.Image = ((System.Drawing.Image)(resources.GetObject("buttonNumberColor.Image")));
            this.buttonNumberColor.Location = new System.Drawing.Point(543, 347);
            this.buttonNumberColor.Name = "buttonNumberColor";
            this.buttonNumberColor.Size = new System.Drawing.Size(34, 29);
            this.buttonNumberColor.TabIndex = 16;
            this.buttonNumberColor.UseVisualStyleBackColor = false;
            this.buttonNumberColor.Click += new System.EventHandler(this.buttonNumberColor_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 398);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "Number Font Size";
            // 
            // textBoxNumberOfFontSize
            // 
            this.textBoxNumberOfFontSize.Location = new System.Drawing.Point(224, 398);
            this.textBoxNumberOfFontSize.MaxLength = 2;
            this.textBoxNumberOfFontSize.Name = "textBoxNumberOfFontSize";
            this.textBoxNumberOfFontSize.Size = new System.Drawing.Size(301, 27);
            this.textBoxNumberOfFontSize.TabIndex = 18;
            this.textBoxNumberOfFontSize.TextChanged += new System.EventHandler(this.textBoxNumberOfFontSize_TextChanged);
            // 
            // textBoxBorderColor
            // 
            this.textBoxBorderColor.Location = new System.Drawing.Point(224, 449);
            this.textBoxBorderColor.Name = "textBoxBorderColor";
            this.textBoxBorderColor.ReadOnly = true;
            this.textBoxBorderColor.Size = new System.Drawing.Size(227, 27);
            this.textBoxBorderColor.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 449);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 20);
            this.label9.TabIndex = 19;
            this.label9.Text = "Border Color (Hex)";
            // 
            // buttonBorderColor
            // 
            this.buttonBorderColor.BackColor = System.Drawing.Color.Transparent;
            this.buttonBorderColor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonBorderColor.BackgroundImage")));
            this.buttonBorderColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonBorderColor.Image = ((System.Drawing.Image)(resources.GetObject("buttonBorderColor.Image")));
            this.buttonBorderColor.Location = new System.Drawing.Point(543, 449);
            this.buttonBorderColor.Name = "buttonBorderColor";
            this.buttonBorderColor.Size = new System.Drawing.Size(34, 29);
            this.buttonBorderColor.TabIndex = 21;
            this.buttonBorderColor.UseVisualStyleBackColor = false;
            this.buttonBorderColor.Click += new System.EventHandler(this.buttonBorderColor_Click);
            // 
            // textBoxToggleSession
            // 
            this.textBoxToggleSession.Location = new System.Drawing.Point(224, 87);
            this.textBoxToggleSession.MaxLength = 2;
            this.textBoxToggleSession.Name = "textBoxToggleSession";
            this.textBoxToggleSession.ReadOnly = true;
            this.textBoxToggleSession.Size = new System.Drawing.Size(301, 27);
            this.textBoxToggleSession.TabIndex = 22;
            this.textBoxToggleSession.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxToggleSession_KeyPress);
            // 
            // textBoxStartRecording
            // 
            this.textBoxStartRecording.Location = new System.Drawing.Point(224, 139);
            this.textBoxStartRecording.MaxLength = 2;
            this.textBoxStartRecording.Name = "textBoxStartRecording";
            this.textBoxStartRecording.ReadOnly = true;
            this.textBoxStartRecording.Size = new System.Drawing.Size(301, 27);
            this.textBoxStartRecording.TabIndex = 23;
            this.textBoxStartRecording.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxStartRecording_KeyPress);
            // 
            // textBoxNewLabel
            // 
            this.textBoxNewLabel.Location = new System.Drawing.Point(224, 191);
            this.textBoxNewLabel.MaxLength = 2;
            this.textBoxNewLabel.Name = "textBoxNewLabel";
            this.textBoxNewLabel.ReadOnly = true;
            this.textBoxNewLabel.Size = new System.Drawing.Size(301, 27);
            this.textBoxNewLabel.TabIndex = 24;
            this.textBoxNewLabel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNewLabel_KeyPress);
            // 
            // textBoxUndo
            // 
            this.textBoxUndo.Location = new System.Drawing.Point(224, 243);
            this.textBoxUndo.MaxLength = 2;
            this.textBoxUndo.Name = "textBoxUndo";
            this.textBoxUndo.ReadOnly = true;
            this.textBoxUndo.Size = new System.Drawing.Size(301, 27);
            this.textBoxUndo.TabIndex = 25;
            this.textBoxUndo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxUndo_KeyPress);
            // 
            // textBoxRotate
            // 
            this.textBoxRotate.Location = new System.Drawing.Point(224, 295);
            this.textBoxRotate.MaxLength = 2;
            this.textBoxRotate.Name = "textBoxRotate";
            this.textBoxRotate.ReadOnly = true;
            this.textBoxRotate.Size = new System.Drawing.Size(301, 27);
            this.textBoxRotate.TabIndex = 26;
            this.textBoxRotate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRotate_KeyPress);
            // 
            // textBoxBorderWidth
            // 
            this.textBoxBorderWidth.Location = new System.Drawing.Point(224, 497);
            this.textBoxBorderWidth.MaxLength = 2;
            this.textBoxBorderWidth.Name = "textBoxBorderWidth";
            this.textBoxBorderWidth.Size = new System.Drawing.Size(301, 27);
            this.textBoxBorderWidth.TabIndex = 28;
            this.textBoxBorderWidth.TextChanged += new System.EventHandler(this.textBoxBorderWidth_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 497);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 20);
            this.label10.TabIndex = 27;
            this.label10.Text = "Border Width";
            // 
            // textBoxNumberColorPallete
            // 
            this.textBoxNumberColorPallete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNumberColorPallete.Location = new System.Drawing.Point(458, 347);
            this.textBoxNumberColorPallete.Name = "textBoxNumberColorPallete";
            this.textBoxNumberColorPallete.Size = new System.Drawing.Size(67, 27);
            this.textBoxNumberColorPallete.TabIndex = 29;
            // 
            // textBoxBorderColorPallete
            // 
            this.textBoxBorderColorPallete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxBorderColorPallete.Location = new System.Drawing.Point(458, 449);
            this.textBoxBorderColorPallete.Name = "textBoxBorderColorPallete";
            this.textBoxBorderColorPallete.Size = new System.Drawing.Size(67, 27);
            this.textBoxBorderColorPallete.TabIndex = 30;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 600);
            this.Controls.Add(this.textBoxBorderColorPallete);
            this.Controls.Add(this.textBoxNumberColorPallete);
            this.Controls.Add(this.textBoxBorderWidth);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxRotate);
            this.Controls.Add(this.textBoxUndo);
            this.Controls.Add(this.textBoxNewLabel);
            this.Controls.Add(this.textBoxStartRecording);
            this.Controls.Add(this.textBoxToggleSession);
            this.Controls.Add(this.buttonBorderColor);
            this.Controls.Add(this.textBoxBorderColor);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxNumberOfFontSize);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.buttonNumberColor);
            this.Controls.Add(this.textBoxNumberColor);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxCursorSize);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Settings_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCursorSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxNumberColor;
        private System.Windows.Forms.Button buttonNumberColor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxNumberOfFontSize;
        private System.Windows.Forms.TextBox textBoxBorderColor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonBorderColor;
        private System.Windows.Forms.TextBox textBoxToggleSession;
        private System.Windows.Forms.TextBox textBoxStartRecording;
        private System.Windows.Forms.TextBox textBoxNewLabel;
        private System.Windows.Forms.TextBox textBoxUndo;
        private System.Windows.Forms.TextBox textBoxRotate;
        private System.Windows.Forms.TextBox textBoxBorderWidth;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label textBoxNumberColorPallete;
        private System.Windows.Forms.Label textBoxBorderColorPallete;
    }
}