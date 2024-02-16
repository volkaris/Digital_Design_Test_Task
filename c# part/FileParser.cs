using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ConsoleApp2.ParsingResult;

namespace ConsoleApp2;

public class FileParser : IFileParser
{
    public ParserResult Parse(string pathToFile, string pathToCountedFile)
    {
        var file = new FileInfo(pathToFile);

        if (!file.Exists)
            return new ParserResult.Unsuccess("File doesn't exists or path is invalid");


        var wordsCounter = new Dictionary<string, uint>();

        using (var reader = new StreamReader(pathToFile, Encoding.UTF8))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                var regex = new Regex("\"|\\[|\\]|»|«|…|–|\\(|\\)|[.,:;!?\\-\\s]");

                var splittedText = regex.Split(line);

                foreach (var word in splittedText)
                {
                    if (string.IsNullOrWhiteSpace(word)) continue;

                    if (wordsCounter.ContainsKey(word))
                        wordsCounter[word]++;
                    else
                        wordsCounter.Add(word, 1);
                }
            }

            using (var pathToNewFile = new StreamWriter(pathToCountedFile, false, Encoding.UTF8))
            {
                foreach (var wordNumberOfOccurences in wordsCounter.OrderByDescending(counter => counter.Value))
                    pathToNewFile.WriteLine(wordNumberOfOccurences.Key + " - " + wordNumberOfOccurences.Value);
            }
        }

        return new ParserResult.Success();
    }
}