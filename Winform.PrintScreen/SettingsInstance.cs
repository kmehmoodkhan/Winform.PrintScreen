using System;
using System.Collections.Generic;
using System.Text;

namespace Winform.PrintScreen
{
    public class SettingsInstance
    {
        int _CursorImageSize = 64;
        public int CursorImageSize
        {
            get
            {
                return _CursorImageSize;
            }
            set
            {
                _CursorImageSize = value;
            }
        }

        char _ToggleSessionKey = '\'';
        public char ToggleSessionKey
        {
            get
            {
                return _ToggleSessionKey;
            }
            set
            {
                _ToggleSessionKey = value;
            }
        }

        char _StartRecordingKey = '/';
        public char StartRecordingKey
        {
            get
            {
                return _StartRecordingKey;
            }
            set
            {
                _StartRecordingKey = value;
            }
        }

        char _NewLabelKey = 'n';
        public char NewLabelKey
        {
            get
            {
                return _NewLabelKey;
            }
            set
            {
                _NewLabelKey = value;
            }
        }

        char _UndoKey = 'z';
        public char UndoKey
        {
            get
            {
                return _UndoKey;
            }
            set
            {
                _UndoKey = value;
            }
        }

        char _RotateKey = 'r';
        public char RotateKey
        {
            get
            {
                return _RotateKey;
            }
            set
            {
                _RotateKey = value;
            }
        }

        string _NumberColor = "000000";
        public string NumberColor
        {
            get
            {
                return _NumberColor;
            }
            set
            {
                _NumberColor = value;
            }
        }

        int _NumberFontSize = 32;
        public int NumberFontSize
        {
            get
            {
                return _NumberFontSize;
            }
            set
            {
                _NumberFontSize = value;
            }
        }

        string _BorderColor = "0012FF";
        public string BorderColor
        {
            get
            {
                return _BorderColor;
            }
            set
            {
                _BorderColor = value;
            }
        }

        int _BorderWidth = 6;
        public int BorderWidth
        {
            get
            {
                return _BorderWidth;
            }
            set
            {
                _BorderWidth = value;
            }
        }
    }
}
