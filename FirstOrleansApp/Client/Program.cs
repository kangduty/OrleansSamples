using Orleans;
using Orleans.Runtime.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //设置并连接一个客户端
            var clientConfig = ClientConfiguration.LocalhostSilo();
            var client = new ClientBuilder().UseConfiguration(clientConfig).Build();
            client.Connect().Wait();

            Console.WriteLine("Client connected.");

            //测试代码
            var friend = client.GetGrain<GrainInterfaces.IGrain>(0);
            var rst = friend.SayHello().Result;
            Console.WriteLine("\n\n{0}\n\n",rst);

            Console.WriteLine("\nPress Enter to terminate...");
            Console.ReadKey();

            //关闭
            client.Close();
        }
    }
}
