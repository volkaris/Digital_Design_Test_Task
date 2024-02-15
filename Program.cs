using System;
using System.Text;
using System.Text.RegularExpressions;
using ConsoleApp2;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Firstly type path to text that should be parsed,then type path where counted output will be created");
        
        if (args.Length != 2)
        {
            Console.WriteLine("Invalid arguments");
        }
        
        Console.OutputEncoding = Encoding.UTF8;
        IFileParser parser = new FileParser();
        parser.Parse(args[0],args[1]);
    }
}