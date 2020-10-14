using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MoodAnalyser
{
    public class MoodAnalyserFactor
    {
        private string message;
        public MoodAnalyserFactor(string message)
        {
            this.message = message;
        }
        public static object CreateMoodAnalyserDefaultConstructor(string className, string constructorName)
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

        public static object CreateMoodAnalyserParameterisedConstructor(string className, string constructorName, string message)
        {
            string pattern = @"." + constructorName + "$";
            try
            {
                Type moodAnalyserType = Type.GetType(className); 
                ConstructorInfo constructorInfo = moodAnalyserType.GetConstructor(new Type[] { typeof(string) });
                if (Regex.IsMatch(className, pattern) == false)
                {
                    throw new ExceptionMessage(ExceptionMessage.ExceptionType.NO_SUCH_METHOD, "No constructor found");
                }
                object moodAnalyser = constructorInfo.Invoke(new object[] { message });
                return moodAnalyser;
            }
            catch (NullReferenceException)
            {
                throw new ExceptionMessage(ExceptionMessage.ExceptionType.NO_SUCH_CLASS, "No class found");
            }
        }

    }
}
