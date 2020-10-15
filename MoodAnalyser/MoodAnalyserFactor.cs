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
        public static string InvokeAnalyseMood(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyser.AnalyseMood");
                object AnalyseMoodObject = MoodAnalyserFactor.CreateMoodAnalyserParameterisedConstructor("MoodAnalyser.AnalyseMood", "AnalyseMood", message);
                MethodInfo method = type.GetMethod(methodName);
                object invokedMood = method.Invoke(AnalyseMoodObject, null);
                return invokedMood.ToString();
            }
            catch (NullReferenceException e)
            {
                throw new ExceptionMessage(ExceptionMessage.ExceptionType.NO_SUCH_METHOD, "No method found");
            }
        }

        public static string SetField(string message, string fieldName)
        {
            try
            {
                Type moodAnalyserType = typeof(AnalyseMood);
                object moodAnalyser = CreateMoodAnalyserDefaultConstructor(moodAnalyserType.FullName, moodAnalyserType.Name);

                FieldInfo fieldInfo = moodAnalyserType.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
                if (message.Equals(""))
                {
                    throw new ExceptionMessage(ExceptionMessage.ExceptionType.NO_SUCH_FIELD, "Mood cannot be NULL");
                }
                fieldInfo.SetValue(moodAnalyser, message);
                return fieldInfo.GetValue(moodAnalyser).ToString();

            }
            catch (NullReferenceException)
            {
                throw new ExceptionMessage(ExceptionMessage.ExceptionType.NO_SUCH_FIELD, "Field not found");
            }
        }

    }
}
