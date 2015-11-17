namespace Task05.StringCountConsoleClient
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var client = new StringCounterClient();

            string lookingFor = "day";
            string text = "monday, tuesday, wednesday... firday";
            int count = client.FindWordOccurance(text, lookingFor);

            Console.WriteLine("The word {0} contains {1} times.", lookingFor, count);
        }
    }
}
