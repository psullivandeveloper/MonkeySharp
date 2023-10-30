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

    private string ReadIdentifier()
    {
        var position = this.position;
        while (char.IsLetter(ch))
        {
            this.ReadChar();
        }

        return this._input.Substring(position, this.position - position);
    }
    private string ReadNumber()
    {
        var position = this.position;
        while (char.IsDigit(ch))
        {
            this.ReadChar();
        }

        return this._input.Substring(position, this.position - position);
    }

    public char PeekChar()
    {
        if (readPosition >= _input.Length)
        {
            return '\0';
        }
        else
        {
            return _input[readPosition];
        }
    }

    public TokenType Keywords(string identifier)
    {
        switch (identifier)
        {
            case "fn":
                return TokenType.FUNCTION;
                break;
            case "let":
                return TokenType.LET;
                break;
            case "true":
                return TokenType.TRUE;
                break;
            case "false":
                return TokenType.FALSE;
            case "if":
                return TokenType.IF;
                break;
            case "else":
                return TokenType.ELSE;
                break;
            case "return":
                return TokenType.RETURN;
                break;
            default:
                return TokenType.IDENT;
        }
    }

    private void SkipWhiteSpace()
    {
        while (ch == ' ' || ch == '\t' || ch == '\n' || ch == '\r')
        {
            this.ReadChar();
        }
        
    }

    public Token NextToken()
    {
        bool readNextChar = true;
        this.SkipWhiteSpace();
        Token result;
        switch (this.ch)
        {
            case '=':
                if (PeekChar() == '=')
                {
                    var ch = this.ch;
                    ReadChar();
                    result = new Token(TokenType.EQ, "==");
                }
                else
                {
                    result = new Token(TokenType.ASSIGN, "=");
                }
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
            case '!':
                if (PeekChar() == '=')
                {
                    var ch = this.ch;
                    ReadChar();
                    result = new Token(TokenType.NOT_EQ, "!=");
                }
                else
                {
                    result = new Token(TokenType.BANG, "!");
                }
                
                break;
            case '-':
                result = new Token(TokenType.MINUS, "-");
                break;
            case '/':
                result = new Token(TokenType.SLASH, "/");
                break;
            case '*':
                result = new Token(TokenType.ASTERISK, "*");
                break;
            case '<':
                result = new Token(TokenType.LT, "<");
                break;
            case '>':
                result = new Token(TokenType.GT, ">");
                break;
            case '\0':
                result = new Token(TokenType.EOF, "");
                break;
            default:
                /*
         * !-/*5;
        5 < 10 > 5;
         */
                if (char.IsLetter(ch))
                {
                    var literal = this.ReadIdentifier();
                    result = new Token(this.Keywords(literal), literal);
                    readNextChar = false;
                }
                else if (char.IsDigit(ch))
                {
                    var literal = this.ReadNumber();
                    result = new Token(TokenType.INT, literal);
                    readNextChar = false;
                }
                else
                {
                    result = new Token(TokenType.ILLEGAL, ch.ToString());
                }
                break;
                
                
        }

        if (readNextChar)
        {
            this.ReadChar();
        }
        
        return result;

    }
}