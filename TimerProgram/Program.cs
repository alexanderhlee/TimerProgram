using System;
using System.Diagnostics;
using System.Linq;

namespace TimerProgram
{
    static class Program
    {
        private static int _counter = 0;
        private static bool _usingDoz;

        static void Main(string[] args)
        {
            _usingDoz = args.Any() && args[0]?.ToLower() == "doz";
            var interval = _usingDoz ? Stopwatch.Frequency * 60 / 144 : Stopwatch.Frequency;

            var dTimer = new BaseXTimer(interval);
            dTimer.TimerChanged += d_TimerChanged;

            Console.WriteLine("000");
            dTimer.RunForOneMinute();
            Console.ReadLine();
        }

        static void d_TimerChanged(object sender, EventArgs e)
        {
            _counter++;
            var formattedInt = _usingDoz ? _counter.ToDoz() : _counter.ToString();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(formattedInt.PadLeft(3, '0'));
        }
    }
}

