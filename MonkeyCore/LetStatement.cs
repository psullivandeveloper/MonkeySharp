using System.Text;

namespace MonkeyCore;

public class LetStatement : Statement
{
    public Token _token;
    public Identifier Name;
    public Expression Value;

    public LetStatement(Token token)
    {
        _token = token;
    }
    public override string TokenLiteral()
    {

        return _token.Literal;
    }

    public override string String()
    {
        var result = new StringBuilder();
        result.Append($"{this.TokenLiteral()} ");
        result.Append($"{this.Name.String()} = ");
        if (this.Value != null)
        {
            result.Append($"{this.Value.String()};");
        }

        return result.ToString();


    }

    public override Node StatementNode()
    {
        throw new NotImplementedException();
    }

    
}