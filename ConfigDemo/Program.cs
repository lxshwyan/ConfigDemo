using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------单级配置节点测试-----------------");
            Console.WriteLine("PlatChName:"+CustomerSingleConfig.GetConfig().PlatChName);
            Console.WriteLine("PlatEnName:"+CustomerSingleConfig.GetConfig().PlatEnName);


            Console.WriteLine("---------------------多级配置节点测试-----------------");
            Console.WriteLine("connectionString:" +CustomerMultiConfig.GetConfig().CustomerElementConfig.Enabled);
            Console.WriteLine("enabled:" + CustomerMultiConfig.GetConfig().CustomerElementConfig.ConnectionString);

            Console.WriteLine("---------------------自定义新增节点测试-----------------");
            Console.WriteLine("TestID:" + TestConfigInfo.GetConfig().TestID);
            Console.WriteLine("TestName:" + TestConfigInfo.GetConfig().TestName);  
            foreach (tracker item in TestConfigInfo.GetConfig().Trackers)
            {
              Console.WriteLine("Host:" + item.Host+" Port:" + item.Port);
            }

            Console.WriteLine("---------------------系统自带appSettings配置文件-----------------");
            Console.WriteLine("logLevel:" + System.Configuration.ConfigurationManager.AppSettings["logLevel"]);
            Console.WriteLine("LogType:" + System.Configuration.ConfigurationManager.AppSettings["LogType"]);

            Console.ReadKey();
        }
    }
}
