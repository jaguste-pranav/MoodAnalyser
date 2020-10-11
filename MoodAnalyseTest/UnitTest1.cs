using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;

namespace MoodAnalyseTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string inputMood = "I am in Sad Mood";
            AnalyseMood mood = new AnalyseMood();
            string moodOutput = mood.analysemood(inputMood);

            Assert.AreEqual(moodOutput, "Sad");
        }
    }
}
