using System;
using FluentAssertions;
using Xunit;

namespace FluentAssertionsSample;

public class FluentAssertionTests
{

    [Fact]
    public void StartsWithTest()
    {
        "ABCDEFG".Should().StartWith("DF");
    }
    
    [Fact]
    public void RunComplexExpression()
    {
        int x = 11;
        int y = 6;
        DateTime d = new DateTime(2010, 3, 1);
        (x + 5).Should().Be(d.Month * y);
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

        actual.Should().BeEquivalentTo(expected);
    }
    
    [Fact]
    public void ExceptionTest()
    {
        Action act = () => throw new ArgumentException();

        act.Should().Throw<ArgumentNullException>();
    }
    
    private class TestObject
    {
        public string Prop1 { get; set; }
        public int Prop2 { get; set; }
    }
}