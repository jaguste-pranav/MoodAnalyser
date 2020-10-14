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
        public void Given_Class_Return_AnalyseMoodObject_DefaultConstructor()
        {
            object expected = new AnalyseMood();
            object obj = MoodAnalyserFactor.CreateMoodAnalyserDefaultConstructor("MoodAnalyser.AnalyseMood", "AnalyseMood");
            Assert.AreEqual(expected.GetType(), obj.GetType());
        }

        [TestMethod]
        public void Given_Wrong_Class_Throw_Exception_DefaultConstructor()
        {
            try
            {
                object expected = new AnalyseMood();
                object obj = MoodAnalyserFactor.CreateMoodAnalyserDefaultConstructor("MoodAnalyser.AnalyseMood", "AnalyseMood");
            }
            catch (ExceptionMessage e)
            {
                Assert.AreEqual("No class found", e.Message);
            }
        }
        [TestMethod]
        public void Given_Wrong_Constructor_Throw_Exception_DefaultConstructor()
        {
            try
            {
                object expected = new AnalyseMood();
                object obj = MoodAnalyserFactor.CreateMoodAnalyserDefaultConstructor("MoodAnalyser.AnalyseMood", "AnalyseMood");
            }
            catch (ExceptionMessage e)
            {
                Assert.AreEqual("No constructor found", e.Message);
            }
        }

        [TestMethod]
        public void Given_Wrong_Class_Throw_Exception_ParameterizedConstructor()
        {
            string message = "Sad";
            try
            {
                object expected = new AnalyseMood("Sad");
                object obj = MoodAnalyserFactor.CreateMoodAnalyserParameterisedConstructor("MoodAnalyser.AnalyseMood", "AnalyseMood", message);
            }
            catch (ExceptionMessage e)
            {
                Assert.AreEqual("No class found", e.Message);
            }
        }
        [TestMethod]
        public void Given_Wrong_Constructor_Throw_Exception_ParameterizedConstructor()
        {
            string message = "Sad";
            try
            {
                object expected = new AnalyseMood("Sad");
                object obj = MoodAnalyserFactor.CreateMoodAnalyserParameterisedConstructor("MoodAnalyser.AnalyseMood", "AnalyseMood", message);
            }
            catch (ExceptionMessage e)
            {
                Assert.AreEqual("No constructor found", e.Message);
            }
        }
    }
}
