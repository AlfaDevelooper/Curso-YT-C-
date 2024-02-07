using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Linq.Expressions;

namespace MultitareaPrueba
{
    class Program
    {
        private static int acumulador = 0;

        static void Main(string[] args)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            
            CancellationToken cancelaToken = tokenSource.Token;

            Task tarea = Task.Run(() => RealizarTarea(cancelaToken));

            for (int i = 0; i < 100; i++)
            {
                acumulador += 5;
                Thread.Sleep(500);
                if(acumulador>100)
                {
                    tokenSource.Cancel();
                    break;
                }

            }
            Thread.Sleep(1000);

            Console.WriteLine("Valor del acumulador {0}", acumulador);

            Console.ReadLine();

        }

        static void RealizarTarea(CancellationToken token)
        {
            for (int i = 0; i <100; i++)
            {
                acumulador++;
                var hilo = Thread.CurrentThread.ManagedThreadId;

                Thread.Sleep(250);

                Console.WriteLine("Ejecutando tarea {0},Acumulador {1} ,en hilo {2}", i,acumulador, hilo);

                if(token.IsCancellationRequested)
                {
                    return;
                }

            }
        }

    }
}