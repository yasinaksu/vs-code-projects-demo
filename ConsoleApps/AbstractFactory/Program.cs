using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var productManager = new ProductManager(new Factory2());
            productManager.Add();
        }
    }
    abstract class LoggerBase
    {
        public abstract void Log(string logMessage);
    }

    class Log4NetLogger : LoggerBase
    {
        public override void Log(string logMessage)
        {
            System.Console.WriteLine($"{logMessage} logged with log4net");
        }
    }

    class NLogger : LoggerBase
    {
        public override void Log(string logMessage)
        {
            System.Console.WriteLine($"{logMessage} logged with nlogger");
        }
    }
    abstract class CrossCuttingConcenrnsFactory
    {
        public abstract LoggerBase CreateLogger();
    }

    class Factory1 : CrossCuttingConcenrnsFactory
    {
        public override LoggerBase CreateLogger()
        {
            return new Log4NetLogger();
        }
    }

    class Factory2 : CrossCuttingConcenrnsFactory
    {
        public override LoggerBase CreateLogger()
        {
            return new NLogger();
        }
    }

    class ProductManager{
        private readonly CrossCuttingConcenrnsFactory _factory;
        private readonly LoggerBase _logger;
        public ProductManager(CrossCuttingConcenrnsFactory factory)
        {
            _factory = factory;
            _logger = _factory.CreateLogger();
        }

        public void Add(){
            _logger.Log("ekleme işlemi");
            Console.WriteLine("Ürün eklendi");
        }
    }
}
