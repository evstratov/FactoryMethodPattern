using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    abstract class Creator
    {
        protected abstract ITransport FactoryMethod();
        public void Create()
        {
            var transport = FactoryMethod();
            Console.WriteLine($"Создаем транспорт {transport}");
            transport.Deliver();
        }
    }

    class AirplaneCreator : Creator
    {
        protected override ITransport FactoryMethod()
        {
            return new Airplane();
        }
    }
    class TrainCreator : Creator
    {
        protected override ITransport FactoryMethod()
        {
            return new Train();
        }
    }

    public interface ITransport
    {
        void Deliver();
    }

    class Airplane : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("Доставка груза самолетом");
        }

        public override string ToString()
        {
            return "самолет";
        }
    }

    class Train : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("Доставка груза поездом");
        }
        public override string ToString()
        {
            return "поезд";
        }
    }
    class Program
    {
        static void ClientCode(Creator creator)
        {
            creator.Create();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("-----------САМОЛЕТ");
            ClientCode(new AirplaneCreator());
            Console.WriteLine();
            Console.WriteLine("-----------ПОЕЗД");
            ClientCode(new TrainCreator());

            Console.Read();
        }

    }
}
