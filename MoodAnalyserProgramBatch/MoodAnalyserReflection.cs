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
    }
}
