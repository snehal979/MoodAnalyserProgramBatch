using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserProgramBatch
{
    public class MoodAnalyserReflection
    {
        public static object CreatMoodAnalyser(string className,string constructorName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type moodAnalyserType = assembly.GetType(className);
            return Activator.CreateInstance(moodAnalyserType);
        }
    }
}
