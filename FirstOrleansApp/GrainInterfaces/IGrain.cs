using Orleans;
using System.Threading.Tasks;

namespace GrainInterfaces
{
    public interface IGrain : IGrainWithIntegerKey
    {
        Task<string> SayHello(string greeting);
    }
}