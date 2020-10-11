using System;

namespace MoodAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mood Analyser Application");

            AnalyseMood mood = new AnalyseMood("juhtgrf");

            string resultMood = mood.analysemood();
            Console.WriteLine("The Mood is " + resultMood);
        }
    }
}
