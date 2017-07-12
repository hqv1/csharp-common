using System;
using NLog;
using Xunit;

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
        public void Should_LogInfoString()
        {
            _logger.LogInfo("This is a test");
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Should_LogInfoObject()
        {
            _logger.LogInfo(new WidgetCleanerBusinessEvent("100", new WidgetModel {Id = 100, Color = "Blue"}, null));
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
            _logger.LogWarning(new WidgetCleanerBusinessEvent("100", new WidgetModel { Id = 100, Color = "Blue" }, null), aggregateException);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Should_LogResponseWithErrors()
        {
            var response = new WidgetCleanerResponse()
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
            _logger.LogWarning(new WidgetCleanerBusinessEvent("100", response, null), new AggregateException(response.Errors));
        }
    }
}
