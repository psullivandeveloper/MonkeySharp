using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace MonkeyCore.Test;


public class ParserTests
{
    private string input;
    private string errorInput;
    private string returnInput;
    private Dictionary<string, string> statementChecks = new Dictionary<string, string>();
    [SetUp]
    public void Setup()
    {
        input = """
                let x = 5;
                let y = 10;
                let foobar = 838383;
                """;
        errorInput = """
                let x 5;
                let = 10;
                let 838383;
                """;
        returnInput = """
                      return 5;
                      return 10;
                      return 993322;
                      """;
        
        /*statementChecks.Add("x", "5");
        statementChecks.Add("y", "10");
        statementChecks.Add("foobar", "838383");*/
        //Temporarily checking to see that the names are right, we'll be grabbing the values later if you look at the code.
        statementChecks.Add("x", "x");
        statementChecks.Add("y", "y");
        statementChecks.Add("foobar", "foobar");
    }

    private bool CheckParserErrors(Parser p)
    {
        if (p.Errors().Count == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    [Test]
    public void TestReturnStatement()
    {
        var l = new Lexer(returnInput);
        var p = new Parser(l);
        var program = p.ParseProgram();
        Assert.That(program, Is.Not.Null);
        Assert.That(program.Statements.Count, Is.EqualTo(3));
        Assert.That(CheckParserErrors(p), Is.EqualTo(false));
        foreach (var statement in program.Statements)
        {
            Assert.That(statement, Is.TypeOf<ReturnStatement>());
            Assert.That(statement.TokenLiteral(), Is.EqualTo("return"));
        }
        
    }

    [Test]
    public void TestErrorChecking()
    {
        var l = new Lexer(errorInput);
        var p = new Parser(l);
        var program = p.ParseProgram();
        
        Assert.That(program, Is.Not.Null);
        Assert.That(program.Statements.Count, Is.EqualTo(0));
        Assert.That(CheckParserErrors(p), Is.EqualTo(true));
        Assert.That(p.Errors().Count, Is.EqualTo(3));

        foreach (var statement in program.Statements)
        {
            var letStatement = statement as LetStatement;
            Assert.That(letStatement.Name.Value, Is.EqualTo(statementChecks[ letStatement.Name.TokenLiteral()]));
        }
    }
    

    [Test]
    public void TestNextToken()
    {
        var l = new Lexer(input);
        var p = new Parser(l);
        var program = p.ParseProgram();
        
        Assert.That(program, Is.Not.Null);
        Assert.That(program.Statements.Count, Is.EqualTo(3));
        Assert.That(CheckParserErrors(p), Is.EqualTo(false));

        foreach (var statement in program.Statements)
        {
            var letStatement = statement as LetStatement;
            Assert.That(letStatement.Name.Value, Is.EqualTo(statementChecks[ letStatement.Name.TokenLiteral()]));
        }

    }
    
}