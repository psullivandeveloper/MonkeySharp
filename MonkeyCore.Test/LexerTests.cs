namespace MonkeyCore.Test;

public class LexerTests
{
    private string input;
    [SetUp]
    public void Setup()
    {
        input = "=+(){},;";
    }

    [Test]
    public void Test1()
    {
        List<Token> output = new List<Token>
        {
            new Token(TokenType.ASSIGN, "="),
            new Token(TokenType.PLUS, "+"),
            new Token(TokenType.LPAREN, "("),
            new Token(TokenType.RPAREN, ")"),
            new Token(TokenType.LBRACE, "{"),
            new Token(TokenType.RBRACE, "}"),
            new Token(TokenType.COMMA, ","),
            new Token(TokenType.SEMICOLON, ";"),
        };
        var lexer = new Lexer(input);
        foreach (var token in output)
        {
            var lexerToken = lexer.NextToken();
            Assert.That(lexerToken.TokenType, Is.EqualTo(token.TokenType));
            Assert.That(lexerToken.Literal, Is.EqualTo(token.Literal));
        }
    }
}