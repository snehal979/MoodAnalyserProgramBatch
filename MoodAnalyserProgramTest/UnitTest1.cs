using MoodAnalyserProgramBatch;
namespace MoodAnalyserProgramTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow ("I am in a Sad mood", "Sad")]
        public void GivenSadMood_whenAnalyser_ReturnTheSadMessage_Method(string message,string expect)
        {
            //act
            MoodAnalyser analyser = new MoodAnalyser();
            string result = analyser.CheckMoodAnalyser(message);
            Assert.AreEqual(expect, result);
        }
    }
}