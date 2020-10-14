using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MoodAnalyser
{
    class MoodAnalyserFactor
    {
        private string message;
        public MoodAnalyserFactor(string message)
        {
            this.message = message;
        }
        public static object CreateMoodAnalyser(string className, string constructorName)
        {

            string pattern = @"." + constructorName + "$";
            try
            {
                Type moodAnalyserType = Type.GetType(className);
                object moodAnalyser = Activator.CreateInstance(moodAnalyserType);

                if (Regex.IsMatch(className, pattern) == false)
                {
                    throw new ExceptionMessage(ExceptionMessage.ExceptionType.NO_SUCH_METHOD, "No constructor found");
                }
                return moodAnalyser;
            }
            catch (ArgumentNullException)
            {
                throw new ExceptionMessage(ExceptionMessage.ExceptionType.NO_SUCH_CLASS, "No class found");
            }
        }
    }
}
