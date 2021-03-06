using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Biblioteca
{
    public class Spinner : IDisposable
    {
        private const string Sequence = @"/-\|";
        private int counter = 0;
        private readonly int left;
        private readonly int top;
        private readonly int delay;
        private readonly string texto;
        private bool active;
        private readonly Thread thread;

        public Spinner(int left, int top, string texto, int delay = 100)
        {
            this.left = left;
            this.top = top;
            this.delay = delay;
            this.texto = texto;
            thread = new Thread(Spin);
        }

        public void Start()
        {
            active = true;
            if (!thread.IsAlive)
                thread.Start();
        }

        public void Stop()
        {
            active = false;
            Draw(' ');
        }

        private void Spin()
        {
            while (active)
            {
                Turn();
                Thread.Sleep(delay);
            }
        }

        private void Draw(char c)
        {
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(texto);
            Console.Write(c);
            Console.Write("\n");
        }

        private void Turn()
        {
            Draw(Sequence[++counter % Sequence.Length]);
        }

        public void Dispose()
        {
            Stop();
        }
    }
}
