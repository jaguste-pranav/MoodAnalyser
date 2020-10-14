using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Reflection;

namespace MoodAnalyser
{
    public class MoodAnalyserFactory
    {
        private string message;
        public MoodAnalyserFactory(string message)
        {
            this.message = message;
        }

        public static object CreateMoodAnalyser(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }

                catch (ArgumentNullException)
                {
                    throw new ExceptionMessage(ExceptionMessage.ExceptionType.NO_SUCH_CLASS, "Class not found");
                }
            }
            else
            {
                throw new ExceptionMessage(ExceptionMessage.ExceptionType.NO_SUCH_METHOD, "Constructor is not found");
            }
        }
    }
}
