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
            try
            {
                if (this.mood == "")
                {
                    throw new ExceptionMessage(ExceptionMessage.TypeOfException.EMPTY_MESSAGE, "Mood cannot be EMPTY");
                }

                if (this.mood.ToLower().Contains("happy") || this.mood.ToLower().Contains("any"))
                {
                    this.mood = "Happy";
                }

                else if (this.mood.ToLower().Contains("sad"))
                {
                    this.mood = "Sad";
                }
            }
            catch(NullReferenceException)
            {
                throw new ExceptionMessage(ExceptionMessage.TypeOfException.EMPTY_MESSAGE, "Mood cannot be NULL");
            }
            return this.mood;
        }
    }
}
