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
    }
}
