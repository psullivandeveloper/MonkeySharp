using MonkeyCore;

namespace MonkeySharp;

public class Repl
{
    private const string prompt = ">> ";
    public static void Start()
    {
        bool keepRunning = true;

        while (keepRunning)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();
            if (input.Trim() == string.Empty)
            {
                keepRunning = false;
            }
            else
            {
                var lexer = new Lexer(input);
                var token = lexer.NextToken();
                while (token.TokenType != TokenType.EOF)
                {
                    Console.WriteLine($"{token.TokenType} :: {token.Literal}");
                    token = lexer.NextToken();
                }
            }
        }

    }
}