using System;
using System.Diagnostics;

namespace TimerProgram
{
    public class BaseXTimer : IDisposable
    {
        private Stopwatch _sw;
        private readonly long _interval;
        public event EventHandler TimerChanged;

        public BaseXTimer(long interval)
        {
            _interval = interval;
        }

        public void RunForOneMinute()
        {
            _sw = Stopwatch.StartNew();
            var sw2 = Stopwatch.StartNew();
            while (sw2.Elapsed.Minutes < 1)
            {
                if (_sw.ElapsedTicks > _interval)
                {
                    if (TimerChanged != null)
                    {
                        TimerChanged(this, new EventArgs());
                    }
                    _sw.Restart();
                }
            }
        }
        
        public void Dispose()
        {
            _sw.Stop();
        }
    }
}