using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestProcessing_1
{
    internal class Program
    {
        // Main entry point: asks for a filename, reads the file, counts word occurrences, and prints results.
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the filename to process:");
            var filePath = Console.ReadLine();

            // Check if the file exists before trying to read
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Error: The file '{filePath}' does not exist.");
                return;
            }

            string[] lines;
            try
            {
                lines = File.ReadAllLines(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not read the file: {ex.Message}");
                return;
            }

            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            for (int i = 0; i < lines.Length; i++)
            {
                var cleanedLine = Regex.Replace(lines[i], @"[^\w\s]", "").ToLower();
                var words = cleanedLine.Split(' ');
                for (int j = 0; j < words.Length; j++)
                {
                    var word = words[j];
                    if (word != "")
                    {
                        if (wordCounts.ContainsKey(word))
                            wordCounts[word] = wordCounts[word] + 1;
                        else
                            wordCounts.Add(word, 1);
                    }
                }
            }
            Console.WriteLine("Processing complete!");
            foreach (var entry in wordCounts)
            {
                Console.WriteLine(entry.Key + ": " + entry.Value);
            }
            Console.WriteLine("Unique words = " + wordCounts.Count);
            Console.ReadKey();
        }
    }
}
