namespace MonkeyCore;

public class Parser
{
    private Lexer l;
    private Token curToken;
    private Token peekToken;
    private List<string> errors = new List<string>();

    public Parser(Lexer lexer)
    {
        l = lexer;
        this.NextToken();
        this.NextToken();

    }

    public List<string> Errors()
    {
        return errors;
    }

    public void PeekError(TokenType tokenType)
    {
        errors.Add($"Expected next token to be {tokenType}, but instead got {this.peekToken.TokenType}");
    }

    public void NextToken()
    {
        this.curToken = this.peekToken;
        this.peekToken = this.l.NextToken();
    }

    public MonkeyProgram ParseProgram()
    {
        var program = new MonkeyProgram();
        while (this.curToken.TokenType != TokenType.EOF)
        {
            var stmt = this.ParseStatement();
            if (stmt != null)
            {
                program.Statements.Add(stmt);
            }
            this.NextToken();
        }
        return program;
    }

    private Statement ParseStatement()
    {
        switch(this.curToken.TokenType)
        {
            case(TokenType.RETURN):
                return this.ParseReturnStatement();
                break;
            case(TokenType.LET):
                return this.ParseLetStatement();
                break;
            default:
                return null;
        }
    }

    private Statement ParseReturnStatement()
    {
        var stmt = new ReturnStatement(this.curToken);
        this.NextToken();
        
        while (!this.curTokenIs(TokenType.SEMICOLON))
        {
            this.NextToken();
        }
        return stmt;
    }

    private LetStatement ParseLetStatement()
    {
        var stmt = new LetStatement(this.curToken);
        if (!this.expectPeek(TokenType.IDENT))
        {
            return null;
        }

        var token = this.curToken;
        //this line is going to get moved to after assign once we start grabbing the stuff before the semicolon. Actually the test probably changes
        stmt.Name = new Identifier(this.curToken, this.curToken.Literal);
        if (!this.expectPeek(TokenType.ASSIGN))
        {
            return null;
        }

        while (!this.curTokenIs(TokenType.SEMICOLON))
        {
            this.NextToken();
        }

        return stmt;
    }

    public bool curTokenIs(TokenType tokenType)
    {
        return this.curToken.TokenType == tokenType;
    }

    public bool peekTokenIs(TokenType tokenType)
    {
        return this.peekToken.TokenType == tokenType;
    }

    public bool expectPeek(TokenType tokenType)
    {
        if(this.peekTokenIs(tokenType))
        {
            this.NextToken();
            return true;
        }
        else
        {
            this.PeekError(tokenType);
            return false;
        }
    }

}