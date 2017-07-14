using System;
using System.Diagnostics;
using System.Text;

namespace Hqv.CSharp.Common.App
{
    public class CommandLineApplicationAsync
    {
        /// <summary>
        /// Information retured from ProcessCompleted
        /// </summary>
        public class ProcessCompletedArgs : EventArgs
        {
            public CommandLineResult Result { get; set; }
        }

        public class Settings
        {
            public Settings(bool displayOutputOnConsole)
            {
                DisplayOutputOnConsole = displayOutputOnConsole;

            }

            /// <summary>
            /// Display error and output information on console window
            /// </summary>
            public bool DisplayOutputOnConsole { get; }
        }

        /// <summary>
        /// This event is called when the process is completed
        /// </summary>
        public event EventHandler<ProcessCompletedArgs> ProcessCompleted;        
        
        private readonly StringBuilder _errorBuilder = new StringBuilder();
        private bool _hasProcessExited;
        private readonly StringBuilder _outputBuilder = new StringBuilder();
        private Process _process;
        private readonly Settings _settings;

        public CommandLineApplicationAsync(Settings settings = null)
        {
            _settings = settings ?? new Settings(false);
        }

        public void RunBegin(string appPath, string appArguments)
        {
            _process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = appPath,
                    Arguments = appArguments,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };
            _process.OutputDataReceived += OutputHandler;
            _process.ErrorDataReceived += ErrorHandler;
            _process.Start();
            _process.BeginOutputReadLine();
            _process.BeginErrorReadLine();
            _process.EnableRaisingEvents = true;
            _process.Exited += OnProcessExited;            
        }

        public bool KillProcess()
        {
            if (_hasProcessExited) return false;
            _process.Kill();
            return true;
        }

        private void ErrorHandler(object sender, DataReceivedEventArgs e)
        {
            if (_settings.DisplayOutputOnConsole)
            {
                Console.WriteLine(e.Data);
            }
            _errorBuilder.AppendLine(e.Data);
        }

        private void OutputHandler(object sender, DataReceivedEventArgs e)
        {
            if (_settings.DisplayOutputOnConsole)
            {
                Console.WriteLine(e.Data);
            }
            _outputBuilder.AppendLine(e.Data);
        }

        private void OnProcessExited(object sender, EventArgs e)
        {
            _hasProcessExited = true;
            ProcessCompleted?.Invoke(this,
                new ProcessCompletedArgs
                {
                    Result = new CommandLineResult(_outputBuilder.ToString().Trim(), _errorBuilder.ToString().Trim())
                });
        }
    }
}