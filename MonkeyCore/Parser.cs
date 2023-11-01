namespace MonkeyCore;

public class Parser
{
    private Lexer l;
    private Token curToken;
    private Token peekToken;

    public Parser(Lexer lexer)
    {
        l = lexer;
        this.NextToken();
        this.NextToken();

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
            case(TokenType.LET):
                return this.ParseLetStatement();
                break;
            default:
                return null;
        }
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
            return false;
        }
    }

}