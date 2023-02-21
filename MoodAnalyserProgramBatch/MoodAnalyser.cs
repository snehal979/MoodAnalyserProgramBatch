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
        /// Refactor code 
        /// </summary>
        string message;
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
                if (this.message.ToLower().Contains("sad"))
                {
                    return "Sad";
                }
                else
                {
                    return "Happy";
                }
            } 
            catch (NullReferenceException)
            {
                return "Happy";
            }
           
        }
    }       
}
