using System;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Ucommerce.Seeder.DataSeeding.Utilities
{
    /// <summary>
    /// An ASCII progress bar
    /// 
    /// This class was made by Daniel Wolfe
    /// https://stackoverflow.com/users/52041/daniel-wolf
    /// 
    /// https://stackoverflow.com/questions/24918768/progress-bar-in-console-application/31193455#31193455
    ///
    /// Thanks, Daniel!
    /// 
    /// </summary>
    public class ProgressBar : IDisposable, IProgress<double>
    {
        private const int BlockCount = 10;
        private readonly TimeSpan _animationInterval = TimeSpan.FromSeconds(1.0 / 8);
        private const string Animation = @"|/-\";

        private readonly Timer _timer;

        private double _currentProgress = 0;
        private string _currentText = string.Empty;
        private bool _disposed = false;
        private int _animationIndex = 0;
        private readonly Stopwatch _stopwatch;

        public ProgressBar()
        {
            _timer = new Timer(TimerHandler);

            // A progress bar is only for temporary display in a console window.
            // If the console output is redirected to a file, draw nothing.
            // Otherwise, we'll end up with a lot of garbage in the target file.
            if (!Console.IsOutputRedirected)
            {
                ResetTimer();
            }

            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }

        public void Report(double value)
        {
            // Make sure value is in [0..1] range
            value = Math.Max(0, Math.Min(1, value));
            Interlocked.Exchange(ref _currentProgress, value);
        }


        private void TimerHandler(object state)
        {
            lock (_timer)
            {
                if (_disposed) return;

                int progressBlockCount = (int) (_currentProgress * BlockCount);
                int percent = (int) (_currentProgress * 100);
                string text = string.Format("[{0}{1}] {2,3}% {3}",
                    new string('#', progressBlockCount), new string('-', BlockCount - progressBlockCount),
                    percent,
                    Animation[_animationIndex++ % Animation.Length]);
                UpdateText(text);

                ResetTimer();
            }
        }

        private void UpdateText(string text)
        {
            // Get length of common portion
            int commonPrefixLength = 0;
            int commonLength = Math.Min(_currentText.Length, text.Length);
            while (commonPrefixLength < commonLength && text[commonPrefixLength] == _currentText[commonPrefixLength])
            {
                commonPrefixLength++;
            }

            // Backtrack to the first differing character
            StringBuilder outputBuilder = new StringBuilder();
            outputBuilder.Append('\b', _currentText.Length - commonPrefixLength);

            // Output new suffix
            outputBuilder.Append(text.Substring(commonPrefixLength));

            // If the new text is shorter than the old one: delete overlapping characters
            int overlapCount = _currentText.Length - text.Length;
            if (overlapCount > 0)
            {
                outputBuilder.Append(' ', overlapCount);
                outputBuilder.Append('\b', overlapCount);
            }

            Console.Write(outputBuilder);
            _currentText = text;
        }

        private void ResetTimer()
        {
            _timer.Change(_animationInterval, TimeSpan.FromMilliseconds(-1));
        }

        public void Dispose()
        {
            lock (_timer)
            {
                _stopwatch.Stop();
                _disposed = true;
                Report(1.0);
                UpdateText(string.Empty);
                Console.WriteLine($"{Math.Round(_stopwatch.Elapsed.TotalSeconds)} secs");
            }
        }
    }
}