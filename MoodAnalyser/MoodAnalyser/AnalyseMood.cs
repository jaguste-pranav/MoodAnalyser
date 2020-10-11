using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    public class AnalyseMood
    {
        string mood = "";
        
        public string analysemood(string inputmessage)
        {
            mood = inputmessage;
            if (this.mood.ToLower().Contains("happy") || this.mood.ToLower().Contains("any"))
            {
                this.mood = "Happy";
            }
            else if (this.mood.ToLower().Contains("sad"))
            {
                this.mood = "Sad";
            }
            else
            {
                this.mood = "Invalid";
            }
            return this.mood;
        }
    }
}

