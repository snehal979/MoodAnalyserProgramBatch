using MoodAnalyserProgramBatch;
using System.ComponentModel;

namespace MoodAnalyserProgramTest
{
    [TestClass]
    public class UnitTest1
    { 
        /// <summary>
        /// Exception Uc1,Uc2,Uc3
        /// </summary>
        /// <param name="message"></param>
        /// <param name="expect"></param>
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
        /// <summary>
        /// Reflrction Uc4
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructorName"></param>
        [TestCategory("Reflection")]
        [DataRow("MoodAnalyserProgramBatch.MoodAnalyser", "MoodAnalyser")] //UC4.1Check two object is equal or not
        [TestMethod]
        public void GivenMoodAnalyserClassName_ReturnMoodAnalyserObjectoOfThatClass(string className,string constructorName)
        {
             object expected = new MoodAnalyser();  //Default constructor object
             object actual = MoodAnalyserReflection.CreatMoodAnalyser(className,constructorName);
            expected.Equals(actual);
        }

        [TestMethod]
        [DataRow("MoodA", "MoodAnalyser","Class not found")]  //Uc4.2 Inproper class name and throw Exception //Error
        [DataRow("MoodAnalyserProgramBatch.MoodAnalyser", "Demo","Constructor not found")] //Uc4.3 Inproper constructorName name and throw Exception//Error
        public void GivenMoodAnalyser_ImpropeName_Return_ExceptionObjectoOfThatClass(string className,string constructorName,string exceptMsg)
        {
            try
            {
               // object expected = new MoodAnalyser();  //Default constructor object
                object actual = MoodAnalyserReflection.CreatMoodAnalyser(className, constructorName);
               // expected.Equals(actual);
            }
            catch(CustomMoodAnalyserExpection ex)
            {
                Assert.AreEqual(ex.Message, exceptMsg);
            }
        }
        /// <summary>
        /// Uc 5
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructorName"></param>
        /// <param name="output"></param>
        [TestMethod]
        [DataRow("MoodAnalyserProgramBatch.MoodAnalyser", "MoodAnalyser","Happy")]
        public void GivenMoodAnalyser_ReturnObject_UsingParametrizeConstructor(string className,string constructorName,string output)
        {
            object expected = new MoodAnalyser(output);  //Parametrized Constructor
            object actual = MoodAnalyserReflection.CreatMoodAnalyser_Parametric(className, constructorName,output);
            expected.Equals(actual);
        }
    }
}