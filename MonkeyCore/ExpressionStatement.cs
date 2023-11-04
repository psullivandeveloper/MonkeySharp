using System.Text;

namespace MonkeyCore;

public class ExpressionStatement : Statement
{
    private Token _token;
    private Expression Expression;

    public ExpressionStatement(Token token)
    {
        _token = token;
    }
    public override string TokenLiteral()
    {
        return this._token.Literal;
    }

    public override string String()
    {
        
        if (this.Expression != null)
        {
            return this.Expression.String();

        }

        return "";


    }

    public override Node StatementNode()
    {
        throw new NotImplementedException();
    }
}