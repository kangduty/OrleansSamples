using GrainInterfaces;
using Orleans;
using System;
using System.Threading.Tasks;

namespace GrainCollection
{
    public class HelloGrain : Grain, IHello
    {
        public Task<string> SayHello(string msg)
        {
            Console.WriteLine("{0} said:{1}",this.GetPrimaryKeyLong(),msg);
            return Task.FromResult(string.Format("You said {0}, I say: Hello!", msg));
        }
    }
}