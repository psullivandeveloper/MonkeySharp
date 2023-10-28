namespace MonkeyCore;

public class Token
{
    public TokenType TokenType;
    public string Literal;

    public const string ILLEGAL = "ILLEGAL";
    public const string EOF = "EOF";
    public const string INT = "INT";
    public const string ASSIGN = "=";
    public const string PLUS = "+";
    public const string COMMA = ",";
    public const string SEMICOLON = ";";
    public const string LPAREN = "(";
    public const string RPAREN = ")";
    public const string LBRACE = "{";
    public const string RBRACE = "}";
    public const string FUNCTION = "FUNCTION";
    public const string LET = "LET";

    public Token(TokenType tokenType, string literal)
    {
        TokenType = tokenType;
        Literal = literal;

    }

}

public enum TokenType
{
    ILLEGAL,
    EOF,
    INT,
    ASSIGN,
    PLUS,
    COMMA,
    SEMICOLON,
    LPAREN,
    RPAREN,
    LBRACE,
    RBRACE,
    FUNCTION,
    LET,
}