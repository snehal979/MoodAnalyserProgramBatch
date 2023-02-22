using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MoodAnalyserProgramBatch.CustomMoodAnalyserExpection;

namespace MoodAnalyserProgramBatch
{
    public class CustomMoodAnalyserExpection:Exception
    {
        public enum MoodAnalyseType
        {
            EMPTY_MOOD,
            NULL_MOOD,
            NO_SUCH_CLASS
        }
        public MoodAnalyseType type; //variable for enum
        public CustomMoodAnalyserExpection(MoodAnalyseType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
