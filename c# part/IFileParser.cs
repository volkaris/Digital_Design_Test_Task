using ConsoleApp2.ParsingResult;

namespace ConsoleApp2;

public interface IFileParser
{
    public ParserResult Parse(string pathToFile, string pathToCountedFile);
}