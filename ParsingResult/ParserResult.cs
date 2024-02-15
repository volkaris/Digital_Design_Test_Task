namespace ConsoleApp2.ParsingResult;

public abstract record ParserResult
{
    public sealed record Success() : ParserResult;
    public sealed record Unsuccess(string failReason) : ParserResult;
}