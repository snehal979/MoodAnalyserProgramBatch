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
            }
            catch (CustomMoodAnalyserExpection ex)
            {
                Assert.AreEqual(ex.Message, expect);
            }
        }
        /// <summary>
        /// Reflrction Uc4 for Default constructor by passing message
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructorName"></param>
        [TestCategory("Reflection")]
        [DataRow("MoodAnalyserProgramBatch.MoodAnalyser", "MoodAnalyser")] //UC4.1Check two object is equal or not
        [TestMethod]
        public void GivenMoodAnalyserClassName_ReturnMoodAnalyserObjectoOfThatClass(string className, string constructorName)
        {
            object expected = new MoodAnalyser();  //Default constructor object
            object actual = MoodAnalyserReflection.CreatMoodAnalyser(className, constructorName);
            expected.Equals(actual);
        }

        [TestMethod]
        [DataRow("MoodA", "MoodAnalyser", "Class not found")]  //Uc4.2 Inproper class name and throw Exception //Error
        [DataRow("MoodAnalyserProgramBatch.MoodAnalyser", "Demo", "Constructor not found")] //Uc4.3 Inproper constructorName name and throw Exception//Error
        public void GivenMoodAnalyser_ImpropeName_Return_ExceptionObjectoOfThatClass(string className, string constructorName, string exceptMsg)
        {
            try
            {
                // object expected = new MoodAnalyser();  //Default constructor object
                object actual = MoodAnalyserReflection.CreatMoodAnalyser(className, constructorName);
                // expected.Equals(actual);
            }
            catch (CustomMoodAnalyserExpection ex)
            {
                Assert.AreEqual(ex.Message, exceptMsg);
            }
        }
        /// <summary>
        /// Uc 5for parametrised constructor by passing message
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructorName"></param>
        /// <param name="output"></param>

        [TestMethod]
        [DataRow("MoodAnalyserProgramBatch.MoodAnalyser", "MoodAnalyser", "Happy")] //Uc 5.1Check two object is equal or not
        public void GivenMoodAnalyser_ReturnObject_UsingParametrizeConstructor(string className, string constructorName, string output)
        {
            object expected = new MoodAnalyser(output);  //Parametrized Constructor
            object actual = MoodAnalyserReflection.CreatMoodAnalyser_Parametric(className, constructorName, output);
            expected.Equals(actual);
        }

        [TestMethod]
        [DataRow("Analyser", "MoodAnalyser", "Happy","Class not found")] //Uc 5.2 Inproper class name and throw Exception //Error
        [DataRow("MoodAnalyserProgramBatch.MoodAnalyser", "Demo", "Happy","Constructor not found")] ////Uc 5.3 Inproper constructorName name and throw Exception//Error
        public void GivenMoodAnalyserInproperName_ReturnObject_UsingParametrizeConstructor(string className, string constructorName, string message, string output)
        {
            try
            {
                object actual = MoodAnalyserReflection.CreatMoodAnalyser_Parametric(className, constructorName, output);
            }
            catch (CustomMoodAnalyserExpection ex)
            {
                Assert.AreEqual(ex.Message, output);
            }
        }

        /// <summary>
        /// Uc6 invoke Method – analyseMood
        /// </summary>
        /// <param name="message"></param>
        /// <param name="methodName"></param>
        /// <param name="expected"></param>
        [TestMethod]
        [DataRow("I am in Happy Mood", "CheckMoodAnalyser","Happy")] //Uc6.1 In proper MethodPass Happy message and return  
        [DataRow("I am in Happy Mood", "Demo", "Happy")] //Uc6.2 In Improper Method Pass and return Exception 
        public void GivenHappyMoodAnalyser_ReturnHappyMessage(string message,string methodName, string expected)
        {
            try
            {
                string actual = MoodAnalyserReflection.InvokeAnalyseMoodAnalyser(message, methodName); //message : "Happy;methodName:Constructor name
                Assert.AreEqual(expected, actual);
            }
            catch(CustomMoodAnalyserExpection ex)
            {
                Assert.AreEqual(ex.Message, "Method not found");
            }
        }

        /// <summary>
        /// Uc 7 Function To set the field Dyanamically Using Reflection 
        /// </summary>
        [TestMethod]
        [DataRow("Happy","message","Happy")] //Uc7.1 Set Happy Message wit Reflector Should Return HAPPY
        public void GiveHappy_ReturnHappy_FieldSet(string message ,string fieldName,string output)
        {
            string actual = MoodAnalyserReflection.CheckTheField(message,fieldName);
            Assert.AreEqual(output,actual);
        }
    }
}