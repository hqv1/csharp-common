using System;
using FluentAssertions;
using Hqv.CSharp.Common.Common.App;
using Xunit;

namespace Common.App.Test
{
    public class CommandLineApplicationTest
    {
        private readonly CommandLineApplication _app;
        private string _appPath;
        private string _appArguments;
        private CommandLineResult _result;

        public CommandLineApplicationTest()
        {
            _app = new CommandLineApplication();
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Test1()
        {
            GivenAValidSetup();
            _result = _app.Run(_appPath, _appArguments);
            _result.ErrorData.Should().Be("\r\n");
            _result.OutputData.Should().Contain("yahoo.com");
        }

        private void GivenAValidSetup()
        {
            _appPath = "ping.exe";
            _appArguments = "yahoo.com";
        }
    }
}
