namespace MonkeyCore;

public class LetStatement : Statement
{
    public Token _token;
    public Identifier Name;
    public object Expression;

    public LetStatement(Token token)
    {
        _token = token;
    }
    public override string TokenLiteral()
    {

        return _token.Literal;
    }

    public override Node StatementNode()
    {
        throw new NotImplementedException();
    }
}