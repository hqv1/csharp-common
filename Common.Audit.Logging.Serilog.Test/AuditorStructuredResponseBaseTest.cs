using System;
using Hqv.CSharp.Common.Logging;
using Serilog;
using Serilog.Formatting.Json;
using Xunit;

namespace Hqv.CSharp.Common.Audit.Logging.Serilog.Test
{
    public class AuditorStructuredResponseBaseTest
    {
        private readonly AuditorResponseBase _auditor;

        public AuditorStructuredResponseBaseTest()
        {
            var settings = new AuditorResponseBase.Settings(
                shouldAuditOnSuccessfulEvent: true,
                shouldDetailAuditOnSuccessfulEvent: false);

            global::Serilog.ILogger logger = new LoggerConfiguration()
                .MinimumLevel.Debug()                
                .WriteTo.File(new JsonFormatter(), "logs\\myapp.txt")
                .CreateLogger();            

            IHqvLogger mylogger = new Common.Logging.Serilog.Logger(logger);            
            _auditor = new AuditorResponseBase(settings, mylogger);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Should_AuditSuccess_ToFile()
        {
            var response = new Response(new Request(Guid.NewGuid().ToString()));
            response.AddWarning(new Message("This is a warning", null));
            _auditor.AuditSuccess("Widget", "001", "Created", response);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Should_AuditFailure_ToFile()
        {
            var a = 0;
            var response = new Response(new Request(Guid.NewGuid().ToString()));
            try
            {
                var v = 10/a;
            }
            catch (Exception ex)
            {
                ex.Data["a"] = a;
                response.AddError(ex);
            }
            _auditor.AuditFailure("Widget", "001", "CreationFailed", response);
        }
    }
}
