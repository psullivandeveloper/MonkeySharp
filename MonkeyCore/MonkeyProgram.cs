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
}