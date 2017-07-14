using System.Threading;
using FluentAssertions;
using Xunit;

namespace Hqv.CSharp.Common.App.Test
{
    public class CommandLineApplicationAsyncTest
    {
        private readonly CommandLineApplicationAsync _app;
        private string _appPath;
        private string _appArguments;
        private CommandLineResult _result;
        private readonly ManualResetEvent _resetEvent = new ManualResetEvent(false);

        public CommandLineApplicationAsyncTest()
        {
            _app = new CommandLineApplicationAsync();
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Should_RunApp_Successfully()
        {
            GivenAValidSetup();
            _app.ProcessCompleted += AppOnProcessCompleted;
            _app.RunBegin(_appPath,_appArguments);
            
            _resetEvent.WaitOne();

            _result.ErrorData.Should().BeNullOrEmpty();
            _result.OutputData.Should().Contain("yahoo.com");
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Should_QuitApp_BeforeCompleted()
        {
            GivenAValidSetup();
            _app.ProcessCompleted += AppOnProcessCompleted;
            _app.RunBegin(_appPath, _appArguments);            
            var killProcess = _app.KillProcess();
            killProcess.Should().BeTrue();
        }

        private void AppOnProcessCompleted(object sender, CommandLineApplicationAsync.ProcessCompletedArgs processCompletedArgs)
        {
            _result = processCompletedArgs.Result;
            _resetEvent.Set();            
        }

        private void GivenAValidSetup()
        {
            _appPath = "ping.exe";
            _appArguments = "yahoo.com";
        }
    }
}