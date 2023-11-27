using System.Text.RegularExpressions;

namespace softUniFund_FinalExamPrep2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var regex = @"(::|\*\*)[A-Z][a-z]{2,}\1";
            var str = Console.ReadLine();

            List<string> emojis = new List<string>();
            List<string> coolEmojis = new List<string>();

            int coolThreshold = 1;
            foreach(char ch in str)
            {
                if(char.IsDigit(ch)) coolThreshold *= ch - '0';
            }

            MatchCollection mc = Regex.Matches(str, regex);
            foreach(Match m in mc)
            {
                int coolness = 0;
                for(int i = 2; i < m.Value.Length - 2; i++) coolness += m.Value[i];
                emojis.Add(m.Value);
                if(coolness > coolThreshold) coolEmojis.Add(m.Value);
            }

            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{emojis.Count} emojis found in the text. The cool ones are:");
            foreach(string coolEmoji in coolEmojis) Console.WriteLine(coolEmoji);
        }
    }
}