using System;
using PowerAssert;
using Xunit;

namespace FluentAssertionsSample;

public class PowerAssertTests
{

    [Fact]
    public void StartsWithTest()
    {
        PAssert.IsTrue(() => "ABCDEFG".StartsWith("DF"));
    }
    
    [Fact]
    public void RunComplexExpression()
    {
        int x = 11;
        int y = 6;
        DateTime d = new DateTime(2010, 3, 1);
        PAssert.IsTrue(() => x + 5 == d.Month * y);
    }
    
    [Fact]
    public void EquivalenceTest()
    {
        var expected = new TestObject
        {
            Prop1 = "ABC",
            Prop2 = 1
        };
        
        var actual = new TestObject
        {
            Prop1 = "AZBC",
            Prop2 = 2
        };

        PAssert.IsTrue(() => actual.Equals(expected));
    }

    [Fact]
    public void ExceptionTest()
    {
        Action act = () => throw new ArgumentException();

        var actualException = PAssert.Throws<Exception>(() => act());
        PAssert.IsTrue(() => actualException is ArgumentNullException);
    }
    
    private class TestObject
    {
        public string Prop1 { get; set; }
        public int Prop2 { get; set; }
    }
}