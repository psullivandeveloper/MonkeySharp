namespace MonkeyCore;

public class ReturnStatement : Statement
{
    private Token _token;
    private Expression ReturnValue;
    

    public ReturnStatement(Token token)
    {
        _token = token;
    }
    public override string TokenLiteral()
    {
        return this._token.Literal;
    }

    public override Node StatementNode()
    {
        throw new NotImplementedException();
    }
}