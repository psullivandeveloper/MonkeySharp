namespace MonkeyCore;

public class Identifier : Expression
{
    public Token _token;
    public string Value;

    public Identifier(Token token, string value)
    {
        _token = token;
        Value = value;
    }
    public override string TokenLiteral()
    {
        return _token.Literal;
    }

    public override string String()
    {
        return Value;
    }

    public override Node ExpressionNode()
    {
        throw new NotImplementedException();
    }
}