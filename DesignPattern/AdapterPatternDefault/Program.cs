using System;

namespace AdapterPatternDefault
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client(new Adapter());
            client.ClientCallInterface();
        }
    }

    public class Client
    {
        private IObject _iObject;
        public Client(IObject iObject)
        {
            _iObject = iObject;
        }

        public void ClientCallInterface()
        {
            Console.WriteLine("Print From Client: " + _iObject.Method());
        }
    }

    public class RealObject
    {
        public int MethodRealObject()
        {
            Console.WriteLine("Return Int in RealObject");
            return 100;
        }
    }

    public interface IObject
    {
        string Method();
    }

    public class Adapter:IObject
    {
        private RealObject _realObject;

        public string Method()
        {
            return _realObject.MethodRealObject().ToString();
        }
    }


}
