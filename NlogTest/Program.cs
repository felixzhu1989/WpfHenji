// See https://aka.ms/new-console-template for more information

namespace NlogTest
{
    class Program
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            logger.Debug("这是一个异常！");
            Console.WriteLine("Hello, World!");
        }
    }
   
}