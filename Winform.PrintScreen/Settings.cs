using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Winform.PrintScreen
{
    public partial class Settings : Form
    {
        SettingsInstance SettingInstance = null;
        public Settings()
        {
            InitializeComponent();
            
            SettingInstance = new SettingsInstance();

            bool settingsExist = false;
            if (File.Exists(Utility.SettingsFilePath))
            {
                settingsExist = true;
                SettingInstance = Utility.GetSettings();

                this.textBoxCursorSize.Text = SettingInstance.CursorImageSize.ToString();
                this.textBoxToggleSession.Text = SettingInstance.ToggleSessionKey.ToString();
                this.textBoxStartRecording.Text = SettingInstance.StartRecordingKey.ToString();
                this.textBoxNewLabel.Text = SettingInstance.NewLabelKey.ToString();
                this.textBoxUndo.Text = SettingInstance.UndoKey.ToString();
                this.textBoxRotate.Text = SettingInstance.RotateKey.ToString();
                this.textBoxNumberColor.Text ="#"+ SettingInstance.NumberColor.ToString();
                this.textBoxNumberOfFontSize.Text = SettingInstance.NumberFontSize.ToString();
                this.textBoxBorderColor.Text = "#" + SettingInstance.BorderColor.ToString();
                this.textBoxBorderWidth.Text = SettingInstance.BorderWidth.ToString();

                var borderColor = Utility.GetColor(SettingInstance.BorderColor);
                this.textBoxBorderColorPallete.BackColor = borderColor;

                var numberColor = Utility.GetColor(SettingInstance.NumberColor);
                this.textBoxNumberColorPallete.BackColor = numberColor;


            }
            if(!settingsExist)
            {
                this.textBoxCursorSize.Text = "64";
                this.textBoxNumberOfFontSize.Text = "32";
                this.textBoxBorderColor.Text = "6";
            }
            //this.FillKeys(ref this.comboBoxToggleSessionKey);
        }

        private void FillKeys(ref ComboBox dropdown)
        {
            dropdown.DataSource = (Keys[])Enum.GetValues(typeof(Keys));
        }

        private void buttonNumberColor_Click(object sender, EventArgs e)
        {
            if (this.textBoxNumberColor.Text.Length > 0)
            {
                var hexString = Int32.Parse(this.textBoxNumberColor.Text.Replace("#",""), NumberStyles.AllowHexSpecifier | NumberStyles.HexNumber);

                this.colorDialog1.Color = Color.FromArgb(hexString);
            }

            if( this.colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                string tempColor = (colorDialog1.Color.ToArgb() & 0x00FFFFFF).ToString("X6");
                this.textBoxNumberColor.Text = "#" + tempColor;
                SettingInstance.NumberColor = tempColor;
            }
        }

        private void buttonBorderColor_Click(object sender, EventArgs e)
        {
            if (this.textBoxNumberColor.Text.Length > 0)
            {
                var hexString = Int32.Parse(this.textBoxBorderColor.Text.Replace("#", ""), NumberStyles.AllowHexSpecifier | NumberStyles.HexNumber);

                this.colorDialog1.Color = Color.FromArgb(hexString);
            }

            if (this.colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                string tempColor = (colorDialog1.Color.ToArgb() & 0x00FFFFFF).ToString("X6");
                this.textBoxBorderColor.Text = "#" + tempColor;
                SettingInstance.BorderColor = tempColor;
            }
        }

        private void textBoxToggleSession_KeyPress(object sender, KeyPressEventArgs e)
        {
            var key = e.KeyChar;
            SettingInstance.ToggleSessionKey = key;
            this.textBoxToggleSession.Text = key.ToString();
        }

        private void textBoxStartRecording_KeyPress(object sender, KeyPressEventArgs e)
        {
            var key = e.KeyChar;
            SettingInstance.StartRecordingKey = key;
            this.textBoxStartRecording.Text = key.ToString();
        }

        private void textBoxNewLabel_KeyPress(object sender, KeyPressEventArgs e)
        {
            var key = e.KeyChar;
            SettingInstance.NewLabelKey = key;
            this.textBoxNewLabel.Text = key.ToString();
        }

        private void textBoxUndo_KeyPress(object sender, KeyPressEventArgs e)
        {
            var key = e.KeyChar;
            SettingInstance.UndoKey = key;
            this.textBoxUndo.Text = key.ToString();
        }

        private void textBoxRotate_KeyPress(object sender, KeyPressEventArgs e)
        {
            var key = e.KeyChar;
            SettingInstance.RotateKey = key;
            this.textBoxRotate.Text = key.ToString();
        }

        
        

        private void Settings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                Utility.SaveSettings(SettingInstance);
            }
        }

        private void textBoxCursorSize_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(this.textBoxCursorSize.Text))
            SettingInstance.CursorImageSize = Convert.ToInt32(this.textBoxCursorSize.Text);
        }

        private void textBoxNumberOfFontSize_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.textBoxNumberOfFontSize.Text))
                SettingInstance.NumberFontSize = Convert.ToInt32(this.textBoxNumberOfFontSize.Text);
        }

        private void textBoxBorderWidth_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.textBoxBorderWidth.Text))
                SettingInstance.BorderWidth = Convert.ToInt32(this.textBoxBorderWidth.Text);
        }
    }

    
}
