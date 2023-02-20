namespace MoodAnalyserProgramBatch
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Mood Analyser Program");
            MoodAnalyser moodAnalyser = new MoodAnalyser();
            Console.WriteLine(moodAnalyser.CheckMoodAnalyser("Iam in Happy mood"));
            Console.ReadLine();
        }
    }
}
