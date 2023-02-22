using MoodAnalyserProgramBatch;
using System.ComponentModel;

namespace MoodAnalyserProgramTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestCategory("Exception Handling")]
        [DataRow("I am in a Sad mood", "Sad")] ////Uc1.1 Given Sad Mood And return Sad
        [DataRow("I am in a Any mood", "Happy")] ////Uc1.2 Given any Mood and return Happy 
        //// [DataRow(null,"Happy")] //Uc2.1 Given Null value and return Happy
        [DataRow(null, "Mood is Null")] ////Uc3.1 Given message is Null return Exception
        [DataRow("", "Mood is Empty")] ////Uc3.2 Given message is Empty return Exception

        [TestMethod]
        public void ExceptionGivenMood_whenAnalyser_ReturnTheSadMessage_Method(string message, string expect)
        {
            try
            {
                MoodAnalyser analyser = new MoodAnalyser(message);
                string result = analyser.CheckMoodAnalyser();
                Assert.AreEqual(expect, result);
            } catch (CustomMoodAnalyserExpection ex)
            {
                Assert.AreEqual(ex.Message, expect);
            }
            
        }
        [TestCategory("Reflection")]
        [TestMethod]
        public void GivenMoodAnalyserClassName_ReturnMoodAnalyserObjectoOfThatClass()
        {
            object expected = new MoodAnalyser();  //Default constructor object
            object actual = MoodAnalyserReflection.CreatMoodAnalyser("MoodAnalyserProgramBatch.MoodAnalyser", "MoodAnalyser");
            expected.Equals(actual);
        }
    }
}