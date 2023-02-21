using MoodAnalyserProgramBatch;
namespace MoodAnalyserProgramTest
{
    [TestClass]
    public class UnitTest1
    {
        [DataRow ("I am in a Sad mood", "Sad")] //Uc1.1 Given Sad Mood And return Sad
        [DataRow("I am in a Any mood", "Happy")] //Uc1.2 Given any Mood and return Happy 
        [DataRow(null,"Happy")] //Uc2.1 Given Null value and return Happy
        [TestMethod]
        public void GivenSadMood_whenAnalyser_ReturnTheSadMessage_Method(string message,string expect)
        {
            //act
            MoodAnalyser analyser = new MoodAnalyser(message);
            string result = analyser.CheckMoodAnalyser();
            Assert.AreEqual(expect, result);
        }
    }
}