using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;

namespace MoodAnalyseTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1_1()
        {
            string inputMood = "I am in Happy Mood";
            AnalyseMood mood = new AnalyseMood(inputMood);
            string moodOutput = mood.analysemood();

            Assert.AreEqual(moodOutput, "Happy");
        }

        [TestMethod]
        public void TestMethod1_2()
        {
            string inputMood = "I am in Sad Mood";
            AnalyseMood mood = new AnalyseMood(inputMood);
            string moodOutput = mood.analysemood();

            Assert.AreEqual(moodOutput, "Sad");
        }

         [TestMethod]
        public void TestMethod2()
        {
            string inputMood = "I am in Sad Mood";
            AnalyseMood mood = new AnalyseMood(inputMood);
            string moodOutput = mood.analysemood();

            Assert.AreEqual(moodOutput, "Sad");
        }

        [TestMethod]
        public void Given_Empty_String_Then_Throw_Custom_Exception()
        {
            try
            {
                string message = "";
                AnalyseMood mood = new AnalyseMood(message);
                string moodOutput = mood.analysemood();
            }
            catch (ExceptionMessage e)
            {
                Assert.AreEqual("Mood cannot be empty", e.Message);
            }
        }

        [TestMethod]
        public void Given_NULL_Then_Throw_Custom_Exception()
        {
            try
            {
                string message = null;
                AnalyseMood mood = new AnalyseMood(message);
                string moodOutput = mood.analysemood();
            }
            catch (ExceptionMessage e)
            {
                Assert.AreEqual("Mood cannot be null", e.Message);
            }
        }

        [TestMethod]
        public void MoodAnalyserClassName_Should_Return_MoodAnalyserObject()
        {
            object expected = new AnalyseMood();
            object obj = MoodAnalyserFactory.CreateMoodAnalyser("MoodAnalyser.AnalyseMood", "AnalyseMood");
            Assert.AreEqual(expected.GetType(), obj.GetType());
        }
        [TestMethod]
        public void ImproperClassName_Should_Throw_MoodAnalysisException()
        {
            try
            {
                object expected = new AnalyseMood();
                object obj = MoodAnalyserFactory.CreateMoodAnalyser("MoodAnalyser.AnalyseMood", "AnalyseMood");
            }
            catch (ExceptionMessage e)
            {
                Assert.AreEqual("No class found", e.Message);
            }
        }
        [TestMethod]
        public void ImproperConstructorName_Should_Throw_MoodAnalysisException()
        {
            try
            {
                object expected = new AnalyseMood();
                object obj = MoodAnalyserFactory.CreateMoodAnalyser("MoodAnalyser.AnalyseMood", "AnalyseMood");
            }
            catch (ExceptionMessage e)
            {
                Assert.AreEqual("No constructor found", e.Message);
            }
        }
    }
}
