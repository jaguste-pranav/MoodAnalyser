using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    public class AnalyseMood
    {
        string mood = "";
        public AnalyseMood(string inputMessage)
        {
            this.mood = inputMessage;
        }

        public AnalyseMood()
        {
            this.mood = "";
        }
        public string analysemood()
        {

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
                try
                {
                    throw new Exception();
                }
                catch (Exception c)
                {
                    this.mood = "Happy";
                }
            }
            return this.mood;
        }
    }
}
