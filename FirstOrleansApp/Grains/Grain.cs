using GrainInterfaces;
using System.Threading.Tasks;

namespace Grains
{
    public class Grain : Orleans.Grain, IGrain
    {
        public Task<string> SayHello()
        {
            return Task.FromResult("Hello world!");
        }
    }
}