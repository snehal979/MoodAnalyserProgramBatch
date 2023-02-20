using MoodAnalyserProgramBatch;
namespace MoodAnalyserProgramTest
{
    [TestClass]
    public class UnitTest1
    {
        [DataRow ("I am in a Sad mood", "Sad")] //Uc1.1 test case 
        [DataRow("I am in a Any mood", "Happy")] //Uc1.2 test case 
        [TestMethod]
        public void GivenSadMood_whenAnalyser_ReturnTheSadMessage_Method(string message,string expect)
        {
            //act
            MoodAnalyser analyser = new MoodAnalyser();
            string result = analyser.CheckMoodAnalyser(message);
            Assert.AreEqual(expect, result);
        }
    }
}