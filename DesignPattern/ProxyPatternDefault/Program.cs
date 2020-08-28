using System;

namespace ProxyPatternDefault
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client(new Proxy(new RealObject()));
            //Client call target without proxy
            //Client client = new Client(new RealObject());
            client.ClientCallTargetMethod();
        }
    }

    public class Client
    {
        private IObject _iObject;
        public Client(IObject iObject)
        {
            _iObject = iObject;
        }

        public void ClientCallTargetMethod()
        {
            _iObject.Method();
            Console.ReadKey();
        }

    }

    public interface IObject
    {
        void Method();
    }
    public class RealObject : IObject
    {
        public void Method()
        {
            Console.WriteLine("Print real object");
        }
    }

    public class Proxy : IObject
    {
        private RealObject _realObject;

        public Proxy(RealObject realObject)
        {
            _realObject = realObject;
        }

        public void Method()
        {
            Console.WriteLine("Print Proxy\n");
            _realObject.Method();
        }
    }
}
