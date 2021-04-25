using System;
using System.Collections.Generic;
using System.Speech.Recognition;
using System.Text;
using System.Threading;

namespace Winform.PrintScreen
{
    public class SpeechRecognizer
    {
        SpeechRecognitionEngine _recognizer = null;
        ManualResetEvent manualResetEvent = null;
        string recordedText = string.Empty;


        public SpeechRecognizer()
        {
            manualResetEvent = new ManualResetEvent(false);
            _recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
            _recognizer.LoadGrammar(new Grammar(new GrammarBuilder("exit")));
            _recognizer.LoadGrammar(new DictationGrammar());
            _recognizer.SpeechRecognized += speechRecognitionWithDictationGrammar_SpeechRecognized;
            _recognizer.SetInputToDefaultAudioDevice();
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }
        void speechRecognitionWithDictationGrammar_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (!string.IsNullOrEmpty(recordedText))
            {
                recordedText += (" " + e.Result.Text);
            }
            else
            {
                recordedText += e.Result.Text;
            }
        }

       public string GetRecordedText()
        {
            var tempText = recordedText;
            recordedText = string.Empty;
            return tempText;
        }

    }
}
