using System;
using System.Linq;

namespace Tetris.Model.Tests.Tools
{
    public static class Execute
    {
        public static void This(Action action, int count)
        {
            foreach (var i in Enumerable.Range(0, count))
            {
                action();
            }
        }

        public static void This(Action<int> action, int count)
        {
            foreach (var i in Enumerable.Range(0, count))
            {
                action(i);
            }
        }
    }
}