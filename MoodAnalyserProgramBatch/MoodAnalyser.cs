using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserProgramBatch
{
    public class MoodAnalyser
    {
        //Default constructor
        public MoodAnalyser()
        {

        }
        /// <summary>
        /// Refactor code 
        /// </summary>
        public string message;
        public MoodAnalyser(string message)
        {
            this.message=message;
        }
        /// <summary>
        /// Uc1 Given Message and Return it(Method)
        /// </summary>
        /// <returns></returns>
        public string CheckMoodAnalyser()
        {
            try
            {
                if(this.message.Equals(string.Empty))
                    throw new CustomMoodAnalyserExpection(CustomMoodAnalyserExpection.MoodAnalyseType.EMPTY_MOOD, "Mood is Empty");
                if (this.message.ToLower().Contains("sad"))
                    return "Sad";
                else
                    return "Happy";
            }
            catch (NullReferenceException)
            {
                throw new CustomMoodAnalyserExpection(CustomMoodAnalyserExpection.MoodAnalyseType.NULL_MOOD,"Mood is Null");
            }

        }
    }
}