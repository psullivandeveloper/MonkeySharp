namespace MonkeyCore;

public class Lexer
{
    private string _input;
    private int position;
    private int readPosition;
    private char ch;

    public Lexer(string input)
    {
        _input = input;
        this.ReadChar();
        
    }

    private void ReadChar()
    {
        if(this.readPosition >= _input.Length)
        {
            this.ch = '\0';
        }
        else
        {
            this.ch = _input[readPosition];
        }

        this.position = this.readPosition;
        this.readPosition += 1;
    }

    public Token NextToken()
    {
        Token result;
        switch (this.ch)
        {
            case '=':
                result = new Token(TokenType.ASSIGN, "=");
                break;
            case ';':
                result = new Token(TokenType.SEMICOLON, ";");
                break;
            case '(':
                result = new Token(TokenType.LPAREN, "(");
                break;
            case ')':
                result = new Token(TokenType.RPAREN, ")");
                break;
            case '{':
                result = new Token(TokenType.LBRACE, "{");
                break;
            case '}':
                result = new Token(TokenType.RBRACE, "}");
                break;
            case ',':
                result = new Token(TokenType.COMMA, ",");
                break;
            case '+':
                result = new Token(TokenType.PLUS, "+");
                break;
            default:
                result = new Token(TokenType.EOF, "");
                break;
        }
        this.ReadChar();
        return result;

    }
}