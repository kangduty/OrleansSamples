using Orleans;
using Orleans.Runtime.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiloHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //设置并启动一个本地 Silo 
            var siloConfig = ClusterConfiguration.LocalhostPrimarySilo();
            var silo = new Orleans.Runtime.Host.SiloHost("TestSilo", siloConfig);
            silo.InitializeOrleansSilo();
            silo.StartOrleansSilo();

            Console.WriteLine("Silo started.");

            Console.WriteLine("\nPress Enter to terminate...");
            Console.ReadKey();
            //关闭
            silo.ShutdownOrleansSilo();
        }
    }
}
