namespace MoodAnalyserProgramBatch
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Mood Analyser Program");
            MoodAnalyser moodAnalyser = new MoodAnalyser("Iam in Happy mood");
            Console.WriteLine(moodAnalyser.CheckMoodAnalyser());
            Console.ReadLine();
        }
    }
}
