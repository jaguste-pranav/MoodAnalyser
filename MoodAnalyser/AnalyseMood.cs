using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    public class AnalyseMood
    {
        private string message;
        public AnalyseMood(string message)
        {
            this.message = message;
        }
        public AnalyseMood()
        {
        }
        public string analysemood()
        {
            string mood;
            try
            {   
                if (this.message.Equals(string.Empty))
                {
                    throw new ExceptionMessage(ExceptionMessage.ExceptionType.EMPTY_MESSAGE, "Mood cannot be empty");
                }
                if (this.message.ToLower().Contains("sad"))
                {
                    mood = "Sad";
                }
                else
                {
                    mood = "Happy";
                }
            }
            catch (NullReferenceException)
            {
                throw new ExceptionMessage(ExceptionMessage.ExceptionType.NULL_MESSAGE, "Mood cannot be null");
            }

            return mood;
        }
    }
}
