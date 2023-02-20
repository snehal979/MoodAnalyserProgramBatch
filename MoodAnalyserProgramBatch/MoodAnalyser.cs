using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserProgramBatch
{
    public class MoodAnalyser
    { 
        /// <summary>
        /// Uc1 Given Message and Return it(Method)
        /// </summary>
        /// <returns></returns>
        public string CheckMoodAnalyser(string message)
        {
            if (message.ToLower().Contains("sad"))
            {
                return "Sad";
            }
            else
            {
                return "Happy";
            }
        }
    }       
}
