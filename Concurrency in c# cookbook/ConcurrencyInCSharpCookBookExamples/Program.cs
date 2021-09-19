using Nito.AsyncEx;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConcurrencyInCSharpCookBookExamples
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var tasks1 = Task.Run(() => DelayAndReturnAsync(300));
            var tasks2 = Task.Run(() => DelayAndReturnAsync(100));
            var tasks3 = Task.Run(() => DelayAndReturnAsync(200));

            Task<int>[] tasks = new Task<int>[] { tasks1, tasks2, tasks3 };
            var processingTasks = tasks.Select(async t =>
            {
                var result = await t;
                Console.WriteLine(result);
            }).ToArray();

            await Task.WhenAll(processingTasks);
            Console.ReadLine();
        }
        static async Task<int> DelayAndReturnAsync(int value)
        {
            await Task.Delay(value);
           // Console.WriteLine(value);
            return value;
        }
    }
}
