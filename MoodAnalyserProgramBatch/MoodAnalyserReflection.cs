using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyserProgramBatch
{
    public class MoodAnalyserReflection
    {
        /// <summary>
        /// UC 4-for Default constructor by passing message
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructorName"></param>
        /// <returns></returns>
        /// <exception cref="CustomMoodAnalyserExpection"></exception>
        public static object CreatMoodAnalyser(string className,string constructorName)
        {
            string pattern = @"." + constructorName +"$";
            Match result = Regex.Match(pattern, className);
            if (result.Success)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyserType = assembly.GetType(className);
                    return Activator.CreateInstance(moodAnalyserType);
                }
                catch (ArgumentNullException)
                {
                    throw new CustomMoodAnalyserExpection(CustomMoodAnalyserExpection.MoodAnalyseType.NO_SUCH_CLASS, "Class not found");
                }
            }
            else
            {
                throw new CustomMoodAnalyserExpection(CustomMoodAnalyserExpection.MoodAnalyseType.NO_SUCH_CONSTRUCTOR,"Constructor not found");
            }
        }
        /// <summary>
        ///  Uc5 for parametrised constructor by passing message
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructorName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static object CreatMoodAnalyser_Parametric(string className, string constructorName,string message)
        {
            Type type = typeof(MoodAnalyser);
            if(type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo newCont = type.GetConstructor(new[] { typeof(string) });
                    object instance = newCont.Invoke(new object[] { message });
                    return instance;
                }
                else
                {
                    throw new CustomMoodAnalyserExpection(CustomMoodAnalyserExpection.MoodAnalyseType.NO_SUCH_CONSTRUCTOR, "Constructor not found");
                }
            }
            else
            {
                throw new CustomMoodAnalyserExpection(CustomMoodAnalyserExpection.MoodAnalyseType.NO_SUCH_CLASS, "Class not found");
            }
        }
        /// <summary>
        /// Uc6 invoke Method – analyseMood
        /// </summary>
        /// <param name="message"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public static string InvokeAnalyseMoodAnalyser(string message,string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyserProgramBatch.MoodAnalyser");// class name Pass
                // making of object of constructor using parameter - method
                object moodAnalyserObject = MoodAnalyserReflection.CreatMoodAnalyser_Parametric("MoodAnalyserProgramBatch.MoodAnalyser", "MoodAnalyser", message);
                MethodInfo analyseMoodInfo = type.GetMethod(methodName);
                object mood = analyseMoodInfo.Invoke(moodAnalyserObject, null);
                return mood.ToString();
            }
            catch (NullReferenceException)
            {
                throw new CustomMoodAnalyserExpection(CustomMoodAnalyserExpection.MoodAnalyseType.NO_SUCH_METHOD, "Method not found");
            }
            
        }
        /// <summary>
        /// Uc7 Function To set the field Dyanamically Using Reflection
        /// </summary>
        /// </summary>
        /// <returns></returns>
        public static string CheckTheField(string message,string fieldName)
        {
            try
            {
                MoodAnalyser moodAnalyser = new MoodAnalyser();
                Type type = typeof(MoodAnalyser);
                FieldInfo fieldInfo = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (message == null)
                {
                    throw new CustomMoodAnalyserExpection(CustomMoodAnalyserExpection.MoodAnalyseType.NO_SUCH_NULLFIELD, "Field is not null");

                }
                fieldInfo.SetValue(moodAnalyser, message);
                return moodAnalyser.message;
            }
            catch(NullReferenceException)
            {
                throw new CustomMoodAnalyserExpection(CustomMoodAnalyserExpection.MoodAnalyseType.NO_SUCH_FIELD, "Field not found");

            }
           
        }
    }
}
