namespace Hqv.CSharp.Common.Common.App
{
    public class CommandLineResult
    {
        public CommandLineResult(string outputData, string errorData)
        {
            OutputData = outputData;
            ErrorData = errorData;
        }

        public string OutputData { get; }
        public string ErrorData { get; }
    }
}