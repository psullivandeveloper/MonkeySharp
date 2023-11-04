using System.Text;

namespace MonkeyCore;

public class MonkeyProgram : Node
{
    public List<Statement> Statements = new List<Statement>();


    public override string TokenLiteral()
    {
        if (Statements.Count > 0)
        {
            return this.Statements[0].TokenLiteral();
        }
        else
        {
            return "";
        }
    }

    public override string String()
    {
        StringBuilder result = new StringBuilder();
        foreach (var statement in Statements)
        {
            result.Append($"{statement.String()}\r\n");
        }

        return result.ToString();
    }
}