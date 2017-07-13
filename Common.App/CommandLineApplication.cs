using System.Diagnostics;
using System.Text;

namespace Hqv.CSharp.Common.App
{
    /// <summary>
    /// Command line application helper
    /// </summary>
    public class CommandLineApplication
    {
        private readonly StringBuilder _errorBuilder = new StringBuilder();
        private readonly StringBuilder _outputBuilder = new StringBuilder();

        /// <summary>
        /// Run an application in the command line. Does not handle any exceptions.
        /// </summary>
        /// <param name="appPath">Path to the application. Can be just the file name (e.g. ping.exe) if the path is known</param>
        /// <param name="appArguments">Arguments for the application</param>
        /// <returns>Result from the output and error streams.</returns>
        public CommandLineResult Run(string appPath, string appArguments)
        {
            _errorBuilder.Clear();
            _outputBuilder.Clear();

            var process = new Process
            {
                StartInfo = CreateProcessStartInfo(appPath, appArguments)
            };
            process.OutputDataReceived += OutputHandler;
            process.ErrorDataReceived += ErrorHandler;
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();

            var output = _outputBuilder.ToString();
            if (output == "\r\n") output = string.Empty;
            var error = _errorBuilder.ToString();
            if (error == "\r\n") error = string.Empty;

            return new CommandLineResult(output, error);
        }

        private static ProcessStartInfo CreateProcessStartInfo(string appPath, string appArguments)
        {
            return new ProcessStartInfo
            {
                FileName = appPath,
                Arguments = appArguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };
        }

        private void ErrorHandler(object sender, DataReceivedEventArgs e)
        {
            _errorBuilder.AppendLine(e.Data);
        }

        private void OutputHandler(object sender, DataReceivedEventArgs e)
        {
            _outputBuilder.AppendLine(e.Data);
        }
    }
}
