using System;
using NLog;
using Xunit;
using Logger = Hqv.CSharp.Common.Logging.NLog.Logger;

namespace Hqv.CSharp.Common.Log.NLog.Test
{
    public class LoggerTest
    {
        private readonly Logger _logger;

        public LoggerTest()
        {
            var nlog = LogManager.GetLogger("console");
            _logger = new Logger(nlog);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Should_LogDebug()
        {
            _logger.Debug("An object named {0} Says Hi", new {name = "Jason", age = 17});        
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Should_LogInfoString()
        {
            _logger.Info("This is a test");
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Should_LogInfoObject()
        {
            _logger.Info(new WidgetCleanerBusinessEvent("100", new WidgetModel {Id = 100, Color = "Blue"}, null));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Should_LogWarningWithException()
        {
            var exceptions = new Exception[]
            {
                new Exception("Exception 1"),
                new Exception("Exception 2")
            };

            var aggregateException = new AggregateException(exceptions);
            _logger.Warning(aggregateException, new WidgetCleanerBusinessEvent("100", new WidgetModel { Id = 100, Color = "Blue" }, null));
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Should_LogResponseWithErrors()
        {
            var response = new WidgetCleanerResponse(new WidgetCleanerRequest(Guid.NewGuid().ToString()))
            {
                State = "Washed"
            };

            var exceptions = new Exception[]
            {
                new Exception("Exception 1"),
                new Exception("Exception 2")
            };
            response.AddErrors(exceptions);

            try
            {
                throw new Exception("Exception 3");
            }
            catch (Exception ex)
            {
                response.AddError(ex);
            }
            _logger.Warning(new AggregateException(response.Errors), new WidgetCleanerBusinessEvent("100", response, null));
        }
    }
}
