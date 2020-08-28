using System;

namespace AdapterPattern
{
        class Program
        {
            static void Main(string[] args)
            {
                AppleUsbPowerAdapter _appleUsbPowerAdapter = new AppleUsbPowerAdapter();
                string myCable = "my usb cable";
                var iphone = new AppleProduct(_appleUsbPowerAdapter, myCable);
                iphone.UsbCharge();
            }
        }

        public class AppleProduct
        {
            private readonly IUsbInterface _usbInterface;
            private readonly string _cable;

            public AppleProduct(IUsbInterface usbInterface, string cable)
            {
                _usbInterface = usbInterface;
                _cable = cable;
            }

            public void UsbCharge()
            {
                Console.WriteLine(_usbInterface.UsbInterface(_cable));
                Console.ReadKey();
            }
        }

        public interface IUsbInterface
        {
            string UsbInterface(string usbCable);
        }

        public class AppleUsbPowerAdapter : IUsbInterface
        {
            PowerSocket _powerSocket = new PowerSocket();

            public string UsbInterface(string cable)
            {
                var usbToPower = "use " + cable + " to charge " + _powerSocket.PowerSupply();
                return usbToPower;
            }
        }

        public class PowerSocket
        {
            public string PowerSupply()
            {
                return "220v power";
            }
        }

}
