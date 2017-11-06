using GrainInterfaces;
using System.Threading.Tasks;

namespace Grains
{
    public class Grain : Orleans.Grain, IGrain
    {
        private string text = "Hello World!";
        public Task<string> SayHello(string greeting)
        {
            var oldText = text;
            text = greeting;
            return Task.FromResult(oldText);
        }
    }
}