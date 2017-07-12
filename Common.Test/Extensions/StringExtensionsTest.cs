using FluentAssertions;
using Hqv.CSharp.Common.Utilities;
using Xunit;

namespace Hqv.Csharp.Common.Test.Extensions
{
    public class StringExtensionsTest
    {
        [Fact]
        [Trait("Category", "Unit")]
        public void ShouldBeNumeric()
        {
            const string value = "45";
            value.IsNumeric().Should().BeTrue();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void ShouldNotBeNumeric()
        {
            const string value = "45a";
            value.IsNumeric().Should().BeFalse();
        }
    }
}