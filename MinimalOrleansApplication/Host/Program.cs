using Orleans.Runtime.Host;
using System;
using System.Net;

namespace Host
{
    internal class Program
    {
        private static SiloHost siloHost;

        private static void Main(string[] args)
        {
            // 让 Orleans 在单独的应用域中启动
            AppDomain hostDomain = AppDomain.CreateDomain("OrleansHost", null,
                new AppDomainSetup()
                {
                    AppDomainInitializer = InitSilo
                });
            Console.WriteLine("Orleans Silo is running.\nPress Enter to terminate...");
            Console.ReadLine();
            // 在 Orleans 所在的应用域中释放 Silo 资源
            hostDomain.DoCallBack(ShutdownSilo);
        }

        private static void InitSilo(string[] args)
        {
            siloHost = new SiloHost(Dns.GetHostName());

            //使用配置文件配置集群
            siloHost.ConfigFileName = "OrleansConfiguration.xml";
            siloHost.InitializeOrleansSilo();
            var startedOk = siloHost.StartOrleansSilo();
            if (!startedOk)
            {
                throw new SystemException(String.Format("Failed to start Orleans silo '{0}' as a {1} node", siloHost.Name, siloHost.Type));
            }
        }

        private static void ShutdownSilo()
        {
            if (siloHost != null)
            {
                siloHost.ShutdownOrleansSilo();
                siloHost.Dispose();
                GC.SuppressFinalize(siloHost);
                siloHost = null;
            }
        }
    }
}