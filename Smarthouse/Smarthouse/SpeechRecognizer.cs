using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Speech.Recognition;

namespace Smarthouse
{
    class SpeechRecognizer
    {
        public SpeechRecognizer()
        {
            sre = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
            sre.SetInputToDefaultAudioDevice();

            keywords = new Choices();
            keywords.Add( new string [] {"Smarti"} );

            guiCommands = new Choices();
            guiCommands.Add(new string[] { "Help", "Exit", "Add appliance","Modify appliance","Delete appliance"});

            allchoices = new Choices(new GrammarBuilder[] { keywords, guiCommands });

            GrammarBuilder gb = new GrammarBuilder(allchoices);
            Grammar g = new Grammar(gb);
            sre.LoadGrammar(g);
            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
            sre.RecognizeAsync(RecognizeMode.Multiple);
        }
        private void Help()
        {

        }
        private void Exit()
        {

        }
        private void AddAppliance()
        {

        }
        private void ModifyAppliance()
        {

        }
        private void DeleteAppliance()
        {

        }
        public void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "Help":
                    Help();
                    break;

                case "Exit":
                    Exit();
                    break;

                case "Add appliance":
                    AddAppliance();
                    break;
                case "Modify appliance":
                    ModifyAppliance();
                    break;
                case "Delete appliance":
                    DeleteAppliance();
                    break;


               

               

                default:
                    break;
            }

        }
        private SpeechRecognitionEngine sre;
        private Choices guiCommands;
        private Choices keywords;
        private Choices allchoices;
    }
}
