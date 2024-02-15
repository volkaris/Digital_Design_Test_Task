using System.Text;
using System.Text.RegularExpressions;
using ConsoleApp2;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        IFileParser parser = new FileParser();
        parser.Parse("text.txt","countedText.txt");
    }
}