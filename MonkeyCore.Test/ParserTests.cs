namespace MonkeyCore.Test;


public class ParserTests
{
    private string input;
    private Dictionary<string, string> statementChecks = new Dictionary<string, string>();
    [SetUp]
    public void Setup()
    {
        input = """
                let x = 5;
                let y = 10;
                let foobar = 838383;
                """;
        /*statementChecks.Add("x", "5");
        statementChecks.Add("y", "10");
        statementChecks.Add("foobar", "838383");*/
        //Temporarily checking to see that the names are right, we'll be grabbing the values later if you look at the code.
        statementChecks.Add("x", "x");
        statementChecks.Add("y", "y");
        statementChecks.Add("foobar", "foobar");
    }
    

    [Test]
    public void TestNextToken()
    {
        var l = new Lexer(input);
        var p = new Parser(l);
        var program = p.ParseProgram();
        Assert.That(program, Is.Not.Null);
        Assert.That(program.Statements.Count, Is.EqualTo(3));

        foreach (var statement in program.Statements)
        {
            var letStatement = statement as LetStatement;
            Assert.That(letStatement.Name.Value, Is.EqualTo(statementChecks[ letStatement.Name.TokenLiteral()]));
        }

    }
    
}