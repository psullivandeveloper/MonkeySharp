﻿using System.Text;

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

    public override string String()
    {
        var result = new StringBuilder();
        result.Append($"{this.TokenLiteral()} ");
        if (this.ReturnValue != null)
        {
            result.Append(this.ReturnValue.String());
        }

        return result.ToString();
    }

    public override Node StatementNode()
    {
        throw new NotImplementedException();
    }
}