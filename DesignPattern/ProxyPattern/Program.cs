using System;

namespace ProxyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            string textToPrint = "Print this one";
            //Client client = new Client(new PrintProxy(new PrintGreetings()), textToPrint);
            Client client = new Client(new PrintGreetings(), textToPrint);
            client.PrintWithPrefix();
        }
    }

    public class Client
    {
        private readonly ITarget _iTarget;
        private readonly string _textToPrint;
        public Client(ITarget iTarget, string textToPrint)
        {
            _iTarget = iTarget;
            _textToPrint = textToPrint;
        }

        public void PrintWithPrefix()
        {
            _iTarget.PrintText(_textToPrint);
            Console.ReadKey();
        }

    }

    public interface ITarget
    {
        void PrintText(string text);
    }

    public class PrintGreetings : ITarget
    {
        public void PrintText(string text)
        {
            Console.WriteLine(text);
        }
    }

    public class PrintProxy : ITarget
    {

        private readonly PrintGreetings _printGreetings;

        public PrintProxy(PrintGreetings printGreetings)
        {
            _printGreetings = printGreetings;
        }

        public void PrintText(String text)
        {
            Console.WriteLine("############################");
            _printGreetings.PrintText(text);
        }
    }
}