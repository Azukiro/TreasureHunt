namespace TreasureMap.Exceptions;

public class ParsingException : Exception
{
    //create excepiton ta take the line stirng[] in paramter and the type of the object that was being parsed

    public ParsingException(string[] line, Exception innerException) : base(
        $"Error parsing line: {string.Join(" ", line)}", innerException)
    {
    }
}